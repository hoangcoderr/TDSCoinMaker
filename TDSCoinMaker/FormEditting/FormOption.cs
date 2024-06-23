using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDSCoinMaker.FormEditting
{
    public class FormOption
    {
        public static void DisableMaximizeBox(Form form)
        {
            if (form != null)
            {
                form.MaximizeBox = false;
            }
        }
        [DllImport("dwmapi.dll", PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_CAPTION_COLOR = 35; // DWM Window Attribute for caption color

        public static void SetTitleBarColor(IntPtr hwnd, Color color)
        {
            int argbColor = color.ToArgb();
            DwmSetWindowAttribute(hwnd, DWMWA_CAPTION_COLOR, ref argbColor, sizeof(int));
        }

    }
}
