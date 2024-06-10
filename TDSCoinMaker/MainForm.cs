using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDSCoinMaker.FormEditting;
using TDSCoinMaker.TDS;


namespace TDSCoinMaker
{
    public partial class MainForm : Form
    {
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
            Utilities.LoadAccFromFile("config\\account.ini", infoTable);
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
                    foreach (User userToAdd in users)
                    {
                        if (userToAdd.getTdsToken().Equals(txtTDSToken.Text))
                        {
                            for (int i = 0; i < userToAdd.getFbToken().Count; i++)
                            {
                                if (userToAdd.getFbToken()[i].Equals(txtFbToken.Text))
                                {
                                    MessageBox.Show("This token is already added");
                                    return;
                                }
                            }
                            userToAdd.getFbToken().Add(txtFbToken.Text);
                            Utilities.updateRow(infoTable, userToAdd, userToAdd.getId());
                        }
                    }
                }
                else
                {
                    User user = new User(txtTDSToken.Text, txtProxy.Text);
                    user.getFbToken().Add(txtFbToken.Text);
                    user.setId(infoTable.RowCount);
                    users.Add(user);
                    Utilities.addDataToTable(infoTable, user);
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
            if (infoTable.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //  MessageBox.Show("Content in this index of this row = " + infoTable.Rows[e.RowIndex].Cells[0].Value.ToString());
                //  User user = users[e.RowIndex];
                //  FBUtilities.OpenBrowser("https://www.facebook.com", 400, 600, user.getFbToken()[user.currentFbTokenIndex], "1231684234886409");

                User user = users[e.RowIndex];
                Task.Run(() => user.doJob());
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Utilities.ToStringCustom(TDSUtilities.getTDSJob("TDSQfiETMyVmdlNnI6IiclZXZzJCLiInclR2bjdmbh9GaiojIyV2c1Jye", "like")));
        }
    }
}
