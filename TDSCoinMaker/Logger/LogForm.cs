using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TDSCoinMaker.FormEditting;

namespace TDSCoinMaker.Logger
{
    public partial class LogForm : Form
    {
        private RichTextBox logRichTextBox;
        private List<(string message, Color color)> logEntries;

        public LogForm(string userName)
        {
            FormOption.DisableMaximizeBox(this);
            InitializeComponent();
            this.Text = $"Log for {userName}";
            logEntries = new List<(string message, Color color)>();

            logRichTextBox = new RichTextBox
            {
                Multiline = true, // Cho phép nhiều dòng
                Dock = DockStyle.Fill, // Điền toàn bộ form
                ReadOnly = true, // Chỉ đọc, không cho chỉnh sửa trực tiếp
                ScrollBars = RichTextBoxScrollBars.Vertical, // Hiển thị thanh cuộn nếu cần
                Font = new Font("Consolas", 14f), // Thay đổi kích thước và kiểu chữ
                ForeColor = Color.Black,
                BackColor = Color.Black
            };

            this.Controls.Add(logRichTextBox);
            this.Load += LogForm_Load;
            this.FormClosing += LogForm_FormClosing;
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            foreach (var logEntry in logEntries)
            {
                AppendText(logEntry.message, logEntry.color);
            }
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private Mutex mutex = new Mutex();
        public void Log(string message, Color color)
        {
            string logMessage = message;
            logEntries.Add((logMessage, color));
   
                if (InvokeRequired)
                {
                    this.Invoke(new Action(() => AppendText(logMessage, color)));
                }
                else
                {
                    AppendText(logMessage, color);
                }
            
        }

        private void AppendText(string text, Color color)
        {
            mutex.WaitOne();
            logRichTextBox.SelectionStart = logRichTextBox.TextLength;
            logRichTextBox.SelectionLength = 0;

            try
            {
                string[] arr = text.Split('|');
                switch (arr.Length)
                {
                    case 3:
                        //Console.WriteLine("3");
                        logRichTextBox.SelectionColor = Color.Yellow;
                        logRichTextBox.AppendText(arr[0]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  ~>  ");
                        logRichTextBox.SelectionColor = Color.White;
                        logRichTextBox.AppendText(arr[1]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  ~> ");
                        logRichTextBox.SelectionColor = Color.Green;
                        logRichTextBox.AppendText(arr[2]);
                        break;
                    case 6:
                        //Console.WriteLine("6");
                        logRichTextBox.SelectionColor = Color.Yellow;
                        logRichTextBox.AppendText("[");
                        logRichTextBox.SelectionColor = Color.AntiqueWhite;
                        logRichTextBox.AppendText(arr[0]);
                        logRichTextBox.SelectionColor = Color.Yellow;
                        logRichTextBox.AppendText("]");
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.PaleGreen;
                        logRichTextBox.AppendText(arr[1]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.YellowGreen;
                        logRichTextBox.AppendText(arr[2]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.White;
                        logRichTextBox.AppendText(arr[3]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.Green;
                        logRichTextBox.AppendText(arr[4]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.Orange;
                        logRichTextBox.AppendText(arr[5]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |");
                        break;
                    case 7:
                        //Console.WriteLine("7");
                        logRichTextBox.SelectionColor = Color.Yellow;
                        logRichTextBox.AppendText("[");
                        logRichTextBox.SelectionColor = Color.AntiqueWhite;
                        logRichTextBox.AppendText(arr[0]);
                        logRichTextBox.SelectionColor = Color.Yellow;
                        logRichTextBox.AppendText("]");
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText(arr[1]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText(arr[2]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText(arr[3]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText(arr[4]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText(arr[5]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |  ");
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText(arr[6]);
                        logRichTextBox.SelectionColor = Color.Red;
                        logRichTextBox.AppendText("  |");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                logRichTextBox.SelectionColor = color;
                logRichTextBox.AppendText(text + "\r\n");
                logRichTextBox.SelectionColor = logRichTextBox.ForeColor; // Reset lại màu
            }
            mutex.ReleaseMutex();
            //append new line
            logRichTextBox.AppendText("\r\n");
        }
    }
}