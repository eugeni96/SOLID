

using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Commands
{
    public interface ICommand
    {
        void Execute(Update update);
        bool IsAppropriate(Update update);
    }
}
