using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogistMate.Components
{
    public class modTrackBar : System.Windows.Forms.TrackBar
    {
        public modTrackBar()
        {
            this.AutoSize = false;
            this.Height = 25;
            this.TickStyle = System.Windows.Forms.TickStyle.None;
        }
    }
}
