using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
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
            updateStrategy.Update(item);
        }
    }
}
