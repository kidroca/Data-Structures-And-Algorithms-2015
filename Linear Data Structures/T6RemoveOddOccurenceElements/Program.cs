namespace T6RemoveOddOccurenceElements
{
    using System;
    using System.Collections.Generic;
    using HomeworkHelpers;

    /// <summary>
    /// Write a program that removes from given sequence all numbers that occur odd number of times.
    ///     {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} → {5, 3, 3, 5}
    /// </summary>
    public class Program
    {
        private static HomeworkHelper helper = new HomeworkHelper();

        private static void Main()
        {
            helper.ConsoleMio.Setup();

            helper.ConsoleMio.PrintHeading("Task 6 Remove Elements That Occur Odd Number Of Times ");

            ICollection<int> collection = helper.ReadCollection(0, new[] { ' ', ',' });

            Dictionary<int, int> occurencesMap = MapByElementOccurence(collection);

            var filteredCollection = new List<int>();

            foreach (int number in collection)
            {
                if (occurencesMap[number] % 2 == 0)
                {
                    filteredCollection.Add(number);
                }
            }

            helper.ConsoleMio.WriteLine(
                "Result: {0}", ConsoleColor.DarkGreen, string.Join(" ", filteredCollection));
        }

        public static Dictionary<T, int> MapByElementOccurence<T>(IEnumerable<T> collection)
            where T : IEquatable<T>
        {
            Dictionary<T, int> result = new Dictionary<T, int>();

            foreach (T element in collection)
            {
                if (!result.ContainsKey(element))
                {
                    result[element] = 0;
                }

                result[element]++;
            }

            return result;
        }
    }
}
