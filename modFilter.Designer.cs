namespace LogistMate.Components
{
    partial class modFilter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toggle = new LogistMate.Components.modCheckBox();
            this.panel_form = new LogistMate.Components.modPanel();
            this.submit = new LogistMate.Components.modSubmitForm();
            this.table = new LogistMate.Components.modTable();
            this.label_startdate = new LogistMate.Components.modLabel();
            this.label_enddate = new LogistMate.Components.modLabel();
            this.label_customer = new LogistMate.Components.modLabel();
            this.label_vehicle = new LogistMate.Components.modLabel();
            this.label_driver = new LogistMate.Components.modLabel();
            this._start = new LogistMate.Components.modDTPicker();
            this._end = new LogistMate.Components.modDTPicker();
            this._customer = new LogistMate.Components.modComboBox();
            this._vehicle = new LogistMate.Components.modComboBox();
            this._driver = new LogistMate.Components.modComboBox();
            this.label_status = new LogistMate.Components.modLabel();
            this._status = new LogistMate.Components.modComboBox();
            this.label_route = new LogistMate.Components.modLabel();
            this._route = new LogistMate.Components.modComboBox();
            this._routeinfo = new LogistMate.Components.modTextBox();
            this.panel_head = new LogistMate.Components.modPanel();
            this.panel_form.SuspendLayout();
            this.table.SuspendLayout();
            this.panel_head.SuspendLayout();
            this.SuspendLayout();
            // 
            // toggle
            // 
            this.toggle.Appearance = System.Windows.Forms.Appearance.Button;
            this.toggle.Dock = System.Windows.Forms.DockStyle.Left;
            this.toggle.Location = new System.Drawing.Point(0, 0);
            this.toggle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toggle.Name = "toggle";
            this.toggle.Size = new System.Drawing.Size(200, 37);
            this.toggle.TabIndex = 0;
            this.toggle.Text = "filter";
            this.toggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggle.UseVisualStyleBackColor = true;
            // 
            // panel_form
            // 
            this.panel_form.AutoSize = true;
            this.panel_form.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_form.Controls.Add(this.submit);
            this.panel_form.Controls.Add(this.table);
            this.panel_form.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_form.Location = new System.Drawing.Point(0, 37);
            this.panel_form.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_form.Name = "panel_form";
            this.panel_form.Size = new System.Drawing.Size(667, 139);
            this.panel_form.TabIndex = 1;
            // 
            // submit
            // 
            this.submit.AutoSize = true;
            this.submit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.submit.buttonSize = new System.Drawing.Size(100, 25);
            this.submit.customButtonText1 = "";
            this.submit.customButtonText2 = null;
            this.submit.customButtonText3 = null;
            this.submit.Dock = System.Windows.Forms.DockStyle.Top;
            this.submit.Location = new System.Drawing.Point(0, 96);
            this.submit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.submit.Name = "submit";
            this.submit.showAccept = true;
            this.submit.showAdd = false;
            this.submit.showCancel = false;
            this.submit.showClear = false;
            this.submit.showClose = false;
            this.submit.showCustom1 = false;
            this.submit.showCustom2 = false;
            this.submit.showCustom3 = false;
            this.submit.showDecline = false;
            this.submit.showDelete = false;
            this.submit.showEdit = false;
            this.submit.showNext = false;
            this.submit.showPrev = false;
            this.submit.showSave = false;
            this.submit.showSplitButton = false;
            this.submit.showView = false;
            this.submit.Size = new System.Drawing.Size(663, 39);
            this.submit.splitButtonText = null;
            this.submit.status = "";
            this.submit.TabIndex = 1;
            // 
            // table
            // 
            this.table.AutoSize = true;
            this.table.ColumnCount = 6;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table.Controls.Add(this.label_startdate, 0, 0);
            this.table.Controls.Add(this.label_enddate, 2, 0);
            this.table.Controls.Add(this.label_customer, 0, 2);
            this.table.Controls.Add(this.label_vehicle, 2, 2);
            this.table.Controls.Add(this.label_driver, 4, 2);
            this.table.Controls.Add(this._start, 1, 0);
            this.table.Controls.Add(this._end, 3, 0);
            this.table.Controls.Add(this._customer, 1, 2);
            this.table.Controls.Add(this._vehicle, 3, 2);
            this.table.Controls.Add(this._driver, 5, 2);
            this.table.Controls.Add(this.label_status, 4, 0);
            this.table.Controls.Add(this._status, 5, 0);
            this.table.Controls.Add(this.label_route, 0, 1);
            this.table.Controls.Add(this._route, 1, 1);
            this.table.Controls.Add(this._routeinfo, 2, 1);
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.table.Name = "table";
            this.table.RowCount = 3;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.table.Size = new System.Drawing.Size(663, 96);
            this.table.TabIndex = 0;
            // 
            // label_startdate
            // 
            this.label_startdate.AutoSize = true;
            this.label_startdate.Location = new System.Drawing.Point(4, 0);
            this.label_startdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_startdate.Name = "label_startdate";
            this.label_startdate.Size = new System.Drawing.Size(63, 16);
            this.label_startdate.TabIndex = 0;
            this.label_startdate.Text = "start date";
            // 
            // label_enddate
            // 
            this.label_enddate.AutoSize = true;
            this.label_enddate.Location = new System.Drawing.Point(232, 0);
            this.label_enddate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_enddate.Name = "label_enddate";
            this.label_enddate.Size = new System.Drawing.Size(61, 16);
            this.label_enddate.TabIndex = 1;
            this.label_enddate.Text = "end date";
            // 
            // label_customer
            // 
            this.label_customer.AutoSize = true;
            this.label_customer.Location = new System.Drawing.Point(4, 64);
            this.label_customer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_customer.Name = "label_customer";
            this.label_customer.Size = new System.Drawing.Size(63, 16);
            this.label_customer.TabIndex = 6;
            this.label_customer.Text = "customer";
            // 
            // label_vehicle
            // 
            this.label_vehicle.AutoSize = true;
            this.label_vehicle.Location = new System.Drawing.Point(232, 64);
            this.label_vehicle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_vehicle.Name = "label_vehicle";
            this.label_vehicle.Size = new System.Drawing.Size(51, 16);
            this.label_vehicle.TabIndex = 7;
            this.label_vehicle.Text = "vehicle";
            // 
            // label_driver
            // 
            this.label_driver.AutoSize = true;
            this.label_driver.Location = new System.Drawing.Point(458, 64);
            this.label_driver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_driver.Name = "label_driver";
            this.label_driver.Size = new System.Drawing.Size(42, 16);
            this.label_driver.TabIndex = 8;
            this.label_driver.Text = "driver";
            // 
            // _start
            // 
            this._start.CustomFormat = "dd MMM, yyyy";
            this._start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._start.Location = new System.Drawing.Point(75, 4);
            this._start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._start.Name = "_start";
            this._start.Size = new System.Drawing.Size(139, 22);
            this._start.TabIndex = 9;
            this._start.TimeType = LogistMate.Components.modDTPicker.TIMETYPE.DATE;
            this._start.Value = new System.DateTime(2015, 3, 7, 0, 0, 0, 0);
            // 
            // _end
            // 
            this._end.CustomFormat = "dd MMM, yyyy";
            this._end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._end.Location = new System.Drawing.Point(301, 4);
            this._end.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._end.Name = "_end";
            this._end.Size = new System.Drawing.Size(139, 22);
            this._end.TabIndex = 10;
            this._end.TimeType = LogistMate.Components.modDTPicker.TIMETYPE.DATE;
            this._end.Value = new System.DateTime(2015, 3, 7, 0, 0, 0, 0);
            // 
            // _customer
            // 
            this._customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._customer.FormattingEnabled = true;
            this._customer.Location = new System.Drawing.Point(75, 68);
            this._customer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._customer.Name = "_customer";
            this._customer.Size = new System.Drawing.Size(139, 24);
            this._customer.TabIndex = 13;
            // 
            // _vehicle
            // 
            this._vehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._vehicle.FormattingEnabled = true;
            this._vehicle.Location = new System.Drawing.Point(301, 68);
            this._vehicle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._vehicle.Name = "_vehicle";
            this._vehicle.Size = new System.Drawing.Size(139, 24);
            this._vehicle.TabIndex = 14;
            // 
            // _driver
            // 
            this._driver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._driver.FormattingEnabled = true;
            this._driver.Location = new System.Drawing.Point(509, 68);
            this._driver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._driver.Name = "_driver";
            this._driver.Size = new System.Drawing.Size(140, 24);
            this._driver.TabIndex = 15;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(458, 0);
            this.label_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(43, 16);
            this.label_status.TabIndex = 5;
            this.label_status.Text = "status";
            // 
            // _status
            // 
            this._status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._status.FormattingEnabled = true;
            this._status.Location = new System.Drawing.Point(509, 4);
            this._status.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._status.Name = "_status";
            this._status.Size = new System.Drawing.Size(139, 24);
            this._status.TabIndex = 12;
            // 
            // label_route
            // 
            this.label_route.AutoSize = true;
            this.label_route.Location = new System.Drawing.Point(4, 32);
            this.label_route.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_route.Name = "label_route";
            this.label_route.Size = new System.Drawing.Size(38, 16);
            this.label_route.TabIndex = 4;
            this.label_route.Text = "route";
            // 
            // _route
            // 
            this._route.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._route.FormattingEnabled = true;
            this._route.Location = new System.Drawing.Point(75, 36);
            this._route.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._route.Name = "_route";
            this._route.Size = new System.Drawing.Size(139, 24);
            this._route.TabIndex = 16;
            // 
            // _routeinfo
            // 
            this._routeinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table.SetColumnSpan(this._routeinfo, 4);
            this._routeinfo.default_value = "";
            this._routeinfo.Enabled = false;
            this._routeinfo.ForeColor = System.Drawing.Color.Black;
            this._routeinfo.inputStyle = LogistMate.Components.modTextBox.InputStyle.TEXT;
            this._routeinfo.Location = new System.Drawing.Point(232, 36);
            this._routeinfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._routeinfo.MaxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._routeinfo.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._routeinfo.Name = "_routeinfo";
            this._routeinfo.ReadOnly = true;
            this._routeinfo.Size = new System.Drawing.Size(425, 22);
            this._routeinfo.TabIndex = 17;
            // 
            // panel_head
            // 
            this.panel_head.Controls.Add(this.toggle);
            this.panel_head.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_head.Location = new System.Drawing.Point(0, 0);
            this.panel_head.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_head.Name = "panel_head";
            this.panel_head.Size = new System.Drawing.Size(667, 37);
            this.panel_head.TabIndex = 2;
            // 
            // modFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel_form);
            this.Controls.Add(this.panel_head);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "modFilter";
            this.Size = new System.Drawing.Size(667, 180);
            this.panel_form.ResumeLayout(false);
            this.panel_form.PerformLayout();
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.panel_head.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private modCheckBox toggle;
        private modPanel panel_form;
        private modTable table;
        private modPanel panel_head;
        private modLabel label_startdate;
        private modLabel label_enddate;
        private modLabel label_route;
        private modLabel label_status;
        private modLabel label_customer;
        private modLabel label_vehicle;
        private modLabel label_driver;
        private modDTPicker _start;
        private modDTPicker _end;
        private modComboBox _status;
        private modComboBox _customer;
        private modComboBox _vehicle;
        private modComboBox _driver;
        private modComboBox _route;
        private modTextBox _routeinfo;
        private modSubmitForm submit;
    }
}
