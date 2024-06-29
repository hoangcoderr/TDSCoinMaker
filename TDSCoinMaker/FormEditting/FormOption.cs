using OpenQA.Selenium.DevTools.V123.Runtime;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Windows.Forms;

namespace TDSCoinMaker.FormEditting
{
    public class FormOption
    {

        public static void FadeInForm(Form form, int duration)
        {
            // Ensure the form is initially invisible
            form.Opacity = 0;
            form.Show();

            // Calculate the amount to increase opacity by
            double increment = 1.0 / duration; // Adjust 'duration' to control the speed

            // Timer to gradually increase the form's opacity
            Timer timer = new Timer();
            timer.Interval = 10; // Interval in milliseconds, adjust as needed
            timer.Tick += (sender, e) =>
            {
                // Increase the opacity
                if (form.Opacity < 1)
                {
                    form.Opacity += increment;
                }
                else
                {
                    // Stop the timer when the form is fully visible
                    timer.Stop();
                    timer.Dispose();
                }
            };
            timer.Start();
        }
        public static void DisableMaximizeBox(Form form)
        {
            if (form != null)
            {
                form.MaximizeBox = false;
            }
        }

        public static void removeBorder(Form form)
        {
            if (form != null)
            {
                form.FormBorderStyle = FormBorderStyle.None;
            }
        }

        public static void disableResize(Form form)
        {
            if (form != null)
            {
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
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
