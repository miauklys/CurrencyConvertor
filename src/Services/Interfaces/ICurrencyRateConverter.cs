namespace CurrencyConverter.Services.Interfaces;

public interface ICurrencyRateConverter
{
    decimal Convert(string currencyPair, decimal amount);
}