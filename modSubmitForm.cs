using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogistMate.CONST;

namespace LogistMate.Components
{
    public partial class modSubmitForm : UserControl
    {
        //button [view],[add],[edit],[delete]
        private bool _showView;
        public bool showView { get { return this._showView; } set { this._view.Visible = this._showView = value; } }
        private bool _showAdd;
        public bool showAdd { get { return this._showAdd; } set { this._add.Visible = this._showAdd = value; } }
        private bool _showEdit;
        public bool showEdit { get { return this._showEdit; } set { this._edit.Visible = this._showEdit = value; } }
        private bool _showDelete;
        public bool showDelete { get { return this._showDelete; } set { this._delete.Visible = this._showDelete = value; } }
        //button [previous],[next]
        private bool _showPrev;
        public bool showPrev { get { return this._showPrev; } set { this._prev.Visible = this._showPrev = value; } }
        private bool _showNext;
        public bool showNext { get { return this._showNext; } set { this._next.Visible = this._showNext = value; } }
        //button [save],[cancel],[accept],[decline]
        private bool _showSave;
        public bool showSave { get { return this._showSave; } set { this._save.Visible = this._showSave = value; } }
        private bool _showCancel;
        public bool showCancel { get { return this._showCancel; } set { this._cancel.Visible = this._showCancel = value; } }
        private bool _showAccept;
        public bool showAccept { get { return this._showAccept; } set { this._accept.Visible = this._showAccept = value; } }
        private bool _showDecline;
        public bool showDecline { get { return this._showDecline; } set { this._decline.Visible = this._showDecline = value; } }
        //button [clear],[close]
        private bool _showClear;
        public bool showClear { get { return this._showClear; } set { this._clear.Visible = this._showClear = value; } }
        private bool _showClose;
        public bool showClose { get { return this._showClose; } set { this._close.Visible = this._showClose = value; } }
        //button and text of [custom1]
        private bool _showCustom1;
        public bool showCustom1 { get { return this._showCustom1; } set { this._custom1.Visible = this._showCustom1 = value; } }
        private string _customText1;
        public string customButtonText1 { get { return this._customText1; } set { this._customText1 = this._custom1.Text = value; } }
        //button and text of [custom2]
        private bool _showCustom2;
        public bool showCustom2 { get { return this._showCustom2; } set { this._custom2.Visible = this._showCustom2 = value; } }
        private string _customText2;
        public string customButtonText2 { get { return this._customText2; } set { this._customText2 = this._custom2.Text = value; } }
        //button and text of [custom3]
        private bool _showCustom3;
        public bool showCustom3 { get { return this._showCustom3; } set { this._custom3.Visible = this._showCustom3 = value; } }
        private string _customText3;
        public string customButtonText3 { get { return this._customText3; } set { this._customText3 = this._custom3.Text = value; } }
        public string status { get { return this._status.Text; } set { this._status.Text = value; } }
        //toolstrip split button
        private bool _showSplitButton;
        public bool showSplitButton { get { return this._showSplitButton; } set { this._showSplitButton = this._strip.Visible = value; } }
        private string _splitbuttontext;
        public string splitButtonText { get { return this._splitbuttontext; } set { this._splitbuttontext = this.splitbutton.Text = value; } }
        //private ToolStripItem[] _items;
        //public ToolStripItem[] splitButtonItems { get { return this._items; } set { this._items = value; addItems(); } }

        //private void addItems()
        //{
        //    if (this._items != null)
        //    {
        //        this.splitbutton.DropDownItems.AddRange(this._items);
        //        foreach (var i in this._items)
        //        {
        //            if (i.Tag != null && i.Tag is Control)
        //            {
        //                i.Click += (s, e) =>
        //                {
        //                    var form = new StandardForm
        //                };
        //            }
        //        }
        //    }
        //}

        private Size _formSize;
        private Size _defaultFormSize = new Size(50, 25);
        public Size buttonSize { get { return this._formSize; } set { this._formSize = value; doSetSize(value); } }

        private void doSetSize(Size size)
        {
            if (size.Height < this._defaultFormSize.Height && size.Width < this._defaultFormSize.Width) { this._formSize = this._defaultFormSize; }
            //Console.WriteLine("[{0}].dosetsize {1}", this.Name, this._formSize.ToString());
            //this.Height = this._formSize.Height;
            //foreach (var i in this.panel01.Controls) { if (i is modButton) { (i as modButton).Size = this.formSize; } }
            //foreach (var i in this.panel02.Controls) { if (i is modButton) { (i as modButton).Size = this.formSize; } }
            foreach (var i in this.table.Controls) { if (i is modButton) { (i as modButton).Size = this.buttonSize; } this.splitbutton.Size = this.buttonSize; }
        }

        public modSubmitForm()
        {
            InitializeComponent();
            showView = showAdd = showEdit = showDelete = false;
            showPrev = showNext = false;
            showSave = showCancel = showAccept = showDecline = showClear = showClose = false;
            showCustom1 = showCustom2 = showCustom3 = false;
            showSplitButton = false;
            this._status.TextChanged += _status_TextChanged;
            init_ui();
        }

        void _status_TextChanged(object sender, EventArgs e)
        {
            //var me = sender as modTextBox;
            //if (me.Text != string.Empty)
            //{
            //    Timer
            //}
        }

        private void init_ui()
        {
            this._view.Text = SIGHT.SUBMISSION.VIEW;
            this._add.Text = SIGHT.SUBMISSION.ADD;
            this._edit.Text = SIGHT.SUBMISSION.EDIT;
            this._delete.Text = SIGHT.SUBMISSION.DELETE;
            this._clear.Text = SIGHT.SUBMISSION.CLEAR;

            this._prev.Text = SIGHT.SUBMISSION.PREV;
            this._next.Text = SIGHT.SUBMISSION.NEXT;

            this._save.Text = SIGHT.SUBMISSION.SAVE;
            this._cancel.Text = SIGHT.SUBMISSION.CANCEL;
            this._accept.Text = SIGHT.SUBMISSION.ACCEPT;
            this._decline.Text = SIGHT.SUBMISSION.DECLINE;
            this._close.Text = SIGHT.SUBMISSION.CLOSE;

            //this.table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        }
    }
}
