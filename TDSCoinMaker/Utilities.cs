using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDSCoinMaker.TDS;
using System.IO;

namespace TDSCoinMaker
{
    public class Utilities
    {
        public static string ToStringCustom(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item);
                sb.Append(", ");
            }
            return sb.ToString().TrimEnd(',', ' ');
        }
        public static void addDataToTable(DataGridView table, User user)
        {
            table.Rows.Add(user.getId(), user.getFbToken(), user.getTdsToken(), user.getJobType(), Utilities.ToStringCustom(user.getJobId()).ToString(), user.getProxy(), user.getStatus());
            SaveAccToFile("config\\account.ini", table);
        }
        public static bool isAvaiableToken(DataGridView dgv, string checkToken, int index)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[index].Value != null && row.Cells[index].Value.ToString().Equals(checkToken))
                {
                    return true;
                }
            }
            return false;
        }
        public static int getJobDone()
        {
            return Program.mainForm.getJobDone();
        }
        public static void LoadAccFromFile(string path, DataGridView dgv)
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    string[] data = line.Split('|');
                    User user = new User(int.Parse(data[0]), data[1], data[2], data[3], new List<string>(), data[5], string.Empty);
                    addDataToTable(dgv, user);
                    MainForm.users.Add(user);
                }
            }
            else
            {
                MessageBox.Show("Account file not found, create new one!");
                //create new file if not found
                File.Create(path).Close();
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
            }
            else
            {
                MessageBox.Show("Config file not found, create new one!");
                //create new file if not found
                File.Create(path).Close();
                File.WriteAllText(path, "0|0|0|0|0|");
            }

        }
        public static void SaveClientConfig(string path, MainForm mainform)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(mainform.getStartHold().ToString() + "|" + mainform.getStopHold() +"|"+ mainform.getJobDone() + "|" + mainform.getStartWaitingJob() + "|" + mainform.getStopWaitingJob());
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
        public static int getTimeToWait()
        {
            //return random time from Program.mainForm.getStartWaitingJob() to Program.mainForm.getStopWaitingJob()
            return new Random().Next(Program.mainForm.getStartWaitingJob(), Program.mainForm.getStopWaitingJob());
        }
        public static void SaveAccToFile(string path, DataGridView dgv)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        sw.WriteLine(row.Cells[0].Value.ToString() + "|" + row.Cells[1].Value.ToString() + "|" + row.Cells[2].Value.ToString() + "|" + row.Cells[3].Value.ToString() + "|" + row.Cells[4].Value.ToString() + "|" + row.Cells[5].Value.ToString() + "|" + row.Cells[6].Value.ToString());
                    }
                }
            }
        }

        public static void UpdateTable(DataGridView dgv, List<User> users)
        {
            dgv.Rows.Clear();
            foreach (User user in users)
            {
                addDataToTable(dgv, user);
            }
        }


        public static void setTableSettings(DataGridView table)
        {
            foreach (DataGridViewColumn column in table.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            table.AllowUserToResizeRows = false;
        }

        public static void updateRow(DataGridView dgv, User user, int index)
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

        public static void updateColumn(DataGridView dgv, int indexRow, int indexColumn, string value)
        {
            dgv.Rows[indexRow].Cells[indexColumn].Value = value;
            SaveAccToFile("config\\account.ini", dgv);
            Program.mainForm.setInfoTable(dgv);
        }

    }
}
