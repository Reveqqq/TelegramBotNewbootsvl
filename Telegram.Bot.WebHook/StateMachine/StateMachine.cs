namespace Telegram.Bot.StateMachine;

public class StateMachine : IStateMachine
{
    private readonly Dictionary<string, IState> _stateStorage;
    private readonly Func<IState> _initStateFactory;

    public StateMachine(Func<IState> initStateFactory)
    {
        _stateStorage = new Dictionary<string, IState>();
        _initStateFactory = initStateFactory;
    }

    public void SetState(string id, IState state)
    {
        _stateStorage[id] = state;
    }

    public int GetPrice(string id)
    {
        return 123;
    }

    public async Task<MessageEventResult> FireEvent(MessageEvent data)
    {
        // если есть состояни по ключу
        if (_stateStorage.TryGetValue(data.Id, out var currentState))
        {
            return await currentState.Update(data);
        }

        // если нету, то создаем и обновляем
        var state = _initStateFactory();
        SetState(data.Id, state);
        return await state.Update(data);
    }
}
