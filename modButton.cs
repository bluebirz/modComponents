using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogistMate.Components
{
    public class modButton : System.Windows.Forms.Button
    {
        public modButton()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 2;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (this.Enabled)
            {
                this.ForeColor = Color.Black;
                //this.BackColor = Color.Transparent;
            }
            else
            {
                this.ForeColor = Color.WhiteSmoke;
                //this.BackColor = Color.WhiteSmoke;
            }
            //Console.WriteLine("[{0}].onenablechanged forcolor = {1}", this.Name, this.ForeColor.ToString());
        }
    }
}
