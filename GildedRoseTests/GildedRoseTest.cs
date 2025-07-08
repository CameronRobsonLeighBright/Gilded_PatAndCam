using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void Aged_Brie_Quality_Increments_On_SellIn()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 };
        var app = new GildedRose([item]);
        
        app.UpdateQuality();

        Assert.Equal("Aged Brie", item.Name);
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(2, item.Quality);
    }
    
    [Fact]
    public void Aged_Brie_Quality_Increments_Before_SellIn()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 };
        var app = new GildedRose([item]);
        
        app.UpdateQuality();

        Assert.Equal("Aged Brie", item.Name);
        Assert.Equal(9, item.SellIn);
        Assert.Equal(1, item.Quality);
    }

    [Fact]
    public void Aged_Brie_Quality_Double_Increments_After_SellIn()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 };
        var app = new GildedRose([item]);
        for (var i = 1; i <= 10; i++)
        {
            app.UpdateQuality();
        }

        Assert.Equal("Aged Brie", item.Name);
        Assert.Equal(-10, item.SellIn);
        Assert.Equal(20, item.Quality);
    }

    [Fact]
    public void Aged_Brie_Quality_Cannot_Go_Past_Fifty()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 };
        var app = new GildedRose([item]);
        for (var i = 1; i <= 31; i++)
        {
            app.UpdateQuality();
        }

        Assert.Equal("Aged Brie", item.Name);
        Assert.Equal(-31, item.SellIn);
        Assert.Equal(50, item.Quality);
    }
}