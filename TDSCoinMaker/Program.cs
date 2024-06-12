using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDSCoinMaker
{
    internal static class Program
    {
        public static MainForm mainForm;
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FreeConsole();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (AllocConsole())
            {
                // Thiết lập mã hóa cho console
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;

                // Hiển thị văn bản mẫu trên console
                //Console.WriteLine("Chào mừng bạn đến với ứng dụng WinForms có hỗ trợ console UTF-8!");
                //Console.WriteLine("Một số ký tự đặc biệt: 你好, Привет, مرحبا, 😊");
            }
            else
            {
                // Nếu không thể mở console, hiển thị thông báo lỗi
                MessageBox.Show("Không thể mở console.");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
            FreeConsole();
        }
    }
}
