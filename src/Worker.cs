using CurrencyConverter.Services.Interfaces;

namespace CurrencyConverter;

public class Worker : BackgroundService
{
    private readonly ICurrencyRateConverter _currencyConverter;

    public Worker(ICurrencyRateConverter currencyConverter)
    {
        _currencyConverter = currencyConverter;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("The Currency Convertor Console application has started working. Press 'CTRL + C' to stop the process.");

        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Enter pair using this pattern: EUR/USD or press 'CTRL + C' to stop.");
            string? pairInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(pairInput))
            {
                Console.WriteLine("Input cannot be empty.");

                continue;
            }

            Console.WriteLine("Enter the amount: ");

            string? amountInput = Console.ReadLine();

            try
            {
                decimal result = _currencyConverter.Convert(pairInput, decimal.Parse(amountInput!));

                Console.WriteLine($"Result: {result:F2}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}.");
            }
        }
 
        return Task.CompletedTask;
    }
}