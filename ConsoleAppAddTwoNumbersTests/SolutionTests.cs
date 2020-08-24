using System.Xml;
using NUnit.Framework;
using ConsoleAppAddTwoNumbers;
using NuGet.Frameworks;

namespace ConsoleAppAddTwoNumbersTests
{
    [TestFixture()]
    public class SolutionTests
    {
        private Solution _solution;

        [SetUp()]
        public void Setup()
        {
            _solution = new Solution();
        }

        private ListNode CreateNodeFromString(string s)
        {
            ListNode ln = null;
            foreach (char c in s)
            {
                int i = int.Parse(c.ToString());
                ln = ln != null
                    ? new ListNode(i, ln)
                    : new ListNode(i);
            }
            return ln;
        }

        [Test]
        [TestCase("123", "234", "357")]
        [TestCase("5", "5", "10")]
        [TestCase("342", "465", "807")]
        [TestCase("81", "0", "81")]
        public void AddTwoNumbersTest(string node1, string node2, string expected)
        {
            var listNode1 = CreateNodeFromString(node1);
            var listNode2 = CreateNodeFromString(node2);
            var result = _solution.AddTwoNumbers(listNode1, listNode2);
            var actual = ListNodeToString(result);
            Assert.AreEqual(expected, actual);
        }

        private string ListNodeToString(ListNode listNode)
        {
            string result = listNode.val.ToString();
            while (listNode.next != null)
            {
                listNode = listNode.next;
                result = listNode.val + result;
            }
            return result;
        }
    }
}