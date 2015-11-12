namespace ProblemSolvers
{
    using System;
    using System.Collections.Generic;

    using HomeworkHelpers.ConsoleEnchantments;

    public class ResultPrinter
    {
        private readonly IConsoleWriter consoleMio;

        public ResultPrinter(IConsoleWriter writer)
        {
            this.consoleMio = writer;
        }

        public void DispalyResults<T>(T[] collection, int combinationSetsLength, CombinatoricsGen<T> combo)
        {
            this.consoleMio.Write("Working with: ", ConsoleColor.DarkMagenta)
                .WriteLine("{0};", ConsoleColor.DarkGreen, string.Join(" ", collection))
                .WriteLine("And variations between {0} elements", ConsoleColor.DarkMagenta, combinationSetsLength);

            IList<IList<T>> items = combo.Result;

            foreach (var list in items)
            {
                this.consoleMio.Write($"({string.Join(" ", list)}), ", ConsoleColor.DarkBlue);
            }

            Console.WriteLine("\n");
        }
    }
}