using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDSCoinMaker
{
    public partial class CustomTitleBar : UserControl
    {
        // Import the user32.dll to use the ReleaseCapture and SendMessage functions.
        // This is for moving the window.
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        public CustomTitleBar(string tabName)
        {
            InitializeComponent();
            this.tabName.Text = tabName;
            this.Dock = DockStyle.Top;
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            minimizeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        // Event handler for the control's MouseDown event.
        private void CustomTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            // Call the imported functions to enable window dragging.
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.ParentForm.Handle, 0xA1, 0x2, 0);
            }
        }

        // Close button click event handler.
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        // Minimize button click event handler.
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Minimized;
        }
    

        private void CustonTitleBar_Load(object sender, EventArgs e)
        {

        }
    }
}
