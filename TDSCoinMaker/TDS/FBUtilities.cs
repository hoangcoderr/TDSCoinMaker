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


namespace TDSCoinMaker.TDS
{
    public class FBUtilities
    {
        public static string[] cookiesGetter(string token)
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
        public static async Task ReactionPost(string cookie, string urlPost, string typeReaction, string proxy)
        {
            string urlReaction = await getReactionLink(cookie, urlPost);
            var client = new RestClient("https://mbasic.facebook.com");
            var request = new RestRequest(urlReaction);
            headerAdder(request, cookie);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                string htmlContent = response.Content;
                //Console.WriteLine(htmlContent);
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
                    Console.WriteLine("Block");
                }
                else
                {
                    Console.WriteLine("Not Block");
                }
            }

            //open file response.html

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
                var client = new RestClient("https://mbasic.facebook.com");
                var request = new RestRequest(urlPost);
                headerAdder(request, cookie);
                var response = await client.ExecuteAsync(request);
                //File.WriteAllText("response.html", response.Content);
                string htmlContent = response.Content;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlContent);
                var reactionPickerNode = doc.DocumentNode.SelectSingleNode("//a[contains(@href, '/reactions/picker/?')]");
                string reactionPickerUrl = string.Empty;
                if (reactionPickerNode != null)
                {
                    reactionPickerUrl = reactionPickerNode.GetAttributeValue("href", string.Empty).TrimStart('/').Replace("amp;", "");
                    //Console.WriteLine(reactionPickerUrl);
                }
                return reactionPickerUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return "";
        }
        public static bool checkBlock(string check)
        {
            try
            {
                if (check.Contains("<div class=\"bn bo bp j bq\"><span class=\"br\"><div>"))
                {
                    string splitCheck = check.Split(new string[] { "<div class=\"bn bo bp j bq\"><span class=\"br\"><div>" }, StringSplitOptions.None)[1]
                                            .Split(new string[] { "<br /><br />" }, StringSplitOptions.None)[0];
                    Console.WriteLine(splitCheck);
                    return splitCheck.Contains("specific content");
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }
    }
}
