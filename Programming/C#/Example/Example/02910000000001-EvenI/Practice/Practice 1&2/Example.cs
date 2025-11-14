//#define P_P01_PRATICE_01_01
#define P_P01_PRATICE_01_02


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_02;

namespace Example._02910000000001_EvenI.Practice.Practice_1_2
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

#if P_P01_PRATICE_01_01

			Console.WriteLine("=====> 리스트 <=====");
			P01PrintValues_01(oListValues);

			oListValues.InsertVal(oRandom.Next(0, 10), 100);

			Console.WriteLine("\n=====> 리스트 - 추가 후 <=====");
			P01PrintValues_01(oListValues);

			oListValues.RemoveVal(100);

			Console.WriteLine("\n=====> 리스트 - 제거 후 <=====");
			P01PrintValues_01(oListValues);

			oListValues.InsertVal(oRandom.Next(0, 10), 100);

			Console.WriteLine("\n=====> 리스트 - 추가 후 <=====");
			P01PrintValues_01(oListValues);

			oListValues.RemoveVal(100);

			Console.WriteLine("\n=====> 리스트 - 제거 후 <=====");
			P01PrintValues_01(oListValues);

#elif P_P01_PRATICE_01_02

			Console.WriteLine("=====> 리스트 <=====");
			P01PrintValues_01(oListValues);

			Console.WriteLine("\n=====> 데이터 빼기 <=====");
			P01PopValues(oListValues);

			Console.WriteLine("=====> 리스트 <=====");
			P01PrintValues_01(oListValues);

			Console.WriteLine("\n=====> 데이터 추가 <=====");
			oListValues.AddVal(oRandom.Next(1, 100));

			Console.WriteLine("=====> 리스트 <=====");
			P01PrintValues_01(oListValues);

			Console.WriteLine("\n=====> 데이터 빼기 <=====");
			P01PopValues(oListValues);
			Console.WriteLine("\n=====> 데이터 빼기 <=====");
			P01PopValues(oListValues);
			Console.WriteLine("\n=====> 데이터 빼기 <=====");
			P01PopValues(oListValues);

			Console.WriteLine("=====> 리스트 <=====");
			P01PrintValues_01(oListValues);

#endif
		}



		private static void P01PrintValues_01<T>(CE01Practice_01<T> a_oListValues) where T : IComparable
		{
			for(int i = 0; i < a_oListValues.NumValues; ++i)
			{
				Console.Write("{0}, ", a_oListValues[i]);
			}

		}

		private static void P01PopValues<T>(CE01Practice_01<T> a_oListValues) where T : IComparable
		{
			a_oListValues.PoP();
		}
	}
}
