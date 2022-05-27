public class Solution {
    public ListNode ReverseList(ListNode head)
    {
        var stack = new Stack<int>();
        var reverseHead = (ListNode)null;
        var current = head;

        while (current != null)
        {
            stack.Push(current.val);
            current = current.next;
        }

        while (stack.Count > 0)
        {
            var node = new ListNode(stack.Peek());

            if (reverseHead == null)
                reverseHead = node;
            else
                current.next = node;

            current = node;
            stack.Pop();
        }

        return reverseHead;
    }
}