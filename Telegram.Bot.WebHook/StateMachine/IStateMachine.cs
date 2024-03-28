namespace Telegram.Bot.StateMachine;

public interface IStateMachine
{
    Task<MessageEventResult> FireEvent(MessageEvent data);
    void SetState(string id, IState state);

    public void CreateUser(string id);

    int GetPrice(string id);

    void SetPrice(string id, int price);
}
