namespace GildedRoseKata;

public class UpdateItemStrategyFactory
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private const string Conjured = "Conjured";

    public static IUpdateItemStrategy Create(string name)
    {
        return name switch
        {
            AgedBrie => new AgedBrieUpdateItemStrategy(),
            BackstagePasses => new BackstagePassesUpdateItemStrategy(),
            Sulfuras => new SulfurasUpdateItemStrategy(),
            Conjured => new ConjuredUpdateItemStrategy(),
            _ => new DefaultUpdateItemStrategy()
        };
    }
}