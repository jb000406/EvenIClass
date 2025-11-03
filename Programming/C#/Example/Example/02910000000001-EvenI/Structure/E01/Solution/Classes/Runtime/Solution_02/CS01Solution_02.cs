using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Solution.Classes.Runtime.Solution_02
{
	/**
	 * Solution 2
	 */
	internal class CS01Solution_02
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			var oStackValues = new CS01Stack_Linked<int>();
			Console.WriteLine("=====> 입력 순서 <=====");

			for(int i = 0; i < 10; ++i)
			{
				Console.Write("{0}, ", i + 1);
				oStackValues.Push(i + 1);
			}

			Console.WriteLine("\n\n=====> 스택 <=====");

			while(!oStackValues.IsEmpty())
			{
				Console.Write("{0}, ", oStackValues.Pop());
			}

			Console.WriteLine();
		}
	}
}
