using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using JapanSolver.Model;

namespace JapanSolver
{
	public partial class MainForm : Form
	{
		Document document;
		Pen mainLinesPen;
		Pen subLinesPen;
		Size cellSize;
		const int drawPanelGAP = 5;
		int minCellDimension;
		float radius;
		Point mapAnchor;
		String currentDrawMode;
		
		public MainForm()
		{
			InitializeComponent();
			drawPanel.Paint += this.OnPaint;
			//drawPanel.MouseClick += this.DrawPanelClick;
			drawPanel.MouseDown += this.DrawPanelMouseDown;
			drawPanel.MouseMove += this.DrawPanelMouseMove;
			drawPanel.MouseUp += this.DrawPanelMouseUp;
			this.Resize += this.OnResize;
			this.MaximizeBox = true;
			
			//document = DocumentGenerator.CreateRandomDocument(20, 20);
			document = DocumentGenerator.CreateJapanHouse();
			
			long temp = MathUtils.QoS(12, 40);
//			MessageBox.Show(temp.ToString());
			using(TextWriter writer = new StreamWriter("qos.txt")) {
				writer.Write(MathUtils.toStringQoS());
			}
			//document = Document.CreateJapanHouse();
			//Map.CheckDigitGroupOnCells(document.TopCollection[0], document.Map.GetColumn(0));
			//MessageBox.Show("[" + Cell.GetStringRepresentation(document.Map.GetColumn(3)) + "]");
		}

		public void OnPaint(object sender, PaintEventArgs e)
		{
			using(Graphics g = drawPanel.CreateGraphics())
			{
				cellSize = new Size(
					(int)((drawPanel.ClientSize.Width - 2 * drawPanelGAP) / (document.Width + document.LeftCollection.ColumnsCount)),
					(int)((drawPanel.ClientSize.Height - 2 * drawPanelGAP) / (document.Height + document.TopCollection.RowsCount))
				);
			    minCellDimension = Math.Min(cellSize.Width, cellSize.Height);
			    cellSize = new Size(minCellDimension, minCellDimension);
			    mapAnchor = new Point(
			    	drawPanelGAP + cellSize.Width * document.LeftCollection.ColumnsCount, 
			    	drawPanelGAP + cellSize.Height * document.TopCollection.RowsCount
			    );
				
			    int mainLinesPenWidth = (minCellDimension < 15) ? 1 : 2; // TODO calibrate width
				mainLinesPen = new Pen(new SolidBrush(Color.Black), mainLinesPenWidth);
				subLinesPen = new Pen(new SolidBrush(Color.Black), 1);
				radius = minCellDimension / 8f;
				g.Clear(Color.White);
				
				#region Digits
				
				DigitGroup dg;
				Font digitFont = new Font(FontFamily.GenericSansSerif, cellSize.Height * 2 / 3, GraphicsUnit.Pixel);
				for(int i = 0; i < document.TopCollection.Count; i++)
				{
					dg = document.TopCollection[i];
					for(int j = 0; j < dg.Count; j++)
					{
						g.DrawString( //TODO Learn how to use StringFormat
							dg[j].ToString(), 
							digitFont, 
							Brushes.Black,
							new RectangleF
							{
								Location = new PointF
								{
									X = mapAnchor.X + i * cellSize.Width,
									Y = mapAnchor.Y - (dg.Count - j) * cellSize.Height
								},
								Size = new SizeF
								{
									Width = cellSize.Width,
									Height = cellSize.Height
								}
							});
					}
				}
				
				for(int m = 0; m < document.LeftCollection.Count; m++)
				{
					dg = document.LeftCollection[m];
					for(int n = 0; n < dg.Count; n++)
					{
						g.DrawString(
							dg[n].ToString(), 
							digitFont, 
							Brushes.Black,
							new RectangleF
							{
								Location = new PointF
								{
									X = mapAnchor.X - (dg.Count - n) * cellSize.Width,
									Y = mapAnchor.Y + m * cellSize.Height
								},
								Size = new SizeF
								{
									Width = cellSize.Width,
									Height = cellSize.Height
								}
							});
					}
				}
				
				#endregion
				
				#region Cells
				g.SmoothingMode = SmoothingMode.AntiAlias;
				Brush rectBrush;
				for(int row = 0; row < document.Height; row++)
				{
					for(int column = 0; column < document.Width; column++)
					{
						if(document.Map.Cells[row,column].State == CellStateEnum.Space)
						{
							g.FillEllipse(Brushes.Gray, 
							              mapAnchor.X + column * cellSize.Width + cellSize.Width / 2f - radius, 
							              mapAnchor.Y + row * cellSize.Height + cellSize.Height / 2f - radius,
							              2 * radius,
							              2 * radius);
						} else {
							switch(document.Map.Cells[row,column].State)
							{
								case CellStateEnum.Normal:
									rectBrush = Brushes.White;
									break;
								case CellStateEnum.Filled:
									rectBrush = Brushes.Black;
									break;
								default:
									throw new ArgumentException("Unknown cell state: " + document.Map.Cells[row,column].State);
							}
							g.FillRectangle(
								rectBrush, 
								mapAnchor.X + column * cellSize.Width, 
								mapAnchor.Y + row * cellSize.Height, 
								cellSize.Width, 
								cellSize.Height
							);
						}
					}
				}
				g.SmoothingMode = SmoothingMode.Default;
				#endregion
				
				#region Grid lines
				
				Pen currentPen;
				
				#region Vertical lines
				for(int i = -document.LeftCollection.ColumnsCount; i <= document.Width; i++)
				{
					currentPen = ((i < 0 && i == -document.LeftCollection.ColumnsCount) || (i >= 0 && i % 5 == 0)) ? mainLinesPen : subLinesPen;
					g.DrawLine(currentPen,
					           new Point{
					           	X = mapAnchor.X + i * cellSize.Width,
					           	Y = mapAnchor.Y - ((i >= 0) ? document.TopCollection.RowsCount * cellSize.Height : 0)
					           },
					           new Point{
					           	X = mapAnchor.X + i * cellSize.Width, 
					           	Y = mapAnchor.Y + document.Height * cellSize.Height
					           });
				}
				#endregion
				
				#region Horizontal lines
				for(int j = -document.TopCollection.RowsCount; j <= document.Height; j++)
				{
					currentPen = ((j < 0 && j == -document.TopCollection.RowsCount) || (j >= 0 && j % 5 == 0)) ? mainLinesPen : subLinesPen;
					g.DrawLine(currentPen, 
					           new Point{
					           	X = mapAnchor.X - ((j >= 0) ? document.LeftCollection.ColumnsCount * cellSize.Width : 0),
					           	Y = mapAnchor.Y + j * cellSize.Height
					           },
					           new Point{
					           	X = mapAnchor.X + document.Width * cellSize.Width, 
					           	Y = mapAnchor.Y + j * cellSize.Height
					           });
				}
				#endregion
				#endregion
			}
		}
		
