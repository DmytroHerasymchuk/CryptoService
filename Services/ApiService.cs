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
        public static async Task<List<Currency>> GetCurrencyTrandsAsync(string url)
        {
            List<Currency> currencies = new List<Currency>();
            string responseBody = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                    if (responseBody != null)
                    {
                        JObject responseObject = JObject.Parse(responseBody);

                        foreach (JToken token in responseObject["coins"])
                        {
                            Currency currency = new Currency()
                            {
                                ID = token["item"].StringValueOf("id"),
                                Name = token["item"].StringValueOf("name"),
                                Symbol = token["item"].StringValueOf("symbol"),
                                Rank = token["item"].StringValueOf("market_cap_rank")
                            };
                            if (currency.Rank == "")
                            {
                                currency.Rank = "No data";
                            }
                            currencies.Add(currency);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                currencies = null;
            }
            return currencies;
        }
        public static async Task<Currency> GetCurrencyInfoAsync(string url)
        {
            Currency currency = null;
            string responseBody = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                    if (responseBody != null)
                    {
                        JObject responseObject = JObject.Parse(responseBody);

                        currency = new Currency()
                        {
                            ID = responseObject.StringValueOf("id"),
                            Name = responseObject.StringValueOf("name"),
                            Symbol = responseObject.StringValueOf("symbol").ToUpper(),
                            Rank = responseObject.StringValueOf("market_cap_rank"),
                            PriceUsd = responseObject["market_data"]["current_price"].DecimalValueOf("usd"),
                            ChangePercent = responseObject["market_data"].StringValueOf("price_change_percentage_24h"),
                            Volume = responseObject["market_data"]["total_volume"].DecimalValueOf("usd"),
                            MarketCap = responseObject["market_data"]["market_cap"].DecimalValueOf("usd"),
                        };
                        if (currency.Rank == "")
                        {
                            currency.Rank = "No data";
                        }
                        if (currency.ChangePercent == "")
                        {
                            currency.ChangePercent = "No data";
                        }

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
                        if (!currency.Markets.Any())
                        {
                            currency.Markets.Add(new Market()
                            {
                                ID = "Not found",
                                Name = "Not found",
                                Url = "https://www.google.com",
                                LastPrice = 0
                            });
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                currency = null;
            }
            return currency;
        }
        public static async Task<List<Currency>> SearchCurrenciesAsync(string url)
        {
            List<Currency> currencies = new List<Currency>();
            string responseBody = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                    if (responseBody != null)
                    {
                        JObject responseObject = JObject.Parse(responseBody);

                        foreach (JToken token in responseObject["coins"])
                        {
                            Currency currency = new Currency()
                            {
                                ID = token.StringValueOf("id"),
                                Name = token.StringValueOf("name"),
                                Symbol = token.StringValueOf("symbol"),
                                Rank = token.StringValueOf("market_cap_rank")
                            };
                            if (currency.Rank == "")
                            {
                                currency.Rank = "No data";
                            }
                            currencies.Add(currency);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                currencies = null;
            }
            return currencies;
        }

        public static async Task<List<Currency>> ConvertAsync(string url)
        {
            List<Currency> currencies = new List<Currency>();
            string responseBody = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                    if (responseBody != null)
                    {
                        JObject responseObject = JObject.Parse(responseBody);
                        foreach (JProperty obj in responseObject["rates"])
                        {
                            foreach (JToken token in obj.Children())
                            {
                                currencies.Add(new Currency()
                                {
                                    Name = token.StringValueOf("name"),
                                    Symbol = token.StringValueOf("unit").ToUpper(),
                                    Rate = token.DecimalValueOf("value")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                currencies = null;
            }
            return currencies;
        }
    }
        
}
