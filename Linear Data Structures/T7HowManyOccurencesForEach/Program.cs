namespace T7HowManyOccurencesForEach
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HomeworkHelpers;

    /// <summary>
    /// Write a program that finds in given array of integers (all belonging to the range [0..1000]) 
    /// how many times each of them occurs.
    /// </summary>
    public class Program
    {
        private const int MAGIC_CONSTANT = 10000;

        private static HomeworkHelper helper = new HomeworkHelper();

        private static void Main()
        {
            helper.ConsoleMio.Setup();

            helper.ConsoleMio.PrintHeading("Task 7 Count Number Occurences");

            int[] collection = helper.GetCollectionFromUserChoice(0, 10000, 0, 1000).ToArray();

            helper.ConsoleMio.WriteLine("Results: ", ConsoleColor.DarkGreen);
            if (collection.Length < MAGIC_CONSTANT)
            {
                SmallCollectionHandler(collection);
            }
            else
            {
                LargeCollectionHandler(collection);
            }

            Console.WriteLine("Completed...");
        }

        private static void LargeCollectionHandler(int[] collection)
        {
            int[] myIndexIsOcurrenceCount = new int[1001];
            foreach (int number in collection)
            {
                myIndexIsOcurrenceCount[number]++;
            }

            for (int i = 1; i < myIndexIsOcurrenceCount.Length; i++)
            {
                if (myIndexIsOcurrenceCount[i] > 0)
                {
                    helper.ConsoleMio.WriteLine(
                        "{0} → {1} time{2}",
                        ConsoleColor.DarkBlue,
                        i,
                        myIndexIsOcurrenceCount[i],
                        myIndexIsOcurrenceCount[i] == 1 ? string.Empty : "s");
                }

                if (i % 100 == 0)
                {
                    Console.WriteLine("Press a key to continue printing");
                    Console.ReadKey(true);
                }
            }
        }

        private static void SmallCollectionHandler(int[] collection)
        {
            Dictionary<int, int> occurencesMap =
                T6RemoveOddOccurenceElements.Program.MapByElementOccurence(collection);

            int i = 1;
            foreach (int key in occurencesMap.Keys)
            {
                helper.ConsoleMio.WriteLine(
                    "{0} → {1} time{2}",
                    ConsoleColor.DarkBlue,
                    key,
                    occurencesMap[key],
                    occurencesMap[key] == 1 ? string.Empty : "s");

                if (i % 10 == 0)
                {
                    Console.WriteLine("Press a key to continue printing");
                    Console.ReadKey(true);
                }

                i++;
            }
        }
    }
}
