using NUnit.Framework;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestFixture()]
    public class E21_MergeTwoSortedListsTests
    {
        private E21_MergeTwoSortedLists _Target;
        private ListNode list_1;
        private ListNode list_2;

        [SetUp]
        public void SetUp()
        {
            _Target = new E21_MergeTwoSortedLists();
        }

        [Test]
        public void Two_single_node_merge()
        {
            list_1 = new ListNode(1);
            list_2 = new ListNode(2);

            var actual = _Target.MergeTwoLists(list_1, list_2);

            var expected = new ListNode(1) { next = new ListNode(2) };

            Assert.AreEqual(expected.val, actual.val);
            Assert.AreEqual(expected.next.val, actual.next.val);
        }

        [Test]
        public void two_multi_nodes_merge()
        {
            list_1 = new ListNode(1)
            {
                next = new ListNode(3)
                {
                    next = new ListNode(5)
                }
            };

            list_2 = new ListNode(2)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(6)
                }
            };

            var actual = _Target.MergeTwoLists(list_1, list_2);

            var expected = new ListNode(1) { next = new ListNode(2){next = new ListNode(3){next = new ListNode(4){next = new ListNode(5){next = new ListNode(6)}}}} };

            Assert.AreEqual(expected.val, actual.val);
            Assert.AreEqual(expected.next.val, actual.next.val);
            Assert.AreEqual(expected.next.next.val, actual.next.next.val);
            Assert.AreEqual(expected.next.next.next.val, actual.next.next.next.val);
            Assert.AreEqual(expected.next.next.next.next.val, actual.next.next.next.next.val);
            Assert.AreEqual(expected.next.next.next.next.next.val, actual.next.next.next.next.next.val);
        }
    }
}
