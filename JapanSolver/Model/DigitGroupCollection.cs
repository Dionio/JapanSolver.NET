using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JapanSolver.Model
{
	public class DigitGroupCollection : Collection<DigitGroup>
	{
		protected int capacity;
		
		public DigitGroupCollection(int capacity)
		{
			this.capacity = capacity;
		}
		
		protected int MaxItemsLength
		{
			get
			{
				int result = 0;
				foreach(DigitGroup dg in Items)
				{
					result = Math.Max(result, dg.Count);
				}
				return result;
			}
		}
		
		/*
		public void GenerateRandomGroupsTempMethod()
		{
			Random r = new Random();
			for(int i = 0; i < capacity; i++)
				Add(DigitGroup.GenerateRandomGroupTempMethod(r.Next(1, capacity * 2 / 6), r));
		}
		*/
	}
	
	public class TopDigitGroupCollection : DigitGroupCollection
	{
		public TopDigitGroupCollection(int columns)
			: base(columns) {}
		
		public int RowsCount
		{
			get	{ return MaxItemsLength;}
		}
	}
	
	public class LeftDigitGroupCollection : DigitGroupCollection
	{
		public LeftDigitGroupCollection(int rows)
			: base(rows) {}
		
		public int ColumnsCount
		{
			get	{ return MaxItemsLength;}
		}
	}
}
