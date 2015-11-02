namespace T10ShortestSequenceOfOperations
{
    using System;
    using HomeworkHelpers;
    using T12AdtAutosizeStack;

    /// <summary>
    /// We are given numbers N and M and the following operations:
    ///     N = N+1
    ///     N = N+2
    ///     N = N*2
    /// 
    /// Write a program that finds the shortest sequence of operations from the list above that starts 
    /// from N and finishes in M.
    ///     Example: N = 5, M = 16
    ///     Sequence: 5 → 7 → 8 → 16
    /// 
    /// Hint: use a queue.
    /// </summary>
    public class Program
    {
        private static HomeworkHelper helper = new HomeworkHelper();

        private static void Main(string[] args)
        {
            helper.ConsoleMio.Setup();

            helper.ConsoleMio.PrintHeading("Task 10 Shortest Sequence Of Operations From N to M");

            Console.Write("Enter number N = ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter number M = ");
            int m = int.Parse(Console.ReadLine());

            // Using the stack from Task 12
            Stack<int> steps = new Stack<int>();
            steps.StackUp(m);

            int current = m;
            while (current > n)
            {
                if (current % 2 == 0 && current / 2 >= n)
                {
                    current /= 2;
                    steps.StackUp(current);
                }
                else if (current - 2 >= n)
                {
                    current -= 2;
                    steps.StackUp(current);
                }
                else if (current - 1 >= n)
                {
                    current -= 1;
                    steps.StackUp(current);
                }
            }

            helper.ConsoleMio.Write("Result: ", ConsoleColor.DarkGreen);
            helper.ConsoleMio.WriteLine(string.Join(" → ", steps), ConsoleColor.DarkBlue);
        }
    }
}
