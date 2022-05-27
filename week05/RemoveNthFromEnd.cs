public class Solution
{
	private void DeleteAtIndex(ref ListNode head, int index, int size)
	{
		if (index < 0 || index >= size)
			return;
		else if (index == 0 && size == 1)
			head = null;
		else if (index == 0 && size == 2)
		{
			var current = head;
			head = head.next;
			current.next = null;
		}
		else if (index == 1 && size == 2)
			head.next = null;
		else if (index == 0 && size > 2)
		{
			var current = head;
			head = head.next;
			current.next = null;
		}
		else if (index == size - 1 && size > 2)
		{
			var current = head;
			for (int i = 1; i < size - 1; i++)
				current = current.next;

			current.next = null;
		}
		else
		{
			var current = head;
			for (int i = 1; i < index; i++)
				current = current.next;

			var temp = current.next;
			current.next = current.next.next;
			temp.next = null;
		}
	}

	public ListNode RemoveNthFromEnd(ListNode head, int n)
	{
		var size = 0;
		var current = head;

		while(current != null)
		{
			size++;
			current = current.next;
		}

		var index = size - n;
		DeleteAtIndex(ref head, index, size);
		return head;
	}
}