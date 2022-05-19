namespace GildedRoseKata;

public class UpdateItemStrategyFactory
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";

    public static IUpdateItemStrategy Create(string name)
    {
        return name switch
        {
            AgedBrie => new AgedBrieUpdateItemStrategy(),
            BackstagePasses => new BackstagePassesUpdateItemStrategy(),
            Sulfuras => new SulfurasUpdateItemStrategy(),
            _ => new DefaultUpdateItemStrategy()
        };
    }
}