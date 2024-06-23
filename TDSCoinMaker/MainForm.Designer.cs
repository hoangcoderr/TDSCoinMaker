using System.Web.UI.WebControls;
using TDSCoinMaker.FormEditting;

namespace TDSCoinMaker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.infoTable = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token_acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TDS_Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TDS_Xu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionButtuon = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ShowLog = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nbrStopWaitingJob = new System.Windows.Forms.NumericUpDown();
            this.nbrStartWaitingJob = new System.Windows.Forms.NumericUpDown();
            this.nbrJobDone = new System.Windows.Forms.NumericUpDown();
            this.nbrStopHold = new System.Windows.Forms.NumericUpDown();
            this.nbrStartHold = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTDSToken = new System.Windows.Forms.TextBox();
            this.txtFbToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProxy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnTest1 = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.infoTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStopWaitingJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStartWaitingJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrJobDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStopHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStartHold)).BeginInit();
            this.SuspendLayout();
            // 
            // infoTable
            // 
            this.infoTable.AllowUserToAddRows = false;
            this.infoTable.AllowUserToDeleteRows = false;
            this.infoTable.AllowUserToResizeColumns = false;
            this.infoTable.ColumnHeadersHeight = 40;
            this.infoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.infoTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Token_acc,
            this.TDS_Token,
            this.Type_job,
            this.List_job,
            this.Proxy,
            this.Status,
            this.TDS_Xu,
            this.ActionButtuon,
            this.ShowLog});
            this.infoTable.Location = new System.Drawing.Point(2, 306);
            this.infoTable.Name = "infoTable";
            this.infoTable.ReadOnly = true;
            this.infoTable.RowHeadersVisible = false;
            this.infoTable.RowTemplate.Height = 30;
            this.infoTable.Size = new System.Drawing.Size(1373, 333);
            this.infoTable.TabIndex = 0;
            this.infoTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.infoTable_CellContentClick);
            this.infoTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.infoTable_CellFormatting);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 70;
            // 
            // Token_acc
            // 
            this.Token_acc.HeaderText = "Cookies_acc";
            this.Token_acc.Name = "Token_acc";
            this.Token_acc.ReadOnly = true;
            this.Token_acc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Token_acc.Width = 200;
            // 
            // TDS_Token
            // 
            this.TDS_Token.HeaderText = "TDS_Token";
            this.TDS_Token.Name = "TDS_Token";
            this.TDS_Token.ReadOnly = true;
            this.TDS_Token.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TDS_Token.Width = 200;
            // 
            // Type_job
            // 
            this.Type_job.HeaderText = "Type_job";
            this.Type_job.Name = "Type_job";
            this.Type_job.ReadOnly = true;
            // 
            // List_job
            // 
            this.List_job.HeaderText = "List_job";
            this.List_job.Name = "List_job";
            this.List_job.ReadOnly = true;
            this.List_job.Width = 200;
            // 
            // Proxy
            // 
            this.Proxy.HeaderText = "Proxy";
            this.Proxy.Name = "Proxy";
            this.Proxy.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 300;
            // 
            // TDS_Xu
            // 
            this.TDS_Xu.HeaderText = "TDS_Xu";
            this.TDS_Xu.Name = "TDS_Xu";
            this.TDS_Xu.ReadOnly = true;
            // 
            // ActionButtuon
            // 
            this.ActionButtuon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Green;
            this.ActionButtuon.DefaultCellStyle = dataGridViewCellStyle1;
            this.ActionButtuon.HeaderText = "Action";
            this.ActionButtuon.Name = "ActionButtuon";
            this.ActionButtuon.ReadOnly = true;
            this.ActionButtuon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionButtuon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ShowLog
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Green;
            this.ShowLog.DefaultCellStyle = dataGridViewCellStyle2;
            this.ShowLog.HeaderText = "Logger";
            this.ShowLog.Name = "ShowLog";
            this.ShowLog.ReadOnly = true;
            this.ShowLog.Width = 50;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1300, 271);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(472, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "after complete a job!";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(385, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "s from";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(310, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Wait";
            // 
            // nbrStopWaitingJob
            // 
            this.nbrStopWaitingJob.Location = new System.Drawing.Point(425, 86);
            this.nbrStopWaitingJob.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrStopWaitingJob.Name = "nbrStopWaitingJob";
            this.nbrStopWaitingJob.Size = new System.Drawing.Size(48, 20);
            this.nbrStopWaitingJob.TabIndex = 24;
            this.nbrStopWaitingJob.ValueChanged += new System.EventHandler(this.nbrStopWaitingJob_ValueChanged);
            // 
            // nbrStartWaitingJob
            // 
            this.nbrStartWaitingJob.Location = new System.Drawing.Point(338, 86);
            this.nbrStartWaitingJob.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrStartWaitingJob.Name = "nbrStartWaitingJob";
            this.nbrStartWaitingJob.Size = new System.Drawing.Size(41, 20);
            this.nbrStartWaitingJob.TabIndex = 23;
            this.nbrStartWaitingJob.ValueChanged += new System.EventHandler(this.nbrStartWaitingJob_ValueChanged);
            // 
            // nbrJobDone
            // 
            this.nbrJobDone.Location = new System.Drawing.Point(512, 59);
            this.nbrJobDone.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrJobDone.Name = "nbrJobDone";
            this.nbrJobDone.Size = new System.Drawing.Size(41, 20);
            this.nbrJobDone.TabIndex = 22;
            this.nbrJobDone.ValueChanged += new System.EventHandler(this.nbrJobDone_ValueChanged);
            // 
            // nbrStopHold
            // 
            this.nbrStopHold.Location = new System.Drawing.Point(425, 60);
            this.nbrStopHold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrStopHold.Name = "nbrStopHold";
            this.nbrStopHold.Size = new System.Drawing.Size(48, 20);
            this.nbrStopHold.TabIndex = 21;
            this.nbrStopHold.ValueChanged += new System.EventHandler(this.nbrStopHold_ValueChanged);
            // 
            // nbrStartHold
            // 
            this.nbrStartHold.Location = new System.Drawing.Point(338, 60);
            this.nbrStartHold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrStartHold.Name = "nbrStartHold";
            this.nbrStartHold.Size = new System.Drawing.Size(41, 20);
            this.nbrStartHold.TabIndex = 20;
            this.nbrStartHold.ValueChanged += new System.EventHandler(this.nbrStartHold_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(561, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "jobs done!";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(479, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "after";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(472, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "s from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Wait";
            // 
            // txtTDSToken
            // 
            this.txtTDSToken.Location = new System.Drawing.Point(77, 275);
            this.txtTDSToken.Name = "txtTDSToken";
            this.txtTDSToken.Size = new System.Drawing.Size(221, 20);
            this.txtTDSToken.TabIndex = 4;
            // 
            // txtFbToken
            // 
            this.txtFbToken.Location = new System.Drawing.Point(358, 275);
            this.txtFbToken.Name = "txtFbToken";
            this.txtFbToken.Size = new System.Drawing.Size(221, 20);
            this.txtFbToken.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "TDS Token";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(304, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Token_fb";
            // 
            // txtProxy
            // 
            this.txtProxy.Location = new System.Drawing.Point(654, 274);
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.Size = new System.Drawing.Size(221, 20);
            this.txtProxy.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(584, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Proxy(v6/v4)";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(1140, 271);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(743, 142);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(228, 55);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(987, 142);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(228, 55);
            this.btnTest1.TabIndex = 15;
            this.btnTest1.Text = "Test";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(1219, 272);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 635);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnTest1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.nbrStopWaitingJob);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.nbrStartWaitingJob);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nbrJobDone);
            this.Controls.Add(this.txtProxy);
            this.Controls.Add(this.nbrStopHold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nbrStartHold);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFbToken);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTDSToken);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.infoTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.infoTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStopWaitingJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStartWaitingJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrJobDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStopHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStartHold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView infoTable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTDSToken;
        private System.Windows.Forms.TextBox txtFbToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProxy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nbrStartHold;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nbrJobDone;
        private System.Windows.Forms.NumericUpDown nbrStopHold;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nbrStopWaitingJob;
        private System.Windows.Forms.NumericUpDown nbrStartWaitingJob;
        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token_acc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDS_Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn List_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDS_Xu;
        private System.Windows.Forms.DataGridViewButtonColumn ActionButtuon;
        private System.Windows.Forms.DataGridViewButtonColumn ShowLog;
    }
}

