using System;
using System.Globalization;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        private decimal _amountInDollars = 0;
        
        public string Display { get { return _amountInDollars > 0 ? string.Format("${0:0.00}", _amountInDollars) :"INSERT COIN"; } }

        public void InsertCoin(CoinType coinType)
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
