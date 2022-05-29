public class Solution
{
	public int PairSum(ListNode head)
	{
		//Find the middle point of the list
		var slow = head;
		var fast = head.next;

		while (fast.next != null)
		{
			slow = slow.next;
			fast = fast.next.next;
		}

		//Reverse second half
		var prev = (ListNode)null;
		var current = slow.next;
		slow.next = null;

		while(current != null)
		{
			var next = current.next;
			current.next = prev;
			prev = current;
			current = next;
		}

		//Iterate over and find max sum
		var max = 0;
		var iter = head;
		while(iter != null)
		{
			var sum = iter.val + prev.val;
			if(sum > max)
				max = sum;
			iter = iter.next;
			prev = prev.next;
		}

		return max;
	}
}