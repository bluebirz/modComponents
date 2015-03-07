namespace LogistMate.Components
{
    public partial class modSearch
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
            this.forms = new System.Windows.Forms.GroupBox();
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toggle = new LogistMate.Components.modButton();
            this.form_panel = new System.Windows.Forms.Panel();
            this.submit = new LogistMate.Components.modSubmitForm();
            this.forms.SuspendLayout();
            this.panel1.SuspendLayout();
            this.form_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // forms
            // 
            this.forms.Controls.Add(this.panel);
            this.forms.Dock = System.Windows.Forms.DockStyle.Top;
            this.forms.Location = new System.Drawing.Point(0, 0);
            this.forms.Name = "forms";
            this.forms.Padding = new System.Windows.Forms.Padding(5);
            this.forms.Size = new System.Drawing.Size(433, 125);
            this.forms.TabIndex = 5;
            this.forms.TabStop = false;
            this.forms.Text = "กรอกค่าเพื่อค้นหา";
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(5, 18);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(423, 0);
            this.panel.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toggle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 27);
            this.panel1.TabIndex = 7;
            // 
            // toggle
            // 
            this.toggle.Dock = System.Windows.Forms.DockStyle.Left;
            this.toggle.Location = new System.Drawing.Point(0, 0);
            this.toggle.Name = "toggle";
            this.toggle.Size = new System.Drawing.Size(109, 27);
            this.toggle.TabIndex = 3;
            this.toggle.UseVisualStyleBackColor = true;
            // 
            // form_panel
            // 
            this.form_panel.AutoSize = true;
            this.form_panel.Controls.Add(this.forms);
            this.form_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.form_panel.Location = new System.Drawing.Point(0, 27);
            this.form_panel.Name = "form_panel";
            this.form_panel.Size = new System.Drawing.Size(433, 125);
            this.form_panel.TabIndex = 8;
            // 
            // submit
            // 
            this.submit.AutoSize = true;
            this.submit.customButtonText1 = null;
            this.submit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.submit.formSize = new System.Drawing.Size(100, 25);
            this.submit.Location = new System.Drawing.Point(0, 158);
            this.submit.Name = "submit";
            this.submit.showAccept = true;
            this.submit.showAdd = false;
            this.submit.showCancel = true;
            this.submit.showClear = false;
            this.submit.showClose = false;
            this.submit.showCustom1 = false;
            this.submit.showDecline = false;
            this.submit.showDelete = false;
            this.submit.showEdit = false;
            this.submit.showSave = false;
            this.submit.showView = false;
            this.submit.Size = new System.Drawing.Size(433, 36);
            this.submit.TabIndex = 9;
            // 
            // modSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.submit);
            this.Controls.Add(this.form_panel);
            this.Controls.Add(this.panel1);
            this.Name = "modSearch";
            this.Size = new System.Drawing.Size(433, 194);
            this.forms.ResumeLayout(false);
            this.forms.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.form_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox forms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel;
        private modButton toggle;
        private System.Windows.Forms.Panel form_panel;
        private modSubmitForm submit;
    }
}
