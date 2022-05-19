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
                UpdateItemQuality(item);
            }
        }

        private void UpdateItemQuality(Item item)
        {
            if (item.Name != AgedBrie && item.Name != BackstagePasses)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != Sulfuras)
                    {
                        item.Quality -= 1;
                    }
                }
            }
            else
            {
                if (!ReachedMaxQuality(item))
                {
                    IncreaseQuality(item);

                    if (item.Name == BackstagePasses)
                    {
                        if (item.SellIn < 11)
                        {
                            IncreaseQualityIfNotMax(item);
                        }

                        if (item.SellIn < 6)
                        {
                            IncreaseQualityIfNotMax(item);
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
                        if (item.Quality > 0)
                        {
                            if (item.Name != Sulfuras)
                            {
                                DecreaseQuality(item);
                            }
                        }
                    }
                    else
                    {
                        item.Quality = 0;
                    }
                }
                else
                {
                    IncreaseQualityIfNotMax(item);
                }
            }
        }

        private static void IncreaseQualityIfNotMax(Item item)
        {
            if (!ReachedMaxQuality(item))
            {
                IncreaseQuality(item);
            }
        }

        private static void IncreaseQuality(Item item)
        {
            item.Quality += 1;
        }
        
        private static void DecreaseQuality(Item item)
        {
            item.Quality -= 1;
        }

        private static bool ReachedMaxQuality(Item item)
        {
            return item.Quality >= 50;
        }
    }
}
