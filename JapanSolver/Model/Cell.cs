using System;

namespace JapanSolver.Model
{
	public sealed class Cell
	{
		public const string FILLED_CHAR = "F";
		public const string SPACE_CHAR = " ";
		public const string NORMAL_CHAR = " ";
		
		public CellStateEnum State {get; set;}
		
		public Cell()
		{
			State = CellStateEnum.Normal;
		}
		
		public static string GetStringRepresentation(Cell[] cells)
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder(cells.Length);
			foreach(Cell cell in cells)
			{
				builder.Append((cell.State == CellStateEnum.Filled) ? Cell.FILLED_CHAR : Cell.SPACE_CHAR);
			}
			return builder.ToString();
		}
		
		public static Cell[] TrimNotFilledCells(Cell[] originalArray)
		{
			Cell[] result;
			int start = 0;
			int end = originalArray.Length - 1;
			bool startFound = false;
			bool endFound = false;
			for(int i = 0; i < originalArray.Length; i++)
			{
				if(!startFound)
				{
					start = i;
					if(originalArray[i].State == CellStateEnum.Filled)
					{
						startFound = true;
					}
				}
			}
			for(int i = originalArray.Length - 1; i >= 0; i--)
			{
				if(!endFound)
				{
					end = i;
					if(originalArray[i].State == CellStateEnum.Filled)
					{
						endFound = true;
					}
				}
			}
			if(start > end)
			{
				result = new Cell[]{};
			} else {
				result = new Cell[end - start + 1];
				for(int i = start; i <= end; i++)
				{
					result[i - start] = originalArray[i];
				}
			}
			return result;
		}
	}
	
	public enum CellStateEnum
	{
		Normal,
		Space,
		Filled
	}
	
	public static class CellStateEnumHelper
	{
		public const String Filled = "Filled";
		public const String Space = "Space";
		public const String Normal = "Normal";
		
		public static String ToString(CellStateEnum state)
		{
			switch (state) {
				case CellStateEnum.Normal:
					return Normal;
				case CellStateEnum.Space:
					return Space;
				case CellStateEnum.Filled:
					return Filled;
				default:
					throw new ArgumentException("Unknown CellStateEnum: " + state.ToString());
			}
		}
		
		public static CellStateEnum Parse(String stateString)
		{
			switch (stateString) {
				case Filled:
					return CellStateEnum.Filled;
				case Space:
					return CellStateEnum.Space;
				case Normal:
					return CellStateEnum.Normal;
				default:
					throw new ArgumentException("Unable to parse string: " + stateString);
			}
		}
	}
}
