using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Models
{
    public static class JSONExtension
    {
        public static string StringValueOf(this JObject jsonObject, string key)
        {
            return jsonObject[key].ToString();
        }
        public static string StringValueOf(this JToken jsonToken, string key)
        {
            return jsonToken[key].ToString();
        }
        public static int IntValueOf(this JToken jsonToken, string key)
        {
            return Convert.ToInt32(jsonToken[key]);
        }
        public static string IntValueToStringOf(this JToken jsonToken, string key)
        {
            return Convert.ToInt32(jsonToken[key]).ToString();
        }
        public static decimal DecimalValueOf(this JToken jsonToken, string key)
        {
            return Convert.ToDecimal(jsonToken[key]);
        }
    }
}
