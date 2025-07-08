using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class BackstageTests
    {
        [Fact]
        public void Backstage_IncreasesBy_1_When_Sellin_Above_10()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            var app = new GildedRose([item]);

            app.UpdateQuality();

            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", item.Name);
            Assert.Equal(14, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void Backstage_IncreasesBy_2_When_Sellin_10_Or_Less()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 25 };
            var app = new GildedRose([item]);

            app.UpdateQuality();

            Assert.Equal(9, item.SellIn);
            Assert.Equal(27, item.Quality);
        }

        [Fact]
        public void Backstage_IncreasesBy_3_When_Sellin_5_Or_Less()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30 };
            var app = new GildedRose([item]);

            app.UpdateQuality();

            Assert.Equal(4, item.SellIn);
            Assert.Equal(33, item.Quality);
        }

        [Fact]
        public void Backstage_Quality_DropsTo_0_After_Concert()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 40 };
            var app = new GildedRose([item]);

            app.UpdateQuality();

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void Backstage_Quality_Does_Not_Exceed_50()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 };
            var app = new GildedRose([item]);

            app.UpdateQuality();

            Assert.Equal(4, item.SellIn);
            Assert.Equal(50, item.Quality); // Should cap at 50
        }

    }
}
