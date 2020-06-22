using System;
using System.Globalization;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        private decimal _amountInDollars = 0;
        
        public string Display { get { return _amountInDollars > 0 ? string.Format("${0:0.00}", _amountInDollars) :"INSERT COIN"; } }


        private decimal _returnAmount;

        public decimal ReturnAmount
        {
            get { return _returnAmount; }
        }


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
            else if (coinType == CoinType.Penny)
            {
                _returnAmount += 0.01M;
            }
        }
    }
}