		public void DrawPanelClick(object sender, MouseEventArgs e)
		{
			int column = (e.X >= mapAnchor.X) ? ((e.X - mapAnchor.X) / cellSize.Width) : -1;
			int row = (e.Y >= mapAnchor.Y) ? ((e.Y - mapAnchor.Y) / cellSize.Height) : -1;
			if(row >= 0 && row < document.Height && column >= 0 && column < document.Width)
			{
				
				document.Map.Cells[row, column].State = (e.Button == MouseButtons.Left) ? CellStateEnum.Filled : (e.Button == MouseButtons.Right) ? CellStateEnum.Space : CellStateEnum.Normal;
				string message = String.Format("Clicked by ({0}) at ({1}) : ({2}) in cell [{3}, {4}]", e.Button, e.X, e.Y, row, column);
				Console.WriteLine(message);
				UpdateCell(row, column);
				//document.RebuildDigitGroupCollectionsFromMap();
				//drawPanel.Invalidate();
			}
		}
		
		public void DrawPanelMouseDown(object sender, MouseEventArgs e) {
			int column = (e.X >= mapAnchor.X) ? ((e.X - mapAnchor.X) / cellSize.Width) : -1;
			int row = (e.Y >= mapAnchor.Y) ? ((e.Y - mapAnchor.Y) / cellSize.Height) : -1;
			if(row >= 0 && row < document.Height && column >= 0 && column < document.Width)
			{
				currentDrawMode = (e.Button == MouseButtons.Left) ? 
					CellStateEnumHelper.Filled : (e.Button == MouseButtons.Right) ? 
					CellStateEnumHelper.Space : CellStateEnumHelper.Normal;
				document.Map.Cells[row, column].State = CellStateEnumHelper.Parse(currentDrawMode);
				
				string message = String.Format("Mouse Down by ({0}) at ({1}) : ({2}) in cell [{3}, {4}]", e.Button, e.X, e.Y, row, column);
				Console.WriteLine(message);
				UpdateCell(row, column);
			}
		}
		
