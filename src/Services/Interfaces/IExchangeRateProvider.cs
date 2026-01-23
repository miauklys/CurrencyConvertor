namespace CurrencyConvertor.Services.Interfaces;

public interface IExchangeRateProvider
{
    decimal GetRateToDkk(string isoCode);

    bool CurrencyExists(string isoCode);
}
