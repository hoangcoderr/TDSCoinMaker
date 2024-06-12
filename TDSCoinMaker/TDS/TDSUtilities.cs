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
        public static int getTDSInfo(string token)
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
                return int.Parse(xu);
            }
            return 0;
        }
        public static (List<String>, List<string>) getTDSJob(string token, string type)
        {
            HttpClient client = new HttpClient();
            bool success = false;
            string responseString = string.Empty;
            while (!success)
            {
                try
                {
                    var response = client.GetAsync($"https://traodoisub.com/api/?fields={type.ToLower()}&access_token={token}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        responseString = response.Content.ReadAsStringAsync().Result;
                        //Console.WriteLine(responseString);
                        JArray jsonArray = null;
                        jsonArray = JArray.Parse(responseString);
                        success = true;
                        List<String> types = new List<String>();
                        List<string> ids = new List<string>();
                        switch (type)
                        {
                            case "like":
                                foreach (var item in jsonArray)
                                {
                                    ids.Add(item["id"].ToString());
                                    types.Add("like");
                                }
                                return (types, ids);
                            case "likevip":
                                foreach (var item in jsonArray)
                                {
                                    ids.Add(item["id"].ToString());
                                    types.Add("likevip");
                                }
                                return (types, ids);
                            case "reaction":
                                foreach (var item in jsonArray)
                                {
                                    ids.Add(item["id"].ToString());
                                    types.Add(item["type"].ToString());
                                }
                                return (types, ids);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(responseString);
                    var jsonObject = Newtonsoft.Json.Linq.JObject.Parse(responseString);
                    double t = (double)jsonObject["countdown"];
                    int timeCountDown = (int)t;
                    Console.WriteLine($"Waiting for: {timeCountDown} seconds to get new jobs");
                    Task.Delay(timeCountDown * 1000).Wait();
                }
            }
            return (new List<string>(), new List<string>());
        }
        public static bool claimTDSXu(string token, string type, string id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://traodoisub.com/api/coin/?type={type.ToUpper()}&id={id}&access_token={token}").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseString = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine(responseString);

                var jsonObject = Newtonsoft.Json.Linq.JObject.Parse(responseString);
                if (jsonObject.ContainsKey("error"))
                {
                    //in trong error viet gi
                    // Console.WriteLine(jsonObject["error"]);
                    return false;
                }
                else if (jsonObject.ContainsKey("success") && (int)jsonObject["success"] == 200)
                {
                    return true;
                }
            }
            return false;
        }
        public static void setAccToDoJob(string token, string idAcc)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"https://traodoisub.com/api/?fields=run&id={idAcc}&access_token={token}").Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content;
                string responseString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseString);
            }
        }
    }
}
