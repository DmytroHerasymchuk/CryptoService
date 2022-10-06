using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Models;
using System.Net.Http;


namespace Services
{
    public class ApiService
    {
        public static List<Currency> GetCurrencyTrands(string url)
        {
            List<Currency> currencies = new List<Currency>();
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
                    
                    foreach (JToken token in responseObject["coins"])
                    {
                        currencies.Add(new Currency()
                        {
                            ID = token["item"].StringValueOf("id"),
                            Name = token["item"].StringValueOf("name"),
                            Symbol = token["item"].StringValueOf("symbol"),
                            Rank = token["item"].IntValueOf("market_cap_rank"),
                            
                        });
                    } 
                }
                
            }
            catch(Exception ex)
            {
                currencies = null;
            }
            return currencies;
        }

        public static Currency GetCurrencyInfo(string url)
        {
            Currency currency = null;
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
                    currency = new Currency()
                    {
                        ID = responseObject.StringValueOf("id"),
                        Name = responseObject.StringValueOf("name"),
                        Symbol = responseObject.StringValueOf("symbol").ToUpper(),
                        Rank = responseObject.IntValueOf("market_cap_rank"),
                        PriceUsd = responseObject["market_data"]["current_price"].DecimalValueOf("usd"),
                        ChangePercent = responseObject["market_data"].DecimalValueOf("price_change_percentage_24h"),
                        Volume = responseObject["market_data"]["total_volume"].DecimalValueOf("usd"),
                        MarketCap = responseObject["market_data"]["market_cap"].DecimalValueOf("usd"),
                    };
                    foreach (JToken token in responseObject["tickers"])
                    {
                        currency.Markets.Add(new Market()
                        {
                            ID = token["market"].StringValueOf("identifier"),
                            Name = token["market"].StringValueOf("name"),
                            Url = token.StringValueOf("trade_url"),
                            LastPrice = token["converted_last"].DecimalValueOf("usd")
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                currency = null;
            }
          
            return currency;
        }
        public static List<Currency> SearchCurrencies(string url)
        {
            List<Currency> currencies = new List<Currency>();
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

                    foreach (JToken token in responseObject["coins"])
                    {
                        currencies.Add(new Currency()
                        {
                            ID = token.StringValueOf("id"),
                            Name = token.StringValueOf("name"),
                            Symbol = token.StringValueOf("symbol"),
                        });
                    }
                }
            }


            catch (Exception ex)
            {
                currencies = null;
            }
                //currencies.ToListAsync();
                return currencies;
            }



    }
}
