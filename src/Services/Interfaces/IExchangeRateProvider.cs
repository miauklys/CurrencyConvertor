namespace CurrencyConverter.Services.Interfaces;

public interface IExchangeRateProvider
{
    decimal GetRateToDkk(string isoCode);
}