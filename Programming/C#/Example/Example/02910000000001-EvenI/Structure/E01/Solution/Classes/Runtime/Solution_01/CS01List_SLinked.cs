using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Solution.Classes.Runtime.Solution_01
{
	/**
	 * 연결 리스트
	 */
	internal class CS01List_SLinked<T>
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
		public CNode Node_Head { get; private set; } = null;

		/** 생성자 */
		public CS01List_SLinked()
		{
			this.Node_Head = this.CreateNode(default);
		}

		/** 인덱서 */
		public T this[int a_nIdx]
		{
			get
			{
				return this.FindNode_At(a_nIdx, out CNode oNode_Prev).Val;
			}
			set
			{
				var oNode = this.FindNode_At(a_nIdx, out CNode oNode_Prev);
				oNode.Val = value;
			}
		}

		/** 값을 추가한다 */
		public void AddVal(T a_tVal)
		{
			var oNode_Tail = this.Node_Head;

			while(oNode_Tail.Node_Next != null)
			{
				oNode_Tail = oNode_Tail.Node_Next;
			}

			oNode_Tail.Node_Next = this.CreateNode(a_tVal);
			this.NumValues += 1;
		}

		/** 값을 추가한다 */
		public void InsertVal(int a_nIdx, T a_tVal)
		{
			this.FindNode_At(a_nIdx, out CNode oNode_Prev);

			// 값 추가가 불가능 할 경우
			if(oNode_Prev == null)
			{
				return;
			}

			var oNode = this.CreateNode(a_tVal);
			oNode.Node_Next = oNode_Prev.Node_Next;

			oNode_Prev.Node_Next = oNode;
			this.NumValues += 1;
		}

		/** 값을 제거한다 */
		public void RemoveVal(T a_tVal)
		{
			var oNode_Remove = this.FindNode(a_tVal, out CNode oNode_Prev);
			this.RemoveNode(oNode_Remove, oNode_Prev);
		}

		/** 값을 제거한다 */
		public void RemoveVal_At(int a_nIdx)
		{
			var oNode_Remove = this.FindNode_At(a_nIdx, out CNode oNode_Prev);
			this.RemoveNode(oNode_Remove, oNode_Prev);
		}

		/** 노드를 제거한다 */
		private void RemoveNode(CNode a_oNode_Remove, CNode a_oNode_Prev)
		{
			// 노드 제거가 불가능 할 경우
			if(a_oNode_Remove == null)
			{
				return;
			}

			a_oNode_Prev.Node_Next = a_oNode_Remove.Node_Next;
			this.NumValues -= 1;
		}

		/** 노드를 탐색한다 */
		private CNode FindNode(T a_tVal, out CNode a_oOutNode_Prev)
		{
			a_oOutNode_Prev = this.Node_Head;

			while(a_oOutNode_Prev.Node_Next != null &&
				!a_tVal.Equals(a_oOutNode_Prev.Node_Next.Val))
			{
				a_oOutNode_Prev = a_oOutNode_Prev.Node_Next;
			}

			return a_oOutNode_Prev.Node_Next;
		}

		/** 노드를 탐색한다 */
		private CNode FindNode_At(int a_nIdx, out CNode a_oOutNode_Prev)
		{
			a_oOutNode_Prev = this.Node_Head;

			for(int i = 0; i < a_nIdx; ++i)
			{
				a_oOutNode_Prev = a_oOutNode_Prev.Node_Next;
			}

			return a_oOutNode_Prev.Node_Next;
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
