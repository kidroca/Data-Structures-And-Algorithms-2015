namespace T1SumAndAverage
{
    using System;
    using System.Linq;
    using HomeworkHelpers;

    /// <summary>
    /// Write a program that reads from the console a sequence of positive integer numbers.
    ///     The sequence ends when empty line is entered.
    ///     Calculate and print the sum and average of the elements of the sequence.
    ///     Keep the sequence in List<int>.
    /// </summary>
    public class Program
    {
        private static HomeworkHelper helper = new HomeworkHelper();

        private static void Main()
        {
            helper.ConsoleMio.Setup();

            helper.ConsoleMio.PrintHeading("Task 1 Sum And Average Of A Sequence");

            uint[] sequence = helper.ReadCollection(
                template: (uint)0,
                splitChars: new char[] { ' ' })
                .ToArray();

            helper.ConsoleMio.Write("Sum: ", ConsoleColor.DarkGreen);
            uint sum = SequenceSum(sequence);
            Console.WriteLine(sum);

            helper.ConsoleMio.Write("Average: ", ConsoleColor.DarkGreen);
            Console.WriteLine(sum / (double)sequence.Length);
        }

        private static uint SequenceSum(uint[] sequence)
        {
            uint sum = 0;

            foreach (uint integer in sequence)
            {
                sum += integer;
            }

            return sum;
        }
    }
}
