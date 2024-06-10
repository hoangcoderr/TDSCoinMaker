using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TDSCoinMaker.TDS
{
    public class TDSUtilities
    {
        public static void getTDSInfo(string token)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://traodoisub.com/api/?fields=profile&access_token={token}").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseString = response.Content.ReadAsStringAsync().Result;
                var jsonObject = Newtonsoft.Json.Linq.JObject.Parse(responseString);
                string user = (string)jsonObject["data"]["user"];
                string xu = (string)jsonObject["data"]["xu"];
                string xudie = (string)jsonObject["data"]["xudie"];
                Console.WriteLine($"User: {user} has {xu} xu and {xudie} xudie");
            }
        }
        public static List<String> getTDSJob(string token, string type)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://traodoisub.com/api/?fields={type}&access_token={token}").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseString);
                var jsonArray = JArray.Parse(responseString);
                List<string> ids = new List<string>();
                foreach (var item in jsonArray)
                {
                    ids.Add(item["id"].ToString());
                }
                return ids;

            }
            return new List<string>();
        }
        public static bool claimTDSXu(string token, string type, string id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://traodoisub.com/api/coin/?type={type.ToUpper()}&id={id}&access_token={token}").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseString);
                return true;
            }
            return false;
        }
    }
}
