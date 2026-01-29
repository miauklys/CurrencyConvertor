using CurrencyConverter;
using CurrencyConverter.Dto;
using CurrencyConverter.Services;
using CurrencyConverter.Services.Interfaces;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ExchangeConfiguration>();
builder.Services.AddSingleton<IExchangeRateProvider, ExchangeRateProvider>();
builder.Services.AddSingleton<ICurrencyRateConverter, CurrencyRateConverter>();
builder.Services.AddHostedService<Worker>();

builder.Logging.ClearProviders();

var host = builder.Build();

await host.RunAsync();