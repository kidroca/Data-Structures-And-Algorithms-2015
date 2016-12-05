namespace SortingHomework.Sorters
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int boundaryIndex = this.Partition(collection, left, right);
            this.QuickSort(collection, left, boundaryIndex - 1);
            this.QuickSort(collection, boundaryIndex + 1, right);
        }

        private int Partition(IList<T> collection, int left, int right)
        {
            int middle = (left + right) / 2;
            collection.SwapIndexes(left, middle);

            T pivot = collection[left];

            int low = left + 1,
                high = right;
            while (low <= high)
            {
                while (collection[high].CompareTo(pivot) > 0)
                {
                    high--;
                }

                while (low <= high && collection[low].CompareTo(pivot) <= 0)
                {
                    low++;
                }

                if (low <= high)
                {
                    collection.SwapIndexes(low, high);
                    low++;
                    high--;
                }
            }

            collection.SwapIndexes(left, high);
            return high;
        }
    }
}
