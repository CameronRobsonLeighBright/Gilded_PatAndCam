namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                int qualityChange = item.Name.Contains("Conjured") ? 2 : 1;

                switch (item.Name)
                {
                    case string name when name.Contains("Aged Brie"):
                        UpdateAgedBrie(item, qualityChange);
                        break;

                    case string name when name.Contains("Backstage passes"):
                        UpdateBackstagePass(item, qualityChange);
                        break;

                    case string name when name.Contains("Sulfuras"):
                        // Legendary item, no changes
                        break;

                    default:
                        UpdateNormalItem(item, qualityChange);
                        break;
                }
            }
        }

        private void UpdateAgedBrie(Item item, int qualityChange)
        {
            if (item.Quality < 50)
                item.Quality += qualityChange;

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality < 50)
                item.Quality += qualityChange;
        }

        private void UpdateBackstagePass(Item item, int qualityChange)
        {
            if (item.Quality < 50)
                item.Quality += qualityChange;

            if (item.SellIn < 11 && item.Quality < 50)
                item.Quality += qualityChange;

            if (item.SellIn < 6 && item.Quality < 50)
                item.Quality += qualityChange;

            item.SellIn--;

            if (item.SellIn < 0)
                item.Quality = 0;
        }

        private void UpdateNormalItem(Item item, int qualityChange)
        {
            if (item.Quality > 0)
                item.Quality -= qualityChange;

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality > 0)
                item.Quality -= qualityChange;
        }
    }
}
