public class Solution
{
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{

		var head = (ListNode)null;
		var current = (ListNode)null;
		var div = 0;

		while (l1 != null || l2 != null || div != 0)
		{
			var num1 = 0;
			var num2 = 0;

			if (l1 != null)
			{
				num1 = l1.val;
				l1 = l1.next;
			}

			if (l2 != null)
			{
				num2 = l2.val;
				l2 = l2.next;
			}

			var sum = num1 + num2 + div;
			div = sum / 10;
			var rem = sum % 10;

			var node = new ListNode(rem);
			if (head == null)
				head = node;
			else
				current.next = node;
			
			current = node;
		}

		return head;
	}
}