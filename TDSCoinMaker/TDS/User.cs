using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TDSCoinMaker.FormEditting;
using System.Net.NetworkInformation;
using System.Data;
using System.Linq.Expressions;
using TDSCoinMaker.Logger;
using OpenQA.Selenium.DevTools.V123.DOM;
using System.Net;
using System.Windows.Forms;
namespace TDSCoinMaker.TDS
{
    public class User
    {
        private bool isStart = false;
        private int id = -1;
        private string tdsToken = string.Empty;
        public string fbToken = string.Empty;
        public WebProxy webProxy = null;
        private string job_type = "likevip";

        private List<string> type_of_job = new List<string>();

        private List<string> job_id = new List<string>();

        private string proxy = string.Empty;

        private string status = string.Empty;

        public int currentJobIndex = 0;

        public int currentFbTokenIndex = 0;

        public string fbId = string.Empty;

        public int jobCompleted = 0;

        public int jobDid = 0;

        public int tdsXu = 0;

        public Task task;

        public LogForm logForm;

        private CancellationTokenSource cts = new CancellationTokenSource();
        public User(int id, string fbToken, string tdsToken, string job_type, List<string> job_id, string proxy, string status)
        {
            this.id = id;
            this.tdsToken = tdsToken;
            this.fbToken = fbToken;
            this.job_type = job_type;
            this.job_id = job_id;
            this.status = status;
            this.proxy = proxy;
            logForm = new LogForm("ID: " + this.id);
        }
        public User(string tdsToken, string proxy, string fbToken)
        {
            this.proxy = proxy;
            this.tdsToken = tdsToken;
            this.fbToken = fbToken;
            logForm = new LogForm("ID: " + this.id);
        }
        public int getId()
        {
            return id;
        }

