using Microsoft.Win32.SafeHandles;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDSCoinMaker.FormEditting;
using TDSCoinMaker.TDS;
using TDSCoinMaker.Logger;

namespace TDSCoinMaker
{
    public partial class MainForm : Form
    {
        public LogForm logForm;

        public int getStartHold()
        {
            return (int)nbrStartHold.Value;
        }
        public void setStartHold(int value)
        {
            nbrStartHold.Value = value;
        }
        public int getStopHold()
        {
            return (int)nbrStopHold.Value;
        }
        public void setStopHold(int value)
        {
            nbrStopHold.Value = value;
        }
        public int getJobDone()
        {
            return (int)nbrJobDone.Value;
        }
        public void setJobDone(int value)
        {
            nbrJobDone.Value = value;
        }
        public int getStartWaitingJob()
        {
            return (int)nbrStartWaitingJob.Value;
        }
        public void setStartWaitingJob(int value)
        {
            nbrStartWaitingJob.Value = value;
        }
        public int getStopWaitingJob()
        {
            return (int)nbrStopWaitingJob.Value;
        }
        public void setStopWaitingJob(int value)
        {
            nbrStopWaitingJob.Value = value;
        }
        public DataGridView getInfoTable()
        {
            return infoTable;
        }
        public void setInfoTable(DataGridView infoTable)
        {
            this.infoTable = infoTable;
        }
        public MainForm()
        {
            FeatureDisable.DisableMaximizeBox(this);
            InitializeComponent();
        }
        public static List<User> users = new List<User>();
        private void MainForm_Load(object sender, EventArgs e)
        {
            Utilities.setTableSettings(infoTable);
            Utilities.LoadAccFromFile(Const.ACCOUNT_PATH, infoTable);
            Utilities.LoadClientConfig(Const.CLIENT_PATH, this);
        }
        public bool isFilledData()
        {
            if (string.IsNullOrEmpty(txtTDSToken.Text) || string.IsNullOrEmpty(txtFbToken.Text))
            {
                return false;
            }
            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isFilledData())
            {
                if (Utilities.isAvaiableToken(infoTable, txtTDSToken.Text, 2))
                {
                    MessageBox.Show("Token already exist");
                }
                else
                {
                    User user = new User(txtTDSToken.Text, txtProxy.Text, txtFbToken.Text);
                    user.setId(infoTable.RowCount);
                    users.Add(user);
                    Utilities.addDataToTable(infoTable, user);
                    txtFbToken.Text = string.Empty;
                    txtTDSToken.Text = string.Empty;
                    txtProxy.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Please fill all data");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //delete selected row and update users, save to file
            int rowIndex = infoTable.CurrentCell.RowIndex;
            infoTable.Rows.RemoveAt(rowIndex);
            users.RemoveAt(rowIndex);
            //update id of all users
            if (infoTable.RowCount > 0)
            {
                Utilities.UpdateTable(infoTable, users);
            }
            else if (infoTable.RowCount == 0)
            {
                File.WriteAllText("config\\account.ini", string.Empty);
            }
        }
        private void infoTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            User user = users[e.RowIndex];
            if (infoTable.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (e.ColumnIndex.Equals(Const.ACTION_INDEX))
                    user.StartJob();
                else
                    if (user.logForm is null)
                    MessageBox.Show("This process have not opened");
                    else
                    logForm.Show();
            }
            else
            {
                int thisRowIndex = int.Parse(infoTable.CurrentCell.RowIndex.ToString());
                txtFbToken.Text = infoTable.Rows[thisRowIndex].Cells[Const.FB_TOKEN_INDEX].Value.ToString();
                txtTDSToken.Text = infoTable.Rows[thisRowIndex].Cells[Const.TDS_TOKEN_INDEX].Value.ToString();
                txtProxy.Text = infoTable.Rows[thisRowIndex].Cells[Const.PROXY_INDEX].Value.ToString();
            }
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            /*  logForm = new LogForm("ID: " + this.id + " LOGGER");
              logForm.Show();
              logForm.AddLog("Test");
  */
            /*List<string> list1 = new List<string>();
            List<string> list2 = new List<string>();
            (list1, list2) = TDSUtilities.getTDSJob("TDSQfiETMyVmdlNnI6IiclZXZzJCLiInclR2bjdmbh9GaiojIyV2c1Jye", "reactcmt");
            Console.WriteLine(Utilities.ToStringCustom(list1));
            Console.WriteLine(Utilities.ToStringCustom(list2));*/
            // string cookies = "sb=B1QZZiHMdna-MeP9zWURAVIH;datr=B1QZZlb--U-cfPQ6RbKChXJR;wd=1872x1078;locale=vi_VN;ps_n=1;ps_l=1;c_user=100027816315772;xs=27%3Af6i30979g-3TDg%3A2%3A1718095082%3A-1%3A6172%3A%3AAcVGkaX5_naTsXH-Cm-NZkBi1hl9I_WLMeXAu2-bjA;fr=1Q220vr4bqFybnBzK.AWXs1NIu65LtLGgdVx4R660MFVQ.BmaR6b..AAA.0.0.BmaR6b.AWXBeIMr_-M;presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1718165249123%2C%22v%22%3A1%7D;";
            // FBUtilities.OpenBrowser(Const.FACEBOOK_URL, 400, 600, cookies, "1297405301196668", "care".ToLower());
            //IWebDriver driver = Utilities.SetupWebDriverWithProxy("116.110.101.27", "27434", "bestproxy.vn", "hoangdaica");

            // Sử dụng driver như bình thường
            //driver.Navigate().GoToUrl("https://whatismyipaddress.com/");

            // Đóng driver khi hoàn thành
            //driver.Quit();
            string cookie = "sb=B1QZZiHMdna-MeP9zWURAVIH;datr=B1QZZlb--U-cfPQ6RbKChXJR;ps_n=1;ps_l=1;c_user=100027816315772;xs=33%3AJNhuRGyhBpha_w%3A2%3A1718699689%3A-1%3A6172%3A%3AAcWC-R2Ee7PEeN24oerzSFy1HxNidcS4QDe-rYQD7Q;fr=1YnUNhmBpIZvqo7Um.AWU6jamcipqoDp-UYwBuBmmPnfI.BmcUbm..AAA.0.0.BmcUbm.AWVZsiYX55k;wd=1920x945;presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1718699753029%2C%22v%22%3A1%7D;m_page_voice=100027816315772;";
            // await FBUtilities.ReactionPost(cookie, "1297405301196668", "sad", "");
            //await FBUtilities.Test();
        }

