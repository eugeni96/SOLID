using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1
{
    public class TemperatureProvider
    {

        public static string ConvertToCelsiusDegree(double temp)
        {
            return temp.ToString("+#;-#") + "°C";
        }
    }
}
