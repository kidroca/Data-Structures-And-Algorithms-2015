namespace T2ReverseCollectionThroughStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HomeworkHelpers;

    /// <summary>
    /// Write a program that reads N integers from the console and reverses them using a stack.
    ///     Use the Stack<int> class.
    /// </summary>
    public class Program
    {
        private static HomeworkHelper helper = new HomeworkHelper();

        private static void Main()
        {
            helper.ConsoleMio.Setup();

            helper.ConsoleMio.PrintHeading("Task 2 Reverse a Sequence Using a Stack");

            int[] collection = helper.ReadCollection(0, new char[] { ' ' }).ToArray();

            Stack<int> stack = new Stack<int>(collection);

            int[] reversed = new int[collection.Length];

            for (int i = 0; i < reversed.Length; i++)
            {
                reversed[i] = stack.Pop();
            }

            helper.ConsoleMio.WriteLine(
                "Result: {0}",
                ConsoleColor.DarkGreen,
                string.Join(" ", reversed));
        }
    }
}
