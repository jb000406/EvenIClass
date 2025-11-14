using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Practice.Practice_1_2
{
	internal class CE01Practice_01<T> where T : IComparable
	{
		public class CNode
		{
			public T Val { get; set; }

			public CNode Node_Next { get; set; }
		}

		public int NumValues { get; private set; } = 0;
		public CNode Node_Head { get; private set; } = null;
		public CNode Node_Tail { get; private set; } = null;

		public T this[int a_nidx]
		{
			get
			{
				if(a_nidx < 0 || a_nidx >= this.NumValues)
					throw new IndexOutOfRangeException($"index: {a_nidx}");

				var (_, curr) = this.FindNodeWithPrev_At(a_nidx);
				return curr.Val;
			}
			set
			{
				var(_, curr) = this.FindNodeWithPrev_At(a_nidx);
				curr.Val = value;
			}
		}

		public void AddVal(T a_tVal)
		{
			var oNode = this.CreateNode(a_tVal);

			if(this.Node_Head == null)
			{
				this.Node_Head = oNode;
				this.Node_Tail = oNode;
			}
			else
			{
				this.Node_Tail.Node_Next = oNode;
				this.Node_Tail = oNode;
			}

			this.NumValues += 1;
		}

		/*
		public void AddVal(T a_tVal)
		{
			var oNode = this.CreateNode(a_tVal);

			if(this.Node_Head == null)
			{
				this.Node_Head = oNode;
			}
			else
			{
				var oNode_Head = this.Node_Head;

				while(oNode_Head.Node_Next != null)
				{
					oNode_Head = oNode_Head.Node_Next;
				}

				oNode_Head.Node_Next = oNode;
			}

			this.NumValues += 1;
		}*/ // Tail을 사용 안 할 경우


		public void InsertVal(int a_nidx, T a_tVal)
		{
			var (oNode_Prev, oNode_Next) = this.FindNodeWithPrev_At(a_nidx);

			if(oNode_Next == null && oNode_Prev.Node_Next == oNode_Next)
			{
				this.Node_Tail.Node_Next = oNode_Next;
				oNode_Next = this.Node_Tail;
			}
			else if (oNode_Next == null)
			{
				return;
			}
			else if(oNode_Prev == null)
			{
				var oNode = this.CreateNode(a_tVal);
				oNode.Node_Next = oNode_Next;

				this.Node_Head = oNode;
			}
			else if(oNode_Prev != null)
			{
				var oNode = this.CreateNode(a_tVal);

				oNode_Prev.Node_Next = oNode;
				oNode.Node_Next = oNode_Next;
			}

			this.NumValues += 1;

		}

		/*
		public void InsertVal(int a_nidx, T a_tVal)
		{
			var (oNode_Prev, oNode_Next) = this.FindNodeWithPrev_At(a_nidx);

			if(oNode_Next == null)
			{
				return;
			}

			if(oNode_Prev == null)
			{
				var oNode = this.CreateNode(a_tVal);
				oNode.Node_Next = oNode_Next;

				this.Node_Head = oNode;
			}
			else if(oNode_Prev != null)
			{
				var oNode = this.CreateNode(a_tVal);

				oNode_Prev.Node_Next = oNode;
				oNode.Node_Next = oNode_Next;
			}

			this.NumValues += 1;

		}*/// tail을 사용안 할 경우

		public void RemoveVal(T a_tVal)
		{
			var (oNode_Remove_Prev, oNode_Remove) = this.FindNodeWithPrev(a_tVal);
			this.RemoveNode(oNode_Remove_Prev, oNode_Remove);
		}

		public void RemoveVal_At(int a_nidx)
		{
			var (oNode_Remove_Prev, oNode_Remove) = this.FindNodeWithPrev_At(a_nidx);
			this.RemoveNode(oNode_Remove_Prev, oNode_Remove);
		}

		private void RemoveNode(CNode oNode_Remove_Prev, CNode a_oNode_Remove)
		{
			if(a_oNode_Remove == null)
				return;

			if(a_oNode_Remove == this.Node_Head)
			{
				this.Node_Head = a_oNode_Remove.Node_Next;
			}
			else
			{
				if(oNode_Remove_Prev != null)
					oNode_Remove_Prev.Node_Next = a_oNode_Remove.Node_Next;
			}


			this.NumValues -= 1;
		}

		private (CNode oNode_Prev, CNode oNode) FindNodeWithPrev(T a_tVal)
		{
			CNode oNode_Prev = null;
			var oNode = this.Node_Head;

			while(oNode != null && oNode.Val.CompareTo(a_tVal) != 0)
			{
				oNode_Prev = oNode;
				oNode = oNode.Node_Next;
			}

			return (oNode_Prev ,oNode);
		}

		private (CNode oNode_Prev, CNode curr) FindNodeWithPrev_At(int a_nidx)
		{
			if(a_nidx < 0)
				return (null, null);

			
			CNode oNode_Prev = null;
			var curr = this.Node_Head;

			for(int i = 0; i < a_nidx && curr != null; i++)
			{
				oNode_Prev = curr;
				curr = curr.Node_Next;
			}

			return (oNode_Prev, curr);
		}

		private CNode CreateNode(T a_tVal)
		{
			return new CNode()
			{
				Val = a_tVal
			};
		}

		public CNode PoP()
		{
			if(this.Node_Head == null)
				throw new InvalidOperationException("리스트가 비어있습니다.");

			CNode prev = null;
			var onode = this.Node_Head;

			while(onode.Node_Next != null)
			{
				prev = onode;
				onode = onode.Node_Next;
			}

			if(prev == null)
			{
				this.Node_Tail = null;
				this.Node_Head = null;
			}
			else
			{
				this.Node_Tail = prev;
				prev.Node_Next = null;
			}

			this.NumValues -= 1;
			return onode;
		}
	}
}
