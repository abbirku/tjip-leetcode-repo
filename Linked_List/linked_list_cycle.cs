public class Solution
{
	public bool HasCycle(ListNode head)
	{
		var slow = head;
		var fast = head;

		while (slow != null && fast != null && fast.next != null)
		{
			slow = slow.next;
			fast = fast.next.next;

			if (slow != null && fast != null && slow == fast)
				return true;
		}

		return false;
	}
}