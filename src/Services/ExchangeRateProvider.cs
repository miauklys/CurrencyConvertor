using CurrencyConvertor.Dto;
using CurrencyConvertor.Services.Interfaces;

namespace CurrencyConvertor.Services;

public class ExchangeRateProvider : IExchangeRateProvider
{
    private readonly ExchangeConfiguration _exchangeConfiguration;

    public ExchangeRateProvider(ExchangeConfiguration exchangeConfiguration)
    {
        _exchangeConfiguration = exchangeConfiguration;
    }

    public decimal GetRateToDkk(string isoCode)
    {
        if (!_exchangeConfiguration.ExchangeRates.ContainsKey(isoCode))
            throw new ArgumentException($"Currency '{isoCode}' is not supported.");

        return _exchangeConfiguration.ExchangeRates[isoCode];
    }

    public bool CurrencyExists(string isoCode) => _exchangeConfiguration.ExchangeRates.ContainsKey(isoCode);
}