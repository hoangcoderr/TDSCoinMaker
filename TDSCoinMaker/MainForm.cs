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
using System.Net;
using System.Drawing;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;

namespace TDSCoinMaker
{
    public partial class MainForm : Form
    {

        public LogForm logForm = new LogForm("Hi");

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

        public int getJobToChangeAcc()
        {
            return (int)nbrJobToChangeAcc.Value;
        }

        public void setJobToChangeAcc(int value)
        {
            nbrJobToChangeAcc.Value = value;
        }

        public int getJobToStop()
        {
            return (int)nbrJobToStop.Value;
        }

        public void setJobToStop(int value)
        {
            nbrJobToStop.Value = value;
        }
        public GunaDataGridView getInfoTable()
        {
            return infoTable;
        }
        public void setInfoTable(GunaDataGridView infoTable)
        {
            this.infoTable = infoTable;
        }
        public MainForm()
        {
            CustomTitleBar customTitleBar = new CustomTitleBar(Const.PROGRAM_NAME + " " + Const.PROGRAM_VERSION);
            customTitleBar.Dock = DockStyle.Top;
            this.Controls.Add(customTitleBar);
            FormOption.SetTitleBarColor(this.Handle, System.Drawing.Color.Red);
            this.FormClosing += MainForm_FormClosing;
            InitializeComponent();
            this.ContextMenuStrip = cmsMenuOption;
        }

