namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[minIndex].CompareTo(collection[j]) > 0)
                    {
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    collection.SwapIndexes(i, minIndex);
                }
            }
        }
    }
}
