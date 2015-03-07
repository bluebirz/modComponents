using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogistMate.Components
{
    public class modLinkText : LinkLabel
    {
        public modLinkText()
        {
            init_ui();
        }

        private void init_ui()
        {
            this.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
        }
    }
}
