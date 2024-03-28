namespace Telegram.Bot.StateMachine;
using Telegram.Bot.Models;

public class StateMachine : IStateMachine
{
    private readonly Dictionary<string, IUser> _stateStorage;
    private readonly Func<IState> _initStateFactory;

    public StateMachine(Func<IState> initStateFactory)
    {
        _stateStorage = new Dictionary<string, IUser>();
        _initStateFactory = initStateFactory;
    }

    public void SetState(string id, IState state)
    {
        _stateStorage[id].UpdateState(state); //change user state
    }

    public void CreateUser(string id)
    {
        var user = new User(id);
        _stateStorage.Add(id, user);
    }

    public int GetPrice(string id)
    {
        return _stateStorage[id].Order.Price;
    }

    public void SetPrice(string id, int price)
    {
        _stateStorage[id].UpdatePrice(price);
    }

    public async Task<MessageEventResult> FireEvent(MessageEvent data)
    {
        // если есть состояни по ключу
        if (_stateStorage.TryGetValue(data.Id, out var currentUser))
        {
            return await currentUser.State.Update(data);
        }

        // если нету, то создаем и обновляем
        CreateUser(data.Id);
        var state = _initStateFactory();
        SetState(data.Id, state);
        return await state.Update(data);
    }
}
