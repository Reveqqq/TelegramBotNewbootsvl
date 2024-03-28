using Telegram.Bot.StateMachine;

namespace Telegram.Bot.Models;

class User : IUser
{
    private string _id;
    private IState _state;
    private IOrder _order;

    public User(string id)
    {
        _id = id;
        _order = new Order();
    }

    public string Id => _id;
    public IState State => _state;
    public IOrder Order => _order;

    public void UpdateOrder(IOrder newOrder)
    {
        _order = newOrder;
    }

    public void UpdatePrice(int newPrice)
    {
        _order.UpdatePrice(newPrice);
    }

    public void UpdateState(IState newState)
    {
        _state = newState;
    }
}
