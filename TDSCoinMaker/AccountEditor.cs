using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDSCoinMaker.FormEditting;
using TDSCoinMaker.TDS;

namespace TDSCoinMaker
{
    public partial class AccountEditor : Form
    {
        private List<string> accountList = new List<string>();
        private List<string> proxyList = new List<string>();
        private readonly int id = 0;
        private readonly string tdsToken = string.Empty;
        public AccountEditor(User user)
        {
            FormOption.FadeInForm(this, 20);
            InitializeComponent();
            
            this.accountList = user.getFbToken();
            this.proxyList = user.getProxy();
            this.id = user.getId();
            this.tdsToken = user.getTdsToken();
            CustomTitleBar customTitleBar = new CustomTitleBar(Const.EDIT + " ID: " + this.id);
            customTitleBar.Dock = DockStyle.Top;
            this.Controls.Add(customTitleBar);
            LoadAccToTable();
            FormOption.removeBorder(this);
        }
        private void LoadAccToTable()
        {
            // Load account to table
            // id is index of account in list
            txtTDSToken.Text = tdsToken;
            for (int id = 0; id < accountList.Count; id++)
            {
                editorTable.Rows.Add(id, accountList[id], proxyList[id]);
            }
        }
        private void AccountEditor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private bool isEmpty()
        {
            return txtCookie.Text == "" || txtProxyOfThisAcc.Text == "";
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            int rowIndex = editorTable.CurrentCell.RowIndex;
            editorTable.Rows.RemoveAt(rowIndex);
            //update id of the rest
            for (int i = 0; i < editorTable.Rows.Count; i++)
            {
                editorTable.Rows[i].Cells[0].Value = i;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Please fill all the blank");
            }
            else
            {
                editorTable.Rows.Add(editorTable.Rows.Count, txtCookie.Text, txtProxyOfThisAcc.Text);
            }
        }


        public void UpdateData()
        {
            accountList = new List<string>();
            proxyList = new List<string>();
            for (int i = 0; i < editorTable.Rows.Count; i++)
            {
                accountList.Add(editorTable.Rows[i].Cells[1].Value.ToString());
                proxyList.Add(editorTable.Rows[i].Cells[2].Value.ToString());
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateData();
            try
            {
                MainForm.users[id].setFbToken(accountList);
                MainForm.users[id].setProxy(proxyList);
                MainForm.users[id].setTdsToken(txtTDSToken.Text);
                Utilities.UpdateTable(Program.mainForm.getInfoTable(), MainForm.users);
                MessageBox.Show("Edit sucessfully!");
            }
            catch
            {
                MessageBox.Show("Unexpected error, please try again later");
            }
        }

        private void editorTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string newValue = editorTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void editorTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
