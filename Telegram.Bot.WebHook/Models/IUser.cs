using Telegram.Bot.StateMachine;

namespace Telegram.Bot.Models;

interface IUser
{
    string Id { get; }
    IState State { get;}
    IOrder Order { get;}

    void UpdateState(IState newState);
    void UpdateOrder(IOrder newState);
    void UpdatePrice(int newPrice);
}
