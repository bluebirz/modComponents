using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogistMate.Components
{
    public class modPanel:Panel
    {
        public void addControl(Control c)
        {
            if (c.Width <= this.Width && c.Height <= this.Height)
            {
                c.Dock = DockStyle.Fill;
                this.Controls.Add(c);
            }
            else
            {
                c.Dock = DockStyle.Top;
                this.Controls.Add(c);
            }
        }
    }
}
