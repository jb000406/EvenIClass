using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Practice.Practice_3
{
	internal class CE01Practice_03<T> where T : IComparable
	{
		public class CNode
		{
			public T Val { get; set; }

			public CNode CNode_Next { get; set; }
			public CNode CNode_Prev { get; set; }

		}

		public int NumValues = 0;
		public CNode node_Head { get; private set; } = null;
		public CNode node_Tail { get; private set; } = null;
		public T[] Values { get; private set; } = null;

		public T this[int a_nIdx]
		{
			get
			{
				return this.FindNode_At(a_nIdx).Val;
			}
			set
			{
				var oNode = this.FindNode_At(a_nIdx);
				oNode.Val = value;
			}
		}

		public void EnQueue(T N_val)
		{
			var node = CreateNode(N_val);

			if(node_Head == null)
			{
				this.node_Head = node;
				this.node_Tail = node;

				NumValues++;
			}
			else
			{
				var node_Tail = this.node_Head;

				node_Tail = this.node_Tail;

				node_Tail.CNode_Next = node;
				node.CNode_Prev = node_Tail;
				this.node_Tail = node;
				node.CNode_Next = this.node_Head;
				this.node_Head.CNode_Prev = node;

				NumValues++;

			}
		}

		public T DeQueue()
		{
			var DNode = this.node_Head;
			var head_next = this.node_Head.CNode_Next;
			var head_prev = this.node_Head.CNode_Prev;
			if(node_Head == null) return default;

			if(head_next != null)
			{
				head_next.CNode_Prev = DNode.CNode_Prev;
				head_prev.CNode_Next = DNode.CNode_Next;
			}

			this.node_Head = DNode.CNode_Next;
			this.node_Tail = DNode.CNode_Prev;
			NumValues--;

			return DNode.Val;
		}

		private CNode FindNode_At(int a_nIdx)
		{
			var oNode = this.node_Head;

			for(int i = 0; i < a_nIdx; ++i)
			{
				oNode = oNode.CNode_Next;
			}

			return oNode;
		}

		public CNode CreateNode(T N_val)
		{
			return new CNode
			{
				Val = N_val
			};
		}

	}
}
