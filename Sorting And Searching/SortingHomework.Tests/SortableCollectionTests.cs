namespace SortingHomework.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SortableCollectionTests
    {
        private SortableCollection<DateTime> testDatesCollection;

        [TestInitialize]
        public void Initialize()
        {
            this.testDatesCollection = new SortableCollection<DateTime>();
            var nextDate = new DateTime(2000, 1, 1);

            for (int i = 0; i < 120; i++)
            {
                this.testDatesCollection.Add(nextDate);

                nextDate = nextDate.AddMonths(1);
            }
        }

        [TestMethod]
        public void LinearSearchShouldWorkCorrectly()
        {
            Assert.IsTrue(this.testDatesCollection.LinearSearch(new DateTime(2001, 1, 1)));
            Assert.IsTrue(this.testDatesCollection.LinearSearch(new DateTime(2009, 1, 1)));

            Assert.IsTrue(this.testDatesCollection.BinarySearch(new DateTime(2005, 3, 1)));

            Assert.IsFalse(this.testDatesCollection.LinearSearch(new DateTime(1999, 1, 1)));
            Assert.IsFalse(this.testDatesCollection.BinarySearch(new DateTime(2013, 1, 1)));
        }

        [TestMethod]
        public void BinarySearchShouldWorkCorrectly()
        {
            Assert.IsTrue(this.testDatesCollection.BinarySearch(new DateTime(2001, 1, 1)));
            Assert.IsTrue(this.testDatesCollection.BinarySearch(new DateTime(2009, 1, 1)));

            Assert.IsTrue(this.testDatesCollection.BinarySearch(new DateTime(2005, 3, 1)));
            Assert.IsTrue(this.testDatesCollection.BinarySearch(new DateTime(2004, 5, 1)));

            Assert.IsFalse(this.testDatesCollection.BinarySearch(new DateTime(1999, 1, 1)));
            Assert.IsFalse(this.testDatesCollection.BinarySearch(new DateTime(2013, 1, 1)));
        }
    }
}