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

namespace ViewModels
{
    public class ViewModel
    {
        private MainForm _form;
        public MainForm Form
        {
            get { return _form; }
            set { _form = value; }
        }
        public void Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.coincap.io/v2/assets");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());
            string responseText = sr.ReadToEnd();
            response.Close();
            JObject responseObject = JObject.Parse(responseText);
            List<CurrencyInfo> nameOfCurrency = new List<CurrencyInfo>();
            foreach (JToken token in responseObject["data"])
            {
                nameOfCurrency.Add(new CurrencyInfo(token.StringValueOf("id"),
                                                    token.StringValueOf("name"),
                                                    token.StringValueOf("symbol"),
                                                    token.IntValueOf("rank"),
                                                    token.DecimalValueOf("priceUsd"),
                                                    token.DecimalValueOf("changePercent24Hr")));

            }
            Form = new MainForm(nameOfCurrency);
        }

    }
}
