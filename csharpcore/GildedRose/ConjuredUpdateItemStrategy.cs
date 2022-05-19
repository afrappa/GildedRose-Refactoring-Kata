namespace GildedRoseKata;

public class ConjuredUpdateItemStrategy : IUpdateItemStrategy
{
    public void Update(Item item)
    {
        item.DecreaseQualityByIfItHasSome(2);

        item.SellIn -= 1;
        if (item.SellIn < 0)
        {
            item.DecreaseQualityByIfItHasSome(2);
        }
    }
}