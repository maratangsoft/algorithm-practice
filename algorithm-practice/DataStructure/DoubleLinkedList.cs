

namespace algorithm_practice.DataStructure
{
	public class Node<T> : IComparable<Node<T>> where T : IComparable<T>
	{
		private T? _data;
		private Node<T>? _next;
		private Node<T>? _previous;

		public Node() : this(default) { }
		public Node(T? dataItem) : this(dataItem, null, null) { }
		public Node(T? dataItem, Node<T>? next, Node<T>? previous)
		{
			Data = dataItem;
			Next = next;
			Previous = previous;
		}

		public T? Data { get => _data; set => _data = value; }
		public Node<T>? Next { get => _next; set => _next = value; }
		public Node<T>? Previous { get => _previous; set => _previous = value; }

		public int CompareTo(Node<T>? other)
		{
			if (other == null) return -1;
			return Data.CompareTo(other.Data);
		}
	}

	public class DoubleLinkedList<T> : IEnumerable<T> where T : IComparable<T>
	{
		private int _count;
		private Node<T>? _firstNode { get; set; }
		private Node<T>? _lastNode { get; set; }

		public virtual Node<T>? Head
		{
			get { return _firstNode; }
		}

		public IEnumerator<T> GetEnumerator()
		{
			var node = _firstNode;
			while (node != null)
			{
				yield return node.Data;
				node = node.Next;
			}
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
