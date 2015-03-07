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
    public partial class modFilter : UserControl
    {
        protected internal modButton apply { get { return this.submit._accept; } }
        private bool _showToggle;
        public bool showToggle { get { return this._showToggle; } set { this.panel_head.Visible = this._showToggle = value; this.panel_form.Visible = !this._showToggle; } }

        public enum MODE { NONE, ORDERASSIGN_MANUAL, ORDERASSIGN_OPT, ORDERSTATUS, BILL };
        //private MODE _mode;
        public MODE FilterMode { get; set; }

        public modFilter()
        {
            InitializeComponent();
            init_ui();
        }

        private void init_ui()
        {
            this.showToggle = true;
            Utility.setStandardComponentUI(this.table.Controls);
            this.submit.buttonSize = CONFIG.SUBMIT_BUTTON_SIZE.FILTER;

            this.label_startdate.Text = SIGHT.FILTER.START_DATE;
            this.label_enddate.Text = SIGHT.FILTER.END_DATE;
            this.label_route.Text = SIGHT.FILTER.ROUTE;
            this.label_customer.Text = SIGHT.FILTER.CUSTOMER;
            this.label_driver.Text = SIGHT.FILTER.DRIVER;
            this.label_vehicle.Text = SIGHT.FILTER.VEHICLE;

            //this.toggle.Checked = false;
            //this.panel_form.Visible = false;
            this.showToggle = true;
            this.panel_form.Visible = false;
        }

        protected internal void initialization()
        {
            init_data();
            init_listener();
            switch (FilterMode)
            {
                case MODE.NONE:
                    {
                        this.toggle.Text = SIGHT.FILTER.FILTER_ORDER;
                        this.label_status.Text = SIGHT.FILTER.STATUS;
                        setVisibilityComponents();
                        break;
                    }
                case MODE.ORDERASSIGN_MANUAL:
                    {
                        this.toggle.Text = SIGHT.FILTER.FILTER_ORDER;
                        this.label_status.Text = SIGHT.FILTER.STATUS_ORDER;
                        setVisibilityComponents();
                        break;
                    }
                case MODE.ORDERASSIGN_OPT:
                    {
                        this.toggle.Text = SIGHT.FILTER.FILTER_ORDER;
                        this.label_status.Text = SIGHT.FILTER.FILTER_ORDER;
                        setVisibilityComponents(true, true, true, false, false, false, false);
                        break;
                    }
                case MODE.ORDERSTATUS:
                    {
                        this.toggle.Text = SIGHT.FILTER.FILTER_ORDER;
                        this.label_status.Text = SIGHT.FILTER.STATUS_ORDER;
                        setVisibilityComponents();
                        break;
                    }
                case MODE.BILL:
                    {
                        this.toggle.Text = SIGHT.FILTER.FILTER_BILL;
                        this.label_status.Text = SIGHT.FILTER.STATUS_BILL;
                        setVisibilityComponents();
                        break;
                    }
            }
        }

        private void setVisibilityComponents(bool startdate = true, bool enddate = true, bool status = true, bool route = true, bool customer = true, bool vehicle = true, bool driver = true)
        {
            this.label_startdate.Visible = this._start.Visible = startdate;
            this.label_enddate.Visible = this._end.Visible = enddate;
            this.label_status.Visible = this._status.Visible = status;
            this.label_route.Visible = this._route.Visible = this._routeinfo.Visible = route;
            this.label_customer.Visible = this._customer.Visible = customer;
            this.label_vehicle.Visible = this._vehicle.Visible = vehicle;
            this.label_driver.Visible = this._driver.Visible = driver;
        }

        private void init_listener()
        {
            this.toggle.CheckedChanged += (s, e) => { this.panel_form.Visible = (s as modCheckBox).Checked; };
            this._route.SelectedIndexChanged += (s, e) => { showInfo((s as Components.modComboBox).SelectedItem as serviceresources, this._routeinfo); };
        }

        private void showInfo(serviceresources res, Components.modTextBox box)
        {
            box.Text = (res != null && res.id > 0 ? res.getInfo() : "");
        }

        private void setStatus()
        {
            var str_orderstate = Utility.GetMemberName(() => new OrderStatus().text);
            var str_billstate = Utility.GetMemberName(() => new BillStatus().text);
            switch (FilterMode)
            {
                case MODE.NONE: break;
                case MODE.ORDERASSIGN_MANUAL:
                    {
                        this._status.initialElements<OrderStatus>(OrderStatus.getList(), str_orderstate);
                        break;
                    }
                case MODE.ORDERASSIGN_OPT:
                    {
                        this._status.initialElements<OrderStatus>(OrderStatus.getList(), str_orderstate);
                        break;
                    }
                case MODE.ORDERSTATUS:
                    {
                        this._status.initialElements<OrderStatus>(OrderStatus.getList(), str_orderstate);
                    break;
                    }
                case MODE.BILL:
                    {
                        this._status.initialElements<BillStatus>(BillStatus.getList(), str_billstate);
                    break;
                    }
            }
        }

        private void init_data()
        {
            setStatus();
            this._route.initialElements<serviceresources>(serviceresources.select(), Utility.GetMemberName(() => new serviceresources().name), true,0,null,true);
            this._driver.initialElements<driver>(driver.select(), Utility.GetMemberName(() => new driver().nameTH), true,0, null, true);
            this._vehicle.initialElements<vehicle>(vehicle.select(), Utility.GetMemberName(() => new vehicle().plateId), true, 0, null, true);
            this._customer.initialElements<customer>(customer.select(), Utility.GetMemberName(() => new customer().nameTH), true, 0, null, true);
        }

        private List<serviceresources> getRouteList()
        {
            var _cust = this._customer.SelectedItem as customer;
            var _driv = this._driver.SelectedItem as driver;
            var _veh = this._vehicle.SelectedItem as vehicle;
            var _rt = this._route.SelectedItem as serviceresources;
            var cust = (_cust != null && _cust.id > 0 ? (long?)_cust.id : null);
            var driv = (_driv != null && _driv.id > 0 ? (long?)_driv.id : null);
            var veh = (_veh != null && _veh.id > 0 ? (long?)_veh.id : null);
            var rt = (_rt != null && _rt.id > 0 ? _rt : null);
            //Console.WriteLine("[{0}].gerroute _rt:{1} rt:{2}", this.Name, _rt == null ? "null" : "not null", rt == null ? "null" : "not null");
            var route = rt != null ? new List<serviceresources>() { rt } : serviceresources.select(null, null, null, null, veh, driv,true);
            //route.ForEach(r => Console.WriteLine("[{0}].route-foreach {1}", this.Name, r == null ? "null" : r.id.ToString()));
            //Console.WriteLine("[{0}].getroute v:{1} d:{2} route.count:{3}", this.Name, veh, driv, route.Count);
            //Console.WriteLine("[{0}].getroute route:{1}", this.Name, route == null ? "null" : route.Count == 0 ? "0" : string.Join(",", route.Select(r => r == null ? "-" : r.id.ToString())));
            return route;
        }

        protected internal List<orderbills> getBills()
        {
            var status = this._status.SelectedItem as BillStatus;
            if (status != null) //existing 'status' includes 'status.ALL'
            {
                var route = getRouteList();
                if (route != null && route.Count > 0 && route.FirstOrDefault() != null && EF.SQLsetting.canUseCustomConnectionString())
                {
                    var start = this._start.Value;
                    var end = this._end.Value;
                    var bill = orderbills.select(null, null, start, end, status);
                    //var order = route.Select(r => orders_mining.select(null,null,null,null,null,null,null,r.id)).
                    Console.WriteLine("[{0}].getbill bill:{1}", this.Name, bill == null ? "null" : bill.Count.ToString());
                    using (var db = new tmsEntities(EF.SQLsetting.getCustomConnectionString()))
                    {
                        var select = from b in bill
                                     join boc in db.billordercompilation on b.id equals boc.OrderBills_id
                                     join o in db.orders_mining on boc.orders_mining_id equals o.id
                                     join r in route on o.ServiceResources_id equals r.id
                                     orderby b.id
                                     select b;
                        return select.Distinct().ToList();
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        protected internal List<orders_mining> getOrders(bool includeUnassignOrders = true)
        {
            var status = this._status.SelectedItem as OrderStatus;
            if (status != null)
            {
                var route = getRouteList();
                //Console.WriteLine("[{0}].getorder {1}", this.Name, route != null && route.Count > 0 ?( route.FirstOrDefault() == null ? "null first":"not null first") : "null");
                if (route != null && route.Count > 0 && route.FirstOrDefault() != null)
                {
                    var start = this._start.Value;
                    var end = this._end.Value;// how to JOIN unassigned orders??
                    var select = orders_mining.select(null, null, null, null, start, end, null, null, null, status);
                    var assigned = select.Join(route, o => o.ServiceResources_id, r => r.id, (o, r) => o).ToList();

                    if (includeUnassignOrders)
                    {
                        var unassigned = select.Where(om => om.ServiceResources_id == null).ToList();
                        return unassigned.Union(assigned).OrderBy(a => a.id).ToList();
                    }
                    else { return assigned; }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //public FilterItem getValue()
        //{
        //    //var type = getFilterType();
        //    var order_status = this._status.SelectedItem as OrderStatus;
        //    var bill_status = this._status.SelectedItem as BillStatus;
        //    var res = this._route.SelectedItem as serviceresources;
        //    var cust = this._customer.SelectedItem as customer;
        //    var veh = this._vehicle.SelectedItem as vehicle;
        //    var driv = this._driver.SelectedItem as driver;
        //    return new FilterItem()
        //    {
        //        order_state = order_status != null && order_status.id > 0 ? order_status : null,
        //        bill_state = bill_status != null && bill_status.id > 0 ? bill_status : null,
        //        resource = res != null && res.id > 0 ? res : null,
        //        customer = cust != null && cust.id > 0 ? cust : null,
        //        vehicle = veh != null && veh.id > 0 ? veh : null,
        //        driver = driv != null && driv.id > 0 ? driv : null
        //    };
        //}

        //private enum PAPER_TYPE { NONE, ORDER, BILL };
        //private PAPER_TYPE getFilterType()
        //{
        //    switch (this.FilterMode)
        //    {
        //        case MODE.ASSIGN: return PAPER_TYPE.ORDER;
        //        case MODE.OPERATE: return PAPER_TYPE.ORDER;
        //        case MODE.EXPENSE: return PAPER_TYPE.ORDER;
        //        case MODE.CREATE_INVOICE: return PAPER_TYPE.BILL;
        //        case MODE.EDIT_INVOICE: return PAPER_TYPE.BILL;
        //        case MODE.INVOICE_TRANSACTION: return PAPER_TYPE.BILL;
        //        default: return PAPER_TYPE.NONE;
        //    }
        //}

    }

    public class FilterItem
    {
        //public orders_mining order { get; set; }
        //public orderbills bill { get; set; }
        public OrderStatus order_state { get; set; }
        public BillStatus bill_state { get; set; }
        public serviceresources resource { get; set; }
        public customer customer { get; set; }
        public vehicle vehicle { get; set; }
        public driver driver { get; set; }

        public FilterItem()
        {
        }

        public FilterItem(OrderStatus orderStatus, BillStatus billStatus, serviceresources resource, customer customer, vehicle vehicle, driver driver)
        {
            //this.order = orderId;
            //this.bill = billId;
            this.order_state = orderStatus;
            this.bill_state = billStatus;
            this.resource = resource;
            this.customer = customer;
            this.vehicle = vehicle;
            this.driver = driver;
        }
    }
}
