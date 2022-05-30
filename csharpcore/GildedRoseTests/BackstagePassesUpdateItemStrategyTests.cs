using FluentAssertions;
using GildedRoseKata;
using Xunit;

namespace GildedRoseTests;

public class BackstagePassesUpdateItemStrategyTests
{
    [Fact]
    public void BackstagePassesIncreasesQualityBy2WhenThereAre10DaysOrLess()
    {
        var backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 };
            
        var strategy = new BackstagePassesUpdateItemStrategy();
        strategy.Update(backstagePasses);
            
        backstagePasses.Quality.Should().Be(7);
    }
        
    [Fact]
    public void BackstagePassesIncreasesQualityBy3WhenThereAre5DaysOrLess()
    {
        var backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 };
            
        var strategy = new BackstagePassesUpdateItemStrategy();
        strategy.Update(backstagePasses);
            
        backstagePasses.Quality.Should().Be(8);
    }
        
    [Fact]
    public void BackstagePassesQualityDropsTo0AfterTheConcert()
    {
        var backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 };
            
        var strategy = new BackstagePassesUpdateItemStrategy();
        strategy.Update(backstagePasses);
            
        backstagePasses.Quality.Should().Be(0);
    }
}