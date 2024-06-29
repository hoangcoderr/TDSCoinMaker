using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDSCoinMaker.TDS;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome.ChromeDriverExtensions;
using System.Net;
using System.Net.Http;
using System.Threading;
using TDSCoinMaker.FormEditting;
using Guna.UI.WinForms;

namespace TDSCoinMaker
{
    public class Utilities
    {
        public static async Task<bool> TestProxy(WebProxy proxy)
        {
            try
            {
                var httpClientHandler = new HttpClientHandler()
                {
                    Proxy = proxy,
                    UseProxy = true,
                };

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    // Đặt thời gian chờ tối đa cho yêu cầu
                    httpClient.Timeout = TimeSpan.FromSeconds(10);

                    // Thử gửi một yêu cầu GET đến một URL. Ví dụ: http://www.example.com
                    var response = await httpClient.GetAsync("http://www.example.com");

                    // Kiểm tra xem phản hồi có thành công không
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {

                return false;
            }
        }
        public static string ToStringCustom(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            if (list != null)
                foreach (var item in list)
                {
                    sb.Append(item);
                    sb.Append(",");
                }
            return sb.ToString().TrimEnd(',', ' ');
        }
        public static List<string> getUID(List<string> list)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(FBUtilities.cookiesGetter(list[i])[0]);
            }
            return result;
        }
        public static void addDataToTable(GunaDataGridView table, User user)
        {
            table.Rows.Add(user.getId(), Utilities.ToStringCustom(getUID(user.getFbToken())), user.getTdsToken(), user.getJobType(), Utilities.ToStringCustom(user.getJobId()).ToString(), Utilities.ToStringCustom(user.getProxy()), user.getStatus());
            SaveAccToFile("config\\account.ini", table);
        }
        public static int indexAvaiableToken(GunaDataGridView dgv, string checkToken, int index)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[index].Value != null && row.Cells[index].Value.ToString().Equals(checkToken))
                {
                    return row.Index;
                }
            }
            return -1;
        }
        public static int getJobDone()
        {
            return Program.mainForm.getJobDone();
        }
        public static void LoadAccFromFile(string path, GunaDataGridView dgv)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    string[] data = line.Split('|');
                    User user = new User(int.Parse(data[0]), new List<string>(data[1].Split(',')), data[2], data[3], new List<string>(), new List<string>(data[5].Split(',')), string.Empty);
                    MainForm.users.Add(user);
                    addDataToTable(dgv, user);

                }
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].Cells[Const.ACTION_INDEX].Value = "Start";
                }
            }

            else
            {
                MessageBox.Show("Account file not found, create new one!");
                //create new file if not found
                File.Create(path).Close();
            }
        }
        public static void UpdateUser(int id, GunaDataGridView dgv)
        {
            User user = MainForm.users.Find(x => x.getId() == id);
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(id.ToString()))
                {
                    user.setFbToken(new List<string>(row.Cells[1].Value.ToString().Split(',')));
                    user.setTdsToken(row.Cells[2].Value.ToString());
                    user.setProxy(new List<string>(row.Cells[5].Value.ToString().Split(',')));
                    break;
                }
            }
        }
        public static void LoadClientConfig(string path, MainForm mainform)
        {
            if (File.Exists(path))
            {
                string[] arr = File.ReadAllText(path).Split('|');
                mainform.setStartHold(int.Parse(arr[0]));
                mainform.setStopHold(int.Parse(arr[1]));
                mainform.setJobDone(int.Parse(arr[2]));
                mainform.setStartWaitingJob(int.Parse(arr[3]));
                mainform.setStopWaitingJob(int.Parse(arr[4]));
                mainform.setJobToChangeAcc(int.Parse(arr[5]));
                mainform.setJobToStop(int.Parse(arr[6]));
            }
            else
            {
                MessageBox.Show("Config file not found, create new one!");
                //create new file if not found
                File.Create(path).Close();
                File.WriteAllText(path, "0|0|0|0|0|0|0");
            }

        }
        public static void SaveClientConfig(string path, MainForm mainform)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(mainform.getStartHold().ToString() + "|" + mainform.getStopHold() + "|" + mainform.getJobDone() + "|" + mainform.getStartWaitingJob() + "|" + mainform.getStopWaitingJob() + "|" + mainform.getJobToChangeAcc() + "|" + mainform.getJobToStop());
                sw.Close();
            }
        }
        public static void setJobToChangeAcc(int jobCount)
        {
            Settings.countJobToChangeAcc = jobCount;
        }
        public static int getTimeToHold()
        {
            //return random time from Program.mainForm.getStartHold() to Program.mainForm.getStopHold()
            return new Random().Next(Program.mainForm.getStartHold(), Program.mainForm.getStopHold());
        }
        public static int getJobToChangeAcc()
        {
            return Program.mainForm.getJobToChangeAcc();
        }
        public static int getJobToStop()
        {
            return Program.mainForm.getJobToStop();
        }
        public static int getTimeToWait()
        {
            //return random time from Program.mainForm.getStartWaitingJob() to Program.mainForm.getStopWaitingJob()
            return new Random().Next(Program.mainForm.getStartWaitingJob(), Program.mainForm.getStopWaitingJob());
        }
        public static void SaveAccToFile(string path, GunaDataGridView dgv)
        {
            // Name of the mutex should be unique to avoid conflicts with other applications
            string mutexName = "Global\\TDSCoinMakerSaveAccToFileMutex";
            using (Mutex mutex = new Mutex(false, mutexName))
            {
                try
                {
                    // Wait until it is safe to enter, with a timeout (e.g., 5 seconds)
                    if (mutex.WaitOne(TimeSpan.FromSeconds(5)))
                    {
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            foreach (User user in MainForm.users)
                            {
                                sw.WriteLine(user.getId() + "|" + Utilities.ToStringCustom(user.getFbToken()) + "|" + user.getTdsToken() + "|" + user.getJobType() + "|" + Utilities.ToStringCustom(user.getJobId()) + "|" + Utilities.ToStringCustom(user.getProxy()) + "|" + user.getStatus());
                            }
                        }
                    }
                    else
                    {
                        // Handle the case when the mutex could not be acquired within the timeout
                        Console.WriteLine("Could not acquire mutex within timeout.");
                    }
                }
                finally
                {
                    // Always release the mutex if it was acquired
                    if (mutex.WaitOne(0))
                    {
                        mutex.ReleaseMutex();
                    }
                }
            }
        }

        public static void resetUserId(List<User> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                users[i].setId(i);
            }
        }

        public static void UpdateTable(GunaDataGridView dgv, List<User> users)
        {
            dgv.Rows.Clear();
            foreach (User user in users)
            {
                addDataToTable(dgv, user);
            }
        }


        public static void setTableSettings(GunaDataGridView table)
        {
            foreach (DataGridViewColumn column in table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            table.AllowUserToResizeRows = false;
        }

        public static void updateRow(GunaDataGridView dgv, User user, int index)
        {
            dgv.Rows[index].Cells[1].Value = user.getFbToken();
            dgv.Rows[index].Cells[2].Value = user.getTdsToken();
            dgv.Rows[index].Cells[3].Value = user.getJobType();
            dgv.Rows[index].Cells[4].Value = Utilities.ToStringCustom(user.getJobId());
            dgv.Rows[index].Cells[5].Value = user.getProxy();
            dgv.Rows[index].Cells[6].Value = user.getStatus();
            SaveAccToFile("config\\account.ini", dgv);
            Program.mainForm.setInfoTable(dgv);
        }

        public static void updateColumn(GunaDataGridView dgv, int indexRow, int indexColumn, string value)
        {
            dgv.Rows[indexRow].Cells[indexColumn].Value = value;
            if (indexColumn != 6)
            {
                Program.mainForm.setInfoTable(dgv);
            }
        }
        public static string[] analyzeProxy(string proxy)
        {
            string[] arr = proxy.Split(':');
            return arr;
        }
        public static void ProxyAuthentication(IWebDriver driver, string proxyUser, string proxyPass)
        {
            driver.Navigate().GoToUrl("https://whatismyipaddress.com/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(CustomExpectedConditions.AlertIsPresent());

            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(proxyUser + System.Windows.Forms.Keys.Tab + proxyPass);
            alert.Accept();
        }


    }
    public static class CustomExpectedConditions
    {
        public static Func<IWebDriver, bool> AlertIsPresent()
        {
            return driver =>
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            };
        }
    }
}