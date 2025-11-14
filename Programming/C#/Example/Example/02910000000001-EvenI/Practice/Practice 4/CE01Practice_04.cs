using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Practice.Practice_4
{
	internal class CE01Practice_04<T> where T : IComparable
	{


		public enum EOrder
		{
			NONE = -1,
			LEVEL,
			MAX_VAL
		}

		public class CNode
		{
			public T Val { get; set; }
			public CNode CNode_Left { get; set; }
			public CNode CNode_Right { get; set; }
		}
		public CNode Node_Root { get; private set; } = null;
		int N_Level = 0;
		public void AddValue(T N_Val)
		{
			var ONode = this.CreateNode(N_Val);

			if(this.Node_Root == null)
			{
				this.Node_Root = ONode;
				return;
			}

			var ONode_Child = this.Node_Root;
			CNode ONode_Parent = null;

			while(ONode_Child != null)
			{
				ONode_Parent = ONode_Child;

				if(N_Val.CompareTo(ONode_Child.Val) >= 0)
				{
					ONode_Child = ONode_Child.CNode_Right;
				}
				else
				{
					ONode_Child = ONode_Child.CNode_Left;
				}
			}

			if(N_Val.CompareTo(ONode_Parent.Val) >= 0)
			{
				ONode_Parent.CNode_Right = ONode;
			}
			else
			{
				ONode_Parent.CNode_Left = ONode;
			}
		}

		public void RemoveValue(T A_tVal)
		{
			var ONode_Remove = this.Node_Root;
			CNode ONode_Parent = null;

			while(ONode_Remove != null && A_tVal.CompareTo(ONode_Remove.Val) != 0)
			{
				ONode_Parent = ONode_Remove;

				if(A_tVal.CompareTo(ONode_Remove.Val) >= 0)
				{
					ONode_Remove = ONode_Remove.CNode_Right;
				}
				else
				{
					ONode_Remove = ONode_Remove.CNode_Left;
				}
			}

			if(ONode_Remove == null)
			{
				return;
			}

			if(ONode_Remove.CNode_Right != null && ONode_Remove.CNode_Left != null)
			{
				ONode_Parent = ONode_Remove;
				var oNode_Descendants = ONode_Remove.CNode_Left;

				while(oNode_Descendants.CNode_Right != null)
				{
					ONode_Parent = oNode_Descendants;
					oNode_Descendants = oNode_Descendants.CNode_Right;
				}

				ONode_Remove.Val = oNode_Descendants.Val;
				ONode_Remove = oNode_Descendants;
			}

			if(ONode_Remove == this.Node_Root)
			{
				this.Node_Root = (this.Node_Root.CNode_Left != null) ?
					this.Node_Root.CNode_Left : this.Node_Root.CNode_Right;

				return;
			}

			if(ONode_Remove.CNode_Left != null)
			{
				if(ONode_Remove == ONode_Parent.CNode_Left)
				{
					ONode_Parent.CNode_Left = ONode_Remove.CNode_Left;
				}
				else
				{
					ONode_Parent.CNode_Right = ONode_Remove.CNode_Left;
				}
			}
			else
			{
				if(ONode_Remove == ONode_Parent.CNode_Left)
				{
					ONode_Parent.CNode_Left = ONode_Remove.CNode_Right;
				}
				else
				{
					ONode_Parent.CNode_Right = ONode_Remove.CNode_Right;
				}
			}
		}

		public void Enumerate(EOrder a_eOrder, Action<T> a_oCallback)
		{
			switch(a_eOrder)
			{
				case EOrder.LEVEL:
					this.Enumerate_ByLevelOrder(this.Node_Root, a_oCallback);
					break;
			}
		}

		public CNode CreateNode(T N_Val)
		{
			return new CNode()
			{
				Val = N_Val
			};
		}

		private void Enumerate_ByLevelOrder(CNode a_oNode, Action<T> a_oCallback)
		{
			if(a_oNode == null)
				return;

			var ONodeQueue = new Queue<CNode>();

			ONodeQueue.Enqueue(a_oNode);

			while(ONodeQueue.Count > 0)
			{
				var Onode = ONodeQueue.Dequeue();

				a_oCallback?.Invoke(Onode.Val);

				if(Onode.CNode_Left != null)
				{
					ONodeQueue.Enqueue(Onode.CNode_Left);
				}

				if(Onode.CNode_Right != null)
				{
					ONodeQueue.Enqueue(Onode.CNode_Right);
				}

			}
		}
	}
}
