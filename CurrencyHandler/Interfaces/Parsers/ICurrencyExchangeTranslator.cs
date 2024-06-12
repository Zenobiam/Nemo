using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyHandler.Interfaces.IParsers
{
    public interface ICurrencyExchangeTranslator
    {        
        decimal GetExchangeRate(string fromCurrency, string toCurrency);
    }
}
