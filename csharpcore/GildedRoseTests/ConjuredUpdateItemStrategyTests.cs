using FluentAssertions;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class ConjuredUpdateItemStrategyTests
{
    [Fact]
    public void ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems()
    {
        var conjured = new Item { Name = "Conjured Mana Cake", SellIn = 12, Quality = 5 };
            
        var strategy = new ConjuredUpdateItemStrategy();
        strategy.Update(conjured);
            
        conjured.Quality.Should().Be(3);
    }
}