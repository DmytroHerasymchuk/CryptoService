using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Currency
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Rank { get; set; }
        public decimal PriceUsd { get; set; }
        public decimal ChangePercent { get; set; }
        public decimal Volume { get; set; }
        public decimal MarketCap { get; set; }
        public List<Market> Markets { get; set; } = new List<Market>();

    }
}
