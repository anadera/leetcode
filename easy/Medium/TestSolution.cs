using System;
using Easy;
using NUnit.Framework;

namespace Medium
{
    [TestFixture]
    internal class TestSolution
    {
        [Test]
        public void TestAddTwoNumbers1()
        {
            var a = new ListNode(3);
            var b = new ListNode(4, a);
            var c = new ListNode(2, b);

            var x = new ListNode(4);
            var y = new ListNode(6, x);
            var z = new ListNode(5, y);

            var r = Solution.AddTwoNumbers(c, z);
            while (r != null)
            {
                Console.Write(r.val);
                r = r.next;
            }
        }

        [Test]
        public void TestAddTwoNumbers2()
        {
            var a1 = new ListNode(9);
            var a2 = new ListNode(9, a1);
            var a3 = new ListNode(9, a2);
            var a4 = new ListNode(9, a3);
            var a5 = new ListNode(9, a4);
            var a6 = new ListNode(9, a5);
            var a7 = new ListNode(9, a6);

            var b1 = new ListNode(9);
            var b2 = new ListNode(9, b1);
            var b3 = new ListNode(9, b2);
            var b4 = new ListNode(9, b3);

            var r = Solution.AddTwoNumbers(a7, b4);
            while (r != null)
            {
                Console.Write(r.val);
                r = r.next;
            }
        }

        [Test]
        public void TestAddTwoNumbers3()
        {
            var a = new ListNode(2);
            var b = new ListNode(3, a);
            var c = new ListNode(8, b);

            var x = new ListNode(1);
            var y = new ListNode(2, x);
            var z = new ListNode(9, y);

            var r = Solution.AddTwoNumbers(c, z);
            while (r != null)
            {
                Console.Write(r.val);
                r = r.next;
            }
        }

        [Test]
        public void TestAddTwoNumbers4()
        {
            var a = new ListNode(1);
            var b = new ListNode(9, a);
            var c = new ListNode(9, b);

            var x = new ListNode(1);

            var r = Solution.AddTwoNumbers(c, x);
            while (r != null)
            {
                Console.Write(r.val);
                r = r.next;
            }
        }
    }
}