		public void DrawPanelMouseMove(object sender, MouseEventArgs e) {
			if(currentDrawMode != null) {
				int column = (e.X >= mapAnchor.X) ? ((e.X - mapAnchor.X) / cellSize.Width) : -1;
				int row = (e.Y >= mapAnchor.Y) ? ((e.Y - mapAnchor.Y) / cellSize.Height) : -1;
				if(row >= 0 && row < document.Height && column >= 0 && column < document.Width)
				{
					document.Map.Cells[row, column].State = (e.Button == MouseButtons.Left) ? 
						CellStateEnum.Filled : (e.Button == MouseButtons.Right) ? 
						CellStateEnum.Space : CellStateEnum.Normal;
					string message = String.Format("Clicked by ({0}) at ({1}) : ({2}) in cell [{3}, {4}]", e.Button, e.X, e.Y, row, column);
					Console.WriteLine(message);
					UpdateCell(row, column);
				}
			}
		}
		
		public void DrawPanelMouseUp(object sender, MouseEventArgs e) {
			currentDrawMode = null;
		}
		
		private void UpdateCell(int row, int column)
		{
			using(Graphics g = drawPanel.CreateGraphics())
			{
				#region Cell
				g.SmoothingMode = SmoothingMode.AntiAlias;
				
				if(document.Map.Cells[row,column].State == CellStateEnum.Space)
				{
					PointF cellCenter = new PointF 
						{
							X = mapAnchor.X + column * cellSize.Width + cellSize.Width / 2f,
							Y = mapAnchor.Y + row * cellSize.Height + cellSize.Height / 2f
						};
					g.FillRectangle(Brushes.White, mapAnchor.X + column * cellSize.Width, mapAnchor.Y + row * cellSize.Height, cellSize.Width, cellSize.Height);
					g.FillEllipse(Brushes.Gray, 
					              cellCenter.X - radius, 
					              cellCenter.Y - radius,
					              2 * radius,
					              2 * radius);
				} else {
					Brush rectBrush;
					switch(document.Map.Cells[row,column].State)
					{
						case CellStateEnum.Normal:
							rectBrush = Brushes.White;
							break;
						case CellStateEnum.Filled:
							rectBrush = Brushes.Black;
							break;
						default:
							throw new ArgumentException("Unknown cell state: " + document.Map.Cells[row,column].State);
					}
					g.FillRectangle(rectBrush, mapAnchor.X + column * cellSize.Width, mapAnchor.Y + row * cellSize.Height, cellSize.Width, cellSize.Height);
				}
				g.SmoothingMode = SmoothingMode.Default;
				#endregion
				
				#region Grid lines
				
				#region Vertical
				g.DrawLine((column % 5 == 0) ? mainLinesPen : subLinesPen,
				           new Point{
				           	X = mapAnchor.X + column * cellSize.Width,
				           	Y = mapAnchor.Y + row * cellSize.Height
				           },
				           new Point{
				           	X = mapAnchor.X + column * cellSize.Width, 
				           	Y = mapAnchor.Y + (row + 1) * cellSize.Height
				           });
				g.DrawLine(((column + 1) % 5 == 0) ? mainLinesPen : subLinesPen,
				           new Point{
			           		X = mapAnchor.X + (column + 1) * cellSize.Width,
				           	Y = mapAnchor.Y + row * cellSize.Height
				           },
				           new Point{
			           		X = mapAnchor.X + (column + 1) * cellSize.Width,
				           	Y = mapAnchor.Y + (row + 1) * cellSize.Height
				           });
				#endregion
				
				#region Horizontal
				g.DrawLine((row % 5 == 0) ? mainLinesPen : subLinesPen, 
				           new Point{
				           	X = mapAnchor.X + column * cellSize.Width,
				           	Y = mapAnchor.Y + row * cellSize.Height
				           },
				           new Point{
				           	X = mapAnchor.X + (column + 1) * cellSize.Width,
				           	Y = mapAnchor.Y + row * cellSize.Height
				           });
				g.DrawLine(((row + 1) % 5 == 0) ? mainLinesPen : subLinesPen,
				           new Point{
				           	X = mapAnchor.X + column * cellSize.Width,
				           	Y = mapAnchor.Y + (row + 1) * cellSize.Height
				           },
				           new Point{
				           	X = mapAnchor.X + (column + 1) * cellSize.Width,
				           	Y = mapAnchor.Y + (row + 1) * cellSize.Height
				           });
				#endregion
				
				#endregion
			}
		}
		
		protected void OnResize(object sender, EventArgs e)
		{
			drawPanel.Invalidate();
		}
	}
}
