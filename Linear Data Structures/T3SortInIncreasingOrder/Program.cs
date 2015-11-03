namespace T3SortInIncreasingOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HomeworkHelpers;

    /// <summary>
    /// Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts 
    /// them in an increasing order.
    /// </summary>
    public class Program
    {
        private static HomeworkHelper helper = new HomeworkHelper();

        private static void Main()
        {
            helper.ConsoleMio.Setup();

            helper.ConsoleMio.PrintHeading("Task 3 Sort a Sequence in Increasing Order");

            List<int> sequence = helper.ReadCollection(0, new[] { ' ' }).ToList();

            helper.ConsoleMio.WriteLine("Sorting with heapsort...", ConsoleColor.DarkBlue);
            HeapSort(sequence, sequence.Count);

            helper.ConsoleMio.WriteLine(
                "Result: {0}",
                ConsoleColor.DarkGreen,
                string.Join(" ", sequence));
        }

        private static void HeapSort<T>(IList<T> collection, int size)
            where T : IComparable
        {
            Heapify(collection, size);

            int end = size - 1;
            while (end > 0)
            {
                Swap(collection, end, 0);
                end -= 1;

                SiftDown(collection, 0, end);
            }
        }

        private static void Heapify<T>(IList<T> collection, int size)
            where T : IComparable
        {
            int start = (size - 2) / 2;

            while (start >= 0)
            {
                SiftDown(collection, start, size - 1);
                start -= 1;
            }
        }

        private static void SiftDown<T>(IList<T> collection, int start, int end)
            where T : IComparable
        {
            while (((start * 2) + 1) <= end)
            {
                int child = (start * 2) + 1;
                int swap = start;

                if (collection[swap].CompareTo(collection[child]) < 0)
                {
                    swap = child;
                }

                if (child + 1 <= end &&
                    collection[swap].CompareTo(collection[child + 1]) < 0)
                {
                    swap = child + 1;
                }

                if (swap == start)
                {
                    return;
                }
                else
                {
                    Swap(collection, start, swap);
                    start = swap;
                }
            }
        }

        private static void Swap<T>(IList<T> collection, int i, int j)
        {
            T prev = collection[i];
            collection[i] = collection[j];
            collection[j] = prev;
        }
    }
}
