namespace T5PositiveOpinion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HomeworkHelpers;

    /// <summary>
    /// Write a program that removes from given sequence all negative numbers.
    /// </summary>
    public class Program
    {
        private static HomeworkHelper helper = new HomeworkHelper();

        private static void Main()
        {
            helper.ConsoleMio.Setup();

            helper.ConsoleMio.PrintHeading("Task 5 Remove All Negative Numbers From a Sequence");

            List<int> collection = helper.ReadCollection(0, null).ToList();

            List<int> positiveCollection = new List<int>(collection.Count);

            foreach (int i in collection)
            {
                if (i >= 0)
                {
                    positiveCollection.Add(i);
                }
            }

            helper.ConsoleMio.WriteLine(
                "Result: {0}", ConsoleColor.DarkGreen, string.Join(" ", positiveCollection));
        }
    }
}
