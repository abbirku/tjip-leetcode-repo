public class Solution 
{
    public void DeleteNode(ListNode node) 
	{
        var temp = node.next;
        node.val = node.next.val;
        node.next = node.next.next;
        temp.next = null;
    }
}