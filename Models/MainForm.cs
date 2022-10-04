using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MainForm
    {
        public CurrencyInfo CurrencyInfo { get; set; }

        public List<CurrencyInfo> CurrencyInfoList = new List<CurrencyInfo>();

        public List<CurrencyInfo> Top10Currency;

        public MainForm(List<CurrencyInfo> currencyInfoList)
        {
            CurrencyInfoList = currencyInfoList;
            Top10Currency = currencyInfoList.GetRange(0, 10);
        }
    }
}
