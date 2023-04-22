﻿namespace LinkedListLibrary.Test
{
    public class RemoveTests
    {
        // removing one element from the end
        // direct, negative, empty list
        [TestCase(false)]
        public void Remove_WhenRemoveOneElementFromEmptyList_ShouldReturnFalse(bool expected)
        {
            LinkedList list = new LinkedList();
            bool actual = list.Remove();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // direct, positive, one element list
        [TestCase(true)]
        public void Remove_WhenRemoveOneElementFromOneElementList_ShouldReturnTrue(bool expected)
        {
            LinkedList list = new LinkedList(1);
            bool actual = list.Remove();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // direct, positive, not empty list
        [TestCase(true)]
        public void Remove_WhenRemoveOneElementFromSeveralElementsList_ShouldReturnTrue(bool expected)
        {
            LinkedList list = new LinkedList(new int[] { 1, 2, 3});
            bool actual = list.Remove();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect, one element list
        [Test]
        public void Remove_WhenRemoveOneElementFromOneElementList_ShouldLeftEmptyList()
        {
            LinkedList actual = new LinkedList(1);
            actual.Remove();
            LinkedList expected = new LinkedList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect, several elements list
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 }) ]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 })]
        public void Remove_WhenRemoveOneElementFromSeveralElementsList_ShouldLeftNotEmptyList(int[] array, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            actual.Remove();
            LinkedList expected = new LinkedList(expectedArray);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // removing N elements from the end
        // direct, empty list
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(5, false)]
        [TestCase(6, false)]
        [TestCase(-1, false)]
        [TestCase(-100, false)]
        public void Remove_WhenRemoveNumberElementFromEmptyList_ShouldReturnFalse(int numberOfElements, bool expected)
        {
            LinkedList list = new LinkedList();
            bool actual = list.Remove(numberOfElements);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // direct, not empty list
        [TestCase(0, true)]
        [TestCase(1, true)]
        [TestCase(5, true)]
        public void Remove_WhenRemoveNumberElementsInRangeFromNotEmptyList_ShouldReturnTrue(int numberOfElements, bool expected)
        {
            LinkedList list = new LinkedList(new int[] { 1, 2, 3, 4, 5 });
            bool actual = list.Remove(numberOfElements);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(6, false)]
        [TestCase(-1, false)]
        [TestCase(-100, false)]
        public void Remove_WhenRemoveNumberElementsOutOfRangeFromNotEmptyList_ShouldReturnFalse(int numberOfElements, bool expected)
        {
            LinkedList list = new LinkedList(new int[] { 1, 2, 3, 4, 5 });
            bool actual = list.Remove(numberOfElements);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect for lists, which left not empty at last
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, new int[] { 1 })]
        public void Remove_WhenRemoveNumberElementsInRangeFromNotEmptyList_ShouldLeftNewSmallerList(int[] ints, int n, int[] intsLeft)
        {
            LinkedList actual = new LinkedList(ints);
            actual.Remove(n);
            LinkedList expected = new LinkedList(intsLeft);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6,   new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0,   new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -1,  new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, -10, new int[] { 1, 2, 3, 4, 5 })]
        public void Remove_WhenRemoveNumberElementsOutOfRangeFromNotEmptyList_ShouldLeftSameList(int[] ints, int n, int[] intsLeft)
        {
            LinkedList actual = new LinkedList(ints);
            actual.Remove(n);
            LinkedList expected = new LinkedList(intsLeft);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // indirect for lists, which left empty at last
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]
        [TestCase(new int[] { 1, 2, 3, 4}, 4)]
        [TestCase(new int[] { 1, 2, 3}, 3)]
        [TestCase(new int[] { 1 }, 1)]
        public void Remove_WhenRemoveNumberElementsInRangeFromNotEmptyList_ShouldLeftEmptyList(int[] ints, int n)
        {
            LinkedList actual = new LinkedList(ints);
            actual.Remove(n);
            LinkedList expected = new LinkedList();

            Assert.That(actual, Is.EqualTo(expected));
        }    
    }
}