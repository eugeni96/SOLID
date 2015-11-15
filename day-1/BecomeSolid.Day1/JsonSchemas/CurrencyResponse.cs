using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecomeSolid.Day1.JsonSchemas
{
    public class Rate
    {
        public string id { get; set; }
        public string name { get; set; }
        public string rate { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string ask { get; set; }
        public string Bid { get; set; }
    }

    public class Results
    {
        public Rate rate { get; set; }
    }

    public class Query
    {
        public int count { get; set; }
        public string created { get; set; }
        public string lang { get; set; }
        public Results results { get; set; }
    }

    public class CurrencyResponse
    {
        public Query query { get; set; }
    }
}
