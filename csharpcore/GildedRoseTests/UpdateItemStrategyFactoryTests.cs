using FluentAssertions;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class UpdateItemStrategyFactoryTests
{
    [Fact]
    public void Create_CreatesAgedBrieUpdateItemStrategy()
    {
        var strategy = UpdateItemStrategyFactory.Create("Aged Brie");
        strategy.Should().BeOfType<AgedBrieUpdateItemStrategy>();
    }
    
    [Fact]
    public void Create_CreatesBackstagePassesUpdateItemStrategy()
    {
        var strategy = UpdateItemStrategyFactory.Create("Backstage passes to a TAFKAL80ETC concert");
        strategy.Should().BeOfType<BackstagePassesUpdateItemStrategy>();
    }
    
    [Fact]
    public void Create_CreatesSulfurasUpdateItemStrategy()
    {
        var strategy = UpdateItemStrategyFactory.Create("Sulfuras, Hand of Ragnaros");
        strategy.Should().BeOfType<SulfurasUpdateItemStrategy>();
    }
    
    [Fact]
    public void Create_CreatesConjuredUpdateItemStrategy()
    {
        var strategy = UpdateItemStrategyFactory.Create("Conjured Mana Cake");
        strategy.Should().BeOfType<ConjuredUpdateItemStrategy>();
    }
    
    [Fact]
    public void Create_CreatesDefaultUpdateItemStrategy()
    {
        var strategy = UpdateItemStrategyFactory.Create("Some other name");
        strategy.Should().BeOfType<DefaultUpdateItemStrategy>();
    }
}