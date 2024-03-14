namespace Telegram.Bot.StateMachine;

public interface IState
{
    Task<MessageEventResult> Update(MessageEvent data);
}
