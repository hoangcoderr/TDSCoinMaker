using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDSCoinMaker.FormEditting
{
    public class FeatureDisable
    {
        public static void DisableMaximizeBox(Form form)
        {
            if (form != null)
            {
                form.MaximizeBox = false;
            }
        }
    }
}
