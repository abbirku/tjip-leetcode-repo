Time Complexity: O(n)
Space Complexity: 

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode resultHead = null;
        ListNode current = null;

        if(list1 == null && list2 == null)
            return null;

        while(list1 != null || list2 != null)
        {
            ListNode node = null;
            if(list1 != null && list2 != null && list1.val <= list2.val)
            {
                node = new ListNode(list1.val);
                list1 = list1.next;
            }
            else if(list1 != null && list2 != null && list1.val >= list2.val)
            {
                node = new ListNode(list2.val);
                list2 = list2.next;
            }
            else if(list1 != null && list2 == null)
            {
                node = new ListNode(list1.val);
                list1 = list1.next;
            }
            else if(list1 == null && list2 != null)
            {
                node = new ListNode(list2.val);
                list2 = list2.next;
            }

            if(resultHead == null)
            {
                resultHead = node;
                current = node;
            }
            else
            {
                current.next = node;
                current = current.next;
            }
        }

        return resultHead;
    }
}