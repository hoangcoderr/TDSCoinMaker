using System;
using System.Drawing;
using System.Windows.Forms;
using TDSCoinMaker.FormEditting;

namespace TDSCoinMaker.Logger
{
    public partial class LogForm : Form
    {
        private TextBox logTextBox;

        public LogForm(string formName)
        {
            FeatureDisable.DisableMaximizeBox(this);

            InitializeComponent();
            InitializeLogTextBox();
            this.Text = formName; // Thiết lập tên của form
        }
        public LogForm()
        {
            FeatureDisable.DisableMaximizeBox(this);

            InitializeComponent();
            InitializeLogTextBox();
            
        }


        private void InitializeLogTextBox()
        {
            logTextBox = new TextBox
            {
                Multiline = true, // Cho phép nhiều dòng
                Dock = DockStyle.Fill, // Điền toàn bộ form
                ReadOnly = true, // Chỉ đọc, không cho chỉnh sửa trực tiếp
                ScrollBars = ScrollBars.Vertical, // Hiển thị thanh cuộn nếu cần
                Font = new Font("Arial", 15f), // Thay đổi kích thước và kiểu chữ
                ForeColor = Color.Red // Thay đổi màu sắc của chữ
            };
            this.Controls.Add(logTextBox); // Thêm TextBox vào form
        }
        // Phương thức để thêm log
        public void AddLog(string message)
        {
            if (logTextBox.InvokeRequired)
            {
                logTextBox.Invoke(new Action<string>(AddLog), message);
            }
            else
            {
                logTextBox.AppendText(message + Environment.NewLine);
            }
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            // Bạn có thể thêm log mặc định ở đây nếu muốn
        }
    }
}