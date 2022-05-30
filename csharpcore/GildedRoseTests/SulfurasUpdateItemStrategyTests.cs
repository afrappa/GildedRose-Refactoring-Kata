using FluentAssertions;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class SulfurasUpdateItemStrategyTests
{
    [Fact]
    public void SulfurasNeverHasToBeSoldOrDecreasesInQuality()
    {
        var sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            
        var strategy = new SulfurasUpdateItemStrategy();
        strategy.Update(sulfuras);
            
        sulfuras.Quality.Should().Be(80);
    }
}