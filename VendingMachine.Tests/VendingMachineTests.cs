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
        private int _weight = 1;
        private int _size = 2;

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
            _coinIdentifier.IdentifyCoin(_weight, _size).Returns(CoinType.Dime);

            _testObject.InsertObject(_weight, _size);

            Assert.AreEqual("$0.10", _testObject.Display);
        }

        [TestMethod]
        public void OneQuarterInserted_Display_ShowsCorrectAmount()
        {
            _coinIdentifier.IdentifyCoin(_weight, _size).Returns(CoinType.Quarter);

            _testObject.InsertObject(_weight, _size);

            Assert.AreEqual("$0.25", _testObject.Display);
        }

        [TestMethod]
        public void OneNickelInserted_Display_ShowsCorrectAmount()
        {
            _coinIdentifier.IdentifyCoin(_weight, _size).Returns(CoinType.Nickel);

            _testObject.InsertObject(_weight, _size);

            Assert.AreEqual("$0.05", _testObject.Display);
        }

        [TestMethod]
        public void UnknownCoinInserted_Display_DoesNOTChange()
        {
            _coinIdentifier.IdentifyCoin(_weight, _size).Returns(CoinType.Unknown);

            _testObject.InsertObject(_weight, _size);

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
