namespace GildedRoseKata;

internal class BackstagePassesUpdateItemStrategy : IUpdateItemStrategy
{
    public void Update(Item item)
    {
        if (!item.ReachedMaxQuality())
        {
            item.IncreaseQuality();
                
            if (item.SellIn < 11)
            {
                item.IncreaseQualityIfNotMax();
            }

            if (item.SellIn < 6)
            {
                item.IncreaseQualityIfNotMax();
            }
        }

        item.SellIn -= 1;
        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
    }
}