using CurrencyHandler.Interfaces.IParsers;

namespace CurrencyHandler.Handlers
{
    /// <summary>
    /// Класс который хранит курсы валют в виде словаря и возвращать их при запросе. 
    /// В реальном приложении этот класс можно реализовать по-другому,
    /// например:
    /// получая данные из базы данных, API или например парсит сайт с курсами валют.
    /// </summary>
    public class CurrencyExchangeTranslator : ICurrencyExchangeTranslator
    {
        private Dictionary<Tuple<string, string>, decimal> _exchangeRates = new Dictionary<Tuple<string, string>, decimal>
        {
            { new Tuple<string, string>("USD", "EUR"), 0.92m },
            { new Tuple<string, string>("EUR", "USD"), 1.08m },

            { new Tuple<string, string>("USD", "RUB"), 89.0m },
            { new Tuple<string, string>("RUB", "USD"), 0.011m },

            { new Tuple<string, string>("EUR", "RUB"), 95.0m },
            { new Tuple<string, string>("RUB", "EUR"), 0.010m }
        };

        /// <summary>
        /// Метод для получения курса валют
        /// </summary>
        public decimal GetExchangeRate(string fromCurrency, string toCurrency)
        {
            if (_exchangeRates.TryGetValue(new Tuple<string, string>(fromCurrency, toCurrency), out decimal rate))
            {
                return rate;
            }

            throw new Exception($"Не найден курс для преобразования валюты {fromCurrency} в {toCurrency}");
        }
    }
}