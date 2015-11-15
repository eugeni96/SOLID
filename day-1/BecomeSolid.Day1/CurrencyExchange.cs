using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1
{
    public class CurrencyExchange
    {
        // key: course name e.g. USDBYR
        // value: crossCourse value
        public Dictionary<string, string> CrossCourseDictionary { get; } = new Dictionary<string, string>();

        public void AddCrossCourse(string key, string value)
        {
            CrossCourseDictionary.Add(key, value);
        }
    }
}
