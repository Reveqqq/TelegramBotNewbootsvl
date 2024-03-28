namespace Telegram.Bot.Models;

class Order : IOrder
{
    private int _price;
    private string _productName;
    private Categories _categories;
    private string _size;
    private string _url;
    

    public int Price => _price;

    public Categories Categories => _categories;

    public string ProductName => _productName;

    public string Size => _size;

    public string Url => _url;

    public void UpdatePrice(int newPrice)
    {
        _price = newPrice;
    }
}
