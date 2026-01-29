using CurrencyConverter.Services.Interfaces;

namespace CurrencyConverter.Services;

public class CurrencyRateConverter : ICurrencyRateConverter
{
    private readonly IExchangeRateProvider _exchangeRateProvider;

    public CurrencyRateConverter(IExchangeRateProvider exchangeRateProvider)
    {
        _exchangeRateProvider = exchangeRateProvider;
    }

    public decimal Convert(string currencyPair, decimal amount)
    {
        var currencies = currencyPair.Split('/');

        string fromIso = currencies[0].Trim();
        string toIso = currencies[1].Trim();

        decimal fromRate = _exchangeRateProvider.GetRateToDkk(fromIso);
        decimal toRate = _exchangeRateProvider.GetRateToDkk(toIso);

        return (amount * fromRate) / toRate;
    }
}