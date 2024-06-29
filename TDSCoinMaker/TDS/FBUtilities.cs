using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome.ChromeDriverExtensions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using RestSharp;
using TDSCoinMaker.FormEditting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Text.RegularExpressions;


namespace TDSCoinMaker.TDS
{
    public class FBUtilities
    {
        public static string[] cookiesGetter(string token)
        {
            try
            {
                string[] cookies = token.Split(';');
                string[] atr = new string[2];
                foreach (string cookie in cookies)
                {
                    if (cookie != null)
                    {
                        if (cookie.Contains("c_user"))
                        {
                            atr[0] = cookie.Split('=')[1];
                        }
                        else if (cookie.Contains("xs"))
                        {
                            atr[1] = cookie.Split('=')[1];
                            break;
                        }
                    }
                }
                return atr;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception at cookiesGetter: {ex.Message}");
                return new string[2];
            }
        }
        public static void ReactionPost(IWebDriver webDriver, string urlPost, string typeReaction)
        {
            // Navigate to the post URL
            /* webDriver.Navigate().GoToUrl(urlPost);

             // Wait until the page is loaded and the reaction button is clickable
             WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
             wait.Until(driver => driver.FindElement(By.XPath("//div[@aria-label='Thích' and @role='button']")));

             // Find the reaction button (assuming it's always available and not already clicked)
             IWebElement reactionButton = webDriver.FindElement(By.XPath("//div[@aria-label='Thích' and @role='button']"));
             reactionButton.Click();

             // Wait for the reaction options to be visible
             wait.Until(driver => driver.FindElement(By.XPath("//div[@role='menu']")));

             // Define the XPath for different reactions

             // Click the specified reaction
             IWebElement reactionTypeButton = webDriver.FindElement(By.XPath(typeReaction switch
             {
                 "like" => "//div[@aria-label='Thích']",
                 "love" => "//div[@aria-label='Yêu thích']",
                 "care" => "//div[@aria-label='Thương thương']",
                 "haha" => "//div[@aria-label='Haha']",
                 "wow" => "//div[@aria-label='Wow']",
                 "sad" => "//div[@aria-label='Buồn']",
                 "angry" => "//div[@aria-label='Phẫn nộ']",
                 _ => throw new ArgumentException("Invalid reaction type")
             }));
             reactionTypeButton.Click();*/
        }
        public static void ReactionPost(IWebDriver webDriver, string typeReaction)
        {
            // Lướt xuống từ từ cho đến khi thấy nút Like hoặc đạt đến cuối trang
            bool likeButtonFound = false;
            int lastScrollPosition = -1;

            while (!likeButtonFound)
            {
                try
                {
                    // Tìm nút Like
                    var likeButton = webDriver.FindElement(By.XPath("//div[@aria-label='Thích' and @role='button']"));
                    if (likeButton.Displayed)
                    {
                        likeButtonFound = true;

                        // Rê chuột vào nút Like    
                        Actions action = new Actions(webDriver);
                        action.MoveToElement(likeButton).Perform();

                        // Đợi menu reactions hiện ra
                        Thread.Sleep(3000); // Đợi 3 giây để menu hiện ra, có thể điều chỉnh nếu cần

                        // Chọn reaction dựa vào typeReaction
                        IWebElement reactionButton = null;
                        switch (typeReaction.ToLower())
                        {
                            case "like":
                                reactionButton = webDriver.FindElement(By.XPath("//div[@aria-label='Thích' and @role='button']"));
                                break;
                            case "likevip":
                                reactionButton = webDriver.FindElement(By.XPath("//div[@aria-label='Thích' and @role='button']"));
                                break;
                            case "love":
                                reactionButton = webDriver.FindElement(By.XPath("//div[@aria-label='Yêu thích' and @role='button']"));
                                break;
                            case "care":
                                reactionButton = webDriver.FindElement(By.XPath("//div[@aria-label='Thương thương' and @role='button']"));
                                break;
                            case "haha":
                                reactionButton = webDriver.FindElement(By.XPath("//div[@aria-label='Haha' and @role='button']"));
                                break;
                            case "wow":
                                reactionButton = webDriver.FindElement(By.XPath("//div[@aria-label='Wow' and @role='button']"));
                                break;
                            case "sad":
                                reactionButton = webDriver.FindElement(By.XPath("//div[@aria-label='Buồn' and @role='button']"));
                                break;
                            case "angry":
                                reactionButton = webDriver.FindElement(By.XPath("//div[@aria-label='Phẫn nộ' and @role='button']"));
                                break;
                            default:
                                throw new ArgumentException("Reaction type không hợp lệ.");
                        }

                        if (reactionButton != null)
                        {
                            // Ấn nút bằng JavaScript
                            //((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].click();", reactionButton);
                            reactionButton.Click();
                        }
                    }
                }
                catch (NoSuchElementException)
                {
                    // Cuộn xuống từ từ
                    ((IJavaScriptExecutor)webDriver).ExecuteScript("window.scrollBy(0, 100);");
                    Thread.Sleep(500);

                    // Kiểm tra vị trí thanh cuộn hiện tại
                    int currentScrollPosition = Convert.ToInt32(((IJavaScriptExecutor)webDriver).ExecuteScript("return window.pageYOffset;"));

                    // Nếu vị trí thanh cuộn không thay đổi, có nghĩa là đã đạt đến cuối trang
                    if (currentScrollPosition == lastScrollPosition)
                    {
                        //Console.WriteLine("CAN NOT FIND THE LIKE BUTTON!");
                        break;
                    }

                    lastScrollPosition = currentScrollPosition;
                }
            }
            Thread.Sleep(500);
            webDriver.Navigate().Refresh();
            Thread.Sleep(1000);
            webDriver.Quit();
        }

