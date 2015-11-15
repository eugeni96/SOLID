using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1.Services.Interfaces
{
    public interface IWeatherService
    {
        Weather GetWeather(string city);
    }
}
