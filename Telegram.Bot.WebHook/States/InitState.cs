using StateMachine;
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
        int price;
        if (!int.TryParse(data.Message, out price))
        {
            return "Введите корректную цену";
        }

        _stateMachine.SetPrice(data.Id, price);
        _stateMachine.SetState(data.Id, new CategoryState(_stateMachine));

        return "Выберите категорию";
    }
}
