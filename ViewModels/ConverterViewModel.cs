using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace ViewModels
{
    public class ConverterViewModel
    {
        public TaskCompletion<List<CurrencyRate>> Currencies { get; set; }
        public CurrencyRate FirstCurrency { get; set; }
        public CurrencyRate SecondCurrency { get; set; }

        public decimal Converted { get; set; }

        public ConverterViewModel(string url)
        {
            Currencies = new TaskCompletion<List<CurrencyRate>>(ApiService.GetRatesAsync(url));
        }

        public void Convert(decimal convertible)
        {
            decimal converted;
            converted = convertible / FirstCurrency.Rate;
            converted *= SecondCurrency.Rate;
            Converted = converted;
        }
    }
}
