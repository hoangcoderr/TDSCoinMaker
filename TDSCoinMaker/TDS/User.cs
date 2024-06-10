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

namespace TDSCoinMaker.TDS
{
    public class User
    {
        private int id = -1;
        private string tdsToken = string.Empty;
        public List<string> fbToken = new List<string>();

        private string job_type = "like";

        private List<string> job_id = new List<string>();

        private string proxy = string.Empty;

        private string status = string.Empty;

        public int currentJobIndex = 0;

        public int currentFbTokenIndex = 0;
        public User(int id, List<string> fbToken, string tdsToken, string job_type, List<string> job_id, string proxy, string status)
        {
            this.id = id;
            this.tdsToken = tdsToken;
            this.fbToken = fbToken;
            this.job_type = job_type;
            this.job_id = job_id;
            this.status = status;
            this.proxy = proxy;
        }
        public User(string tdsToken, string proxy)
        {
            this.proxy = proxy;
            this.tdsToken = tdsToken;
        }
        public int getId()
        {
            return id;
        }
        public string getTdsToken()
        {
            return tdsToken;
        }
        public List<string> getFbToken()
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
        public void getJobIdFromTDS()
        {
            this.status = Const.GETTING_TDS_JOB;
            Utilities.updateColumn(Program.mainForm.getInfoTable(), this.id, 6, status);
            job_id = TDSUtilities.getTDSJob(tdsToken, job_type);
            this.status = Const.GETTING_TDS_COMPLETE;
            Utilities.updateRow(Program.mainForm.getInfoTable(), this, id);
        }

        public void doJob()
        {
            if (job_id.Count == 0)
            {
                getJobIdFromTDS();
            }
            foreach (string job in job_id)
            {
                status = Const.DOING_JOB + job;
                Utilities.updateColumn(Program.mainForm.getInfoTable(), id, 6, status);
                OpenBrowser(Const.FACEBOOK_URL, 400, 600, fbToken[currentFbTokenIndex], job);
                Thread.Sleep(1000);
                if (TDSUtilities.claimTDSXu(tdsToken, job_type, job))
                {
                    status = Const.DONE_JOB + job;
                    Utilities.updateColumn(Program.mainForm.getInfoTable(), id, 6, status);
                }
                else
                {
                    status = Const.FAIL_JOB + job;
                    Utilities.updateColumn(Program.mainForm.getInfoTable(), id, 6, status);
                }
                Thread.Sleep(1000);
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
        public void setFbToken(List<string> fbToken)
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
        
        public void OpenBrowser(string url, int width, int height, string cookies, string urlPost)
        {
            FBUtilities.OpenBrowser(url, width, height, cookies, urlPost);
        }
    }
}
