using System;

namespace ConsoleAppAddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = null;
            bool isNeedToAddOne = false;
            while (l1 != null || l2 != null)
            {
                var i = (l1?.val ?? 0) + (l2?.val ?? 0);
                if (isNeedToAddOne)
                {
                    i++;
                    isNeedToAddOne = false;
                }
                if (i > 9)
                {
                    isNeedToAddOne = true;
                    i -= 10;
                }
                result = new ListNode(i, result);
                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (isNeedToAddOne)
            {
                result = new ListNode(1, result);
            }

            return ReverseList(result);
        }

        private ListNode ReverseList(ListNode root)
        {
            ListNode p = root;
            ListNode n = null;
            while (p != null)
            {
                ListNode tmp = p.next;
                p.next = n;
                n = p;
                p = tmp;
            }
            return n;
        }
    }
}
