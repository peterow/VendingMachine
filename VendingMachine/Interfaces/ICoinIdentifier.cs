using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineKata.Interfaces
{
    public interface ICoinIdentifier
    {
        CoinType IdentifyCoin(int weight, int size);
    }
}