        public static List<User> users = new List<User>();
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            FormOption.FadeInForm(this, 8);
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
                if (Utilities.indexAvaiableToken(infoTable, txtTDSToken.Text, 2) != -1)
                {
                    int rowIndex = Utilities.indexAvaiableToken(infoTable, txtTDSToken.Text, 2);
                    User user = users.Find(x => x.getId() == Convert.ToInt32(infoTable.Rows[rowIndex].Cells[0].Value));
                    user.getFbToken().Add(txtFbToken.Text);
                    user.getProxy().Add(txtProxy.Text);
                    Utilities.updateColumn(infoTable, rowIndex, 1, Utilities.ToStringCustom(Utilities.getUID(user.getFbToken())));
                    Utilities.updateColumn(infoTable, rowIndex, 5, Utilities.ToStringCustom(user.getProxy()));
                    Utilities.SaveAccToFile(Const.ACCOUNT_PATH, infoTable);
                }
                else
                {
                    User user = new User(txtTDSToken.Text);
                    user.getFbToken().Add(txtFbToken.Text);
                    user.getProxy().Add(txtProxy.Text);
                    user.setId(infoTable.RowCount);
                    users.Add(user);
                    Utilities.addDataToTable(infoTable, user);
                    txtFbToken.Text = string.Empty;
                    txtTDSToken.Text = string.Empty;
                    txtProxy.Text = string.Empty;
                }
                infoTable.Rows[infoTable.RowCount - 1].Cells[Const.ACTION_INDEX].Value = "Start";
            }
            else
            {
                MessageBox.Show("Please fill all data");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (infoTable.CurrentCell == null)
            {
                MessageBox.Show("Please select a row to delete");
                return;
            }
            //delete selected row and update users, save to file
            int rowIndex = infoTable.CurrentCell.RowIndex;
            infoTable.Rows.RemoveAt(rowIndex);
            users.RemoveAt(rowIndex);
            Utilities.resetUserId(users);
            //update id of all users
            if (infoTable.RowCount > 0)
            {
                Utilities.UpdateTable(infoTable, users);
            }
            else if (infoTable.RowCount == 0)
            {
                File.WriteAllText("config\\account.ini", string.Empty);
            }
            for (int i = 0; i < infoTable.RowCount; i++)
            {
                User user = MainForm.users.Find(x => x.getId() == Convert.ToInt32(infoTable.Rows[i].Cells[0].Value));
                if (user.task == null)
                    infoTable.Rows[i].Cells[Const.ACTION_INDEX].Value = "Start";
                else
                    infoTable.Rows[i].Cells[Const.ACTION_INDEX].Value = "Stop";
            }
        }
        private void infoTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                infoTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red; // Thay đổi màu tùy ý
            }
            //kiem tra xem nguoi dung an vao index >=0 khong
            if (e.RowIndex < 0)
            {
                return;
            }
            User user = users[e.RowIndex];
            if (infoTable.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (e.ColumnIndex.Equals(Const.ACTION_INDEX))
                {
                    if (user.task != null)
                    {
                        infoTable.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        infoTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Const.START;
                    }
                    else
                    {
                        infoTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Const.STOP;
                        infoTable.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                    }


                    user.logForm.Show();
                    //user.logForm.Log("Dai ca hoang", Color.ForestGreen);
                    user.StartJob();
                }
                else
                    if (user.logForm == null || user.task == null)
                    {
                        MessageBox.Show("This process have not opened");
                    }
                    else
                    {
                        user.logForm.Show();
                    }


            }
            else
            {
                /* int thisRowIndex = int.Parse(infoTable.CurrentCell.RowIndex.ToString());
                 txtFbToken.Text = infoTable.Rows[thisRowIndex].Cells[Const.FB_TOKEN_INDEX].Value.ToString();
                 txtTDSToken.Text = infoTable.Rows[thisRowIndex].Cells[Const.TDS_TOKEN_INDEX].Value.ToString();
                 txtProxy.Text = infoTable.Rows[thisRowIndex].Cells[Const.PROXY_INDEX].Value.ToString();*/
            }
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            //Logger.Instance.ShowLogForm();
            //logForm.Show();
            MessageBox.Show(await Utilities.TestProxy(Const.PROXY_TO_GET_URL) ? "Yes" : "No");

            //await FBUtilities.getFacebookIdPost("457314160581340");
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
            // await FBUtilities.ReactionPost(cookie, "1297405301196668", "sad", "");
            string cookie = "sb=B1QZZiHMdna-MeP9zWURAVIH;datr=B1QZZlb--U-cfPQ6RbKChXJR;ps_n=1;ps_l=1;wd=1872x1078;c_user=100027816315772;m_page_voice=100027816315772;xs=11%3A8wzghiMItlDemQ%3A2%3A1718718895%3A-1%3A6172%3A%3AAcVoZiqNBoAqmEvZ41JNacqso4ZQC8JxMzYshH2B6g;fr=1kRw3m4DmVijKk4mu.AWU5xDeEvVlKULHDLgXoE2fBGj0.Bmcvpu..AAA.0.0.Bmcvpu.AWX5MR-huaw;presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1718811249052%2C%22v%22%3A1%7D;";
            //await FBUtilities.Test(cookie, "100002910703301_7615500045223610");
            //await FBUtilities.getFacebookIdPost("100034874357399_1103941204111681");
            //FBUtilities.Test();
            /*var proxyVia = new WebProxy
            {
                Address = new Uri($"http://103.79.143.201:49195"), // Ensure the address includes a scheme
                Credentials = new NetworkCredential("user49195", "OHFOjtHYUL") // Proxy credentials
            };
            Console.WriteLine((await Utilities.TestProxy(proxyVia) ? "GOOD CONNECT" : "BAD CONNECT"));*/

            //await FBUtilities.getFacebookIdPost("100002423876778_7654449104645809");
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
            AccountEditor accountEditor = new AccountEditor(users[0]);
            accountEditor.Show();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //txtFbToken.Text = infoTable.Rows[1].Cells[1].Value.ToString();
            /*          if (isFilledData())
                      {
                          int thisRowIndex = int.Parse(infoTable.CurrentCell.RowIndex.ToString());
                          infoTable.Rows[thisRowIndex].Cells[Const.FB_TOKEN_INDEX].Value = txtFbToken.Text;
                          infoTable.Rows[thisRowIndex].Cells[Const.TDS_TOKEN_INDEX].Value = txtTDSToken.Text;
                          infoTable.Rows[thisRowIndex].Cells[Const.PROXY_INDEX].Value = txtProxy.Text;
                          Utilities.UpdateUser(int.Parse(infoTable.Rows[thisRowIndex].Cells[0].Value.ToString()), this.infoTable);
                          Utilities.SaveAccToFile(Const.ACCOUNT_PATH, infoTable);
                      }*/
            //  
            //kiem tra xem nguoi dung da chon dong nao chua
            if (infoTable.CurrentCell == null)
            {
                MessageBox.Show("Please select a row to edit");
                return;
            }
            User user = users.Find(x => x.getId() == Convert.ToInt32(infoTable.Rows[infoTable.CurrentCell.RowIndex].Cells[0].Value));
            AccountEditor accountEditor = new AccountEditor(user);
            accountEditor.Show();
        }

        private void infoTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem cột được nhấn có phải là cột nút không
            if (infoTable.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Thay đổi văn bản của nút

            }
        }

        private void infoTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            User user = users[e.RowIndex];
            if (infoTable.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (e.ColumnIndex.Equals(Const.ACTION_INDEX))
                {


                }
                else
                {
                    if (user.logForm.Visible)
                    {
                        infoTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Const.CLOSE; // Đặt lại văn bản nếu form log đang hiển thị

                    }
                    else
                    {
                        infoTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Const.OPEN; // Thay đổi văn bản nếu form log đang ẩn

                    }
                }
            }
        }

        private void nbrJobToStop_ValueChanged(object sender, EventArgs e)
        {
            Utilities.SaveClientConfig(Const.CLIENT_PATH, this);
        }

        private void nbrJobToChangeAcc_ValueChanged(object sender, EventArgs e)
        {
            Utilities.SaveClientConfig(Const.CLIENT_PATH, this);
        }

        private void option1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Option 1");
        }

        private void txtTDSToken_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
