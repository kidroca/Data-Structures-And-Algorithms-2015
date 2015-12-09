namespace SortingHomework.Tests.Sorting
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QuickSorterTests : SortingsTestsBase<double>
    {
        [TestInitialize]
        public override void TestInitialization()
        {
            base.collection = new[] { 21312.12, -223, 1214, 23423.4, 123, 0, 100 };
            base.sorty = new Quicksorter<double>();
        }
    }
}