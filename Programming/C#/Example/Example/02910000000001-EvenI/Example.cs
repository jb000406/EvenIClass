using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_02;

namespace Example._02910000000001_EvenI
{
	internal class Example
	{
		public static void Start(string[] args)
		{

			var oRandom = new Random();
			var oListValues = new CE01Practice_01<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.AddVal(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 리스트 <=====");
			E01PrintValues_02(oListValues);

			oListValues.InsertVal(oRandom.Next(0, 10), 100);

			Console.WriteLine("\n=====> 리스트 - 추가 후 <=====");
			E01PrintValues_02(oListValues);

			oListValues.RemoveVal(100);

			Console.WriteLine("\n=====> 리스트 - 제거 후 <=====");
			E01PrintValues_02(oListValues);

			oListValues.InsertVal(11, 100);

			Console.WriteLine("\n=====> 리스트 - 추가 후 <=====");
			E01PrintValues_02(oListValues);

			oListValues.RemoveVal(100);

			Console.WriteLine("\n=====> 리스트 - 제거 후 <=====");
			E01PrintValues_02(oListValues);
		}

		private static void E01PrintValues_02<T>(CE01Practice_01<T> a_oListValues) where T : IComparable
		{
			for(int i = 0; i < a_oListValues.NumValues; ++i)
			{
				Console.Write("{0}, ", a_oListValues[i]);
			}

		}
	}
}
