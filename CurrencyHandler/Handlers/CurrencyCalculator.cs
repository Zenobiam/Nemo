using CurrencyHandler.Interfaces.IHandlers;
using CurrencyHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyHandler.Handlers
{
    /// <summary>
    /// Выполненяет операции с деньгами - сложения и вычитания с поддержкой конвертации валют
    /// </summary>
    public class CurrencyCalculator
    {
        private readonly ICurrencyConverter _currencyConverter;

        public CurrencyCalculator(ICurrencyConverter currencyConverter)
        {
            _currencyConverter = currencyConverter;
        }

        public Currency Add(Currency currency1, Currency currency2)
        {
            var convertedCurrency = _currencyConverter.Convert(currency1, currency2.Name);
            return new Currency(convertedCurrency.Amount + currency2.Amount, currency2.Name);
        }

        public Currency Subtract(Currency currency1, Currency currency2)
        {
            var convertedCurrency = _currencyConverter.Convert(currency1, currency2.Name);
            return new Currency(convertedCurrency.Amount - currency2.Amount, currency2.Name);
        }
    }
}
