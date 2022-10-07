﻿using System;
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
        public TaskCompletion<List<Currency>> Currencies { get; set; }

        public SearchViewModel(string url)
        {
            Currencies = new TaskCompletion<List<Currency>>(ApiService.SearchCurrenciesAsync(url));
            
        }
    }
}
