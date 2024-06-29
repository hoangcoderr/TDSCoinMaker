using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Windows.Forms;
using TDSCoinMaker.FormEditting;
using TDSCoinMaker.Logger;

namespace TDSCoinMaker.TDS
{
    public class TDSUtilities
    {
        public static int getTDSInfo(string token, LogForm logForm)
        {
            HttpClient client = new HttpClient();
            try
            {
                var response = client.GetAsync($"https://traodoisub.com/api/?fields=profile&access_token={token}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    var jsonObject = Newtonsoft.Json.Linq.JObject.Parse(responseString);
                    string user = (string)jsonObject["data"]["user"];
                    string xu = (string)jsonObject["data"]["xu"];
                    string xudie = (string)jsonObject["data"]["xudie"];
                    Console.WriteLine($"User: {user} Xu: {xu} XuDie: {xudie}");
                    logForm.Log($"{user}|{xu}|{xudie}", System.Drawing.Color.PaleGreen);
                    return int.Parse(xu);
                }

            }
            //catch the http request exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return 0;
        }
        public static (List<String>, List<string>) getTDSJob(string token, string type, User user)
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
                        Console.WriteLine(responseString);
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
                            case "reactcmt":
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
                    try
                    {
                        double t = (double)jsonObject["countdown"];
                        int timeCountDown = (int)t;
                        Console.WriteLine($"Waiting for: {timeCountDown} seconds to get new jobs");
                        Thread.Sleep((timeCountDown + 1) * 1000);
                    }
                    catch
                    {
                        user.UpdateStatus("Full Mission: " + type.ToUpper());
                        Console.WriteLine("Full Mission");
                        return (null, null);
                    }
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
                Console.WriteLine(responseString);

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
            bool isSuccess = false;
            int retryCount = 0;
            const int maxRetry = 5; // Giới hạn số lần thử lại

            while (!isSuccess && retryCount < maxRetry)
            {
                var response = client.GetAsync($"https://traodoisub.com/api/?fields=run&id={idAcc}&access_token={token}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseString);

                    if (!responseString.Contains("error"))
                    {
                        isSuccess = true; // Thoát khỏi vòng lặp nếu không có lỗi
                    }
                    else
                    {
                        Console.WriteLine("Detected error in response, retrying...");
                        retryCount++;
                        Thread.Sleep(1000); // Đợi 1 giây trước khi thử lại
                    }
                }
                else
                {
                    // Xử lý trường hợp phản hồi không thành công
                    Console.WriteLine("Failed to get a successful response from the server.");
                    break;
                }
            }

            if (!isSuccess)
            {
                Console.WriteLine("Failed to set account to do job after retries.");
            }
        }


    }
}
