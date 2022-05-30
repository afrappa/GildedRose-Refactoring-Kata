using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void AtTheEndOfEachDaySellInAndQualityLower()
        {
            var foo = new Item { Name = "foo", SellIn = 5, Quality = 3 };
            var bar = new Item { Name = "bar", SellIn = 12, Quality = 5 };
            
            IList<Item> items = new List<Item>
            {
                foo,
                bar
            };
            
            var app = new GildedRose(items);
            app.UpdateQuality();

            foo.SellIn.Should().Be(4);
            foo.Quality.Should().Be(2);
            
            bar.SellIn.Should().Be(11);
            bar.Quality.Should().Be(4);
        }

        [Fact]
        public void OnceTheSellByDateHasPassedQualityDegradesTwiceAsFast()
        {
            var foo = new Item { Name = "foo", SellIn = 0, Quality = 9 };
            
            IList<Item> items = new List<Item> { foo };
            
            var app = new GildedRose(items);
           
            app.UpdateQuality();
            
            foo.SellIn.Should().Be(-1);
            foo.Quality.Should().Be(7);
        }

        [Fact]
        public void TheQualityOfAnItemIsNeverNegative()
        {
            var foo = new Item { Name = "foo", SellIn = 1, Quality = 0 };
            
            IList<Item> items = new List<Item> { foo };
            
            var app = new GildedRose(items);
            app.UpdateQuality();
            
            foo.Quality.Should().Be(0);
        }

        [Fact]
        public void AgedBrieIncreasesQualityTheOlderItGets()
        {
            var agedBrie = new Item { Name = "Aged Brie", SellIn = 5, Quality = 1 };
            
            IList<Item> items = new List<Item> { agedBrie };
            
            var app = new GildedRose(items);
            app.UpdateQuality();
            
            agedBrie.Quality.Should().Be(2);
        }
        
        [Fact]
        public void TheQualityOfAnItemIsNeverMoreThan50()
        {
            var agedBrie = new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 };
            
            IList<Item> items = new List<Item> { agedBrie };
            
            var app = new GildedRose(items);
            app.UpdateQuality();
            
            agedBrie.Quality.Should().Be(50);
        }

        [Fact]
        public void SulfurasNeverHasToBeSoldOrDecreasesInQuality()
        {
            var sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 };
            
            IList<Item> items = new List<Item> { sulfuras };
            
            var app = new GildedRose(items);
            app.UpdateQuality();
            
            sulfuras.Quality.Should().Be(80);
        }
        
        [Fact]
        public void BackstagePassesIncreasesQualityBy2WhenThereAre10DaysOrLess()
        {
            var backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 };
            
            IList<Item> items = new List<Item> { backstagePasses };
            
            var app = new GildedRose(items);
            app.UpdateQuality();
            
            backstagePasses.Quality.Should().Be(7);
        }
        
        [Fact]
        public void BackstagePassesIncreasesQualityBy3WhenThereAre5DaysOrLess()
        {
            var backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 5 };
            
            IList<Item> items = new List<Item> { backstagePasses };
            
            var app = new GildedRose(items);
            app.UpdateQuality();
            
            backstagePasses.Quality.Should().Be(8);
        }
        
        [Fact]
        public void BackstagePassesQualityDropsTo0AfterTheConcert()
        {
            var backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 5 };
            
            IList<Item> items = new List<Item> { backstagePasses };
            
            var app = new GildedRose(items);
            app.UpdateQuality();
            
            backstagePasses.Quality.Should().Be(0);
        }
        
        [Fact]
        public void ConjuredItemsDegradeInQualityTwiceAsFastAsNormalItems()
        {
            var conjured = new Item { Name = "Conjured Mana Cake", SellIn = 12, Quality = 5 };
            
            IList<Item> items = new List<Item> { conjured };
            
            var app = new GildedRose(items);
            app.UpdateQuality();
            
            conjured.Quality.Should().Be(3);
        }
    }
}
