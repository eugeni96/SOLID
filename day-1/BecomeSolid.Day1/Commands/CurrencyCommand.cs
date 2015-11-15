using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Services.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Commands
{
    public class CurrencyCommand : ICommand
    {

        private const string CurrencyQueryUrl = @"https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22{0}%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";

        private readonly List<string> defaultCurrenciesList = new List<string> { "USD", "EUR", "RUB" };

        private Api bot;

        private ICurrencyService currencyService;

        public CurrencyCommand(Api bot, ICurrencyService currencyService)
        {
            this.bot = bot;
            this.currencyService = currencyService;
        }


        public async void Execute(Update update)
        {
            var inputMessage = update.Message.Text;
            string[] messageParts = inputMessage.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> currencyList;
            if (messageParts.Length == 1)
            {
                currencyList = defaultCurrenciesList;
            }
            else currencyList = messageParts.Skip(1).First().Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();

            CurrencyExchange currencyExchange = currencyService.GetCurrencyExchange(currencyList);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Currency today: ");
            foreach (var curPair in currencyExchange.CrossCourseDictionary)
            {
                stringBuilder.Append(curPair.Key);
                stringBuilder.Append(": ");
                stringBuilder.Append(curPair.Value);
            }

            var t = await bot.SendTextMessage(update.Message.Chat.Id, stringBuilder.ToString());

        }

        public bool IsAppropriate(Update update)
        {
            if (update.Message.Type == MessageType.TextMessage)
            {
                var inputMessage = update.Message.Text;
                return inputMessage.StartsWith("/rate");
            }
            return false;
        }
    }
}
