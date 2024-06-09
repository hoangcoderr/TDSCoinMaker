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

        public static void LikePost(IWebDriver webDriver, string urlPost)
        {
            IJavaScriptExecutor javaExecutor = (IJavaScriptExecutor)webDriver;
            int scrollStep = 100;
            // Thời gian chờ giữa các lần cuộn (ms)
            int delay = 50;
            bool likeButtonFound = false;

            try
            {
             
                while (!likeButtonFound)
                {
                    try
                    {
                        // Tìm nút "Like"
                        IWebElement likeButton = webDriver.FindElement(By.XPath("//div[(contains(@aria-label, 'Thích') or contains(@aria-label, 'Like')) and @role='button']"));
                        // Nếu tìm thấy, ấn vào nút Like
                        likeButton.Click();
                        likeButtonFound = true;
                        Console.WriteLine("Đã ấn nút Like!");
                    }
                    catch (NoSuchElementException)
                    {
                        // Nếu không tìm thấy nút "Like", cuộn xuống một đoạn và chờ
                        long documentHeight = (long)javaExecutor.ExecuteScript("return document.body.scrollHeight");
                        long currentScrollPosition = (long)javaExecutor.ExecuteScript("return window.scrollY + window.innerHeight");

                        // Kiểm tra xem đã cuộn đến cuối trang chưa
                        if (currentScrollPosition >= documentHeight)
                        {
                            Console.WriteLine("Không tìm thấy nút Like. Cuộn hết trang.");
                            break;
                        }
                        javaExecutor.ExecuteScript($"window.scrollBy(0, {scrollStep});");
                        Thread.Sleep(delay);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            finally
            {
                webDriver.Quit();
            }
        }

        public static void OpenBrowser(string url, int width, int height, string cookies, string urlPost)
        {
            string[] atr = cookiesGetter(cookies);
            string cUserCookieValue = atr[0];
            string xsCookieValue = atr[1];

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--disable-notifications");
            IWebDriver chromeDriver = new ChromeDriver(options);
            chromeDriver.Manage().Window.Size = new System.Drawing.Size(width, height);
            chromeDriver.Navigate().GoToUrl(url);
            Thread.Sleep(3000);
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
            chromeDriver.Navigate().GoToUrl(url + "/" + urlPost);
            LikePost(chromeDriver, urlPost);
        }

    }
}
