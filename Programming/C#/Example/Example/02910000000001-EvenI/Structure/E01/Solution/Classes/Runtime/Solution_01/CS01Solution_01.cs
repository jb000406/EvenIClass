using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Solution.Classes.Runtime.Solution_01
{
	/**
	 * Solution 1
	 */
	internal class CS01Solution_01
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			var oRandom = new Random();
			var oListValues = new CS01List_SLinked<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.AddVal(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 리스트 <=====");
			S01PrintValues_01(oListValues);

			oListValues.InsertVal(0, 100);

			Console.WriteLine("\n=====> 리스트 - 추가 후 <=====");
			S01PrintValues_01(oListValues);

			oListValues.RemoveVal(100);

			Console.WriteLine("\n=====> 리스트 - 제거 후 <=====");
			S01PrintValues_01(oListValues);
		}

		/** 값을 출력한다 */
		private static void S01PrintValues_01<T>(CS01List_SLinked<T> a_oListValues) where T : IComparable
		{
			for(int i = 0; i < a_oListValues.NumValues; ++i)
			{
				Console.Write("{0}, ", a_oListValues[i]);
			}

			Console.WriteLine();
		}
	}
}
