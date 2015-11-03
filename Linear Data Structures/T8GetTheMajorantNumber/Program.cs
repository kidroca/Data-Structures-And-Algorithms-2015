namespace T8GetTheMajorantNumber
{
    using System;
    using System.Linq;
    using HomeworkHelpers;

    /// <summary>
    /// The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
    ///     Write a program to find the majorant of given array (if exists).
    ///     {2, 2, 3, 3, 2, 3, 4, 3, 3} → 3
    /// </summary>
    public class Program
    {
        private static HomeworkHelper helper = new HomeworkHelper();

        private static void Main()
        {
            helper.ConsoleMio.Setup();

            helper.ConsoleMio.PrintHeading("Task 8 Find The Majorant In A Collection");

            int[] collection = helper.GetCollectionFromUserChoice(0, 100, 5, 7).ToArray();

            helper.ConsoleMio.WriteLine("Working with: ", ConsoleColor.DarkBlue);
            Console.WriteLine(string.Join(" ", collection));

            int majorant;
            if (GetMajorant(collection, out majorant))
            {
                helper.ConsoleMio.WriteLine("The Majorant is: {0}", ConsoleColor.DarkGreen, majorant);
            }
            else
            {
                helper.ConsoleMio.WriteLine("The collection doesn't have a majorant", ConsoleColor.DarkRed);
            }
        }

        private static bool GetMajorant<T>(T[] collection, out T majorant)
            where T : IEquatable<T>
        {
            var groups = collection
                .GroupBy(s => s);
            try
            {
                majorant = groups
                .First(x => x.Count() >= (collection.Length / 2) + 1)
                .Key;

                return true;
            }
            catch (InvalidOperationException)
            {
                majorant = default(T);
                return false;
            }
        }
    }
}
