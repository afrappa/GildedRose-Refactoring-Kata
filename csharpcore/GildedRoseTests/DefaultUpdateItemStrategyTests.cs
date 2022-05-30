using FluentAssertions;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class DefaultUpdateItemStrategyTests
{
    [Fact]
    public void AtTheEndOfEachDaySellInAndQualityLower()
    {
        var foo = new Item { Name = "foo", SellIn = 5, Quality = 3 };
            
        var strategy = new DefaultUpdateItemStrategy();
        strategy.Update(foo);

        foo.SellIn.Should().Be(4);
        foo.Quality.Should().Be(2);
    }
    
    [Fact]
    public void OnceTheSellByDateHasPassedQualityDegradesTwiceAsFast()
    {
        var foo = new Item { Name = "foo", SellIn = 0, Quality = 9 };
            
        var strategy = new DefaultUpdateItemStrategy();
        strategy.Update(foo);
            
        foo.SellIn.Should().Be(-1);
        foo.Quality.Should().Be(7);
    }

    [Fact]
    public void TheQualityOfAnItemIsNeverNegative()
    {
        var foo = new Item { Name = "foo", SellIn = 1, Quality = 0 };
            
        var strategy = new DefaultUpdateItemStrategy();
        strategy.Update(foo);
            
        foo.Quality.Should().Be(0);
    }
    
        
   
}