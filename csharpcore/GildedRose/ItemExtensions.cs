namespace GildedRoseKata;

public static class ItemExtensions
{
    public static bool HasSomeQuality(this Item item) => item.Quality > 0;

    public static void IncreaseQuality(this Item item) => item.Quality += 1;

    public static void DecreaseQualityBy(this Item item, int toDecrease = 1) => item.Quality -= toDecrease;

    public static bool ReachedMaxQuality(this Item item) => item.Quality >= 50;
    
    public static void IncreaseQualityIfNotMax(this Item item)
    {
        if (!item.ReachedMaxQuality())
        {
            item.IncreaseQuality();
        }
    }
    
    public static void DecreaseQualityByIfItHasSome(this Item item, int toDecrease = 1)
    {
        if (item.HasSomeQuality())
        {
            item.DecreaseQualityBy(toDecrease);
        }
    }
}