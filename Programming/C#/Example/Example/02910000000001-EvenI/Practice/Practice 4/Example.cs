using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Practice.Practice_4
{
	internal class Example
	{
		public static void Start(string[] args)
		{
			var oRandom = new Random();
			var oTreeValues = new CE01Practice_04<int>();

			for(int i = 0; i < 10; i++)
			{
				oTreeValues.AddValue(oRandom.Next(0, 30));
			}

			Console.WriteLine("=====> 이진 탐색 트리 <=====");

			oTreeValues.Enumerate(CE01Practice_04<int>.EOrder.LEVEL, (N_Val) =>
			{
				Console.Write("{0}, ", N_Val);
			});

			for(int i = 0; i < 10; i++)
			{
				oTreeValues.AddValue(oRandom.Next(0, 30));
			}

			Console.WriteLine("\n=====>  추가 후 <=====");

			oTreeValues.Enumerate(CE01Practice_04<int>.EOrder.LEVEL, (N_Val) =>
			{
				Console.Write("{0}, ", N_Val);
			});

			for(int i = 0; i < 20; i++)
			{
				oTreeValues.RemoveValue(oRandom.Next(0, 30));
			}

			Console.WriteLine("\n=====>  제거 후 <=====");

			oTreeValues.Enumerate(CE01Practice_04<int>.EOrder.LEVEL, (N_Val) =>
			{
				Console.Write("{0}, ", N_Val);
			});

			var oTreeLevelValues = new CE01Practice_04<int>();

			oTreeLevelValues.AddValue(5);
			oTreeLevelValues.AddValue(3);
			oTreeLevelValues.AddValue(8);
			oTreeLevelValues.AddValue(4);
			oTreeLevelValues.AddValue(2);
			oTreeLevelValues.AddValue(9);
			oTreeLevelValues.AddValue(6);



			Console.WriteLine("\n=====>  과제용 탐색 트리  <=====");

			oTreeLevelValues.Enumerate(CE01Practice_04<int>.EOrder.LEVEL, (N_Val) =>
			{
				Console.Write("{0}, ", N_Val);
			});

			oTreeLevelValues.AddValue(2);

			Console.WriteLine("\n=====>  과제용 탐색 트리 추가 후 <=====");

			oTreeLevelValues.Enumerate(CE01Practice_04<int>.EOrder.LEVEL, (N_Val) =>
			{
				Console.Write("{0}, ", N_Val);
			});

		}
	}
}
