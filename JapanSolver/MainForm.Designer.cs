namespace JapanSolver
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.topDrawPanel = new System.Windows.Forms.Panel();
			this.leftDrawPanel = new System.Windows.Forms.Panel();
			this.drawPanel = new System.Windows.Forms.Panel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.ColumnCount = 3;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Controls.Add(this.topDrawPanel, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.leftDrawPanel, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.drawPanel, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.statusStrip1, 0, 2);
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 3;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(802, 374);
			this.tableLayoutPanel.TabIndex = 1;
			// 
			// topDrawPanel
			// 
			this.topDrawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.topDrawPanel.Location = new System.Drawing.Point(23, 3);
			this.topDrawPanel.Name = "topDrawPanel";
			this.topDrawPanel.Size = new System.Drawing.Size(756, 14);
			this.topDrawPanel.TabIndex = 1;
			// 
			// leftDrawPanel
			// 
			this.leftDrawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.leftDrawPanel.Location = new System.Drawing.Point(3, 23);
			this.leftDrawPanel.Name = "leftDrawPanel";
			this.leftDrawPanel.Size = new System.Drawing.Size(14, 328);
			this.leftDrawPanel.TabIndex = 4;
			// 
			// drawPanel
			// 
			this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.drawPanel.Location = new System.Drawing.Point(23, 23);
			this.drawPanel.Name = "drawPanel";
			this.drawPanel.Size = new System.Drawing.Size(756, 328);
			this.drawPanel.TabIndex = 3;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 354);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(20, 20);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(802, 374);
			this.Controls.Add(this.tableLayoutPanel);
			this.Name = "MainForm";
			this.Text = "JapanSolver";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel leftDrawPanel;
		private System.Windows.Forms.Panel drawPanel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Panel topDrawPanel;
	}
}
