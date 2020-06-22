using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineKata;

namespace VendingMachineKata.Tests
{
    [TestClass]
    public class VendingMachineTests
    {
        private VendingMachine _testObject;

        [TestInitialize]
        public void SetUp()
        {
            _testObject = new VendingMachine();
        }

        [TestMethod]
        public void NoCoinsInserted_DisplaySays_INSERTCOIN()
        {
            Assert.AreEqual("INSERT COIN", _testObject.Display);
        }

        [TestMethod]
        public void OneDimeInserted_Display_ShowsCorrectAmount()
        {
            _testObject.InsertCoin(CoinType.Dime);
            Assert.AreEqual("$0.10", _testObject.Display);
        }

        [TestMethod]
        public void OneQuarterInserted_Display_ShowsCorrectAmount()
        {
            _testObject.InsertCoin(CoinType.Quarter);
            Assert.AreEqual("$0.25", _testObject.Display);
        }
    }
}