        private void nbrStartHold_ValueChanged(object sender, EventArgs e)
        {
            Utilities.SaveClientConfig(Const.CLIENT_PATH, this);
        }

        private void nbrStopHold_ValueChanged(object sender, EventArgs e)
        {
            Utilities.SaveClientConfig(Const.CLIENT_PATH, this);
        }

        private void nbrJobDone_ValueChanged(object sender, EventArgs e)
        {
            Utilities.SaveClientConfig(Const.CLIENT_PATH, this);
        }

        private void nbrStartWaitingJob_ValueChanged(object sender, EventArgs e)
        {
            Utilities.SaveClientConfig(Const.CLIENT_PATH, this);
        }

        private void nbrStopWaitingJob_ValueChanged(object sender, EventArgs e)
        {
            Utilities.SaveClientConfig(Const.CLIENT_PATH, this);
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            logForm.AddLog("Random number + " + (new Random().Next()));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //txtFbToken.Text = infoTable.Rows[1].Cells[1].Value.ToString();
            if (isFilledData())
            {
                int thisRowIndex = int.Parse(infoTable.CurrentCell.RowIndex.ToString());
                infoTable.Rows[thisRowIndex].Cells[Const.FB_TOKEN_INDEX].Value = txtFbToken.Text;
                infoTable.Rows[thisRowIndex].Cells[Const.TDS_TOKEN_INDEX].Value = txtTDSToken.Text;
                infoTable.Rows[thisRowIndex].Cells[Const.PROXY_INDEX].Value = txtProxy.Text;
                Utilities.SaveAccToFile(Const.ACCOUNT_PATH, infoTable);
            }
        }
    }
}
