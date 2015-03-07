using LogistMate.CONST;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogistMate.Components
{
    public class modComboBox : System.Windows.Forms.ComboBox
    {
        private bool isExisted_ALLOPTION = false;
        private bool isShowingNodata = false;
        private bool enableAutoSuggestion = false;
        private IEnumerable<object> autoSuggestData = null;
        private string member = null;
        private string[] autoSuggestArray = null;

        public modComboBox()
        {
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            //Console.WriteLine("[{0}].flat = {1}", this.Name, this.FlatStyle);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            //Console.WriteLine("[{0}].flat(onvis) = {1}", this.Name, this.FlatStyle);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height));
            //Console.WriteLine("[{0}].flat(onpaint) = {1}", this.Name, this.FlatStyle);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            //Console.WriteLine("bool:{0} list:{1} member:{2}", this.enableAutoSuggestion, this.autoSuggestData, this.member);
            //doTextChanged_modifySearch();
            base.OnTextChanged(e);
        }

        private void doTextChanged_modifySearch()
        {
            if (this.enableAutoSuggestion == true)
            {
                //Console.WriteLine("+ {0}", autoSuggestData.GetType());
                var text = this.Text;
                if (member == null) { toggleAutoSuggestBox(text, autoSuggestArray); }
                else { toggleAutoSuggestBox(text); }
                //this.setSelectedIndex(-2);
            }
            //this.SelectedIndex = -1;
        }

        private void doKeyUp_modifySearch(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                int sStart = this.SelectionStart;
                if (sStart > 0)
                {
                    sStart--;
                    if (sStart == 0)
                    {
                        this.Text = "";
                    }
                    else
                    {
                        this.Text = this.Text.Substring(0, sStart);
                    }
                }
                e.Handled = true;
            }
        }

        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            //doKeyUp_modifySearch(e);
            base.OnKeyUp(e);
        }

        #region autosuggest
        private void addAutoSuggest<T>(List<T> source, string displaymember) where T : new()
        {
            if (source != null)
            {
                var src = source.Select(s => s.GetType().GetProperty(displaymember).GetValue(s).ToString()).ToArray();
                var acsc = new AutoCompleteStringCollection();
                acsc.AddRange(src);
                this.AutoCompleteCustomSource = acsc;
                this.DropDownStyle = ComboBoxStyle.DropDown;
                this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            }
        }

        private void addAutoSuggest(string[] source)
        {
            if (source != null)
            {
                this.DropDownStyle = ComboBoxStyle.DropDown;
                this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
                var acsc = new AutoCompleteStringCollection();
                acsc.AddRange(source);
                this.AutoCompleteCustomSource = acsc;
            }
        }

        private void toggleAutoSuggestBox(string s)
        {
            //Console.WriteLine(this.autoSuggestData == null ? "null" : "not null");
            if (this.enableAutoSuggestion == true && this.autoSuggestData != null && Utility.isNullString(s) == false)
            {
                var filterData = new List<object>();
                string firstString = null;
                //Console.WriteLine(this.Text);
                foreach (object f in this.autoSuggestData)
                {
                    var captureString = f.GetType().GetProperty(this.member).GetValue(f).ToString();
                    //Console.Write("+" + captureString);
                    if (Utility.isSubstring(captureString, s) && captureString != s)
                    {
                        if (firstString == null) { firstString = captureString; }
                        filterData.Add(f);

                    }
                }

                //Console.WriteLine("f:{0} f.len:{1} s:{2} s.len:{3}", firstString, firstString.Length, s, s.Length);
                if (filterData.Count() > 0)
                {
                    this.DataSource = new System.Windows.Forms.BindingSource().DataSource = filterData;
                    this.DisplayMember = member;
                    //this.SelectionStart = s.Length;
                    //this.SelectionLength = firstString.Length - s.Length;
                    //this.SelectedIndex = -1;
                    //this.SelectedText = s;
                    this.SelectionStart = s.Length;
                    this.SelectionLength = 0;
                    this.DroppedDown = true;
                }
                else
                {
                    //this.SelectionStart = s.Length;
                    this.DroppedDown = false;
                }
            }
        }

        private void toggleAutoSuggestBox(string s, string[] data)
        {
            var filterData = new List<string>();
            foreach (string d in data) { if (Utility.isSubstring(d, s)) { filterData.Add(d); } }
            //this.SelectionStart = s.Length;
            var filterArr = filterData.ToArray();
            if (filterArr.Count() > 0)
            {
                this.DataSource = filterArr;
                //this.SelectionLength = filterArr[0].Length - s.Length;
                this.DroppedDown = true;
            }
            else
            {
                this.DroppedDown = false;
            }
        }
        #endregion

        #region initialization
        protected internal void initialElements(string singleData)
        {
            this.BindingContext = new System.Windows.Forms.BindingContext();
            this.DataSource = new System.Windows.Forms.BindingSource().DataSource = new string[] { singleData };
            this.Invalidate();
        }

        protected internal void initialElements(string[] data, int default_index = 0, string default_string = "", bool autosuggest = false)
        {
            this.DataSource = data;
            this.Invalidate();
            setSelectedIndex(default_index);
            if (autosuggest)
            {
                //this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                //this.enableAutoSuggestion = true;
                //this.autoSuggestData = data;
                addAutoSuggest(data);
            }
        }

        protected internal enum TYPE { DAY, MONTH, YEAR };
        protected internal void initialTime(TYPE type, bool showDefault = false, int default_index = 0, string default_text = null, bool autosuggest = false)
        {
            var data = new List<CalendarItems>();
            string member = Utility.GetMemberName(() => new CalendarItems().Text);
            switch (type)
            {
                case TYPE.DAY: data = CalendarItems.selectDates(); break;
                case TYPE.MONTH: data = CalendarItems.selectMonths(); break;
                case TYPE.YEAR: data = CalendarItems.selectYears(); break;
            }
            this.initialElements<CalendarItems>(data, member, showDefault, default_index, default_text);
            if (autosuggest)
            {
                //this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                //this.enableAutoSuggestion = true;
                ////this.autoSuggestData = data;
                addAutoSuggest(data, member);
            }
        }

        /// <summary>
        /// set a datasource to the specific combobox. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="displayMember"></param>
        /// <param name="showDefault">if this is true, options in combobox include "ALL" option. Expecting that object T in a list contains variable 'id', this method will set a datasource with that option and its id = -1</param>
        /// <param name="default_index"></param>
        /// <param name="default_string"></param>
        protected internal void initialElements<T>(List<T> list, string displayMember, bool showDefault = false, int default_index = 0, string default_string = null, bool autosuggest = false) where T : new()
        {
            if (list != null && list.Count > 0)
            {
                if (showDefault)
                {
                    Object o = Activator.CreateInstance(new T().GetType());
                    o.GetType().GetProperty(displayMember).SetValue(o, default_string == null ? SIGHT.MISC.ALL : default_string, null);
                    var v = o.GetType().GetProperty("id");
                    var grant = Convert.ChangeType(-1, v.GetValue(o, null).GetType());
                    v.SetValue(o, grant, null);
                    list.Insert(0, (T)o);
                    this.isExisted_ALLOPTION = true;
                    //default_index--;
                }
                //this.Enabled = true;
                this.BindingContext = new System.Windows.Forms.BindingContext();
                this.DataSource = new System.Windows.Forms.BindingSource().DataSource = list;
                this.DisplayMember = displayMember;
                this.isShowingNodata = false;
                this.Invalidate();
                int counter = list.Count;
                setSelectedIndex(default_index);
                if (autosuggest)
                {
                    //this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
                    //this.enableAutoSuggestion = true;
                    //this.autoSuggestData = list.Cast<object>().ToList();
                    ////Console.WriteLine(this.autoSuggestData.First() is location ? "loc" : this.autoSuggestData.First().GetType().ToString());
                    //this.member = displayMember;
                    ////this.autoSuggestArray = list.Select(l => l.GetType().GetProperty(displayMember).GetValue(l).ToString()).ToArray();
                    addAutoSuggest<T>(list, displayMember);
                }
            }
            else
            {
                initialNoElements();
            }
        }

        protected internal void initialNoElements()
        {
            this.isShowingNodata = true;
            this.initialElements(SIGHT.MISC.NO_DATA);
        }

        protected internal void clearComboBox()
        {
            this.DataSource = null;
            this.Text = string.Empty;
        }
        #endregion

        #region indexOf
        /// <summary>
        /// launch a specific item to be shown in this combobox
        /// </summary>
        /// <typeparam name="T">class of combobox item</typeparam>
        /// <param name="propNameOfDataSource">property name of items in this combobox</param>
        /// <param name="obj">object that relates to the property name eg. int/double/etc.</param>
        protected internal void promptValue<T>(string propNameOfDataSource, object obj) where T : new()
        {
            var list = this.DataSource as List<T>;
            int run = 0;
            int index = -1;
            if (list != null && list.Count > 0)
            {
                foreach (T item in list)
                {
                    object propList = item.GetType().GetProperty(propNameOfDataSource).GetValue(item, null);
                    //Console.WriteLine("[{0}].promptvalue() obj{1} proL{2}", this.Name, obj, propList);
                    if (obj != null && propList != null && propList.GetType() == obj.GetType() && propList.Equals(obj))
                    {
                        index = run;
                        //Console.WriteLine("[{0}].promptvalue() [if] obj{1} proL{2} run{3}", this.Name, obj, propList, run);
                        break;
                    }
                    run++;
                }
            }
            //Console.WriteLine("[{0}].promptvalue index = {1}", this.Name, index);
            setSelectedIndex(index);
        }

        //protected internal void promptValue<T>(T obj, string propName) where T : new()
        //{
        //    promptValue(obj.GetType().GetProperty(propName).GetValue(obj, null), propName);
        //}

        protected internal void promptValue(string obj)
        {
            if (this.DataSource as string[] != null && obj != null)
            {
                int locate = Array.IndexOf(this.DataSource as string[], obj);
                setSelectedIndex(locate);
            }
        }

        protected internal void promptValue<T, U>(List<T> data, U value, string memberOfList, string memberNameOfSample)
            where T : new()
            where U : new()
        {
            int run = 0;
            int index = -1;
            foreach (object obj in data)
            {
                object memberInListElement = obj.GetType().GetProperty(memberOfList).GetValue(obj, null);
                object memberInSample = value.GetType().GetProperty(memberNameOfSample).GetValue(value, null);
                if (memberInListElement.GetType() == memberInSample.GetType() && memberInListElement.Equals(memberInSample))
                {
                    index = run;
                }
                run++;
            }
            setSelectedIndex(index);
        }

        protected internal void setSelectedIndex(int index)
        {
            //Console.WriteLine("[{0}].setindex idx{1} allOption{2} itemcount{3}", this.Name, index, isExisted_ALLOPTION, this.Items.Count);
            //index += isExisted_ALLOPTION ? 1 : 0;
            this.SelectedIndex = (this.Items.Count > index && index >= 0) ? index : -1;
        }
        #endregion

        protected internal bool hasNoItems()
        {
            //Console.WriteLine("[{0}].hasnoitem() ds={1} count:{2} allop:{3} showno:{4}", this.Name, this.DataSource == null, this.Items.Count, isExisted_ALLOPTION, isShowingNodata);
            return this.DataSource == null || this.Items.Count <= (isExisted_ALLOPTION ? 1 : 0) || isShowingNodata;
        }

    }

    public class modComboBoxItem
    {
        public string text { get; set; }
        public object TaggedObject { get; set; }

        public modComboBoxItem() { }
        public modComboBoxItem(string text, object tag) { this.text = text; this.TaggedObject = tag; }
    }
}
