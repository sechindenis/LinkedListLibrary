﻿namespace LinkedListLibrary.Test
{
    public class UpSortTests
    {
        // up sort bubble
        // list length >= 2
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void UpSortBubbleSeveralElementsListTest(int mockParametr, int mockExpected)
        {
            LinkedList actual = new LinkedList(UpSortMock.GetMockParametrForUpSort(mockParametr));
            actual.UpSortBubble();
            LinkedList expected = new LinkedList(UpSortMock.GetMockExpectedForUpSort(mockExpected));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // list length = 1
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        public void UpSortBubbleOneElementListTest(int value)
        {
            LinkedList actual = new LinkedList(value);
            actual.UpSortBubble();
            LinkedList expected = new LinkedList(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // empty list
        [Test]
        public void UpSortBubbleEmptyListTest()
        {
            LinkedList actual = new LinkedList();
            actual.UpSortBubble();
            LinkedList expected = new LinkedList();

            Assert.That(actual, Is.EqualTo(expected));
        }

        // up sort insertions
        // list length >= 2
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        public void UpSortInsertionsSeveralElementsListTest(int mockParametr, int mockExpected)
        {
            LinkedList actual = new LinkedList(UpSortMock.GetMockParametrForUpSort(mockParametr));
            actual.UpSortInsertions();
            LinkedList expected = new LinkedList(UpSortMock.GetMockExpectedForUpSort(mockExpected));

            Assert.That(actual, Is.EqualTo(expected));
        }

        // list length = 1
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        public void UpSortInsertionsOneElementListTest(int value)
        {
            LinkedList actual = new LinkedList(value);
            actual.UpSortInsertions();
            LinkedList expected = new LinkedList(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // empty list
        [Test]
        public void UpSortInsertionsEmptyListTest()
        {
            LinkedList actual = new LinkedList();
            actual.UpSortInsertions();
            LinkedList expected = new LinkedList();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public static class UpSortMock
    {
        public static int[] GetMockParametrForUpSort(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 5, 4, 3, 2, 1 };
                    break;

                case 2:
                    parametr = new int[] { 10000, 1000, 100, 10 };
                    break;

                case 3:
                    parametr = new int[] { 5, -2, -1 };
                    break;

                case 4:
                    parametr = new int[] { 1, 1, 1 };
                    break;

                case 5:
                    parametr = new int[] { -1, -2, -3 };
                    break;
            }

            return parametr;
        }

        public static int[] GetMockExpectedForUpSort(int number)
        {
            int[] parametr = new int[0];

            switch (number)
            {
                case 1:
                    parametr = new int[] { 1, 2, 3, 4, 5 };
                    break;

                case 2:
                    parametr = new int[] { 10, 100, 1000, 10000 };
                    break;

                case 3:
                    parametr = new int[] { -2, -1, 5 };
                    break;

                case 4:
                    parametr = new int[] { 1, 1, 1 };
                    break;

                case 5:
                    parametr = new int[] { -3, -2, -1 };
                    break;
            }

            return parametr;
        }
    }
}