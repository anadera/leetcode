namespace Easy;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var currentVal1 = list1;
        var currentVal2 = list2;
        var result = new ListNode();
        var head = result;
        do
        {
            if (currentVal1 != null && currentVal2 != null)
            {
                if (currentVal1.val <= currentVal2.val)
                {
                    result.next = currentVal1;
                    currentVal1 = currentVal1.next;
                }
                else
                {
                    result.next = currentVal2;
                    currentVal2 = currentVal2.next;
                }

                result = result.next;
            }
        } while (currentVal1 != null && currentVal2 != null);

        if (currentVal2 is not null)
        {
            result.next = currentVal2;
        }
        else if (currentVal1 is not null)
        {
            result.next = currentVal1;
        }

        return head.next;
    }

    public static ListNode RemoveElements(ListNode head, int val)
    {
        var result = new ListNode();
        var headPointer = result;
        while (head != null)
        {
            if (head.val != val)
            {
                result.next = head;
                head = head.next;
                result = result.next;
            }
            else
            {
                result.next = null;
                head = head.next;
            }
        }

        return headPointer.next;
    }
}