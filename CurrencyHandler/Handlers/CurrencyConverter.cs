using CurrencyHandler.Interfaces.IHandlers;
using CurrencyHandler.Interfaces.IParsers;
using CurrencyHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyHandler.Handlers
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private readonly ICurrencyExchangeTranslator _exchangeTranslator;
        private readonly string _crossCurrency;

        public CurrencyConverter(ICurrencyExchangeTranslator exchangeTranslator, string crossCurrency)
        {
            _exchangeTranslator = exchangeTranslator;
            _crossCurrency = crossCurrency;
        }

        /// <summary>
        /// Конвертирует валюту currency в валюту targetCurrency
        /// </summary>
        public Currency Convert(Currency currency, string targetCurrency)
        {
            if (currency.Name == targetCurrency)
            {
                return currency;
            }

            try
            {
                var directRate = _exchangeTranslator.GetExchangeRate(currency.Name, targetCurrency);
                var convertedAmount = currency.Amount * directRate;
                return new Currency(convertedAmount, targetCurrency);
            }
            catch (Exception)
            {
                var rateThroughCrossCurrency = ConvertThroughCrossCurrency(currency, targetCurrency);
                return rateThroughCrossCurrency;
            }
        }

        /// <summary>
        /// Конвертирует валюту currency в валюту targetCurrency, через кросс валюту
        /// </summary>
        private Currency ConvertThroughCrossCurrency(Currency currency, string targetCurrency)
        {
            var rate1 = _exchangeTranslator.GetExchangeRate(currency.Name, _crossCurrency);
            var rate2 = _exchangeTranslator.GetExchangeRate(_crossCurrency, targetCurrency);

            var convertedAmount = currency.Amount * rate1 * rate2;
            return new Currency(convertedAmount, targetCurrency);
        }
    }
}
