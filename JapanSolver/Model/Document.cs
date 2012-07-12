using System;
using System.Collections.Generic;

namespace JapanSolver.Model
{
	public sealed class Document
	{
		public int Width {get; private set;}
		public int Height {get; private set;}
		
		private Map map;
		public Map Map { get { return map;}}
		
		private TopDigitGroupCollection topCollection;
		public TopDigitGroupCollection TopCollection { get { return topCollection;}}
		private LeftDigitGroupCollection leftCollection;
		public LeftDigitGroupCollection LeftCollection { get { return leftCollection;}}
		
		public Document(int width, int height)
		{
			Width = width;
			Height = height;

			map = new Map(width, height);
			topCollection = new TopDigitGroupCollection(width);
			leftCollection = new LeftDigitGroupCollection(height);
		}
		
		public void RebuildDigitGroupCollectionsFromMap() {
			leftCollection = new LeftDigitGroupCollection(Height);
			DigitGroup digitGroup = null;
			int currentBarLength = 0;
			for (int i = 0; i < Height; i++) {
				Cell[] row = map.GetRow(i);
				digitGroup = new DigitGroup();
				for(int j = 0; j < Width; j++) {
					switch(row[j].State) {
						case CellStateEnum.Filled:
							currentBarLength++;
							break;
						case CellStateEnum.Normal:
						case CellStateEnum.Space:
							if(currentBarLength > 0) {
								digitGroup.Add(currentBarLength);
							}
							currentBarLength = 0;
							break;
					}
					if(j == Width - 1 && currentBarLength > 0) {
						digitGroup.Add(currentBarLength);
						currentBarLength = 0;
					}
				}
				leftCollection.Add(digitGroup);
			}
			
			topCollection = new TopDigitGroupCollection(Width);
			currentBarLength = 0;
			for (int i = 0; i < Width; i++) {
				Cell[] column = map.GetColumn(i);
				digitGroup = new DigitGroup();
				for(int j = 0; j < Height; j++) {
					switch(column[j].State) {
						case CellStateEnum.Filled:
							currentBarLength++;
							break;
						case CellStateEnum.Normal:
						case CellStateEnum.Space:
							if(currentBarLength > 0) {
								digitGroup.Add(currentBarLength);
							}
							currentBarLength = 0;
							break;
					}
					if(j == Height - 1 && currentBarLength > 0) {
						digitGroup.Add(currentBarLength);
						currentBarLength = 0;
					}
				}
				topCollection.Add(digitGroup);
			}
		}
		
		public IEnumerator<DigitGroupState> BuildEnumeratorForRow(int index, int cellsCount)
		{
			return BuildEnumeratorForGroup(leftCollection, index, Width);
		}
		
		public IEnumerator<DigitGroupState> BuildEnumeratorForColumn(int index)
		{
			return BuildEnumeratorForGroup(topCollection, index, Height);
		}
		
		private IEnumerator<DigitGroupState> BuildEnumeratorForGroup(
			DigitGroupCollection digitGroupCollection, 
			int index, 
			int cellsCount)
		{
			var state = new DigitGroupState(digitGroupCollection[index]);
			state.CellsCount = cellsCount;
			return state.GetEnumerator();
		}
	}
}