        public static void OpenBrowser(string url, int width, int height, string cookies, string urlPost, string typeReaction, string proxy)
        {
            string[] atr = cookiesGetter(cookies);
            string cUserCookieValue = atr[0];
            string xsCookieValue = atr[1];

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArgument("--disable-notifications");
            // Add your HTTP-Proxy
            if (proxy != null && proxy != "")
            {
                string[] proxyArray = Utilities.analyzeProxy(proxy);
                options.AddHttpProxy(proxyArray[0], int.Parse(proxyArray[1]), proxyArray[2], proxyArray[3]);
            }
            IWebDriver chromeDriver = new ChromeDriver(service, options);
            chromeDriver.Manage().Window.Size = new System.Drawing.Size(width, height);
            chromeDriver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10));
            wait.Until(driver =>
            {
                string readyState = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString();
                return readyState.Equals("complete");
            });
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)chromeDriver;
            string script = $@"
                function setCookie(name, value, days) {{
                    var expires = '';
                    if (days) {{
                        var date = new Date();
                        date.setTime(date.getTime() + (days*30*24*60*60*1000));
                        expires = '; expires=' + date.toUTCString();
                    }}
                    document.cookie = name + '=' + (value || '')  + expires + '; path=/';
                }}

                // Set Facebook cookies
                setCookie('c_user', '{cUserCookieValue}', 30);
                setCookie('xs', '{xsCookieValue}', 30);
                // Add other relevant cookies as needed
            ";
            jsExecutor.ExecuteScript(script);
            //chromeDriver.Navigate().Refresh();
            chromeDriver.Navigate().GoToUrl(url + urlPost);
            //đợi đến khi trang web load xong mới dùng chạy reactionPost
            wait.Until(driver =>
            {
                string readyState = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").ToString();
                return readyState.Equals("complete");
            });
            ReactionPost(chromeDriver, typeReaction);
        }
        //
        public static async Task<string> ReactionPost(string cookie, string urlPost, string typeReaction, WebProxy proxy)
        {
            RestClient client = null;
            string urlReaction = string.Empty;

            if (proxy != null)
            {

                if (await TestProxy(proxy) == false) return "proxy error";
                var options = new RestClientOptions("https://mbasic.facebook.com")
                {
                    Proxy = proxy
                };
                client = new RestClient(options);
                urlReaction = await getReactionLink(cookie, urlPost, proxy);
            }
            else
            {
                urlReaction = await getReactionLink(cookie, urlPost);
                client = new RestClient("https://mbasic.facebook.com");
            }

            if (urlReaction == null || urlReaction.Equals(string.Empty)) return "invalid";
            var request = new RestRequest(urlReaction);
            headerAdder(request, cookie);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                try
                {
                    string htmlContent = response.Content;
                    //File.WriteAllText("response.html", htmlContent);
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlContent);

                    var typeReactions = doc.DocumentNode
                                      .SelectNodes("//a[contains(@href, '/ufi/reaction')]")
                                      .Select(node => node.Attributes["href"].Value.Replace("amp;", "").TrimStart('/'))
                                      .ToList();
                    //print reactionUrls

                    string urlResponse = string.Empty;
                    switch (typeReaction)
                    {
                        case "like":

                            urlResponse = typeReactions[Const.LIKE_BUTTON_INDEX];
                            break;
                        case "likevip":
                            urlResponse = typeReactions[Const.LIKE_BUTTON_INDEX];
                            break;
                        case "love":
                            urlResponse = typeReactions[Const.LOVE_BUTTON_INDEX];
                            break;
                        case "care":
                            urlResponse = typeReactions[Const.CARE_BUTTON_INDEX];
                            break;
                        case "haha":
                            urlResponse = typeReactions[Const.HAHA_BUTTON_INDEX];
                            break;
                        case "wow":
                            urlResponse = typeReactions[Const.WOW_BUTTON_INDEX];
                            break;
                        case "sad":
                            urlResponse = typeReactions[Const.SAD_BUTTON_INDEX];
                            break;
                        case "angry":
                            urlResponse = typeReactions[Const.ANGRY_BUTTON_INDEX];
                            break;
                        default:
                            throw new ArgumentException("Invalid reaction type");
                    }
                    var clientToResponse = new RestClient("https://mbasic.facebook.com");
                    var requestToResponse = new RestRequest(urlResponse);

                    headerAdder(requestToResponse, cookie);
                    var responseAfterReaction = await clientToResponse.ExecuteAsync(requestToResponse);
                    File.WriteAllText("response.html", responseAfterReaction.Content);
                    if (checkBlock(responseAfterReaction.Content))
                    {
                        Console.WriteLine("Acc died");
                        return "die acc";
                    }
                    else
                    {
                        Console.WriteLine("Acc still alive");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception at ReactionPost: {ex.Message}");
                }
                //open file response.html
            }
            return "success";
        }
        public static async Task<bool> isCookieAlive(string cookie)
        {
            Console.WriteLine("Called 1 agrument");
            var client = new RestClient("https://mbasic.facebook.com");
            var request = new RestRequest(cookiesGetter(cookie)[0]);
            headerAdder(request, cookie);
            var response = await client.ExecuteAsync(request);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(response.Content);
            var titleNode = doc.DocumentNode.SelectSingleNode("//head/title");

            if (titleNode != null)
            {
                string titleText = titleNode.InnerText;
                if (titleText.Contains("Facebook"))
                {
                    return false;
                }
                Console.WriteLine("Cookie alive: " + titleText);
                return true;
            }
            return false;
        }
        public static async Task<bool> isCookieAlive(string cookie, WebProxy webProxy)
        {
            Console.WriteLine("Called 2 arguments of isCookieAlive");
            if (await TestProxy(webProxy) == false)
            {
                Console.WriteLine("Proxy error at check Acc");
                return false;
            }
            var options = new RestClientOptions("https://mbasic.facebook.com")
            {
                Proxy = webProxy
            };

            var client = new RestClient(options);
            var request = new RestRequest(cookiesGetter(cookie)[0]);
            headerAdder(request, cookie);
            var response = await client.ExecuteAsync(request);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(response.Content);
            //File.WriteAllText("response.html", response.Content);
            var titleNode = doc.DocumentNode.SelectSingleNode("//head/title");
            if (titleNode != null)
            {
                string titleText = titleNode.InnerText;
                if (titleText.Contains("Facebook"))
                {
                    return false;
                }
                Console.WriteLine("Cookie alive: " + titleText);
                return true;
            }
            return false;
        }
        public static void headerAdder(RestRequest request, string cookie)
        {
            request.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.AddHeader("accept-language", "en-US,en;q=0.9");
            request.AddHeader("cookie", cookie);
            request.AddHeader("dpr", "1");
            request.AddHeader("priority", "u=0, i");
            request.AddHeader("sec-ch-prefers-color-scheme", "dark");
            request.AddHeader("sec-ch-ua", "\"Not/A)Brand\";v=\"8\", \"Chromium\";v=\"126\", \"Google Chrome\";v=\"126\"");
            request.AddHeader("sec-ch-ua-full-version-list", "\"Not/A)Brand\";v=\"8.0.0.0\", \"Chromium\";v=\"126.0.6478.61\", \"Google Chrome\";v=\"126.0.6478.61\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-model", "\"\"");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-ch-ua-platform-version", "\"15.0.0\"");
            request.AddHeader("sec-fetch-dest", "document");
            request.AddHeader("sec-fetch-mode", "navigate");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("sec-fetch-user", "?1");
            request.AddHeader("upgrade-insecure-requests", "1");
            request.AddHeader("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36");
            request.AddHeader("viewport-width", "1365");
        }
        public static async Task<string> getReactionLink(string cookie, string urlPost)
        {
            try
            {
                string urlFB = await getFacebookIdPost(urlPost);
                if (urlFB == null) return null;
                var client = new RestClient("https://mbasic.facebook.com");
                var request = new RestRequest(urlFB);
                headerAdder(request, cookie);
                var response = await client.ExecuteAsync(request);
               // File.WriteAllText("response1.html", response.Content);
                string htmlContent = response.Content;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);
                var reactionPickerNode = doc.DocumentNode.SelectSingleNode("//a[contains(@href, '/reactions/picker/?')]");
                string reactionPickerUrl = string.Empty;
                if (reactionPickerNode != null)
                {
                    reactionPickerUrl = reactionPickerNode.GetAttributeValue("href", string.Empty).TrimStart('/').Replace("amp;", "");
                    Console.WriteLine("mbasic.facebook.com/" + reactionPickerUrl);
                }
                return reactionPickerUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception at getReactionLink: {ex.Message}");
            }
            return "";
        }
        public static async Task<string> getReactionLink(string cookie, string urlPost, WebProxy proxy)
        {
            try
            {
                var options = new RestClientOptions("https://mbasic.facebook.com")
                {
                    Proxy = proxy
                };
                var client = new RestClient(options);
                string urlFB = await getFacebookIdPostByHttp(urlPost);
                if (urlFB == null) return null;

                var request = new RestRequest(urlFB);
                headerAdder(request, cookie);
                var response = await client.ExecuteAsync(request);
               // File.WriteAllText("response1.html", response.Content);
                string htmlContent = response.Content;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);
                var reactionPickerNode = doc.DocumentNode.SelectSingleNode("//a[contains(@href, '/reactions/picker/?')]");
                string reactionPickerUrl = string.Empty;
                if (reactionPickerNode != null)
                {
                    reactionPickerUrl = reactionPickerNode.GetAttributeValue("href", string.Empty).TrimStart('/').Replace("amp;", "");
                    Console.WriteLine("mbasic.facebook.com/" + reactionPickerUrl);
                }
                return reactionPickerUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception at getReactionLink: {ex.Message}");
            }
            return "";
        }
        public static async Task<string> getFacebookIdPost(string urlPost)
        {
            /*       var proxyToDo = new WebProxy
                   {
                       Address = new Uri($"http://203.175.96.39:31423"), // Ensure the address includes a scheme
                       Credentials = new NetworkCredential("hoangkv", "kvhoang") // Proxy credentials
                   };*/
            //Console.WriteLine((await checkProxyIp(Const.PROXY_TO_GET_URL) ? "GOOD CONNECT" : "BAD CONNECT"));
            var options = new RestClientOptions("https://facebook.com")
            {
                Proxy = Const.PROXY_TO_GET_URL
            };
            var client = new RestClient(options);
            var request = new RestRequest(urlPost);
            headerAdder(request, "");
            var response = await client.ExecuteAsync(request);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(response.Content);
           // File.WriteAllText("response3.html", response.Content);

            // Output the tokens

            string urlReaction = ExtractToken(doc);
            if (urlReaction == null) return null;
            Console.WriteLine("mbasic.facebook.com/" + urlReaction);
            return urlReaction;
        }
        public static async Task<string> getFacebookIdPostByHttp(string urlPost)
        {

            HttpClientHandler handler = new HttpClientHandler()
            {
                Proxy = Const.PROXY_TO_GET_URL,
                UseProxy = true,
            };
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://www.facebook.com/{urlPost}");

            request.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            request.Headers.Add("accept-language", "en-US,en;q=0.9");
            request.Headers.Add("cookie", "sb=jHh-ZnTqxXmMqQk2mnZ232J9; fr=036JmfutsgDgDzQ0d..BmfniM..AAA.0.0.BmfniM.AWVUD-XvNQg; datr=jHh-ZlFAze6jfwy1YnSkCWK0; ps_n=1; ps_l=1; wd=1920x1080");
            request.Headers.Add("dpr", "1");
            request.Headers.Add("priority", "u=0, i");
            request.Headers.Add("sec-ch-prefers-color-scheme", "dark");
            request.Headers.Add("sec-ch-ua", "\"Not/A)Brand\";v=\"8\", \"Chromium\";v=\"126\", \"Microsoft Edge\";v=\"126\"");
            request.Headers.Add("sec-ch-ua-full-version-list", "\"Not/A)Brand\";v=\"8.0.0.0\", \"Chromium\";v=\"126.0.6478.114\", \"Microsoft Edge\";v=\"126.0.2592.68\"");
            request.Headers.Add("sec-ch-ua-mobile", "?0");
            request.Headers.Add("sec-ch-ua-model", "\"\"");
            request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
            request.Headers.Add("sec-ch-ua-platform-version", "\"15.0.0\"");
            request.Headers.Add("sec-fetch-dest", "document");
            request.Headers.Add("sec-fetch-mode", "navigate");
            request.Headers.Add("sec-fetch-site", "none");
            request.Headers.Add("sec-fetch-user", "?1");
            request.Headers.Add("upgrade-insecure-requests", "1");
            request.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36 Edg/126.0.0.0");
            request.Headers.Add("viewport-width", "1920");

         string urlReaction = null;
do
{
    HttpResponseMessage response = await client.SendAsync(request);
    response.EnsureSuccessStatusCode();
    // Read the response content as a byte array
    byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();

    // Convert the byte array to a string using a known encoding (e.g., UTF-8)
    string responseBody = Encoding.UTF8.GetString(responseBytes);

    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(responseBody);
    File.WriteAllText("response3.html", responseBody);

    // Output the tokens
    urlReaction = ExtractToken(doc);

    if (urlReaction != null) break; // Nếu urlReaction không phải là null, thoát khỏi vòng lặp

    // Tùy chọn: Thêm một khoảng thời gian chờ trước khi thực hiện request lại để tránh làm quá tải server
    await Task.Delay(1000); // Chờ 1 giây trước khi thử lại
} while (urlReaction == null); // Tiếp tục lặp nếu urlReaction vẫn là null

if (urlReaction == null) return null; 
            Console.WriteLine("mbasic.facebook.com/" + urlReaction); return urlReaction;
        }
        public static string ExtractToken(HtmlAgilityPack.HtmlDocument doc)
        {

            var scriptNode = doc.DocumentNode.SelectSingleNode("//script[contains(text(), '\"url\":\"')]");

            if (scriptNode != null)
            {
                // Extract the text from the script node
                string scriptText = scriptNode.InnerText;

                // Use a regular expression to find the first URL
                var match = Regex.Match(scriptText, "\"url\":\"(\\\\/[^\\\"]+)\"");
                if (match.Success)
                {
                    // Extract and decode the URL
                    string url = match.Groups[1].Value.Replace("\\/", "/");
                    Console.WriteLine("Extracted URL content: " + url);
                    if (url.Contains("videos"))
                    {
                        string[] parts = url.Split('/');
                        string id = parts[parts.Length - 2];
                        return $"watch/?v={id}";
                    }
                    return url.TrimStart('/').Replace("amp;", "");
                }
                else
                {
                    Console.WriteLine("URL not found in the script text.");
                }
            }
            else
            {
                Console.WriteLine("Script node containing the URL not found.");
            }
            return null;
        }
        public static bool checkBlock(string check)
        {
            if (check.Contains("khoản của bạn hiện bị hạn chế") || check.Contains("account is restricted right now"))
            {
                return true;
            }
            return false;
        }
        public static void Test()
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load("response2.html");  // Replace with your file path

            // Replace with your file path

            // Find the script node or text node that contains the URL
            var scriptNode = doc.DocumentNode.SelectSingleNode("//script[contains(text(), '\"url\":\"')]");

            if (scriptNode != null)
            {
                // Extract the text from the script node
                string scriptText = scriptNode.InnerText;

                // Use a regular expression to find the first URL
                var match = Regex.Match(scriptText, "\"url\":\"(\\\\/[^\\\"]+)\"");
                if (match.Success)
                {
                    // Extract and decode the URL
                    string url = match.Groups[1].Value.Replace("\\/", "/");
                    Console.WriteLine("Extracted URL content: " + url);
                }
                else
                {
                    Console.WriteLine("URL not found in the script text.");
                }
            }
            else
            {
                Console.WriteLine("Script node containing the URL not found.");
            }
        }
        public static async Task<bool> TestProxy(WebProxy proxy)
        {

            return await Utilities.TestProxy(proxy);
        }
        public static async Task<bool> checkProxyIp(WebProxy proxy)
        {
            var options = new RestClientOptions("https://api64.ipify.org")
            {
                Proxy = proxy,
                ThrowOnAnyError = true
            };
            var client = new RestClient(options);
            var request = new RestRequest("?format=jsonp", Method.Get);

            int retryCount = 0;
            int maxRetries = 3; // Maximum number of retries
            while (retryCount < maxRetries)
            {
                try
                {
                    // Execute the request asynchronously and await the result
                    var response = await client.ExecuteAsync(request);

                    // Check if the proxy authentication failed
                    if (response.StatusCode == System.Net.HttpStatusCode.ProxyAuthenticationRequired)
                    {
                        Console.WriteLine("Proxy authentication required.");
                        return false;
                    }
                    else if (!response.IsSuccessful)
                    {
                        // Handle other unsuccessful status codes
                        Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine(response.Content); // Print the response content
                        return true; // Success
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle the specific case of an HttpRequestException
                    Console.WriteLine($"HttpRequestException: {ex.Message}");
                    return false; // Return false as per the requirement
                }
                catch (TaskCanceledException ex)
                {
                    // Handle the case of a timeout
                    Console.WriteLine($"Timeout occurred: {ex.Message}");
                    retryCount++; // Increment the retry count
                    if (retryCount >= maxRetries)
                    {
                        Console.WriteLine("Max retries reached. Giving up.");
                        return false; // Return false after exceeding max retries
                    }
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Console.WriteLine($"Exception: {ex.Message}");
                    return false; // Return false for any other exceptions
                }
            }
            return false;
        }

    }
}
