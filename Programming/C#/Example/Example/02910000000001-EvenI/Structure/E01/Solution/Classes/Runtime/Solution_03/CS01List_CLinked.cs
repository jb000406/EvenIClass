using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Solution.Classes.Runtime.Solution_03
{
	/**
	 * 연결 리스트
	 */
	internal class CS01List_CLinked<T>
	{
		/**
		 * 노드
		 */
		public class CNode
		{
			public T Val { get; set; }
			public CNode Node_Next { get; set; } = null;
		}

		public int NumValues { get; private set; } = 0;
		public CNode Node_Tail { get; private set; } = null;

		/** 값을 추가한다 */
		public void AddVal(T a_tVal)
		{
			var oNode_New = this.CreateNode(a_tVal);
			this.NumValues += 1;

			// 테일 노드가 없을 경우
			if(this.Node_Tail == null)
			{
				this.Node_Tail = oNode_New;
				this.Node_Tail.Node_Next = this.Node_Tail;

				return;
			}

			oNode_New.Node_Next = this.Node_Tail.Node_Next;
			this.Node_Tail.Node_Next = oNode_New;

			this.Node_Tail = oNode_New;
			this.NumValues += 1;
		}

		/** 노드를 생성한다 */
		private CNode CreateNode(T a_tVal)
		{
			return new CNode()
			{
				Val = a_tVal
			};
		}
	}
}
