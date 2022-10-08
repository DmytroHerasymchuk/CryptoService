using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Currency
    {
        public string ID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Rank { get; set; } = string.Empty;
        public decimal PriceUsd { get; set; } = decimal.Zero;
        public string ChangePercent { get; set; } = string.Empty;
        public decimal Volume { get; set; } = decimal.Zero;
        public decimal MarketCap { get; set; } = decimal.Zero;
        public decimal Rate { get; set; } = decimal.Zero;
        public List<Market> Markets { get; set; } = new List<Market>();

    }
}
