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
        
        public VendingMachine(ICoinIdentifier coinIdentifier, List<Product> products)
        {
            _coinIdentifier = coinIdentifier;
            _products = products;
        }

        public string Display 
        {
            get
            {
                if (!string.IsNullOrEmpty(_displayText))
                {
                    string result = _displayText;
                    _displayText = null;
                    return result;
                }
                else if (_amountInDollars > 0)
                {
                    return string.Format("${0:0.00}", _amountInDollars);
                }
                else
                {
                    return "INSERT COIN";
                }
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
                _amountInDollars -= product.Price;

                _displayText = "THANKYOU";

                return true;
            }

            _displayText = string.Format("PRICE: {0}", _products[button].Price);
            
            return false;
        }
    }
}
