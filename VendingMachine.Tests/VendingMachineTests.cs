using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using VendingMachineKata;
using VendingMachineKata.Interfaces;

namespace VendingMachineKata.Tests
{
    [TestClass]
    public class VendingMachineTests
    {
        private VendingMachine _testObject;
        private ICoinIdentifier _coinIdentifier;

        [TestInitialize]
        public void SetUp()
        {
            _coinIdentifier = NSubstitute.Substitute.For<ICoinIdentifier>();
            _testObject = new VendingMachine(_coinIdentifier);
            
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

        [TestMethod]
        public void OneNickelInserted_Display_ShowsCorrectAmount()
        {
            _testObject.InsertCoin(CoinType.Nickel);
            Assert.AreEqual("$0.05", _testObject.Display);
        }

        [TestMethod]
        public void UnknownCoinInserted_Display_DoesNOTChange()
        {
            _testObject.InsertCoin(CoinType.Unknown);
            Assert.AreEqual("INSERT COIN", _testObject.Display);
        }


        [TestMethod]
        public void InsertObject_CoinIdentifier_Called()
        {
            int weight = 1;
            int size = 2;
            _testObject.InsertObject(weight, size);

            _coinIdentifier.Received().IdentifyCoin(weight, size);
        }

        [TestMethod]
        public void InsertObject_ReturnValue_SameAsThatSuppliedByCoinIdentifer()
        {
            int weight = 1;
            int size = 2;
            var expectedResult = CoinType.Quarter;
            _coinIdentifier.IdentifyCoin(weight, size).Returns(expectedResult);

            var result = _testObject.InsertObject(weight, size);

            Assert.AreEqual(expectedResult, result);
        }

    }
}
