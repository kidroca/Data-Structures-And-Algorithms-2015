namespace T9FirstMembersOfASequenceUsingQueue
{
    using System;
    using System.Collections.Generic;
    using HomeworkHelpers;
    using T13AdtDynamicLinkedListQueue;

    /// <summary>
    /// We are given the following sequence:
    ///     S1 = N;
    ///     S2 = S1 + 1;
    ///     S3 = 2* S1 + 1;
    ///     S4 = S1 + 2;
    ///     S5 = S2 + 1;
    ///     S6 = 2* S2 + 1;
    ///     S7 = S2 + 2;
    /// Using the Queue<T> class write a program to print its first 50 members for given N.
    ///     N=2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...
    /// </summary>
    public class Program
    {
        private const int SEQUENCE_LENGTH = 50;

        private static HomeworkHelper helper = new HomeworkHelper();

        private static void Main()
        {
            helper.ConsoleMio.Setup();

            helper.ConsoleMio.PrintHeading("Task 9 The 50 Members Of The Night's Watch");

            Console.Write("Night gathers, and now my watch begins. Give me a number ");
            helper.ConsoleMio.Write("N", ConsoleColor.Red);
            Console.Write(", for this\n" +
                "night and all the nights to come: ");

            int n = int.Parse(helper.ConsoleMio.ReadInColor(ConsoleColor.Red));

            // Using the queue from Task 13
            LinkedQueue<int> thisIsJavaScript = new LinkedQueue<int>();
            List<int> result = new List<int>(SEQUENCE_LENGTH);

            thisIsJavaScript.Enqueue(n);
            result.Add(n);

            while (result.Count <= SEQUENCE_LENGTH)
            {
                int baseNumber = thisIsJavaScript.GetNextInLine();
                int x = baseNumber + 1;
                int y = baseNumber * 2 + 1;
                int z = baseNumber + 2;

                thisIsJavaScript.Enqueue(x);
                result.Add(x);

                thisIsJavaScript.Enqueue(y);
                result.Add(y);

                thisIsJavaScript.Enqueue(z);
                result.Add(z);
            }

            helper.ConsoleMio.WriteLine(
                "Result: {0}", ConsoleColor.DarkGreen, string.Join(" ", result));
        }
    }
}
