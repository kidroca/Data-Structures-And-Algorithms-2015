namespace IterationSimulation
{
    using System;
    using System.Collections.Generic;
    using HomeworkHelpers;

    /// <summary>
    /// Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.
    /// </summary>
    public class Program
    {
        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static readonly Queue<ConsoleColor> TheColorsOfRecursion = new Queue<ConsoleColor>();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();

            Helper.ConsoleMio.PrintHeading("Task 1 Iteration Simulation ");

            TheColorsOfRecursion.Enqueue(ConsoleColor.DarkGreen);
            TheColorsOfRecursion.Enqueue(ConsoleColor.DarkBlue);
            TheColorsOfRecursion.Enqueue(ConsoleColor.DarkRed);
            TheColorsOfRecursion.Enqueue(ConsoleColor.DarkMagenta);

            int n = int.Parse(Helper.ConsoleMio.Write("Enter n: ", ConsoleColor.DarkCyan)
                    .ReadInColor(ConsoleColor.Gray));

            SimulateItreation(1, n, 1, new Queue<int>());
        }

        private static void Nestify(int from, int to, int depth, Queue<int> currentCombo)
        {
            if (depth > to)
            {
                ConsoleColor currentColor = TheColorsOfRecursion.Dequeue();
                TheColorsOfRecursion.Enqueue(currentColor);

                Helper.ConsoleMio
                    .WriteLine(string.Join(" ", currentCombo), currentColor);
                return;
            }

            SimulateItreation(from, to, depth, currentCombo);
        }

        private static void SimulateItreation(int from, int to, int depth, Queue<int> currentCombo)
        {
            if (from > to)
            {
                return;
            }

            currentCombo.Enqueue(from);

            Nestify(from, to, depth + 1, currentCombo);

            currentCombo.Dequeue();

            SimulateItreation(from + 1, to, depth, currentCombo);
        }
    }
}
