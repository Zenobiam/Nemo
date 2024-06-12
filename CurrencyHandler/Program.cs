using CurrencyHandler.Handlers;
using CurrencyHandler.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var exchangeTranslator = new CurrencyExchangeTranslator();
        var currencyConverter = new CurrencyConverter(exchangeTranslator, "RUB");
        var currencyCalculator = new CurrencyCalculator(currencyConverter);

        var currency1 = new Currency(100, "USD");
        var currency2 = new Currency(50, "EUR");

        var sum = currencyCalculator.Add(currency1, currency2);
        Console.WriteLine($"Sum: {sum.Amount} {sum.Name}");

        var difference = currencyCalculator.Subtract(currency1, currency2);
        Console.WriteLine($"Difference: {difference.Amount} {difference.Name}");
    }
}