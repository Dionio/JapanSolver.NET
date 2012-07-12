using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JapanSolver.Model
{
	public sealed class DigitGroup : Collection<int>, IEnumerable<DigitGroupState>
	{
		Regex regex = new Regex("");
		Regex regexForTrimmedString = new Regex("");
		
		public Regex Regex { get { return regex;}}
		public Regex RegexForTrimmedString { get { return regexForTrimmedString;}}
		
		IEnumerator<DigitGroupState> IEnumerable<DigitGroupState>.GetEnumerator()
		{
			return null;
		}
		
		public DigitGroup() 
		{
		}
		
		protected override void InsertItem(int index, int item)
		{
			base.InsertItem(index, item);
			OnDigitsChanged();
		}
		
		public event EventHandler DigitsChanged;
		
		private void OnDigitsChanged()
		{
			UpdateRegex();
			if(DigitsChanged != null)
			{
				DigitsChanged(this, null);
			}
		}
		
		public int MinLength
		{
			get
			{
				int result = 0;
				foreach(int i in this)
					result += this[i];
				return result + Count - 1;
			}
		}
		
		/*
		public static DigitGroup GenerateRandomGroupTempMethod(int length, Random r)
		{
			DigitGroup result = new DigitGroup();
			for(int i = 0; i < length; i++)
				//Add(r.Next(5, 15));
				result.Add((i + 1) * 3);
			return result;
		}
		*/
		
		private void UpdateRegex()
		{
			string pattern = "";
			string patternTrimmed = "";
			string temp;
			for(int i = 0; i < this.Count; i++)
			{
				temp = @"[" + Cell.FILLED_CHAR + "]{" + this[i] + "}" + ((i < this.Count - 1) ? @"\s+" : "");
				pattern += temp;
				patternTrimmed += temp;
			}
			if(pattern.Length == 0) 
			{
				//pattern //TODO complete this
			}
			regex = new Regex(@"(\s*" + pattern + @"\s*)");
			regexForTrimmedString = new Regex(@"(" + patternTrimmed + @")");
		}
		
		public bool CheckDigitGroupOnCells(Cell[] cellSeq)
		{
			return CheckDigitGroupOnCells(this, cellSeq);
		}
		
		public bool CheckDigitGroupOnString(string cellsString, bool trimmed)
		{
			return CheckDigitGroupOnString(this, cellsString, trimmed);
		}

		public static bool CheckDigitGroupOnCells(DigitGroup dg, Cell[] cellSeq)
		{
			bool result = true;
			Cell[] trimmedCells = Cell.TrimNotFilledCells(cellSeq);
			string trimmedString = Cell.GetStringRepresentation(trimmedCells);
			if(trimmedCells.Length == 0) return false;
			if(trimmedCells.Length < dg.MinLength) return false;
			//TODO implement this
			return result;
		}
		
		public static bool CheckDigitGroupOnString(DigitGroup dg, string cellsString, bool trimmed)
		{
			bool result = false;
			Regex regex = trimmed ? dg.RegexForTrimmedString : dg.Regex;
			return result;
		}
	}
}
