namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Add(T item)
        {
            this.Items.Add(item);
        }

        public bool Remove(T item)
        {
            return this.Items.Remove(item);
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in this.Items)
            {
                if (element.CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int left = 0,
                right = this.Items.Count - 1;

            while (left <= right)
            {
                int index = left + (right - left) / 2;

                if (this.Items[index].CompareTo(item) == 0)
                {
                    return true;
                }
                else if (this.Items[index].CompareTo(item) > 0)
                {
                    right = index - 1;
                }
                else
                {
                    left = index + 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
