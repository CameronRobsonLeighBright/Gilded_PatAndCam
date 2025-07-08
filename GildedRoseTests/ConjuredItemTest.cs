using GildedRoseKata;

namespace GildedRoseTests;

public class ConjuredItemTest
{
    [Fact]
    public void Conjured_Item_Quality_Decreases_Double_Before_SellIn()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 };
        var app = new GildedRose([item]);
        
        app.UpdateQuality();

        Assert.Equal("Conjured Mana Cake", item.Name);
        Assert.Equal(9, item.SellIn);
        Assert.Equal(8, item.Quality);
    }
    
    [Fact]
    public void Conjured_Item_Quality_Decreases_4x_After_SellIn()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 };
        var app = new GildedRose([item]);
        
        app.UpdateQuality();

        Assert.Equal("Conjured Mana Cake", item.Name);
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(6, item.Quality);
    }
    
    [Fact]
    public void Conjured_Item_Quality_Does_Not_Decrease_Below_0()
    {
        var item = new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 0 };
        var app = new GildedRose([item]);
        
        app.UpdateQuality();

        Assert.Equal("Conjured Mana Cake", item.Name);
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(0, item.Quality);
    }
}