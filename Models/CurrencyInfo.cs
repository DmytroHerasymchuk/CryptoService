using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CurrencyInfo
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public string Symbol { get; set; }

        public int Rank { get; set; }
        public decimal PriceUsd { get; set; }

        public decimal ChangePercent { get; set; }

        public CurrencyInfo(string iD, string name, string symbol, int rank, decimal priceUsd, decimal changePercent)
        {
            ID = iD;
            Name = name;
            Symbol = symbol;
            Rank = rank;
            PriceUsd = priceUsd;
            ChangePercent = changePercent;
        }
    }
}
