using CurrencyConvertor.Services;
using CurrencyConvertor.Services.Interfaces;
using Moq;

namespace CurrencyConverterTests;

public class CurrencyConverterTests
{
    private readonly Mock<IExchangeRateProvider> _mockProvider;
    private readonly CurrencyConverter _converter;

    public CurrencyConverterTests()
    {
        _mockProvider = new Mock<IExchangeRateProvider>();
        _converter = new CurrencyConverter(_mockProvider.Object);
    }

    [Fact]
    public void ConvertEurToUsdTest()
    {
        // Arrange
        decimal amount = 100m;
        _mockProvider.Setup(p => p.GetRateToDkk("EUR")).Returns(743.94m);
        _mockProvider.Setup(p => p.GetRateToDkk("USD")).Returns(663.11m);

        // Act
        decimal result = _converter.Convert("EUR/USD", amount);

        // Assert
        decimal expected = amount * 743.94m / 663.11m;

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ConvertEurToDkkTest()
    {
        // Arrange
        _mockProvider.Setup(p => p.GetRateToDkk("EUR")).Returns(743.94m);
        _mockProvider.Setup(p => p.GetRateToDkk("DKK")).Returns(100.00m);

        // Act
        decimal result = _converter.Convert("EUR/DKK", 1m);

        // Assert
        Assert.Equal(7.4394m, result);
    }

    [Fact]
    public void ConvertSameCurrencyReturnsOriginalAmount()
    {
        // Arrange
        _mockProvider.Setup(p => p.GetRateToDkk("USD")).Returns(663.11m);

        // Act
        decimal result = _converter.Convert("USD/USD", 50m);

        // Assert
        Assert.Equal(50m, result);
    }

    [Fact]
    public void ConvertWithWhitespaceTrimsAndSucceeds()
    {
        // Arrange
        _mockProvider.Setup(p => p.GetRateToDkk("EUR")).Returns(743.94m);
        _mockProvider.Setup(p => p.GetRateToDkk("USD")).Returns(663.11m);

        // Act
        var result = _converter.Convert(" EUR / USD ", 100m);

        // Assert
        _mockProvider.Verify(p => p.GetRateToDkk("EUR"), Times.Once);
        _mockProvider.Verify(p => p.GetRateToDkk("USD"), Times.Once);
    }
}