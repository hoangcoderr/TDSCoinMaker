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
            this.infoTable = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token_acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TDS_Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionButtuon = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTDSToken = new System.Windows.Forms.TextBox();
            this.txtFbToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProxy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.infoTable)).BeginInit();
            this.SuspendLayout();
            // 
            // infoTable
            // 
            this.infoTable.AllowUserToAddRows = false;
            this.infoTable.AllowUserToDeleteRows = false;
            this.infoTable.AllowUserToResizeColumns = false;
            this.infoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.infoTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Token_acc,
            this.TDS_Token,
            this.Type_job,
            this.List_job,
            this.Proxy,
            this.Status,
            this.ActionButtuon});
            this.infoTable.Location = new System.Drawing.Point(2, 392);
            this.infoTable.Name = "infoTable";
            this.infoTable.ReadOnly = true;
            this.infoTable.RowHeadersVisible = false;
            this.infoTable.Size = new System.Drawing.Size(1317, 357);
            this.infoTable.TabIndex = 0;
            this.infoTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.infoTable_CellContentClick);
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
            this.Token_acc.HeaderText = "Token_acc";
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
            this.Status.Width = 400;
            // 
            // ActionButtuon
            // 
            this.ActionButtuon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActionButtuon.HeaderText = "Action";
            this.ActionButtuon.Name = "ActionButtuon";
            this.ActionButtuon.ReadOnly = true;
            this.ActionButtuon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionButtuon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1231, 360);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(51, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 224);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(678, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 224);
            this.panel2.TabIndex = 3;
            // 
            // txtTDSToken
            // 
            this.txtTDSToken.Location = new System.Drawing.Point(77, 361);
            this.txtTDSToken.Name = "txtTDSToken";
            this.txtTDSToken.Size = new System.Drawing.Size(221, 20);
            this.txtTDSToken.TabIndex = 4;
            // 
            // txtFbToken
            // 
            this.txtFbToken.Location = new System.Drawing.Point(351, 361);
            this.txtFbToken.Name = "txtFbToken";
            this.txtFbToken.Size = new System.Drawing.Size(221, 20);
            this.txtFbToken.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "TDS Token";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Token_fb";
            // 
            // txtProxy
            // 
            this.txtProxy.Location = new System.Drawing.Point(641, 360);
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.Size = new System.Drawing.Size(221, 20);
            this.txtProxy.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(584, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Proxy(v6)";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(1154, 360);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(465, 263);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(228, 55);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 749);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProxy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFbToken);
            this.Controls.Add(this.txtTDSToken);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.infoTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.infoTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView infoTable;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTDSToken;
        private System.Windows.Forms.TextBox txtFbToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProxy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token_acc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDS_Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn List_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewButtonColumn ActionButtuon;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnTest;
    }
}

