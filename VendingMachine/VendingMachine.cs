
using System;
using VendingMachineKata.Interfaces;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        private decimal _amountInDollars = 0;
        private ICoinIdentifier _coinIdentifier;

        public VendingMachine(ICoinIdentifier coinIdentifier)
        {
            this._coinIdentifier = coinIdentifier;
        }

        public string Display { get { return _amountInDollars > 0 ? string.Format("${0:0.00}", _amountInDollars) :"INSERT COIN"; } }

        

        public CoinType InsertObject(int weight, int size)
        {
            var coinType = _coinIdentifier.IdentifyCoin(weight, size);

            if (coinType != CoinType.Unknown)
            {
                InsertCoin(coinType);
            }

            return coinType;
        }

        private void InsertCoin(CoinType coinType)
        {
            if (coinType == CoinType.Dime)
            {
                _amountInDollars += 0.1M;
            }
            else if (coinType == CoinType.Quarter)
            {
                _amountInDollars += 0.25M;
            }
            else if (coinType == CoinType.Nickel)
            {
                _amountInDollars += 0.05M;
            }

        }
    }
}
