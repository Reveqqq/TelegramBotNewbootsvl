namespace Telegram.Bot.Models;

interface IOrder
{
    int Price { get; }
    Categories Categories { get; }
    string ProductName { get; }
    string Size { get; }
    string Url { get; }

    void UpdatePrice(int newPrice);
}
