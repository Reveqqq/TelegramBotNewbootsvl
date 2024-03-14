namespace Telegram.Bot.StateMachine;

public interface IStateMachine
{
    Task<MessageEventResult> FireEvent(MessageEvent data);
    void SetState(string id, IState state);

    int GetPrice(string id);
}
