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
    public class SearchViewModel
    {
        public List<Currency> Currencies { get; set; }

        public SearchViewModel(string url)
        {
            Currencies = ApiService.SearchCurrencies(url);
        }
    }
}
