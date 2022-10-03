using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MainForm
    {
        public List<CurrencyInfo> CurrencyInfoList = new List<CurrencyInfo>();

        public MainForm(List<CurrencyInfo> currencyInfoList)
        {
            CurrencyInfoList = currencyInfoList;
        }
    }
}
