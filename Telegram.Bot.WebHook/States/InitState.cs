using Telegram.Bot.StateMachine;

namespace Telegram.Bot.States;

class InitState : IState
{
    private readonly IStateMachine _stateMachine;

    public InitState(IStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public async Task<MessageEventResult> Update(MessageEvent data)
    {
        //TODO: парсер на цену
        if (data.Message != "123")
            return "введите цену";

        _stateMachine.SetState(data.Id, new CategoryState(_stateMachine));

        return "Выберите категорию";
    }
}
