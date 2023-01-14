internal class MyLinkedList<Type> where Type : IEquatable<Type>
{
	#region properties and internal classes



	internal class Node
	{
		public Type Value { get; set; }
		public MyLinkedList<Type> Children { get; set; }
		public Node Next { get; set; }
		public Node Previous { get; set; }
		public Node(Type value) => Value = value;
		public Node(MyLinkedList<Type> children) => Children = children;
	}

	private Node First { get; set; }
	private Node Last { get; set; }
	private int Size { get; set; }

	#endregion



	public void AddFirst(Type value)
	{
		var node = new Node(value);
		Size++;
		if (IsEmpty())
		{
			First = Last = node;
			return;
		}
		First.Previous = node;
		node.Next = First;
		First = node;
		return;
	}

	public void AddLast(Type value)
	{
		var node = new Node(value);
		Size++;
		if (IsEmpty())
		{
			First = Last = node;
			return;
		}
		Last.Next = node;
		node.Previous = Last;
		Last = node;
	}

	public void InsertRight(Type value, Type newValue)
	{
		var node = new Node(newValue);
		var current = GetTheNode(value);

		if (!IsEmpty())
		{
			if (current.Next != null)
			{
				var right = current.Next;
				current.Next = node;
				node.Next = right;
				current.Next = right.Previous = node;
				return;
			}
		}
		else
		{
			Last = First = node;
			return;
		}
		current.Next = node;
		node.Previous = current;

		Last = node;
		Size++;
	}

	public void DeleteNode(Type value)
	{
		var current = GetTheNode(value);
		if (!IsEmpty())
		{
			if (!(Equals(current, Last) || Equals(current, First)))
			{
				var prev = current.Previous;
				var next = current.Next;
				prev.Next = next;
				next.Previous = prev;
			}
			if (Equals(current.Value, First.Value))
			{
				var secone = current.Next;
				secone.Previous = null;
				First = secone;
			}
			if (Equals(current.Value, Last.Value))
			{
				var prev = current.Previous;
				prev.Next = null;
				Last = prev;
			}
			if (Last == First)
			{
				Last = First = null;
			}
		}
		Size--;
	}

	public void AddListAsElement(MyLinkedList<Type> list)
	{
		var node = new Node(list);
		Last.Next = node;
		node.Previous = Last;
		Last = node;
	}


	private Node GetTheNode(Type value)
	{
		var current = First;
		while (!Equals(value, current.Value))
		{
			current = current.Next;
		}
		return current;
	}

	public void PrintList()
	{
		var current = First;
		while (current != null)
		{
			if (current.Children != null)
			{
				Console.Write("{");
				var child = current.Children.First;
				while (child != null)
				{
					Console.Write($"<=> {child.Value} ");
					child = child.Next;
				}
				Console.Write("}");
			}

			if (current.Children == null)
			{
				Console.Write($"<=> {current.Value} ");
			}
			current = current.Next;
		}
	}

	private bool IsEmpty() => First == null;
}