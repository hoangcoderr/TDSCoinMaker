namespace TDSCoinMaker
{
    partial class CustomTitleBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomTitleBar));
            this.closeButton = new Guna.UI.WinForms.GunaGradientButton();
            this.minimizeButton = new Guna.UI.WinForms.GunaGradientButton();
            this.tabName = new Guna.UI.WinForms.GunaLabel();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.AnimationHoverSpeed = 0.07F;
            this.closeButton.AnimationSpeed = 0.03F;
            this.closeButton.BaseColor1 = System.Drawing.Color.IndianRed;
            this.closeButton.BaseColor2 = System.Drawing.Color.Firebrick;
            this.closeButton.BorderColor = System.Drawing.Color.Black;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.closeButton.FocusedColor = System.Drawing.Color.Empty;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.closeButton.ImageSize = new System.Drawing.Size(20, 20);
            this.closeButton.Location = new System.Drawing.Point(968, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.closeButton.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.closeButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.closeButton.OnHoverForeColor = System.Drawing.Color.White;
            this.closeButton.OnHoverImage = null;
            this.closeButton.OnPressedColor = System.Drawing.Color.Black;
            this.closeButton.Size = new System.Drawing.Size(29, 26);
            this.closeButton.TabIndex = 0;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.AnimationHoverSpeed = 0.07F;
            this.minimizeButton.AnimationSpeed = 0.03F;
            this.minimizeButton.BaseColor1 = System.Drawing.Color.DodgerBlue;
            this.minimizeButton.BaseColor2 = System.Drawing.Color.RoyalBlue;
            this.minimizeButton.BorderColor = System.Drawing.Color.Black;
            this.minimizeButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.minimizeButton.FocusedColor = System.Drawing.Color.Empty;
            this.minimizeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("minimizeButton.Image")));
            this.minimizeButton.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minimizeButton.ImageSize = new System.Drawing.Size(20, 20);
            this.minimizeButton.Location = new System.Drawing.Point(933, 3);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.OnHoverBaseColor1 = System.Drawing.Color.LightCyan;
            this.minimizeButton.OnHoverBaseColor2 = System.Drawing.Color.PaleTurquoise;
            this.minimizeButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.minimizeButton.OnHoverForeColor = System.Drawing.Color.White;
            this.minimizeButton.OnHoverImage = null;
            this.minimizeButton.OnPressedColor = System.Drawing.Color.Black;
            this.minimizeButton.Size = new System.Drawing.Size(29, 26);
            this.minimizeButton.TabIndex = 1;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // tabName
            // 
            this.tabName.AutoSize = true;
            this.tabName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tabName.Location = new System.Drawing.Point(7, 4);
            this.tabName.Name = "tabName";
            this.tabName.Size = new System.Drawing.Size(126, 21);
            this.tabName.TabIndex = 2;
            this.tabName.Text = "TDS Coin Maker";
            this.tabName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomTitleBar_MouseDown);
            // 
            // CustomTitleBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.tabName);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.closeButton);
            this.Name = "CustomTitleBar";
            this.Size = new System.Drawing.Size(1000, 32);
            this.Load += new System.EventHandler(this.CustonTitleBar_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomTitleBar_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton closeButton;
        private Guna.UI.WinForms.GunaGradientButton minimizeButton;
        private Guna.UI.WinForms.GunaLabel tabName;
    }
}
