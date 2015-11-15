using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.JsonSchemas;
using BecomeSolid.Day1.JsonSchemas.Weather;
using BecomeSolid.Day1.Services.Interfaces;
using Newtonsoft.Json;

namespace BecomeSolid.Day1.Services
{
    public class CurrencyService : ICurrencyService
    {

        private string url = "https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22{0}%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";

        public CurrencyExchange GetCurrencyExchange(List<string> courses)
        {
            CurrencyExchange currencyExchange = new CurrencyExchange();
            string delimiter = "";
            StringBuilder sb = new StringBuilder();
            foreach (var course in courses)
            {
                sb.Append(delimiter);
                sb.Append(course);
                sb.Append("BYR");
                delimiter = ",";
            }

            string urlApi = string.Format(url, sb);
            WebRequest request = WebRequest.Create(urlApi);
            WebResponse response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string responseString = streamReader.ReadToEnd();
                var currencyResponse = JsonConvert.DeserializeObject<CurrencyResponse>(responseString);
                var rate = currencyResponse.query.results.rate;
                currencyExchange.AddCrossCourse(rate.id, rate.rate);
                return currencyExchange;
            }
        }
    }
}
