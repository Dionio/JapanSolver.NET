using System;
using JapanSolver.Model;

namespace JapanSolver
{
	public static class DocumentGenerator
	{
		public static Document CreateJapanHouse()
		{
			Document document = new Document(7, 7);
			
			int[,] filledCells2 = 
			{
				{0, 0, 0, 1, 0, 0, 0},
				{0, 0, 1, 1, 1, 0, 0},
				{0, 1, 1, 1, 1, 1, 0},
				{1, 1, 0, 0, 0, 1, 1},
				{0, 1, 0, 0, 0, 1, 0},
				{0, 1, 0, 0, 0, 1, 0},
				{0, 1, 1, 1, 1, 1, 0}
			};
			
			for(int i = 0; i < filledCells2.GetLength(0); i++) {
				for(int j = 0; j < filledCells2.GetLength(1); j++) {
					document.Map.Cells[i, j].State = (filledCells2[i, j] > 0 ? CellStateEnum.Filled : CellStateEnum.Normal);
				}
			}
			
			document.RebuildDigitGroupCollectionsFromMap();
			
			return document;
		}
		
		public static Document CreateRandomDocument(int width, int height)
		{
			Document document = new Document(width, height);
			
			Random r = new Random();
			//((i + j) % 2 == 0)
			//(r.NextDouble() < 0.6)
			//(i > j)
			DocumentGenerator.GenerateRandomCells(document, (i, j) => ((i + j) % 2 == 0));
			document.RebuildDigitGroupCollectionsFromMap();
			
			return document;
		}
		
		public static void CreateJapanHouseCells(Document doc)
		{
			#region OldVariant
			/*
			int[][] filledCells = new int[][]
			{
																new int[]{0, 3},
												new int[]{1, 2},new int[]{1, 3},new int[]{1, 4},
								new int[]{2, 1},new int[]{2, 2},new int[]{2, 3},new int[]{2, 4},new int[]{2, 5},
				new int[]{3, 0},new int[]{3, 1},												new int[]{3, 5},new int[]{3, 6},
								new int[]{4, 1},												new int[]{4, 5},
								new int[]{5, 1},												new int[]{5, 5},
								new int[]{6, 1},new int[]{6, 2},new int[]{6, 3},new int[]{6, 4},new int[]{6, 5}
			};
			
			foreach(int[] point in filledCells)
				doc.Map.Cells[point[0], point[1]].State = CellStateEnum.Filled;
			*/
			#endregion
		}
		
		public static void GenerateRandomCells(Document doc, Func<Int32, Int32, Boolean> mapper)
		{
			Random r = new Random();
			double d;
			for(int i = 0; i < doc.Map.Cells.GetLength(0); i++)
			{
				for(int j = 0; j < doc.Map.Cells.GetLength(1); j++)
				{
					d = r.NextDouble();
					doc.Map.Cells[i, j].State = (mapper(i, j)) ? CellStateEnum.Filled : CellStateEnum.Normal;
				}
			}
		}
	}
}
