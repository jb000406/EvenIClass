using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Example._02910000000001_EvenI.Structure.E01.Solution.Classes.Runtime.Solution_01;

namespace Example._02910000000001_EvenI.Structure.E01.Solution.Classes.Runtime.Solution_02
{
	/**
	 * 스택
	 */
	internal class CS01Stack_Linked<T>
	{
		private CS01List_SLinked<T> m_oListValues = new CS01List_SLinked<T>();

		/** 빈 여부를 검사한다 */
		public bool IsEmpty()
		{
			return m_oListValues.NumValues <= 0;
		}

		/** 값을 추가한다 */
		public void Push(T a_tVal)
		{
			m_oListValues.InsertVal(0, a_tVal);
		}

		/** 값을 제거한다 */
		public T Pop()
		{
			T tVal = m_oListValues[0];
			m_oListValues.RemoveVal_At(0);

			return tVal;
		}
	}
}
