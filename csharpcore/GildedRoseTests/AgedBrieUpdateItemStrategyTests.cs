using FluentAssertions;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class AgedBrieUpdateItemStrategyTests
{
    [Fact]
    public void AgedBrieIncreasesQualityTheOlderItGets()
    {
        var agedBrie = new Item { Name = "Aged Brie", SellIn = 5, Quality = 1 };
        
        var strategy = new AgedBrieUpdateItemStrategy();
        strategy.Update(agedBrie);
            
        agedBrie.Quality.Should().Be(2);
    }
    
    [Fact]
    public void TheQualityOfAnItemIsNeverMoreThan50()
    {
        var agedBrie = new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 };
            
        var strategy = new AgedBrieUpdateItemStrategy();
        strategy.Update(agedBrie);
            
        agedBrie.Quality.Should().Be(50);
    }
}