namespace SortingHomework.Tests.Sorting
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public abstract class SortingsTestsBase<T> where T : IComparable<T>
    {
        protected T[] collection;
        protected ISorter<T> sorty;

        [TestInitialize]
        public abstract void TestInitialization();

        [TestMethod]
        public void SortingShouldProduceSortedCollectionInAscendingOrder()
        {
            this.sorty.Sort(collection);

            Assert.IsTrue(this.IsSortedAscending(collection), "The collection is not sorted in ascending order");
        }

        private bool IsSortedAscending(T[] collection)
        {
            T prev = collection[0];

            for (int i = 1; i < collection.Length; i++)
            {
                if (prev.CompareTo(collection[i]) > 0)
                {
                    return false;
                }

                prev = collection[i];
            }

            return true;
        }
    }
}
