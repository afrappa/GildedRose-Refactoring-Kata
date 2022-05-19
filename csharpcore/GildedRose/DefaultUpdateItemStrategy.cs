namespace GildedRoseKata;

internal class DefaultUpdateItemStrategy : IUpdateItemStrategy
{
    public void Update(Item item)
    {
        item.DecreaseQualityIfItHasSome();

        item.SellIn -= 1;
        if (item.SellIn < 0)
        {
            item.DecreaseQualityIfItHasSome();
        }
    }
}