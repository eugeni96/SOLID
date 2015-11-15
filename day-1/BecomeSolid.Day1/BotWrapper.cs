using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BecomeSolid.Day1.Commands;
using Telegram.Bot;

namespace BecomeSolid.Day1
{
    public class BotWrapper
    {
        private readonly Api bot;

        private bool isRun;

        private readonly IList<ICommand> commands;
        
        public BotWrapper(Api bot, IList<ICommand> commands)
        {
            this.commands = commands;
            this.bot = bot;
        }

        public async Task StartBot()
        {
            var offset = 0;
            isRun = true;
            
            while (isRun)
            {
                var updates = await bot.GetUpdates(offset);

                foreach (var update in updates)
                {
                    foreach (var command in commands)
                    {
                        if (command.IsAppropriate(update))
                        {
                            command.Execute(update);
                        }
                    }
                    offset = update.Id + 1;
                }
                
                await Task.Delay(1000);
            }
        }

        public void StopBot()
        {
            isRun = false;
        }


    }
}
