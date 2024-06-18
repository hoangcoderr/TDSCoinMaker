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
namespace TDSCoinMaker.TDS
{
    public class User
    {
        private bool isStart = false;
        private int id = -1;
        private string tdsToken = string.Empty;
        public string fbToken = string.Empty;

        private string job_type = "likevip";

        private List<string> type_of_job = new List<string>();

        private List<string> job_id = new List<string>();

        private string proxy = string.Empty;

        private string status = string.Empty;

        public int currentJobIndex = 0;

        public int currentFbTokenIndex = 0;

        public string fbId = string.Empty;

        public int jobCompleted = 0;

        public int tdsXu = 0;

        public LogForm logForm = new LogForm();

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
        }
        public User(string tdsToken, string proxy, string fbToken)
        {
            this.proxy = proxy;
            this.tdsToken = tdsToken;
            this.fbToken = fbToken;
        }
        public int getId()
        {
            return id;
        }
        public void StartJob()
        {
            Thread newThread = new Thread(() =>
            {
                doJob(cts.Token);
            });

            newThread.Start();
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
            (type_of_job, job_id) = TDSUtilities.getTDSJob(tdsToken, job_type);
            UpdateStatus(Const.GETTING_TDS_COMPLETE);
            Console.WriteLine(Utilities.ToStringCustom(type_of_job));
            Console.WriteLine(Utilities.ToStringCustom(job_id));
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
        public void doJob(CancellationToken cancellationToken)
        {
            
            Task.Run(() =>
            {
                logForm = new LogForm("ID: " + this.id + " LOGGER");
                logForm.ShowDialog(); // Sử dụng ShowDialog để đảm bảo form được mở trong Task
            });

            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    UpdateStatus("STOPED");
                    break;
                }
                this.tdsXu = TDSUtilities.getTDSInfo(tdsToken);
                updateTdsXu(0);
                for (int j = 0; j < 4; j++)
                {
                    UpdateListJob(Const.LIST_TYPE_JOB[j]);
                   
                    
                    for (int i = 0; i < job_id.Count; i++)
                    {
                        UpdateStatus(Const.DOING_JOB + type_of_job[i].ToUpper() + " " + job_id[i]);
                        //OpenBrowser(Const.FACEBOOK_URL, 400, 600, fbToken, job_id[i], type_of_job[i].ToLower(), proxy);
                        ReactionPost(fbToken, job_id[i], type_of_job[i].ToLower(), proxy);
                        Thread.Sleep(5000);
                        if (TDSUtilities.claimTDSXu(tdsToken, type_of_job[i].ToUpper(), job_id[i]))
                        {
                            UpdateStatus(Const.DONE_JOB + job_id[i]);
                            
                            logForm.AddLog($"COMPLETE|{job_id[i]}|{type_of_job[i]}|+{Const.LIST_XU_CLAIM_BY_JOB[j]}|{updateTdsXu(Const.LIST_XU_CLAIM_BY_JOB[j])}");
                        }
                        else
                        {
                            UpdateStatus(Const.FAIL_JOB + job_id[i]);
                            logForm.AddLog("FAIL|" + job_id[i] + "|" + type_of_job[i]);
                        }
                        jobCompleted++;
                        int waitForNextJob = Utilities.getTimeToWait();
                        UpdateStatus(Const.DO_NEXT_JOB_IN + waitForNextJob + "s");
                        Thread.Sleep(waitForNextJob * 1000);
                        if (jobCompleted == Utilities.getJobDone())
                        {
                            int timeToHold = Utilities.getTimeToHold();
                            UpdateStatus(Const.DO_ENOUGH_JOB + timeToHold + "s");
                            resetJobDone();
                            Thread.Sleep(timeToHold * 1000);
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
        public async void ReactionPost(string cookie, string urlPost, string typeReaction, string proxy)
        {
            Console.WriteLine("Da truyen vao: " + $"{cookie}|{urlPost}|{typeReaction}");
            await FBUtilities.ReactionPost(cookie, urlPost, typeReaction.ToLower(), proxy);
        }
    }
}
