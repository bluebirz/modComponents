using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogistMate.Components
{
    class modGroupBox:GroupBox
    {
        public modGroupBox()
        {
            //var f = this.Font;
            //this.Font = new System.Drawing.Font(f.FontFamily, f.Size, System.Drawing.FontStyle.Regular);
            this.Padding = new Padding(5);
        }
    }
}
