using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Example._02910000000001_EvenI.Practice.Practice_3
{
	internal class Example
	{
		public static void Start(string[] args)
		{
			var oRandom = new Random();
			var list = new CE01Practice_03<int>();

			for (int i = 0; i < 10; i++)
			{
				list.EnQueue(oRandom.Next(1, 100));
			}

			Console.WriteLine("데이터 추가 후 \n");

			CE01Practice_03_Print(list);

			Console.WriteLine("\n 데이터 삭제");
			Console.WriteLine("삭제된 데이터 = {0}", list.DeQueue());

			Console.WriteLine("데이터 삭제");
			Console.WriteLine("삭제된 데이터 = {0}", list.DeQueue());

			Console.WriteLine("데이터  리스트 \n");

			CE01Practice_03_Print(list);
		}

		public static void CE01Practice_03_Print<T>(CE01Practice_03<T> NodeList) where T : IComparable
		{
			for(int i = 0; i < NodeList.NumValues; i++)
			{
				Console.Write("{0} ", NodeList[i]);
			}
		}
	}
}
