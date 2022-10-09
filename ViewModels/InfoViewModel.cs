using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace ViewModels
{
    public class InfoViewModel
    {
        public TaskCompletion<CurrencyInfo> Currency { get; set; }


        public InfoViewModel(string url)
        {
            Currency = new TaskCompletion<CurrencyInfo>(ApiService.GetCurrencyInfoAsync(url));
        }
    }
}
