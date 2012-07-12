using System;

namespace JapanSolver.Model
{
	public class Map
	{
		public int Width { get; private set; }
		public int Height { get; private set; }
		
		private Cell[,] cells;
		public Cell[,] Cells
		{
			get{ return cells;}
		}
		private Cell[][] rows;
		private Cell[][] columns;
		
		public Cell[] GetRow(int row)
		{
			return rows[row];
		}
		
		public Cell[] GetColumn(int column)
		{
			return columns[column];
		}
		
		public Map(int width, int height)
		{
			Width = width;
			Height = height;
			cells = new Cell[Height, Width];
			rows = new Cell[Height][];
			columns = new Cell[Width][];
			for(int i = 0; i < Height; i++)
				rows[i] = new Cell[Width];
			for(int i = 0; i < Width; i++)
				columns[i] = new Cell[Height];
			for(int i = 0; i < Height; i++)
				for(int j = 0; j < Width; j++)
					columns[j][i] = rows[i][j] = cells[i, j] = new Cell();
		}
		
		public static long CountOfStates(int cellsCount, DigitGroup digits)
		{
			checked{
				long result = 0;
				int barsCount = digits.Count; // n
				int freeCellsCount = cellsCount - digits.MinLength - barsCount + 1; // N1 = N - H - n + 1
				
				return result;
			}
		}
	}
}
