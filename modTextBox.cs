using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogistMate.Components
{
    class modTextBox : System.Windows.Forms.TextBox
    {
        //malicious message
        private const int WM_GETTEXT = 0x000D;
        //true from the property, false from else
        bool allowAccess { get; set; }

        //public override string Text
        //{
        //    get
        //    {
        //        allowAccess = true;
        //        return base.Text;
        //    }
        //    set
        //    {
        //        base.Text = value;
        //    }
        //}
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_GETTEXT)  // if the message is WM_GETTEXT 
        //    {
        //        if (allowAccess)  // and it comes from the Text property
        //        {
        //            allowAccess = false;   //we temporarily remove the access
        //            base.WndProc(ref m);  //and finally, process the message
        //        }
        //    }
        //    else
        //    {
        //        base.WndProc(ref m);
        //    }
        //}

        #region custom attributes
        protected internal bool isValidValue { get; set; }
        protected bool Required { get; set; }
        protected bool Autosuggestion { get; set; }

        private Color required_border = Color.Red;
        private Color norequired_border = Color.Black;

        private KeyValuePair<Color, Color> validValue = new KeyValuePair<Color, Color>(Color.Black, Color.White);
        private KeyValuePair<Color, Color> invalidValue = new KeyValuePair<Color, Color>(Color.White, Color.Red);

        public enum InputStyle { TEXT, NUMERIC, ALPHABET, MEASUREMENT, EMAIL };
        public InputStyle inputStyle { get; set; }

        public decimal MaxValue { get; set; }
        public decimal MinValue { get; set; }
        protected internal string placeHolder { get; set; }

        //private Color textColor;
        private string _defValue;
        public string default_value { get { return this._defValue; } set { this._defValue = value; this.Text = this._defValue; } }
        #endregion

        public modTextBox()
        {
            this.isValidValue = true;
            this.inputStyle = InputStyle.TEXT;
            //this.placeHolder = "";
            //this.placeHolderColor = Color.Black;
            //this.textColor = Color.Black;
            this.ForeColor = Color.Black;
            this.default_value = string.Empty;
            //this.MinValue = this.MaxValue = 0;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Text = "";
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height));
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            //doPlaceHolder(this.hasNoString());
            //setValidity();
            if (string.IsNullOrWhiteSpace(this.Text)) { this.Text = this.default_value; }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            //doPlaceHolder(this.hasNoString());
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            //var cancel = filteringModTextBox((char)e.KeyValue, this.Text);
            //Console.WriteLine("[{0}].keydown e:{1} t:{2} p:{3}", this.Name, (char)e.KeyData, this.Text, cancel);
            ////e.Handled = cancel;
            //Console.WriteLine("[{0}].keydown: text:{1} data:{2} code{3} value{4}", this.Name, this.Text , e.KeyData, e.KeyCode, e.KeyValue);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            var filter = filteringModTextBox(e.KeyChar, this.Text);
            //var range = isInRangeMaxMin();
            var modifier = allowModifierKey(e.KeyChar);
            var pass = filter || modifier;
            //Console.WriteLine("[{0}].keypress f:{1} m:{2}", this.Name, filter, modifier);
            //Console.WriteLine("[{0}].keypress f:{1} r:{2} b:{3}", this.Name, filter,range,back);
            e.Handled = !pass;
            //Console.WriteLine("[{0}].keypress color = {1}", this.Name, this.ForeColor);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            //var cancel = filteringModTextBox((char)e.KeyValue, this.Text);
            //Console.WriteLine("[{0}].keyup e:{1} t:{2} p:{3}", this.Name, (char)e.KeyData, this.Text, cancel);
            //e.Handled = !pass && e.KeyValue != (int)Keys.Back;
            //Console.WriteLine("[{0}].keyup: text:{1} data:{2} code{3} value{4}", this.Name, this.Text , e.KeyData, e.KeyCode, e.KeyValue);
        }

        private void setValidity()
        {
            this.ForeColor = (isValidValue ? validValue.Key : validValue.Key);
            this.BackColor = (isValidValue ? validValue.Value : invalidValue.Value);
        }

        protected internal bool hasNoString()
        {
            return string.IsNullOrEmpty(this.Text) || string.IsNullOrWhiteSpace(this.Text);
        }

        private void doPlaceHolder(bool enable)
        {
            if (enable)
            {
                this.Text = this.placeHolder;
                //this.ForeColor = this.placeHolderColor;
                this.Select(0, this.Text.Length);
            }
            else
            {
                //this.ForeColor = this.textColor;
            }
        }

        private bool filteringModTextBox(char p, string s)
        {
            switch (this.inputStyle)
            {
                case InputStyle.ALPHABET: return char.IsLetter(p);
                case InputStyle.NUMERIC: return char.IsDigit(p);
                case InputStyle.MEASUREMENT: return char.IsDigit(p) || (p == '.' && s.Count(str => str.Equals('.')) < 1);
                case InputStyle.TEXT: return true;
                default: return true;

            }
        }

        private bool allowModifierKey(char key)
        {
            switch (key)
            {
                case (char)Keys.ControlKey: return true;
                case (char)Keys.Back: return true;
                case (char)Keys.Delete: return true;
                case (char)Keys.Insert: return true;
                case (char)Keys.ShiftKey: return true;
                default: return false;
            }
        }

        //private bool isInRangeMaxMin()
        //{
        //    //Console.WriteLine("[{0}].isinrangemaxmin : {1}->{2} {3} {4}", this.Name, this.MinValue, this.MaxValue, this.getDecimal() ,this.getDecimal() <= this.MaxValue && this.getDecimal() >= this.MinValue);
        //    if (this.MaxValue != 0 && this.MinValue != 0)
        //    {
        //        return this.getDecimal() <= this.MaxValue && this.getDecimal() >= this.MinValue;
        //    }
        //    else { return true; }
        //}

        protected internal decimal getDecimal()
        {
            decimal value = 0;
            if (decimal.TryParse(this.Text, out value))
            {
                return value;
            }
            else
            {
                return 0M;
            }
        }

        protected internal double getDouble()
        {
            double value = 0;
            if (double.TryParse(this.Text, out value))
            {
                return value;
            }
            else
            {
                return 0D;
            }
        }

        protected internal int getInt32()
        {
            int value = 0;
            if (int.TryParse(this.Text, out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        protected internal long getLong()
        {
            long value = 0;
            if (long.TryParse(this.Text, out value))
            {
                return value;
            }
            else
            {
                return 0L;
            }
        }

    }
}
