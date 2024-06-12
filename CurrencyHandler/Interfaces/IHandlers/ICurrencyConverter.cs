using CurrencyHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyHandler.Interfaces.IHandlers
{
    /// <summary>
    /// Интерфейс для конвертации суммы из одной валюты в другую
    /// </summary>
    public interface ICurrencyConverter
    {
        /// <summary>
        /// Конвертирует сумму из одной валюты {currency} в другую {targetCurrency} TODO норм комментарий
        /// </summary>
        Currency Convert(Currency currency, string targetCurrency);
    }
}
