using Easy;

namespace Medium
{
    public static class Solution
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var carret = 0;
            ListNode head;
            var current = head = new ListNode();
            head.next = current;
            while (l1 != null || l2 != null)
            {
                var a = l1?.val ?? 0;
                var b = l2?.val ?? 0;
                var r = a + b + carret;
                carret = 0;
                while (r >= 10)
                {
                    carret++;
                    r -= 10;
                }
                var s = new ListNode(r);
                current.next = s;
                current = s;
                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (carret >= 1)
            {
                var s = new ListNode(carret);
                current.next = s;
            }
            return head.next;
        }
    }
}