public class Solution
{
	public Node CopyRandomList(Node head)
	{
		var primMap = new Dictionary<Node, Node>();
		var secMap = new Dictionary<Node, Node>();

		var newHead = (Node)null;
		var current = (Node)null;

		while (head != null)
		{
			var node = new Node(head.val);

			if (newHead == null)
				newHead = node;
			else
				current.next = node;

			current = node;

			primMap.Add(head, head.random);
			secMap.Add(head, current);

			head = head.next;
		}

		current = newHead;
		foreach (var pm in primMap)
		{
			if (pm.Value != null && secMap.ContainsKey(pm.Value))
				current.random = secMap[pm.Value];
			else
				current.random = null;

			current = current.next;
		}

		return newHead;
	}
}