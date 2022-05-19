using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        readonly IList<Item> Items;
        
        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItem(item);
            }
        }

        private void UpdateItem(Item item)
        {
            var updateStrategy = UpdateItemStrategyFactory.Create(item.Name);
            if (updateStrategy is DefaultUpdateItemStrategy or AgedBrieUpdateItemStrategy or BackstagePassesUpdateItemStrategy or SulfurasUpdateItemStrategy)
            {
                updateStrategy.Update(item);
                return;
            }

            if (item.Name != AgedBrie && item.Name != BackstagePasses)
            {
                if (item.HasSomeQuality())
                {
                    if (item.Name != Sulfuras)
                    {
                        item.DecreaseQuality();
                    }
                }
            }
            else
            {
                if (!item.ReachedMaxQuality())
                {
                    item.IncreaseQuality();

                    if (item.Name == BackstagePasses)
                    {
                        if (item.SellIn < 11)
                        {
                            item.IncreaseQualityIfNotMax();
                        }

                        if (item.SellIn < 6)
                        {
                            item.IncreaseQualityIfNotMax();
                        }
                    }
                }
            }

            if (item.Name != Sulfuras)
            {
                item.SellIn -= 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrie)
                {
                    if (item.Name != BackstagePasses)
                    {
                        if (!item.HasSomeQuality())
                            return;
                        
                        if (item.Name != Sulfuras)
                        {
                            item.DecreaseQuality();
                        }
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    item.IncreaseQualityIfNotMax();
                }
            }
        }
    }
}
