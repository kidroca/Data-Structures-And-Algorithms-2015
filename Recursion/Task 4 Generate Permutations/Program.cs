namespace PermutationsGeneration
{
    using HomeworkHelpers;
    using ProblemSolvers;

    /// <summary>
    /// Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., 
    /// n for given integer number n.
    /// </summary>
    public class Program
    {
        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();

            Helper.ConsoleMio.PrintHeading("Task 4 Permutations of numbers");

            ResultPrinter printer = new ResultPrinter(Helper.ConsoleMio);

            int[] collection = { 1, 2, 3, 4 };

            int subsetSize = 4;

            CombinatoricsGen<int> combo = new PermutationsGenerator<int>(subsetSize, collection);

            printer.DispalyResults(collection, collection.Length, combo);
        }
    }
}
