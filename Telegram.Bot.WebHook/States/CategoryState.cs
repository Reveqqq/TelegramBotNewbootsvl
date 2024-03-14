using Telegram.Bot.StateMachine;
using Telegram.Bot.States;

public class CategoryState : IState
{
    private readonly IStateMachine _stateMachine;

    public CategoryState(IStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public async Task<MessageEventResult> Update(MessageEvent data)
    {
        if (data.Message != "категория1")
            return "нет такой категории";

        _stateMachine.SetState(data.Id, new InitState(_stateMachine));
        return "Категория выбрана, стоимость:" + _stateMachine.GetPrice(data.Id);
    }
}
