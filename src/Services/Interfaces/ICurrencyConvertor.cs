namespace CurrencyConvertor.Services.Interfaces;

public interface ICurrencyConvertor
{
    decimal Convert(string currencyPair, decimal amount);
}
