using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.JsonSchemas.Weather;
using BecomeSolid.Day1.Services.Interfaces;
using Newtonsoft.Json;

namespace BecomeSolid.Day1.Services
{
    public class WeatherService : IWeatherService
    {
        private string url = "http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric";

        private string weatherApiKey = "ec259b32688dc1c1d087ebc30cbff9ed";

        public Weather GetWeather(string city)
        {
            string urlApi = string.Format(url, city, weatherApiKey);
            WebRequest request = WebRequest.Create(urlApi);
            WebResponse response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string responseString = streamReader.ReadToEnd();
                var weatherResponce = JsonConvert.DeserializeObject<Forecast>(responseString);
                return new Weather()
                {
                    Name = weatherResponce.name,
                    Description = weatherResponce.weather.First().description,
                    Temperature = weatherResponce.main.temp
                };
            }
        }

    }
}
