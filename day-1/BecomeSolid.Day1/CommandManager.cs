using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Commands;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1
{
    public class CommandManager
    {

        private Api bot;

        private readonly ConcurrentBag<ICommand> commandDictionary;

        public CommandManager(Api bot, ConcurrentBag<ICommand> commands)
        {
            commandDictionary = commands;
            this.bot = bot;
        }

    }
}
