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
        public TaskCompletion<List<Currency>> Currencies { get; set; }
        public Currency FirstCurrency { get; set; }
        public Currency SecondCurrency { get; set; }

        public decimal Converted { get; set; }

        public ConverterViewModel(string url)
        {
            Currencies = new TaskCompletion<List<Currency>>(ApiService.ConvertAsync(url));
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
