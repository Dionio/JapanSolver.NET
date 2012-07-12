using System;
using System.Collections;
using System.Collections.Generic;

namespace JapanSolver.Model
{
	public sealed class DigitGroupState : IEnumerable<DigitGroupState>
	{
		public DigitGroup DigitGroup{ get; private set;}
		public int CellsCount{get; set;}
		private List<int> positions;
			
//		public struct BarPosition
//		{
//			int digit;
//			int position;
//		}
		
		public DigitGroupState(DigitGroup digitGroup)
		{
			DigitGroup = digitGroup;
			positions = new List<int>(digitGroup.Count);
			digitGroup.DigitsChanged += this.RebuildStates;
			//this.Reset();
		}
		
		public void RebuildStates(object sender, EventArgs e)
		{
			//this.Reset();
		}
		
		#region IEnumerable
		
		public IEnumerator<DigitGroupState> GetEnumerator()
		{
			return new DigitGroupStateEnumerator(this);
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		
		#endregion
		
		#region public class DigitGroupStateEnumerator : IEnumerator<DigitGroupState>
		
		public class DigitGroupStateEnumerator : IEnumerator<DigitGroupState>
		{
			DigitGroupState state;
			
			public DigitGroupStateEnumerator(DigitGroupState state)
			{
				this.state = state;
			}
			
			public DigitGroupState Current { get { return state;}}
		
			object IEnumerator.Current { get { return state;}}
			
			public void Dispose()
			{
				
			}
			
			public bool MoveNext()
			{
				return false;
			}
			
			public void Reset()
			{
				if(state.CellsCount < state.DigitGroup.MinLength)
				{
					return;
				}
			}
		}
		#endregion
	}
}
