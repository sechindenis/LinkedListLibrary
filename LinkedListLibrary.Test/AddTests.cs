namespace LinkedListLibrary.Test
{
    public class AddTests
    {
        // value to the end
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Add_WhenAddValueToEmptyList_ShouldAddValueToTheEnd(int value)
        {
            LinkedList actual = new LinkedList();
            actual.Add(value);
            LinkedList expected = new LinkedList(new int[] { value });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Add_WhenAddValueToOneElementList_ShouldAddValueToTheEnd(int value)
        {
            LinkedList actual = new LinkedList(5);
            actual.Add(value);
            LinkedList expected = new LinkedList(new int[] { 5, value });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Add__WhenAddValueToSeveralElementsList_ShouldAddValueToTheEnd(int value)
        {
            LinkedList actual = new LinkedList(new int[] { 1, 2, 3 });
            actual.Add(value);
            LinkedList expected = new LinkedList(new int[] { 1, 2, 3, value });

            Assert.That(actual, Is.EqualTo(expected));
        }

        // array of values to the end
        // positive
        [Test]
        public void Add_WhenAddArrayOfValuesToEmptyList_ShouldAddArrayOfValuesToTheEnd()
        {
            LinkedList actual = new LinkedList();
            actual.Add(new int[] { 4, 5, 6 });
            LinkedList expected = new LinkedList(new int[] { 4, 5, 6 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_WhenAddArrayOfValuesToOneElementList_ShouldAddArrayOfValuesToTheEnd()
        {
            LinkedList actual = new LinkedList(5);
            actual.Add(new int[] { 4, 5, 6 });
            LinkedList expected = new LinkedList(new int[] { 5, 4, 5, 6 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_WhenAddArrayOfValuesToSeveralElementsList_ShouldAddArrayOfValuesToTheEnd()
        {
            LinkedList actual = new LinkedList(new int[] { 1, 2, 3 });
            actual.Add(new int[] { 4, 5, 6 });
            LinkedList expected = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.That(actual, Is.EqualTo(expected));
        }

        // negative
        [Test]
        public void Add_WhenAddNullArrayToEmptyList_ShouldThrowNullReferenceException()
        {
            LinkedList actual = new LinkedList();
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => actual.Add(ints));
        }

        [Test]
        public void Add_WhenAddNullArrayToOneElementList_ShouldThrowNullReferenceException()
        {
            LinkedList actual = new LinkedList(6);
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => actual.Add(ints));
        }

        [Test]
        public void Add_WhenAddNullArrayToOfSeveralElementsList_ShouldThrowNullReferenceException()
        {
            LinkedList actual = new LinkedList(new int[] { 1, 2, 3 });
            int[] ints = null;

            Assert.Throws<NullReferenceException>(() => actual.Add(ints));
        }
    }
}
