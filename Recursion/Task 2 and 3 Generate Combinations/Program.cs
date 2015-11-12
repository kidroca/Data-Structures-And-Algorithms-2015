namespace CombinationGeneration
{
    using HomeworkHelpers;
    using ProblemSolvers;

    /// <summary>
    /// Task 2: Write a recursive program for generating and printing all the combinations with duplicates
    /// of k elements from n-element
    /// 
    /// Tas 3 Modify the previous program to skip duplicates
    /// </summary>
    public class Program
    {
        private static readonly HomeworkHelper Helper = new HomeworkHelper();

        private static void Main()
        {
            Helper.ConsoleMio.Setup();
            Helper.ConsoleMio.PrintHeading("Task 2 Generate All Combinations With Duplicates");

            int[] collection = { 1, 2, 3, 4, 5 };
            int combinationSetsLength = 2;
            CombinatoricsGen<int> combo =
                new CombinatoricsesWithDuplicates<int>(combinationSetsLength, collection);

            var resultPrinter = new ResultPrinter(Helper.ConsoleMio);

            resultPrinter.DispalyResults(collection, combinationSetsLength, combo);

            Helper.ConsoleMio.PrintHeading("Task 3 Generate All Regular Combinations");

            combo = new CombinatoricsesRegular<int>(combinationSetsLength, collection);

            resultPrinter.DispalyResults(collection, combinationSetsLength, combo);
        }
    }
}
