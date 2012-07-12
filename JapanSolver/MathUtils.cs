using System;
using System.Text;
using System.Collections.Generic;
using JapanSolver.Model;

namespace JapanSolver
{
	public static class MathUtils
	{
		private static SortedDictionary<int, SortedDictionary<int, long>> qos;
		private static long[,] qosArray = new long[0,0];
		
		public static int MinLength(DigitGroup dg)
		{
			return 0;
		}
		
		public static long factorial(int n)
		{
			if(n == 0 || n == 1)
				return 1;
			return n * factorial(n - 1);
		}
		
		//public static long QoSArray(int k, int S) {
			
		//}
		
		private static void UpdateQoSArray(ref long[,] array, int newk, int newS) {
			long[,] oldArray = array;
			array = new long[Math.Max(oldArray.GetLength(0), newk), Math.Max(oldArray.GetLength(1), newS)];
		}
		
		/**
		 * k = n + 1
		 * 
		 * */
		public static long QoS(int k, int S)
		{
			if(k < 1 || S < 0) {
				throw new ArgumentException("Parameters must be: k >= 1; S >= 0");
			}
			if(qos == null) {
				qos = new SortedDictionary<int, SortedDictionary<int, long>>();
				qos[1] = new SortedDictionary<int, long>();
			}
			if(!qos.ContainsKey(k)){
				qos[k] = new SortedDictionary<int, long>();
			}
			if(k == 1 || S == 0)
			{
				qos[k][S] = 1;
				return 1;
			}
			
			if(qos[k].ContainsKey(S))
			{
				return qos[k][S];
			} else {
				long temp = 0;
				for(int i = 0; i <= S; i++) temp += QoS(k - 1, i);
				
				qos[k][S] = temp;
				qos[k][S] = QoS(k - 1, S) + QoS(k, S - 1);
				return temp;
			}
			
		}
		
		public static String toStringQoS(){
			if(qos == null) return String.Empty;
			StringBuilder builder = new StringBuilder();
			int digits = 1;
			foreach(var line in qos.Values) {
				foreach(var val in line.Values) {
					if(val == 0) continue;
					digits = Math.Max(digits, (int)Math.Floor(Math.Log10(val)) + 1);
				}
			}
			String format = "({0:D2}:{1:D2}:{2," + digits + "})";
			foreach(var key in qos.Keys) {
				builder.Append(String.Format("k = {0:D3}:", key));
				foreach(var valkey in qos[key].Keys) {
					builder.Append(String.Format(format, key, valkey, qos[key][valkey]));
				}
				builder.Append("\n");
			}
			return builder.ToString();
		}
	}
}
