namespace SubsetsofKStrings
{
    using HomeworkHelpers;
    using ProblemSolvers;

    /// <summary>
    /// Write a program for generating and printing all subsets of k strings from given set of strings.
    /// </summary>
    public class Program
    {
        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();

            Helper.ConsoleMio.PrintHeading("Task 6 All Subsets of K Strings");

            var printr = new ResultPrinter(Helper.ConsoleMio);

            string[] collection = { "test", "rock", "fun" };

            int size = 2;

            CombinatoricsGen<string> combo = new CombinatoricsesRegular<string>(size, collection);

            printr.DispalyResults(collection, 2, combo);
        }
    }
}
