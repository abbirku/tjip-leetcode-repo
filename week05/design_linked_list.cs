public class Node
{
	public int Val { get; set; }
	public Node Next { get; set; }
}

public class MyLinkedList
{
	private Node _head;
	private Node _tail;
	private int _size;

	public MyLinkedList()
	{
		_head = null;
		_tail = null;
		_size = 0;
	}

	public int Get(int index)
	{
		if (index < 0 || index >= _size)
			return -1;
		else
		{
			var current = _head;
			for (int i = 1; i <= index; i++)
				current = current.Next;

			return current.Val;
		}
	}

	public void AddAtHead(int val)
	{
		var node = new Node { Val = val };
		if (_size == 0)
		{
			_head = node;
			_tail = node;
		}
		else
		{
			node.Next = _head;
			_head = node;
		}
		_size++;
	}

	public void AddAtTail(int val)
	{
		var node = new Node { Val = val };
		if (_size == 0)
		{
			_head = node;
			_tail = node;
		}
		else
		{
			_tail.Next = node;
			_tail = node;
		}
		_size++;
	}

	public void AddAtIndex(int index, int val)
	{
		if (index < 0 || index > _size)
			return;
		else if (index == _size)
			AddAtTail(val);
		else if (index == 0)
			AddAtHead(val);
		else
		{
			var node = new Node { Val = val };
			var current = _head;
			for (int i = 1; i < index; i++)
				current = current.Next;

			node.Next = current.Next;
			current.Next = node;

			_size++;
		}
	}

	public void DeleteAtIndex(int index)
	{
		if (index < 0 || index >= _size)
			return;
		else if (index == 0 && _size == 1)
		{
			_head = null;
			_tail = null;
			_size--;
		}
		else if (index == 0 && _size == 2)
		{
			var current = _head;
			_head = _head.Next;
			current.Next = null;
			_size--;
		}
		else if (index == 1 && _size == 2)
		{
			_tail = _head;
			_head.Next = null;
			_size--;
		}
		else if (index == 0 && _size > 2)
		{
			var current = _head;
			_head = _head.Next;
			current.Next = null;
			_size--;
		}
		else if (index == _size - 1 && _size > 2)
		{
			var current = _head;
			for (int i = 1; i < _size - 1; i++)
				current = current.Next;

			_tail = current;
			current.Next = null;
			_size--;
		}
		else
		{
			var current = _head;
			for (int i = 1; i < index; i++)
				current = current.Next;

			var temp = current.Next;
			current.Next = current.Next.Next;
			temp.Next = null;

			_size--;
		}
	}

	public void PrintNodes()
	{
		Console.Write("All Node Val: ");
		var current = _head;
		while (current != null)
		{
			Console.Write($"{current.Val}, ");

			if (current.Next == null)
			{
				Console.WriteLine("Finished.");
				break;
			}

			current = current.Next;
		}
		Console.WriteLine("-------------------------------------");
	}

	public void GetCheck(int index)
	{
		Console.WriteLine($"Get Val: {Get(index)}");
		Console.WriteLine("-------------------------------------");
	}
}