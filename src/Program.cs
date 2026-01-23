using CurrencyConvertor.Dto;
using CurrencyConvertor.Services;
using CurrencyConvertor.Services.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        var config = new ExchangeConfiguration();

        IExchangeRateProvider provider = new ExchangeRateProvider(config);
        CurrencyConverter converter = new CurrencyConverter(provider);

        if (args.Length < 2)
        {
            Console.WriteLine("Usage: FxTool [CurrencyPair] [Amount]");
            Console.WriteLine("Example: FxTool EUR/USD 100");
            return;
        }

        try
        {
            string pair = args[0];
            if (!decimal.TryParse(args[1], out decimal amount))
            {
                Console.WriteLine("Error: Amount must be a valid number.");
                return;
            }

            decimal result = converter.Convert(pair, amount);

            Console.WriteLine($"{result:F4}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}