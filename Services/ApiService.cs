using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Models;

namespace Services
{
    public class ApiService
    {
        public static List<CurrencyInfo> GetCurrencyInfos(string url)
        {
            List<CurrencyInfo> currencies = new List<CurrencyInfo>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response != null) 
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string responseText = sr.ReadToEnd();
                    response.Close();
                    JObject responseObject = JObject.Parse(responseText);
                    
                    foreach (JToken token in responseObject["data"])
                    {
                        currencies.Add(new CurrencyInfo(token.StringValueOf("id"),
                                                            token.StringValueOf("name"),
                                                            token.StringValueOf("symbol"),
                                                            token.IntValueOf("rank"),
                                                            token.DecimalValueOf("priceUsd"),
                                                            token.DecimalValueOf("changePercent24Hr")));

                    } 
                }
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return currencies;
        }
}
}
