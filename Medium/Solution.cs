using System.Collections.Generic;
using Easy;

namespace Medium;

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

    public static int LengthOfLongestSubstring(string s)
    {
        var max = 0;
        for (int j = 0; j < s.Length; j++)
        {
            var current = new HashSet<char>() { };
            current.Add(s[j]);
            for (int i = j + 1; i < s.Length; i++)
            {
                if (current.Contains(s[i]))
                {
                    break;
                }

                current.Add(s[i]);
            }

            if (max < current.Count)
            {
                max = current.Count;
            }
        }

        return max;
    }

    public static string LongestPalindrome(string s)
    {
        var result = s.Substring(0, 1);
        var start = 0;
        var end = 0;
        var diff = 0;
        for (var i = 1; i < s.Length; i++)
        {
            var pointerX = i - 1;
            var pointerY = i + 1;

            while (pointerX > 0 && pointerY < s.Length - 1)
            {
                if (s[pointerX] == s[pointerY])
                {
                    start = pointerX;
                    end = pointerY;
                    pointerX--;
                    pointerY++;
                    continue;
                }

                diff = end - start + 1;
                if (diff > result.Length)
                {
                    result = s.Substring(start, diff);
                }

                break;
            }

            if (pointerX >= 0 && pointerY <= s.Length - 1 && s[pointerX] == s[pointerY])
            {
                start = pointerX;
                end = pointerY;
            }

            diff = end - start + 1;
            if (diff > result.Length)
            {
                result = s.Substring(start, diff);
            }
        }

        for (var i = 1; i < s.Length; i++)
        {
            var pointerX = i - 1;
            var pointerY = i;

            while (pointerY < s.Length)
            {
                if (s[pointerX] == s[pointerY])
                {
                    start = pointerX;
                    end = pointerY;
                    pointerY++;
                    continue;
                }

                diff = end - start + 1;
                if (diff > result.Length)
                {
                    result = s.Substring(start, diff);
                }

                break;
            }

            if (pointerY < s.Length && s[pointerX] == s[pointerY])
            {
                start = pointerX;
                end = pointerY;
            }

            diff = end - start + 1;
            if (diff > result.Length)
            {
                result = s.Substring(start, diff);
            }
        }

        for (var i = 1; i < s.Length; i++)
        {
            var pointerX = i - 1;
            var pointerY = i;

            while (pointerX >= 0 && pointerY < s.Length)
            {
                if (s[pointerX] == s[pointerY])
                {
                    start = pointerX;
                    end = pointerY;
                    pointerX--;
                    pointerY++;
                    continue;
                }

                diff = end - start + 1;
                if (diff > result.Length)
                {
                    result = s.Substring(start, diff);
                }

                break;
            }

            if (pointerY < s.Length && pointerX >= 0 && s[pointerX] == s[pointerY])
            {
                start = pointerX;
                end = pointerY;
            }

            diff = end - start + 1;
            if (diff > result.Length)
            {
                result = s.Substring(start, diff);
            }
        }

        return result;
    }
}