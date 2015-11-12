namespace OrderedSubsets
{
    using HomeworkHelpers;
    using ProblemSolvers;

    /// <summary>
    /// Write a recursive program for generating and printing all ordered k-element subsets from 
    /// n-element set (variations Vkn).
    /// </summary>
    public class Program
    {
        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();

            Helper.ConsoleMio.PrintHeading("Task 5 Print Ordered Subsets of K from Set of N");

            string[] mainSet = { "hi", "a", "b" };

            int subsetLength = 2;

            var printer = new ResultPrinter(Helper.ConsoleMio);

            CombinatoricsGen<string> combo = new PermutationsWithRepetition<string>(subsetLength, mainSet);

            printer.DispalyResults(mainSet, subsetLength, combo);
        }
    }
}
