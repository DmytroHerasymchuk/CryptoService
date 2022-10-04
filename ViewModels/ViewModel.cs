using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Models;
using Services;

namespace ViewModels
{
    public class ViewModel
    {
        public List<CurrencyInfo> Currencies {get;set;}

        public ViewModel(string url)
        {
            Currencies = ApiService.GetCurrencyInfos(url);
        }
    }
}
