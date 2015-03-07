using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogistMate.Components
{
    public class modCheckBox : CheckBox
    {
        public modCheckBox()
        {
            this.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }
    }
}
