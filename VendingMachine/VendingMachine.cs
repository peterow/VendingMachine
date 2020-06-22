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
            _amountInDollars += 0.1M;
        }
    }
}
