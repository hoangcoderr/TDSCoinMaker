namespace TDSCoinMaker
{
    partial class AccountEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountEditor));
            this.editorTable = new Guna.UI.WinForms.GunaDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cookie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProxyOfThisAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTDSToken = new Guna.UI.WinForms.GunaTextBox();
            this.btnDeleteRow = new Guna.UI.WinForms.GunaGradientButton();
            this.btnSave = new Guna.UI.WinForms.GunaGradientButton();
            this.txtCookie = new Guna.UI.WinForms.GunaTextBox();
            this.txtProxyOfThisAcc = new Guna.UI.WinForms.GunaTextBox();
            this.btnAdd = new Guna.UI.WinForms.GunaGradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.editorTable)).BeginInit();
            this.SuspendLayout();
            // 
            // editorTable
            // 
            this.editorTable.AllowUserToAddRows = false;
            this.editorTable.AllowUserToDeleteRows = false;
            this.editorTable.AllowUserToResizeColumns = false;
            this.editorTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.editorTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.editorTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.editorTable.BackgroundColor = System.Drawing.Color.White;
            this.editorTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editorTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.editorTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.editorTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.editorTable.ColumnHeadersHeight = 35;
            this.editorTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.editorTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Cookie,
            this.ProxyOfThisAcc});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.editorTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.editorTable.EnableHeadersVisualStyles = false;
            this.editorTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.editorTable.Location = new System.Drawing.Point(1, 84);
            this.editorTable.Name = "editorTable";
            this.editorTable.RowHeadersVisible = false;
            this.editorTable.RowTemplate.Height = 35;
            this.editorTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.editorTable.Size = new System.Drawing.Size(1007, 360);
            this.editorTable.TabIndex = 0;
            this.editorTable.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.editorTable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.editorTable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.editorTable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.editorTable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.editorTable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.editorTable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.editorTable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.editorTable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.editorTable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.editorTable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.editorTable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.editorTable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.editorTable.ThemeStyle.HeaderStyle.Height = 35;
            this.editorTable.ThemeStyle.ReadOnly = false;
            this.editorTable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.editorTable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.editorTable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.editorTable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.editorTable.ThemeStyle.RowsStyle.Height = 35;
            this.editorTable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.editorTable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.editorTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.editorTable_CellContentClick);
            this.editorTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.editorTable_CellEndEdit);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cookie
            // 
            this.Cookie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cookie.HeaderText = "Cookie";
            this.Cookie.Name = "Cookie";
            this.Cookie.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cookie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProxyOfThisAcc
            // 
            this.ProxyOfThisAcc.HeaderText = "ProxyOfThisAcc";
            this.ProxyOfThisAcc.Name = "ProxyOfThisAcc";
            this.ProxyOfThisAcc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProxyOfThisAcc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(522, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cookie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(529, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Proxy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Editting data for TDS Token:";
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
            this.txtTDSToken.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTDSToken.Location = new System.Drawing.Point(283, 36);
            this.txtTDSToken.Name = "txtTDSToken";
            this.txtTDSToken.PasswordChar = '\0';
            this.txtTDSToken.Radius = 10;
            this.txtTDSToken.SelectedText = "";
            this.txtTDSToken.Size = new System.Drawing.Size(714, 42);
            this.txtTDSToken.TabIndex = 36;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Animated = true;
            this.btnDeleteRow.AnimationHoverSpeed = 0.07F;
            this.btnDeleteRow.AnimationSpeed = 0.03F;
            this.btnDeleteRow.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteRow.BaseColor1 = System.Drawing.Color.DarkRed;
            this.btnDeleteRow.BaseColor2 = System.Drawing.Color.Red;
            this.btnDeleteRow.BorderColor = System.Drawing.Color.Black;
            this.btnDeleteRow.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDeleteRow.FocusedColor = System.Drawing.Color.Empty;
            this.btnDeleteRow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDeleteRow.ForeColor = System.Drawing.Color.White;
            this.btnDeleteRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRow.Image")));
            this.btnDeleteRow.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDeleteRow.Location = new System.Drawing.Point(12, 478);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteRow.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDeleteRow.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDeleteRow.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDeleteRow.OnHoverImage = null;
            this.btnDeleteRow.OnPressedColor = System.Drawing.Color.Black;
            this.btnDeleteRow.Radius = 15;
            this.btnDeleteRow.Size = new System.Drawing.Size(228, 75);
            this.btnDeleteRow.TabIndex = 42;
            this.btnDeleteRow.Text = "REMOVE";
            this.btnDeleteRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.AnimationHoverSpeed = 0.07F;
            this.btnSave.AnimationSpeed = 0.03F;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor1 = System.Drawing.Color.LightSeaGreen;
            this.btnSave.BaseColor2 = System.Drawing.Color.SlateGray;
            this.btnSave.BorderColor = System.Drawing.Color.Black;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.FocusedColor = System.Drawing.Color.Empty;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSave.Location = new System.Drawing.Point(264, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSave.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSave.OnHoverImage = null;
            this.btnSave.OnPressedColor = System.Drawing.Color.Black;
            this.btnSave.Radius = 15;
            this.btnSave.Size = new System.Drawing.Size(222, 75);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCookie
            // 
            this.txtCookie.BackColor = System.Drawing.Color.Transparent;
            this.txtCookie.BaseColor = System.Drawing.Color.White;
            this.txtCookie.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCookie.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCookie.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCookie.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtCookie.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCookie.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtCookie.Location = new System.Drawing.Point(583, 450);
            this.txtCookie.Name = "txtCookie";
            this.txtCookie.PasswordChar = '\0';
            this.txtCookie.Radius = 10;
            this.txtCookie.SelectedText = "";
            this.txtCookie.Size = new System.Drawing.Size(414, 36);
            this.txtCookie.TabIndex = 45;
            // 
            // txtProxyOfThisAcc
            // 
            this.txtProxyOfThisAcc.BackColor = System.Drawing.Color.Transparent;
            this.txtProxyOfThisAcc.BaseColor = System.Drawing.Color.White;
            this.txtProxyOfThisAcc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProxyOfThisAcc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProxyOfThisAcc.FocusedBaseColor = System.Drawing.Color.White;
            this.txtProxyOfThisAcc.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtProxyOfThisAcc.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtProxyOfThisAcc.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtProxyOfThisAcc.Location = new System.Drawing.Point(583, 486);
            this.txtProxyOfThisAcc.Name = "txtProxyOfThisAcc";
            this.txtProxyOfThisAcc.PasswordChar = '\0';
            this.txtProxyOfThisAcc.Radius = 10;
            this.txtProxyOfThisAcc.SelectedText = "";
            this.txtProxyOfThisAcc.Size = new System.Drawing.Size(414, 36);
            this.txtProxyOfThisAcc.TabIndex = 46;
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
            this.btnAdd.Location = new System.Drawing.Point(583, 528);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAdd.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAdd.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnAdd.OnHoverForeColor = System.Drawing.Color.White;
            this.btnAdd.OnHoverImage = null;
            this.btnAdd.OnPressedColor = System.Drawing.Color.Black;
            this.btnAdd.Radius = 15;
            this.btnAdd.Size = new System.Drawing.Size(414, 39);
            this.btnAdd.TabIndex = 47;
            this.btnAdd.Text = "ADD";
            this.btnAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // AccountEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 573);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtProxyOfThisAcc);
            this.Controls.Add(this.txtCookie);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.txtTDSToken);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.editorTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountEditor";
            this.Text = "AccountEditor";
            this.Load += new System.EventHandler(this.AccountEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editorTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaDataGridView editorTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cookie;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProxyOfThisAcc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaTextBox txtTDSToken;
        private Guna.UI.WinForms.GunaGradientButton btnDeleteRow;
        private Guna.UI.WinForms.GunaGradientButton btnSave;
        private Guna.UI.WinForms.GunaTextBox txtCookie;
        private Guna.UI.WinForms.GunaTextBox txtProxyOfThisAcc;
        private Guna.UI.WinForms.GunaGradientButton btnAdd;
    }
}