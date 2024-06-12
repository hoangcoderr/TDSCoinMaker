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
using System.CodeDom.Compiler;
using OpenQA.Selenium.Interactions;


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
                        Thread.Sleep(2000); // Đợi 2 giây để menu hiện ra, có thể điều chỉnh nếu cần

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
            webDriver.Quit();
        }

        public static void OpenBrowser(string url, int width, int height, string cookies, string urlPost, string typeReaction)
        {
            string[] atr = cookiesGetter(cookies);
            string cUserCookieValue = atr[0];
            string xsCookieValue = atr[1];

            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            options.AddArgument("--disable-notifications");

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
    }
}
