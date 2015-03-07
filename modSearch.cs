using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogistMate.Components
{
    public partial class modSearch : UserControl
    {
        #region fields
        private bool showMonth;
        private string cbname_month = "month";
        private string lbname_month = "lb_month";
        private string label_month = "เดือน";

        private bool showYear;
        private string cbname_year = "year";
        private string lbname_year = "lb_year";
        private string label_year = "ปี";

        private bool showOrderNumber;
        private string cbname_orderNo = "orderNo";
        private string lbname_orderNo = "lb_orderNo";
        private string label_orderNo = "หมายเลขใบงาน";

        private bool showBillNumber;
        private string cbname_billNo = "billNo";
        private string lbname_billNo = "lb_billNo";
        private string label_billNo = "หมายเลขใบแจ้งหนี้";

        private bool showTransitType;
        private string cbname_transittype = "transitType";
        private string lbname_transittype = "lb_transitType";
        private string label_transitTypes = "ประเภทใบงาน";

        private bool showOrderStatus;
        private string cbname_orderStatus = "orderStatus";
        private string lbname_orderStatus = "lb_orderStatus";
        private string label_orderStatus = "สถานะใบงาน";

        private bool showPaidStatus;
        private string cbname_paidStatus = "expenseStatus";
        private string lbname_paidStatus = "lb_expenseStatus";
        private string label_paidStatus = "สถานะค่าใช้จ่าย";

        private bool showHirer;
        private string cbname_hirer = "hirer";
        private string lbname_hirer = "lb_hirer";
        private string label_hirer = "ผู้ว่าจ้าง";

        private bool showReceiver;
        private string cbname_receiver = "receiver";
        private string lbname_receiver = "lb_receiver";
        private string label_receiver = "ผู้รับ";

        private bool showstaff;
        private string cbname_staff = "staff";
        private string lbname_staff = "lb_staff";
        private string label_staff = "ชื่อพนักงาน";

        private bool showCarrierPlate;
        private string cbname_plate = "plate";
        private string lbname_plate = "lb_plate";
        private string label_plate = "เลขทะเบียนรถ";
        #endregion

        #region initialization
        private bool form_opened = false;
        private modTable table = null;
        private string table_name = "table";

        public enum SEARCHING_PURPOSE { ASSIGN, OPERATE, EXPENSE, CREATE_INVOICE, EDIT_INVOICE, INVOICE_TRANSACTION };

        public modSearch()
        {
            InitializeComponent();
        }

        //public modSearch(SEARCHING_PURPOSE sp)
        //{
        //    InitializeComponent();
        //    this.Purpose = sp;
        //    init_ui();
        //}
        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    init_ui();
        //}

        public modSearch(bool showMonth, bool showYear, bool showTransitType, bool showOrderNumber, bool showOrderStatus, bool showBillNumber, bool showExpenseStatus, bool showHirer, bool showReceiver, bool showstaff, bool showCarrierPlate)
        {
            InitializeComponent();
            init_ui(showMonth, showYear, showTransitType, showOrderNumber, showOrderStatus, showBillNumber, showExpenseStatus, showHirer, showReceiver, showstaff, showCarrierPlate);
        }

        public void init_ui(SEARCHING_PURPOSE purpose)
        {
            switch (purpose)
            {
                case SEARCHING_PURPOSE.ASSIGN:
                    init_ui(true, true, true, true, false, false, false, true, true, true, true); break;
                case SEARCHING_PURPOSE.OPERATE:
                    init_ui(true, true, true, true, true, false, false, true, true, true, true); break;
                case SEARCHING_PURPOSE.EXPENSE:
                    init_ui(true, true, false, true, true, false, false, true, true, true, true); break;
                case SEARCHING_PURPOSE.CREATE_INVOICE:
                    init_ui(true, true, true, true, true, false, false, true, true, false, false); break;
                case SEARCHING_PURPOSE.EDIT_INVOICE:
                    init_ui(true, true, false, false, false, true, true, true, true, false, false); break;
                case SEARCHING_PURPOSE.INVOICE_TRANSACTION:
                    init_ui(true, true, false, false, false, true, true, true, true, false, false); break;
                default: return;
            }
        }

        /// <summary>
        /// should not set flag true to both 'showOrderNumber' and 'showBillNumber', they are separated case.
        /// </summary>
        /// <param name="showM"></param>
        /// <param name="showY"></param>
        /// <param name="showTT"></param>
        /// <param name="showONum"></param>
        /// <param name="showOState"></param>
        /// <param name="showBillNum"></param>
        /// <param name="showExpState"></param>
        /// <param name="showH"></param>
        /// <param name="showR"></param>
        /// <param name="showD"></param>
        /// <param name="showP"></param>
        public void init_ui(bool showM = false, bool showY = false, bool showTT = false, bool showONum = false, bool showOState = false, bool showBillNum = false, bool showExpState = false, bool showH = false, bool showR = false, bool showD = false, bool showP = false)
        {
            this.showMonth = showM;
            this.showYear = showY;
            this.showTransitType = showTT;
            this.showOrderNumber = showONum;
            this.showOrderStatus = showOState;
            this.showBillNumber = showBillNum;
            this.showPaidStatus = showExpState;
            this.showHirer = showH;
            this.showReceiver = showR;
            this.showstaff = showD;
            this.showCarrierPlate = showP;

            this.toggle.Text = CONST.VAR.MISC.FILTER_ON;
            this.form_panel.Visible = form_opened;

            this.toggle.Click += toggle_Click;
            //this.clear.Visible = false;
            //this.clear.Click += clear_Click;
            //this.apply.Click += apply_Click;

            this.panel.Controls.Clear();
            table = createDynamicTable();
            this.panel.Controls.Add(table);
            modifyDynamicTable();

            //doFilterOrderNumber();
            //doFilterBillNumber();
            //this.Invalidate();

        }
        #endregion

        #region debug
        public string verbose_flag()
        {
            string s = flag("m", this.showMonth) + flag("y", this.showYear) + flag("tt", this.showTransitType) + flag("onum", this.showOrderNumber) + flag("ostate", this.showOrderStatus) + flag("bnum", this.showBillNumber) + flag("pstate", this.showPaidStatus) + flag("h", this.showHirer) + flag("r", this.showReceiver) + flag("d", this.showstaff) + flag("p", this.showCarrierPlate);
            return s;
        }
        private string flag(string s, bool f) { return string.Format("{0} is {1}{2}", s, f, Environment.NewLine); }
        #endregion

        private void enableFields(bool b, modLabel l, modComboBox mcb)
        {
            l.Visible = true;
            l.Enabled = b;
            mcb.Visible = true;
            mcb.Enabled = b;
            if (mcb.Enabled == false) { mcb.Text = "ไม่สามารถแสดงข้อมูล"; }
        }

        private bool doFilterOrderNumber()
        {
            var mbox = findComboBox(cbname_month);
            var ybox = findComboBox(cbname_year);
            var ttype = findComboBox(cbname_transittype);
            var ordernumber_label = findLabel(lbname_orderNo);
            var ordernumber_combobox = findComboBox(cbname_orderNo);
            if (ordernumber_label != null && ordernumber_combobox != null && mbox != null && ybox != null)
            {
                var m = (mbox.SelectedItem as CalendarItems);
                var y = (ybox.SelectedItem as CalendarItems);
                //if (m != null && y != null && (m.Indicator != null || y.Indicator != null))
                //{
                //    enableFields(true, ordernumber_label, ordernumber_combobox);
                //    long? tt = (isObvNull(ttype) ? null : ((ttype.SelectedItem as transittypes) == null ? null : (tt = (ttype.SelectedItem as transittypes).id) > 0 ? tt : null));
                //    ordernumber_combobox.initialElements<transits>(transits.select(tt, null, null, null, null, null, null, null, y.Indicator, m.Indicator), Utility.GetMemberName(() => new transits().number), true);
                //}
                //else
                //{
                //    enableFields(false, ordernumber_label, ordernumber_combobox);
                //}
                return true;
            }
            return false;
        }

        private bool doFilterBillNumber()
        {
            var mbox = findComboBox(cbname_month);
            var ybox = findComboBox(cbname_year);
            var expbox = findComboBox(cbname_paidStatus);
            var billnumber_label = findLabel(lbname_billNo);
            var billnumber_combobox = findComboBox(cbname_billNo);
            if (mbox != null && ybox != null && billnumber_label != null && billnumber_combobox != null)
            {
                var m = (mbox.SelectedItem as CalendarItems);
                var y = (ybox.SelectedItem as CalendarItems);
                //if (m != null && y != null && (m.Indicator != null || y.Indicator != null))
                //{
                //    enableFields(true, billnumber_label, billnumber_combobox);
                //    bool? exp = (isObvNull(expbox) ? null : (expbox.SelectedItem as PaidStatus == null ? null : (exp = (expbox.SelectedItem as PaidStatus).id > 0 ? (bool?)((expbox.SelectedItem as PaidStatus).indicator == PaidStatus.ALLPAID.indicator) : null)));
                //    billnumber_combobox.initialElements<transitbills>(transitbills.select(null, null, null, exp, m.Indicator, y.Indicator), Utility.GetMemberName(() => new transitbills().number), true);
                //}
                //else
                //{
                //    enableFields(false, billnumber_label, billnumber_combobox);

                //}
                return true;
            }
            return false;
        }

        private bool isObvNull(modComboBox combobox)
        {
            return combobox == null || combobox.hasNoItems();
        }

        public searchObject getSeachObject()
        {
            var so = new searchObject();
            //var m = findComboBox(cbname_month);
            //so.month = (isObvNull(m) ? null : (m.SelectedItem as CalendarItems).Indicator);
            //var y = findComboBox(cbname_year);
            //so.year = (isObvNull(y) ? null : (y.SelectedItem as CalendarItems).Indicator);
            //var tt = findComboBox(cbname_transittype);
            //so.transittypeId = (isObvNull(tt) ? null : so.transittypeId = (so.transittypeId = (tt.SelectedItem as transittypes).id) > 0 ? so.transittypeId : null);
            //var oNum = findComboBox(cbname_orderNo);
            //so.orderId = (isObvNull(oNum) || oNum.Items.Count <= 0 || oNum.Enabled == false ? null :
            //    so.orderId = (so.orderId = (oNum.SelectedItem as transits).id) > 0 ? so.orderId : null);
            //var oState = findComboBox(cbname_orderStatus);
            //so.orderStatus = (isObvNull(oState) ? new TransitStatuses() : (oState.SelectedItem as TransitStatuses));
            //var paid = findComboBox(cbname_paidStatus);
            //so.paidStatus = (isObvNull(paid) ? new PaidStatus() : (paid.SelectedItem as PaidStatus));
            //var bNum = findComboBox(cbname_billNo);
            //so.billId = (isObvNull(bNum) || bNum.Items.Count <= 0 || bNum.Enabled == false ? null :
            //    so.billId = (so.billId = (bNum.SelectedItem as transitbills).id) > 0 ? so.billId : null);
            //var h = findComboBox(cbname_hirer);
            //so.hirerId = (isObvNull(h) ? null : so.hirerId = (so.hirerId = (h.SelectedItem as customers).id) > 0 ? so.hirerId : null);
            //var r = findComboBox(cbname_receiver);
            //so.receiverId = (isObvNull(r) ? null : so.receiverId = (so.receiverId = (r.SelectedItem as customers).id) > 0 ? so.receiverId : null);
            //var d = findComboBox(cbname_staff);
            //so.staffId = (isObvNull(d) ? null : so.staffId = (so.staffId = (d.SelectedItem as staff).id) > 0 ? so.staffId : null);
            //var p = findComboBox(cbname_plate);
            //so.carrierId = (isObvNull(p) ? null : so.carrierId = (so.carrierId = (p.SelectedItem as carriers).id) > 0 ? so.carrierId : null);
            return so;
        }

        #region listeners I
        void apply_Click(object sender, EventArgs e)
        {
            //search = applySearchObject();
            //Console.WriteLine(search.verbose());
        }

        void clear_Click(object sender, EventArgs e)
        {

        }

        void toggle_Click(object sender, EventArgs e)
        {
            form_panel.Visible = !form_opened; form_opened = !form_opened;
            toggle.Text = form_opened ? CONST.VAR.MISC.FILTER_OFF : CONST.VAR.MISC.FILTER_ON;
        }

        private void cb_enableChanged(object sender, EventArgs e)
        {
            var cb = sender as modComboBox;
            //cb.
        }
        #endregion

        #region listener II
        void cb_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!doFilterOrderNumber()) { doFilterBillNumber(); }
        }

        void cb_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!doFilterOrderNumber()) { doFilterBillNumber(); }
        }

        private void cb_transittype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!doFilterOrderNumber()) { doFilterBillNumber(); }
        }

        void cb_ordernumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void cb_billnumber_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        void cb_orderstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void cb_expensestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        void cb_hirer_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        void cb_receiver_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        void cb_staff_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        void cb_plate_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion

        #region find
        private modTable findTable()
        {
            return this.panel.Controls.Find(table_name, false).FirstOrDefault() as modTable;
        }

        private modComboBox findComboBox(string name)
        {
            if (findTable() == null) { return null; }
            else { return findTable().Controls.Find(name, false).FirstOrDefault() as modComboBox; }
        }

        private modLabel findLabel(string name)
        {
            if (findTable() == null) { return null; }
            else { return findTable().Controls.Find(name, false).FirstOrDefault() as modLabel; }
        }
        #endregion

        #region DYNAMIC TABLE
        private modTable createDynamicTable()
        {
            int max_col = 6;
            var row = new modRowStyle(SizeType.AutoSize, 0F);
            var col = new List<modColumnStyle>(){
                new modColumnStyle(SizeType.AutoSize, 0f),
                new modColumnStyle(SizeType.Percent, 33f),
                new modColumnStyle(SizeType.AutoSize, 0f),
                new modColumnStyle(SizeType.Percent, 33f),
                new modColumnStyle(SizeType.AutoSize, 0f),
                new modColumnStyle(SizeType.Percent, 33f)
            };

            table = new modTable(0, max_col, row, col);
            //table.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            table.AutoSize = true;
            table.Name = table_name;
            table.Dock = DockStyle.Top;
            return table;
        }

        #region controls in table
        private int curr_row = 0;
        private int curr_col = 0;
        private void add_controls(modLabel l, modComboBox mc, bool first_visible)//assume that the table has even number of columns
        {
            if (table.RowCount <= curr_row)
            {
                table.AddRow();
            }
            if (table.ColumnCount <= curr_col)
            {
                table.AddRow();
                curr_col = 0;
                curr_row++;
            }
            l.Visible = first_visible;
            mc.Visible = first_visible;
            table.AddControls(l, curr_row, curr_col);
            curr_col++;
            table.AddControls(mc, curr_row, curr_col);
            curr_col++;
        }

        private modLabel createLabel(string text, string name)
        {
            var l = new modLabel();
            l.Text = text;
            l.Name = name;
            l.Dock = DockStyle.Fill;
            l.TextAlign = ContentAlignment.MiddleRight;
            l.AutoSize = true;
            return l;
        }

        private modComboBox createComboBox(string name)
        {
            var cb = new modComboBox();
            cb.Name = name;
            cb.Dock = DockStyle.Fill;
            return cb;
        }
        #endregion

        private void modifyDynamicTable()
        {
            //always
            #region month
            if (this.showMonth)
            {
                var cb_month = createComboBox(cbname_month);
                cb_month.initialElements<CalendarItems>(CalendarItems.selectMonths(), Utility.GetMemberName(() => new CalendarItems().Text), true);
                cb_month.SelectedIndexChanged += cb_month_SelectedIndexChanged;
                add_controls(createLabel(label_month, lbname_month), cb_month, true);
            }
            #endregion
            //always
            #region year
            if (this.showYear)
            {
                var cb_year = createComboBox(cbname_year);
                cb_year.initialElements<CalendarItems>(CalendarItems.selectYears(), Utility.GetMemberName(() => new CalendarItems().Text), true);
                cb_year.SelectedIndexChanged += cb_year_SelectedIndexChanged;
                add_controls(createLabel(label_year, lbname_year), cb_year, true);
            }
            #endregion
            //select
            #region transit type
            if (this.showTransitType)
            {
                var cb_transittype = createComboBox(cbname_transittype);
                //cb_transittype.initialElements<transittypes>(transittypes.select(), Utility.GetMemberName(() => new transittypes().name), true);
                cb_transittype.SelectedIndexChanged += cb_transittype_SelectedIndexChanged;
                add_controls(createLabel(label_transitTypes, lbname_transittype), cb_transittype, true);
            }
            #endregion
            //select + depend
            #region order num
            if (this.showOrderNumber)
            {
                var cb_ordernumber = createComboBox(cbname_orderNo);
                cb_ordernumber.SelectedIndexChanged += cb_ordernumber_SelectedIndexChanged;
                cb_ordernumber.EnabledChanged += cb_enableChanged;
                add_controls(createLabel(label_orderNo, lbname_orderNo), cb_ordernumber, false);
            }
            #endregion
            //select
            #region order status
            if (this.showOrderStatus)
            {
                var cb_orderstatus = createComboBox(cbname_orderStatus);
                //cb_orderstatus.initialElements<TransitStatuses>(TransitStatuses.getList(), Utility.GetMemberName(() => new TransitStatuses().text), true);
                cb_orderstatus.SelectedIndexChanged += cb_orderstatus_SelectedIndexChanged;
                add_controls(createLabel(label_orderStatus, lbname_orderStatus), cb_orderstatus, true);
            }
            #endregion
            //select
            #region paid status
            if (this.showPaidStatus)
            {
                var cb_expensestatus = createComboBox(cbname_paidStatus);
                //cb_expensestatus.initialElements<PaidStatus>(PaidStatus.getList(), Utility.GetMemberName(() => new PaidStatus().text), true);
                cb_expensestatus.SelectedIndexChanged += cb_expensestatus_SelectedIndexChanged;
                add_controls(createLabel(label_paidStatus, lbname_paidStatus), cb_expensestatus, true);
            }
            #endregion
            //select + depend
            #region bill num
            if (this.showBillNumber)
            {
                var cb_billnumber = createComboBox(cbname_billNo);
                cb_billnumber.SelectedIndexChanged += cb_billnumber_SelectedIndexChanged;
                cb_billnumber.EnabledChanged += cb_enableChanged;
                add_controls(createLabel(label_billNo, lbname_billNo), cb_billnumber, false);
            }
            #endregion
            //always
            #region hirer
            if (this.showHirer)
            {
                var cb_hirer = createComboBox(cbname_hirer);
                //cb_hirer.initialElements<customers>(customers.select(), Utility.GetMemberName(() => new customers().thaiName), true);
                cb_hirer.SelectedIndexChanged += cb_hirer_SelectedIndexChanged;
                add_controls(createLabel(label_hirer, lbname_hirer), cb_hirer, true);
            }
            #endregion
            //always
            #region receiver
            if (this.showReceiver)
            {
                var cb_receiver = createComboBox(cbname_receiver);
                //cb_receiver.initialElements<customers>(customers.select(), Utility.GetMemberName(() => new customers().thaiName), true);
                cb_receiver.SelectedIndexChanged += cb_receiver_SelectedIndexChanged;
                add_controls(createLabel(label_receiver, lbname_receiver), cb_receiver, true);
            }
            #endregion
            //always
            #region staff
            if (this.showstaff)
            {
                var cb_staff = createComboBox(cbname_staff);
                //cb_staff.initialElements<staff>(staff.select(), Utility.GetMemberName(() => new staff().thaiName), true);
                cb_staff.SelectedIndexChanged += cb_staff_SelectedIndexChanged;
                add_controls(createLabel(label_staff, lbname_staff), cb_staff, true);
            }
            #endregion
            //always
            #region plate
            if (this.showCarrierPlate)
            {
                var cb_plate = createComboBox(cbname_plate);
                //cb_plate.initialElements<carriers>(carriers.select(), Utility.GetMemberName(() => new carriers().plate), true);
                cb_plate.SelectedIndexChanged += cb_plate_SelectedIndexChanged;
                add_controls(createLabel(label_plate, lbname_plate), cb_plate, true);
            }
            #endregion
        }

        #endregion
    }

    public sealed class searchObject
    {
        public Nullable<int> month { get; set; }
        public Nullable<int> year { get; set; }
        public Nullable<long> transittypeId { get; set; }
        public Nullable<decimal> orderId { get; set; }
        //public TransitStatuses orderStatus { get; set; }
        //public PaidStatus paidStatus { get; set; }
        public Nullable<decimal> billId { get; set; }
        public Nullable<decimal> hirerId { get; set; }
        public Nullable<decimal> receiverId { get; set; }
        public Nullable<decimal> staffId { get; set; }
        public Nullable<decimal> carrierId { get; set; }

        //internal string verbose()
        //{
        //    string s = "";
        //    s += getValue("Month", this.month) + getValue("Year", this.year) + getValue("ttId", this.transittypeId);
        //    s += getValue("oId", this.orderId) + getValue("oState", this.orderStatus) + this.orderStatus.verbose();
        //    s += getValue("pState", this.paidStatus) + this.paidStatus.verbose();
        //    s += getValue("bId", this.billId) + getValue("hId", this.hirerId) + getValue("rId", this.receiverId);
        //    s += getValue("dId", this.staffId) + getValue("cId", this.carrierId);
        //    return s;
        //}

        private string getValue(string t, object o)
        {
            return string.Format("{0} = '{1}'({2})", t, o, o == null ? "null" : "not null") + Environment.NewLine;
        }
    }
}