        public async Task Test(CancellationToken cancellationToken)
        {
            int count = 0;
            while (isTaskRunning)
            {
                logForm.Log(count++ + "|" + DateTime.Now.ToString("HH:mm:ss") + "|LIKE|52300024123123123|+600 XU|1000000000", System.Drawing.Color.IndianRed);
                try
                {
                    await Task.Delay(1000, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    // Handle the cancellation here if needed
                    break; // Exit the loop if the task was canceled
                }
            }
        }

        private bool isTaskRunning = false;
        public bool getIsTaskRunning()
        {
            return isTaskRunning;
        }
        public void setIsTaskRunning(bool isTaskRunning)
        {
            this.isTaskRunning = isTaskRunning;
        }
        public async void StartJob()
        {
            if (isTaskRunning)
            {
                MessageBox.Show("Stopping");
                UpdateStatus(Const.DOING_LAST_JOB);
                isTaskRunning = false;
                cts.Cancel();
                
                cts = new CancellationTokenSource();
                isTaskRunning = false; // Cập nhật cờ trước khi khởi chạy Task mới
                task = null;// Đặt lại cờ
                return; // Thoát sớm nếu Task đang chạy
            }

           
            task = Task.Run(async () =>
            {
                try
                {
                    isTaskRunning = true;
                    //await Test(cts.Token);
                    await doJob(cts.Token);
                }
                catch (OperationCanceledException)
                {
                    // Xử lý khi Task bị hủy
                }
                finally
                {
                    isTaskRunning = false;
                     // Đặt lại cờ khi Task hoàn thành hoặc bị hủy
                }
            }, cts.Token);
        }
        public void StopJob()
        {
            cts.Cancel();
        }
        public void setFbId()
        {

            string[] temp = FBUtilities.cookiesGetter(fbToken);
            fbId = temp[0];

        }
        public void resetJobDone()
        {
            jobCompleted = 0;
        }
        public string getTdsToken()
        {
            return tdsToken;
        }
        public string getFbToken()
        {
            return fbToken;
        }
        public string getJobType()
        {
            return job_type;
        }
        public List<string> getJobId()
        {
            return job_id;
        }
        public string getStatus()
        {
            return status;
        }
        public void getJobIdFromTDS(string job_type)
        {
            UpdateStatus(Const.GETTING_TDS_JOB);
            try
            {
                (type_of_job, job_id) = TDSUtilities.getTDSJob(tdsToken, job_type, this);
            }
            catch
            {
                UpdateStatus(Const.DID_ENOUGH_JOB);
                return;
            }
            if (type_of_job != null && job_id != null)
            {
                Console.WriteLine(Utilities.ToStringCustom(type_of_job));
                Console.WriteLine(Utilities.ToStringCustom(job_id));
                UpdateStatus(Const.GETTING_TDS_COMPLETE);
            }
            return;
        }
        public void UpdateStatus(string stringUpdating)
        {
            this.status = stringUpdating;
            Utilities.updateColumn(Program.mainForm.getInfoTable(), this.id, 6, status);
        }
        public void UpdateListJob(string job_type)
        {
            this.job_type = job_type;
            Utilities.updateColumn(Program.mainForm.getInfoTable(), this.id, 3, job_type);
            getJobIdFromTDS(this.job_type);
            Utilities.updateColumn(Program.mainForm.getInfoTable(), this.id, 4, Utilities.ToStringCustom(job_id));
        }
        public void configAccToDoJob()
        {
            TDSUtilities.setAccToDoJob(tdsToken, fbId);
        }
        public int updateTdsXu(int bonusXu)
        {
            this.tdsXu += bonusXu;
            Utilities.updateColumn(Program.mainForm.getInfoTable(), this.id, Const.TDS_XU_INDEX, tdsXu.ToString());
            return tdsXu;
        }
        public int getTimeToWait()
        {
            return Utilities.getTimeToWait();
        }
        private static Mutex mutex = new Mutex();
        public async Task doJob(CancellationToken cancellationToken)
        {
            jobDid = 0;
            UpdateStatus("GETTING INFO OF TDS ACC AND COOKIE ...");
         
            while (true)
            {
                
                this.tdsXu = TDSUtilities.getTDSInfo(tdsToken, logForm);
                updateTdsXu(0);
                if (proxy != string.Empty)
                {
                    string[] proxyAtr = Utilities.analyzeProxy(proxy);
                    webProxy = new WebProxy
                    {
                        Address = new Uri($"http://{proxyAtr[0]}:{proxyAtr[1]}"), // Ensure the address includes a scheme
                        Credentials = new NetworkCredential(proxyAtr[2], proxyAtr[3]) // Proxy credentials
                    };
                    if (await FBUtilities.isCookieAlive(fbToken, webProxy))
                    {
                        UpdateStatus("COOKIE ALIVE");
                    }
                    else
                    {
                        UpdateStatus("COOKIE DEAD");
                        cts.Cancel(); // Hủy bỏ CancellationTokenSource
                        return;
                    }
                }
                else
                {
                    if (await FBUtilities.isCookieAlive(fbToken))
                    {
                        UpdateStatus("COOKIE ALIVE NO PROXY");
                    }
                    else
                    {
                        UpdateStatus("COOKIE DEAD NO PROXY");
                        cts.Cancel(); // Hủy bỏ CancellationTokenSource
                        return;
                    }
                }
                await Task.Delay(3000);
                for (int j = 0; j < Const.LIST_TYPE_JOB.Length; j++)
                {
                    if (!isTaskRunning)
                    {
                        UpdateStatus("STOPPED");
                        return;
                    }
                    UpdateListJob(Const.LIST_TYPE_JOB[j]);
                    if (job_id == null)
                    {
                        if (!isTaskRunning)
                        {
                            UpdateStatus("STOPPED");
                            return;
                        }
                        continue;
                    }
                    for (int i = 0; i < job_id.Count; i++)
                    {
                        if (!isTaskRunning)
                        {
                            UpdateStatus("STOPPED");
                            return;
                        }
                        UpdateStatus(Const.DOING_JOB + type_of_job[i].ToUpper() + " " + job_id[i]);
                        //OpenBrowser(Const.FACEBOOK_URL, 400, 600, fbToken, job_id[i], type_of_job[i].ToLower(), proxy);
                        string output = await ReactionPost(fbToken, job_id[i], type_of_job[i].ToLower(), webProxy);
                        Console.WriteLine("Output: " + output);
                        if (output.Equals("proxy error"))
                        {

                            UpdateStatus("PROXY ERROR, STOPPED!");
                            cts.Cancel(); // Hủy bỏ CancellationTokenSource
                            return;
                        }
                        await Task.Delay(500);
                        if (TDSUtilities.claimTDSXu(tdsToken, type_of_job[i].ToUpper(), job_id[i]))
                        {
                            UpdateStatus(Const.DONE_JOB + job_id[i]);
                            logForm.Log($"{jobDid++}|{DateTime.Now.ToString("HH:mm:ss")}|{type_of_job[i].ToUpper()}|{job_id[i]}|{Const.LIST_XU_CLAIM_BY_JOB[j]}|{updateTdsXu(Const.LIST_XU_CLAIM_BY_JOB[j])}", System.Drawing.Color.PaleGreen);
                        }
                        else
                        {
                            UpdateStatus(Const.FAIL_JOB + job_id[i]);
                            if (!output.Equals("invalid"))
                            {
                                logForm.Log($"{jobDid++}|{DateTime.Now.ToString("HH:mm:ss")}|{type_of_job[i].ToUpper()}|{job_id[i]}|0|{this.tdsXu}|MISSED", System.Drawing.Color.PaleGreen);
                            }
                            //.printFailedLog("FAIL BY MISSED JOB", type_of_job[i], job_id[i],  this.tdsXu.ToString());
                            else
                            {
                                logForm.Log($"{jobDid++}|{DateTime.Now.ToString("HH:mm:ss")}|{type_of_job[i].ToUpper()}|{job_id[i]}|0|{this.tdsXu}|INVALID", System.Drawing.Color.PaleGreen);
                                //logForm.printFailedLog("FAIL BY INVALID LINK", type_of_job[i], job_id[i], this.tdsXu.ToString());
                                //in job_id[i] + type_of_job[i] + fail ra file log.txt
                                mutex.WaitOne();
                                try
                                {
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt", true))
                                    {
                                        file.WriteLine(job_id[i] + "|" + type_of_job[i] + "|FAIL");
                                    }
                                }
                                finally
                                {
                                    mutex.ReleaseMutex();
                                }
                            }
                        }

                        if (!output.Equals("invalid"))
                        {
                            jobCompleted++;
                            int waitForNextJob = this.getTimeToWait();
                            while (waitForNextJob > 0)
                            {
                                UpdateStatus(Const.DO_NEXT_JOB_IN + waitForNextJob + "s");
                                await Task.Delay(1000);
                                if (!isTaskRunning)
                                {
                                    UpdateStatus("STOPPED");
                                    return;
                                }
                                waitForNextJob--;
                            }
                        }


                        if (jobCompleted == Utilities.getJobDone())
                        {
                            int timeToHold = Utilities.getTimeToHold();
                            while (timeToHold > 0)
                            {
                                UpdateStatus(Const.DO_ENOUGH_JOB + timeToHold + "s");
                                await Task.Delay(1000);
                                if (!isTaskRunning)
                                {
                                    UpdateStatus("STOPPED");
                                    return;
                                }
                                timeToHold--;
                            }
                            resetJobDone();
                            break;
                        }
                    }
                    job_id = new List<string>();
                    type_of_job = new List<string>();
                }
            }
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public void setTdsToken(string tdsToken)
        {
            this.tdsToken = tdsToken;
        }
        public void setFbToken(string fbToken)
        {
            this.fbToken = fbToken;
        }
        public void setJobType(string job_type)
        {
            this.job_type = job_type;
        }
        public void setJobId(List<string> job_id)
        {
            this.job_id = job_id;
        }
        public void setStatus(string status)
        {
            this.status = status;
        }
        public void setProxy(string proxy)
        {
            this.proxy = proxy;
        }
        public string getProxy()
        {
            return proxy;
        }

        public void OpenBrowser(string url, int width, int height, string cookies, string urlPost, string typeReaction, string proxy)
        {
            FBUtilities.OpenBrowser(url, width, height, cookies, urlPost, typeReaction.ToLower(), proxy);
        }
        public async Task<string> ReactionPost(string cookie, string urlPost, string typeReaction, WebProxy proxy)
        {
            Console.WriteLine("Da truyen vao: " + $"{cookie}|{urlPost}|{typeReaction}");
            return await FBUtilities.ReactionPost(cookie, urlPost, typeReaction.ToLower(), proxy);
        }
    }
}
