
using System;
using System.Collections.Generic;
using VendingMachineKata.Interfaces;

namespace VendingMachineKata
{
    public class VendingMachine
    {
        private decimal _amountInDollars = 0;
        private ICoinIdentifier _coinIdentifier;
        private readonly List<Product> _products;
        private string _displayText;
        
        public VendingMachine(ICoinIdentifier coinIdentifier, System.Collections.Generic.List<Product> products)
        {
            this._coinIdentifier = coinIdentifier;
            this._products = products;
        }

        public string Display 
        {
            get
            {
                return 
                        !string.IsNullOrEmpty(_displayText) ? _displayText :
                        _amountInDollars > 0 ?
                        string.Format("${0:0.00}", _amountInDollars) :
                        "INSERT COIN";
            } 
        }

        

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

        public bool PressButton(int button)
        {
            var product = _products[button];
            if (_amountInDollars >= product.Price)
            {
                _displayText = "THANKYOU";

                return true;
            }

            _displayText = string.Format("PRICE: {0}", _products[button].Price);
            
            return false;
        }
    }
}
