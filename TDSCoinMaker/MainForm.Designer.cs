using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Drawing;
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.infoTable = new Guna.UI.WinForms.GunaDataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Token_acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TDS_Token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.List_job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TDS_Xu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ShowLog = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmsMenuOption = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.option1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.option2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.option3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFbToken = new Guna.UI.WinForms.GunaTextBox();
            this.txtTDSToken = new Guna.UI.WinForms.GunaTextBox();
            this.txtProxy = new Guna.UI.WinForms.GunaTextBox();
            this.btnRemove = new Guna.UI.WinForms.GunaGradientButton();
            this.btnEdit = new Guna.UI.WinForms.GunaGradientButton();
            this.btnAdd = new Guna.UI.WinForms.GunaGradientButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nbrStartHold = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nbrStopHold = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nbrJobDone = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nbrStartWaitingJob = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nbrStopWaitingJob = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nbrJobToChangeAcc = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nbrJobToStop = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnTest1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.infoTable)).BeginInit();
            this.cmsMenuOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStartHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStopHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrJobDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStartWaitingJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStopWaitingJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrJobToChangeAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrJobToStop)).BeginInit();
            this.SuspendLayout();
            // 
            // infoTable
            // 
            this.infoTable.AllowUserToAddRows = false;
            this.infoTable.AllowUserToDeleteRows = false;
            this.infoTable.AllowUserToResizeColumns = false;
            this.infoTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.infoTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.infoTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.infoTable.BackgroundColor = System.Drawing.Color.White;
            this.infoTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.infoTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.infoTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.ActionButton,
            this.ShowLog});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.MediumOrchid;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.infoTable.DefaultCellStyle = dataGridViewCellStyle5;
            this.infoTable.EnableHeadersVisualStyles = false;
            this.infoTable.GridColor = System.Drawing.Color.Silver;
            this.infoTable.Location = new System.Drawing.Point(2, 306);
            this.infoTable.Name = "infoTable";
            this.infoTable.ReadOnly = true;
            this.infoTable.RowHeadersVisible = false;
            this.infoTable.RowTemplate.Height = 30;
            this.infoTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.infoTable.Size = new System.Drawing.Size(1373, 384);
            this.infoTable.TabIndex = 0;
            this.infoTable.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.infoTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.infoTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.infoTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.infoTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.infoTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.infoTable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.infoTable.ThemeStyle.GridColor = System.Drawing.Color.Silver;
            this.infoTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.infoTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.infoTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.infoTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.infoTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.infoTable.ThemeStyle.HeaderStyle.Height = 40;
            this.infoTable.ThemeStyle.ReadOnly = true;
            this.infoTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.infoTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.infoTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.infoTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.infoTable.ThemeStyle.RowsStyle.Height = 30;
            this.infoTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.infoTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.infoTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.infoTable_CellContentClick);
            this.infoTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.infoTable_CellFormatting);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Token_acc
            // 
            this.Token_acc.HeaderText = "Cookies_acc";
            this.Token_acc.Name = "Token_acc";
            this.Token_acc.ReadOnly = true;
            this.Token_acc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TDS_Token
            // 
            this.TDS_Token.HeaderText = "TDS_Token";
            this.TDS_Token.Name = "TDS_Token";
            this.TDS_Token.ReadOnly = true;
            this.TDS_Token.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // 
            // TDS_Xu
            // 
            this.TDS_Xu.HeaderText = "TDS_Xu";
            this.TDS_Xu.Name = "TDS_Xu";
            this.TDS_Xu.ReadOnly = true;
            // 
            // ActionButton
            // 
            this.ActionButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Green;
            this.ActionButton.DefaultCellStyle = dataGridViewCellStyle3;
            this.ActionButton.HeaderText = "Action";
            this.ActionButton.Name = "ActionButton";
            this.ActionButton.ReadOnly = true;
            this.ActionButton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ActionButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ShowLog
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Green;
            this.ShowLog.DefaultCellStyle = dataGridViewCellStyle4;
            this.ShowLog.HeaderText = "Logger";
            this.ShowLog.Name = "ShowLog";
            this.ShowLog.ReadOnly = true;
            this.ShowLog.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(270, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 20);
            this.label11.TabIndex = 27;
            this.label11.Text = "after complete a job!";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.Location = new System.Drawing.Point(143, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "s from";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(29, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Wait";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(395, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "jobs done!";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(268, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "after";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "s";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(141, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "s from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(29, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Wait";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(709, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Proxy(v6/v4)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(27, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(156, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "Stop doing jobs after";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(270, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 20);
            this.label13.TabIndex = 31;
            this.label13.Text = "jobs!";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label14.Location = new System.Drawing.Point(29, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 20);
            this.label14.TabIndex = 33;
            this.label14.Text = "Change acc at";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label15.Location = new System.Drawing.Point(224, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 20);
            this.label15.TabIndex = 34;
            this.label15.Text = "jobs!";
            // 
            // cmsMenuOption
            // 
            this.cmsMenuOption.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.option1ToolStripMenuItem,
            this.option2ToolStripMenuItem,
            this.option3ToolStripMenuItem});
            this.cmsMenuOption.Name = "cmsMenuOption";
            this.cmsMenuOption.Size = new System.Drawing.Size(121, 70);
            // 
            // option1ToolStripMenuItem
            // 
            this.option1ToolStripMenuItem.Name = "option1ToolStripMenuItem";
            this.option1ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.option1ToolStripMenuItem.Text = "Option 1";
            this.option1ToolStripMenuItem.Click += new System.EventHandler(this.option1ToolStripMenuItem_Click);
            // 
            // option2ToolStripMenuItem
            // 
            this.option2ToolStripMenuItem.Name = "option2ToolStripMenuItem";
            this.option2ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.option2ToolStripMenuItem.Text = "Option 2";
            // 
            // option3ToolStripMenuItem
            // 
            this.option3ToolStripMenuItem.Name = "option3ToolStripMenuItem";
            this.option3ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.option3ToolStripMenuItem.Text = "Option 3";
            // 
            // txtFbToken
            // 
            this.txtFbToken.BackColor = System.Drawing.Color.Transparent;
            this.txtFbToken.BaseColor = System.Drawing.Color.White;
            this.txtFbToken.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFbToken.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFbToken.FocusedBaseColor = System.Drawing.Color.White;
            this.txtFbToken.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtFbToken.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFbToken.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFbToken.Location = new System.Drawing.Point(59, 269);
            this.txtFbToken.Name = "txtFbToken";
            this.txtFbToken.PasswordChar = '\0';
            this.txtFbToken.Radius = 10;
            this.txtFbToken.SelectedText = "";
            this.txtFbToken.Size = new System.Drawing.Size(330, 26);
            this.txtFbToken.TabIndex = 35;
            // 
            // txtTDSToken
            // 
            this.txtTDSToken.BackColor = System.Drawing.Color.Transparent;
            this.txtTDSToken.BaseColor = System.Drawing.Color.White;
            this.txtTDSToken.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTDSToken.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTDSToken.FocusedBaseColor = System.Drawing.Color.White;
            this.txtTDSToken.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtTDSToken.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTDSToken.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTDSToken.Location = new System.Drawing.Point(473, 269);
            this.txtTDSToken.Name = "txtTDSToken";
            this.txtTDSToken.PasswordChar = '\0';
            this.txtTDSToken.Radius = 10;
            this.txtTDSToken.SelectedText = "";
            this.txtTDSToken.Size = new System.Drawing.Size(230, 26);
            this.txtTDSToken.TabIndex = 39;
            this.txtTDSToken.TextChanged += new System.EventHandler(this.txtTDSToken_TextChanged);
            // 
            // txtProxy
            // 
            this.txtProxy.BackColor = System.Drawing.Color.Transparent;
            this.txtProxy.BaseColor = System.Drawing.Color.White;
            this.txtProxy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProxy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProxy.FocusedBaseColor = System.Drawing.Color.White;
            this.txtProxy.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtProxy.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtProxy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProxy.Location = new System.Drawing.Point(795, 269);
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.PasswordChar = '\0';
            this.txtProxy.Radius = 10;
            this.txtProxy.SelectedText = "";
            this.txtProxy.Size = new System.Drawing.Size(228, 26);
            this.txtProxy.TabIndex = 40;
            // 
            // btnRemove
            // 
            this.btnRemove.Animated = true;
            this.btnRemove.AnimationHoverSpeed = 0.07F;
            this.btnRemove.AnimationSpeed = 0.03F;
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.BaseColor1 = System.Drawing.Color.DarkRed;
            this.btnRemove.BaseColor2 = System.Drawing.Color.Red;
            this.btnRemove.BorderColor = System.Drawing.Color.Black;
            this.btnRemove.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRemove.FocusedColor = System.Drawing.Color.Empty;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.ImageSize = new System.Drawing.Size(20, 20);
            this.btnRemove.Location = new System.Drawing.Point(1051, 259);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemove.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRemove.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnRemove.OnHoverForeColor = System.Drawing.Color.White;
            this.btnRemove.OnHoverImage = null;
            this.btnRemove.OnPressedColor = System.Drawing.Color.Black;
            this.btnRemove.Radius = 15;
            this.btnRemove.Size = new System.Drawing.Size(101, 38);
            this.btnRemove.TabIndex = 41;
            this.btnRemove.Text = "REMOVE";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Animated = true;
            this.btnEdit.AnimationHoverSpeed = 0.07F;
            this.btnEdit.AnimationSpeed = 0.03F;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.BaseColor1 = System.Drawing.Color.SlateBlue;
            this.btnEdit.BaseColor2 = System.Drawing.Color.Fuchsia;
            this.btnEdit.BorderColor = System.Drawing.Color.Black;
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEdit.FocusedColor = System.Drawing.Color.Empty;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageSize = new System.Drawing.Size(20, 20);
            this.btnEdit.Location = new System.Drawing.Point(1158, 259);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
            this.btnEdit.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnEdit.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnEdit.OnHoverForeColor = System.Drawing.Color.White;
            this.btnEdit.OnHoverImage = null;
            this.btnEdit.OnPressedColor = System.Drawing.Color.Black;
            this.btnEdit.Radius = 15;
            this.btnEdit.Size = new System.Drawing.Size(101, 38);
            this.btnEdit.TabIndex = 42;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.AnimationHoverSpeed = 0.07F;
            this.btnAdd.AnimationSpeed = 0.03F;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BaseColor1 = System.Drawing.Color.OliveDrab;
            this.btnAdd.BaseColor2 = System.Drawing.Color.LawnGreen;
            this.btnAdd.BorderColor = System.Drawing.Color.Black;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.FocusedColor = System.Drawing.Color.Empty;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageSize = new System.Drawing.Size(20, 20);
            this.btnAdd.Location = new System.Drawing.Point(1265, 259);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdd.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAdd.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAdd.OnHoverImage = null;
            this.btnAdd.OnPressedColor = System.Drawing.Color.Black;
            this.btnAdd.Radius = 15;
            this.btnAdd.Size = new System.Drawing.Size(101, 38);
            this.btnAdd.TabIndex = 43;
            this.btnAdd.Text = "ADD";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(395, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "TDS Token";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(12, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Cookie";
            // 
            // nbrStartHold
            // 
            this.nbrStartHold.BackColor = System.Drawing.Color.Transparent;
            this.nbrStartHold.BorderRadius = 10;
            this.nbrStartHold.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nbrStartHold.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nbrStartHold.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nbrStartHold.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nbrStartHold.DisabledState.Parent = this.nbrStartHold;
            this.nbrStartHold.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.nbrStartHold.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.nbrStartHold.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nbrStartHold.FocusedState.Parent = this.nbrStartHold;
            this.nbrStartHold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrStartHold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.nbrStartHold.Location = new System.Drawing.Point(67, 61);
            this.nbrStartHold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrStartHold.Name = "nbrStartHold";
            this.nbrStartHold.ShadowDecoration.Parent = this.nbrStartHold;
            this.nbrStartHold.Size = new System.Drawing.Size(71, 29);
            this.nbrStartHold.TabIndex = 48;
            this.nbrStartHold.ValueChanged += new System.EventHandler(this.nbrStartHold_ValueChanged);
            // 
            // nbrStopHold
            // 
            this.nbrStopHold.BackColor = System.Drawing.Color.Transparent;
            this.nbrStopHold.BorderRadius = 10;
            this.nbrStopHold.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nbrStopHold.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nbrStopHold.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nbrStopHold.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nbrStopHold.DisabledState.Parent = this.nbrStopHold;
            this.nbrStopHold.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.nbrStopHold.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.nbrStopHold.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nbrStopHold.FocusedState.Parent = this.nbrStopHold;
            this.nbrStopHold.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrStopHold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.nbrStopHold.Location = new System.Drawing.Point(200, 61);
            this.nbrStopHold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrStopHold.Name = "nbrStopHold";
            this.nbrStopHold.ShadowDecoration.Parent = this.nbrStopHold;
            this.nbrStopHold.Size = new System.Drawing.Size(71, 29);
            this.nbrStopHold.TabIndex = 49;
            this.nbrStopHold.ValueChanged += new System.EventHandler(this.nbrStopHold_ValueChanged);
            // 
            // nbrJobDone
            // 
            this.nbrJobDone.BackColor = System.Drawing.Color.Transparent;
            this.nbrJobDone.BorderRadius = 10;
            this.nbrJobDone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nbrJobDone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nbrJobDone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nbrJobDone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nbrJobDone.DisabledState.Parent = this.nbrJobDone;
            this.nbrJobDone.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.nbrJobDone.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.nbrJobDone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nbrJobDone.FocusedState.Parent = this.nbrJobDone;
            this.nbrJobDone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrJobDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.nbrJobDone.Location = new System.Drawing.Point(318, 61);
            this.nbrJobDone.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrJobDone.Name = "nbrJobDone";
            this.nbrJobDone.ShadowDecoration.Parent = this.nbrJobDone;
            this.nbrJobDone.Size = new System.Drawing.Size(71, 29);
            this.nbrJobDone.TabIndex = 50;
            this.nbrJobDone.ValueChanged += new System.EventHandler(this.nbrJobDone_ValueChanged);
            // 
            // nbrStartWaitingJob
            // 
            this.nbrStartWaitingJob.BackColor = System.Drawing.Color.Transparent;
            this.nbrStartWaitingJob.BorderRadius = 10;
            this.nbrStartWaitingJob.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nbrStartWaitingJob.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nbrStartWaitingJob.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nbrStartWaitingJob.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nbrStartWaitingJob.DisabledState.Parent = this.nbrStartWaitingJob;
            this.nbrStartWaitingJob.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.nbrStartWaitingJob.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.nbrStartWaitingJob.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nbrStartWaitingJob.FocusedState.Parent = this.nbrStartWaitingJob;
            this.nbrStartWaitingJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrStartWaitingJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.nbrStartWaitingJob.Location = new System.Drawing.Point(69, 101);
            this.nbrStartWaitingJob.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrStartWaitingJob.Name = "nbrStartWaitingJob";
            this.nbrStartWaitingJob.ShadowDecoration.Parent = this.nbrStartWaitingJob;
            this.nbrStartWaitingJob.Size = new System.Drawing.Size(71, 29);
            this.nbrStartWaitingJob.TabIndex = 48;
            this.nbrStartWaitingJob.ValueChanged += new System.EventHandler(this.nbrStartWaitingJob_ValueChanged);
            // 
            // nbrStopWaitingJob
            // 
            this.nbrStopWaitingJob.BackColor = System.Drawing.Color.Transparent;
            this.nbrStopWaitingJob.BorderRadius = 10;
            this.nbrStopWaitingJob.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nbrStopWaitingJob.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nbrStopWaitingJob.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nbrStopWaitingJob.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nbrStopWaitingJob.DisabledState.Parent = this.nbrStopWaitingJob;
            this.nbrStopWaitingJob.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.nbrStopWaitingJob.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.nbrStopWaitingJob.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nbrStopWaitingJob.FocusedState.Parent = this.nbrStopWaitingJob;
            this.nbrStopWaitingJob.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrStopWaitingJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.nbrStopWaitingJob.Location = new System.Drawing.Point(194, 101);
            this.nbrStopWaitingJob.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrStopWaitingJob.Name = "nbrStopWaitingJob";
            this.nbrStopWaitingJob.ShadowDecoration.Parent = this.nbrStopWaitingJob;
            this.nbrStopWaitingJob.Size = new System.Drawing.Size(71, 29);
            this.nbrStopWaitingJob.TabIndex = 49;
            this.nbrStopWaitingJob.ValueChanged += new System.EventHandler(this.nbrStopWaitingJob_ValueChanged);
            // 
            // nbrJobToChangeAcc
            // 
            this.nbrJobToChangeAcc.BackColor = System.Drawing.Color.Transparent;
            this.nbrJobToChangeAcc.BorderRadius = 10;
            this.nbrJobToChangeAcc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nbrJobToChangeAcc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nbrJobToChangeAcc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nbrJobToChangeAcc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nbrJobToChangeAcc.DisabledState.Parent = this.nbrJobToChangeAcc;
            this.nbrJobToChangeAcc.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.nbrJobToChangeAcc.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.nbrJobToChangeAcc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nbrJobToChangeAcc.FocusedState.Parent = this.nbrJobToChangeAcc;
            this.nbrJobToChangeAcc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrJobToChangeAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.nbrJobToChangeAcc.Location = new System.Drawing.Point(147, 144);
            this.nbrJobToChangeAcc.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrJobToChangeAcc.Name = "nbrJobToChangeAcc";
            this.nbrJobToChangeAcc.ShadowDecoration.Parent = this.nbrJobToChangeAcc;
            this.nbrJobToChangeAcc.Size = new System.Drawing.Size(71, 29);
            this.nbrJobToChangeAcc.TabIndex = 48;
            this.nbrJobToChangeAcc.ValueChanged += new System.EventHandler(this.nbrJobToChangeAcc_ValueChanged);
            // 
            // nbrJobToStop
            // 
            this.nbrJobToStop.BackColor = System.Drawing.Color.Transparent;
            this.nbrJobToStop.BorderRadius = 10;
            this.nbrJobToStop.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nbrJobToStop.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nbrJobToStop.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nbrJobToStop.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nbrJobToStop.DisabledState.Parent = this.nbrJobToStop;
            this.nbrJobToStop.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.nbrJobToStop.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.nbrJobToStop.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nbrJobToStop.FocusedState.Parent = this.nbrJobToStop;
            this.nbrJobToStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbrJobToStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.nbrJobToStop.Location = new System.Drawing.Point(189, 185);
            this.nbrJobToStop.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrJobToStop.Name = "nbrJobToStop";
            this.nbrJobToStop.ShadowDecoration.Parent = this.nbrJobToStop;
            this.nbrJobToStop.Size = new System.Drawing.Size(71, 29);
            this.nbrJobToStop.TabIndex = 48;
            this.nbrJobToStop.ValueChanged += new System.EventHandler(this.nbrJobToStop_ValueChanged);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(783, 67);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(228, 55);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(783, 152);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(228, 55);
            this.btnTest1.TabIndex = 15;
            this.btnTest1.Text = "Test";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1378, 691);
            this.Controls.Add(this.nbrJobDone);
            this.Controls.Add(this.nbrStopWaitingJob);
            this.Controls.Add(this.nbrStopHold);
            this.Controls.Add(this.nbrJobToStop);
            this.Controls.Add(this.nbrJobToChangeAcc);
            this.Controls.Add(this.nbrStartWaitingJob);
            this.Controls.Add(this.nbrStartHold);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.txtProxy);
            this.Controls.Add(this.txtTDSToken);
            this.Controls.Add(this.txtFbToken);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnTest1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.infoTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "TDSCoinMaker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.infoTable)).EndInit();
            this.cmsMenuOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nbrStartHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStopHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrJobDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStartWaitingJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrStopWaitingJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrJobToChangeAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrJobToStop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaDataGridView infoTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ContextMenuStrip cmsMenuOption;
        private System.Windows.Forms.ToolStripMenuItem option1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem option2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem option3ToolStripMenuItem;
        private Guna.UI.WinForms.GunaTextBox txtFbToken;
        private Guna.UI.WinForms.GunaTextBox txtTDSToken;
        private Guna.UI.WinForms.GunaTextBox txtProxy;
        private Guna.UI.WinForms.GunaGradientButton btnRemove;
        private Guna.UI.WinForms.GunaGradientButton btnEdit;
        private Guna.UI.WinForms.GunaGradientButton btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Token_acc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDS_Token;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn List_job;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proxy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TDS_Xu;
        private System.Windows.Forms.DataGridViewButtonColumn ActionButton;
        private System.Windows.Forms.DataGridViewButtonColumn ShowLog;
        private Guna.UI2.WinForms.Guna2NumericUpDown nbrStartHold;
        private Guna.UI2.WinForms.Guna2NumericUpDown nbrStopHold;
        private Guna.UI2.WinForms.Guna2NumericUpDown nbrJobDone;
        private Guna.UI2.WinForms.Guna2NumericUpDown nbrStartWaitingJob;
        private Guna.UI2.WinForms.Guna2NumericUpDown nbrStopWaitingJob;
        private Guna.UI2.WinForms.Guna2NumericUpDown nbrJobToChangeAcc;
        private Guna.UI2.WinForms.Guna2NumericUpDown nbrJobToStop;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnTest1;
    }
}

