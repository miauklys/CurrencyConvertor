namespace CurrencyConverter.Dto;

public class ExchangeConfiguration
{
    public Dictionary<string, decimal> ExchangeRates { get; set; }

    public ExchangeConfiguration()
    {
        ExchangeRates = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
        {
            { "EUR", 7.4394m },
            { "USD", 6.6311m },
            { "GBP", 8.5285m },
            { "SEK", 0.7610m },
            { "NOK", 0.7840m },
            { "CHF", 6.8358m },
            { "JPY", 0.05974m },
            { "DKK", 1.0000m }
        };
    }
}