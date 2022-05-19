namespace GildedRoseKata;

internal class AgedBrieUpdateItemStrategy : IUpdateItemStrategy
{
    public void Update(Item item)
    {
        if (!item.ReachedMaxQuality())
        {
            item.IncreaseQuality();
        }

        item.SellIn -= 1;
        if (item.SellIn >= 0)
            return;
            
        if (!item.ReachedMaxQuality())
        {
            item.IncreaseQuality();
        }
    }
}