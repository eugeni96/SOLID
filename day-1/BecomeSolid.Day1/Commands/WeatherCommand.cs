using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using BecomeSolid.Day1.Parsers;
using BecomeSolid.Day1.Services;
using BecomeSolid.Day1.Services.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BecomeSolid.Day1.Commands
{
    public class WeatherCommand : ICommand
    {

        private Api bot;

        private IWeatherService service;

        private IWeatherParser parser;

        public WeatherCommand(Api bot, IWeatherService service, IWeatherParser parser)
        {
            this.bot = bot;
            this.service = service;
            this.parser = parser;
        }

        public async void Execute(Update update)
        {
            var inputMessage = update.Message.Text;
            var messageParts = inputMessage.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var city = messageParts.Length == 1 ? "Minsk" : messageParts.Skip(1).First();
            WebUtility.UrlEncode(city);

            var weather = service.GetWeather(city);

            var message = "In " + weather.Name + " " + weather.Description + " and the temperature is " + TemperatureProvider.ConvertToCelsiusDegree(weather.Temperature);

            var t = await bot.SendTextMessage(update.Message.Chat.Id, message);
            Console.WriteLine("Echo Message: {0}", message);
            
        }

        public bool IsAppropriate(Update update)
        {
            if (update.Message.Type == MessageType.TextMessage)
            {
                var inputMessage = update.Message.Text;
                return inputMessage.StartsWith("/weather");
            }
            return false;
        }
    }
}