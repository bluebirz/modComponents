using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogistMate.Components
{
    public class modListView : ListView
    {
        public event EventHandler<ItemChangedArgs> ItemChanged;

        public modListView()
        {
            this.View = System.Windows.Forms.View.Details;
            this.GridLines = true;
            this.CheckBoxes = false;
            this.FullRowSelect = true;
            this.MultiSelect = false;
            this.HideSelection = false;
            this.ItemChanged += (s, e) => { };
        }

        #region override
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion

        #region setup
        protected internal void setDefaultProperties(bool addCheckbox = false, View v = View.Details, bool fullrow = true, bool multi = false, bool showSelect = true)
        {

            this.View = v;
            this.GridLines = true;
            this.CheckBoxes = addCheckbox;
            this.FullRowSelect = fullrow;
            this.MultiSelect = multi;
            this.HideSelection = !showSelect;
        }

        private int getDefaultColumnWidth(string s)
        {

            int formula = s.Length * 10;
            formula = -2;
            return formula;
        }

        protected internal bool initialHeader(string[] header)
        {
            try
            {
                if (header != null)
                {
                    foreach (string i in header)
                    {
                        var h = new ColumnHeader(i);
                        h.Text = i;
                        h.Width = getDefaultColumnWidth(i);
                        h.TextAlign = HorizontalAlignment.Center;
                        //Console.WriteLine(i + h.TextAlign);
                        this.Columns.Add(h);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        #region count
        protected internal int countSelectedItems()
        {
            return this.SelectedItems.Count;
        }

        protected internal int countUnselectItems()
        {
            return this.Items.Count - this.countSelectedItems();
        }

        protected internal int countCheckedItems()
        {
            return this.CheckedItems.Count;
        }

        protected internal int countUncheckedItems()
        {
            return this.Items.Count - this.countCheckedItems();
        }
        #endregion

        #region find
        private int findColumnName(string find)
        {
            int index = 0;
            foreach (ColumnHeader ch in this.Columns)
            {
                if (find == ch.Text)
                {
                    return index;
                }
                else
                {
                    index++;
                }
            }
            return -1;
        }

        private bool compare(object o, object p)
        {
            bool result = o.Equals(p);
            //Console.WriteLine("[{0}].compare o{1} p{2} res{3}", this.Name, o.GetType(), p.GetType(), result);
            return result;
        }

        protected internal int[] findObjectRow(object o)
        {
            var f = new List<int>();
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (compare(o, (this.Items[i].Tag))) { f.Add(i); }
            }
            return f.ToArray<int>();
        }
        #endregion

        #region GET (select/unselect/check/uncheck + obj/list<T>
        protected internal List<T> getAllItems<T>() where T : class
        {
            var list = new List<T>();
            for (int i = 0; i < this.Items.Count; i++)
            {
                list.Add(this.Items[i].Tag as T);
            }
            return list;
        }

        protected internal object getSelectedObj(int selectedIndex = 0)
        {
            if (this.countSelectedItems() > 0 && this.SelectedItems.Count > selectedIndex)
            {
                return this.SelectedItems[selectedIndex].Tag;
            }
            else
            {
                return null;
            }
        }

        protected internal object getUnselectedObj(int seletedIndex = 0)
        {
            if (this.countUnselectItems() > 0)
            {
                for (int i = 0, shift = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Selected == false)
                    {
                        if (shift == seletedIndex) { return this.Items[i].Tag; }
                        else { shift++; }
                    }
                }
            }
            return null;
        }

        protected internal object getCheckedObj(int selectedIndex = 0)
        {
            if (this.CheckBoxes == true && this.countCheckedItems() > 0 && this.CheckedItems.Count > selectedIndex)
            {
                return this.CheckedItems[selectedIndex].Tag;
            }
            else
            {
                return null;
            }
        }

        protected internal object getUncheckedObj(int selectedIndex = 0)
        {
            if (this.CheckBoxes == true)
            {
                for (int i = 0, shift = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Checked == false)
                    {
                        if (shift == selectedIndex) { return this.Items[i].Tag; }
                        else { shift++; }
                    }
                }
            }
            return null;
        }

        protected internal List<T> getSelectedList<T>() where T : new()
        {
            if (this.countSelectedItems() > 0)
            {
                List<T> tags = new List<T>();
                for (int i = 0; i < this.SelectedItems.Count; i++)
                {
                    tags.Add((T)this.SelectedItems[i].Tag);
                }
                return tags;
            }
            else
            {
                return null;
            }
        }

        protected internal List<T> getUnselectedList<T>() where T : new()
        {
            if (this.countUnselectItems() > 0)
            {
                List<T> tags = new List<T>();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Selected == true)
                    {
                        tags.Add((T)this.Items[i].Tag);
                    }
                }
                return tags;
            }
            else
            {
                return null;
            }
        }

        protected internal List<T> getCheckedList<T>() where T : new()
        {
            if (this.CheckBoxes == true && this.countCheckedItems() > 0)
            {
                List<T> tags = new List<T>();
                for (int i = 0; i < this.CheckedItems.Count; i++)
                {
                    tags.Add((T)this.CheckedItems[i].Tag);
                }
                return tags;
            }
            else
            {
                return null;
            }
        }

        protected internal List<T> getUncheckedList<T>() where T : new()
        {
            if (this.CheckBoxes == true)
            {
                List<T> tags = new List<T>();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Checked == false)
                    {
                        tags.Add((T)this.Items[i].Tag);
                    }
                }
                return tags;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region SET
        /// <summary>
        /// set specific row to be selected/unselected
        /// </summary>
        /// <param name="isSelected"></param>
        /// <param name="rowId"></param>
        /// <returns></returns>
        protected internal bool setSelectedRow(bool isSelected, int rowId)
        {
            if (rowId > 0)
            {
                this.Items[rowId].Selected = isSelected;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected internal bool setSelectedObj(bool isSelected, object obj)
        {
            if (obj != null)
            {
                int pointer = 0;
                foreach (ListViewItem row in this.Items)
                {
                    if (compare(row.Tag, obj))
                    {
                        this.Items[pointer].Selected = isSelected;
                        return true;
                    }
                    else
                    {
                        pointer++;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        protected internal bool setCheckedRow(bool isChecked, int rowId)
        {
            if (rowId < this.Items.Count && this.CheckBoxes == true)
            {
                this.Items[rowId].Checked = isChecked;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected internal bool setCheckedObj(bool isChecked, object obj)
        {
            if (obj != null && this.CheckBoxes == true)
            {
                int pointer = 0;
                foreach (ListViewItem row in this.Items)
                {
                    if (row.Tag.Equals(obj))
                    {
                        this.Items[pointer].Checked = isChecked;
                        return true;
                    }
                    else
                    {
                        pointer++;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        protected internal void setAllSelectedObj(bool isSelected)
        {
            for (int i = 0; i < this.Items.Count; i++) { this.Items[i].Selected = isSelected; }
        }

        protected internal void setAllCheckedObj(bool isChecked)
        {
            if (this.CheckBoxes == true) { for (int i = 0; i < this.Items.Count; i++) { this.Items[i].Checked = isChecked; } }
        }
        #endregion

        #region add/update/delete/clear
        internal bool addItems(List<string[]> list)
        {
            if (list != null)
            {
                foreach (var l in list) { this.Items.Add(new ListViewItem(l)); }
                ItemChanged(this, new ItemChangedArgs(list.Count));
                return true;
            }
            else { return false; }
        }

        internal bool addItems(List<string[]> string_list, List<object[]> obj_list)
        {
            if (string_list != null && obj_list != null && string_list.Count == obj_list.Count)
            {
                for (int i = 0; i < string_list.Count; i++)
                {
                    var lvItem = new ListViewItem(string_list[i]);
                    lvItem.Tag = obj_list[i];
                    this.Items.Add(lvItem);
                }
                if (obj_list.Count > 0) { ItemChanged(this, new ItemChangedArgs(obj_list.Count)); }
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool addItems<T>(List<T> ObjItems) where T : new()
        {
            if (ObjItems != null && ObjItems.Count > 0)
            {
                try
                {

                    foreach (dynamic item in ObjItems)
                    {
                        //Console.WriteLine("[{0}].add item.toarr.null={1}", this.Name, item.ToArray() == null);
                        var lvItem = new ListViewItem(item.ToArray());
                        lvItem.Tag = item;
                        this.Items.Add(lvItem);
                        ItemChanged(this, new ItemChangedArgs(ObjItems.Count));
                    }
                    return true;
                }
                catch (Exception e)
                {
                    //throw new Exception();
                    //Console.WriteLine("here");
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        internal bool updateItems<T>(List<T> ObjItems)
        {
            try
            {
                int nSelect = this.countSelectedItems();
                if (nSelect > 0 && nSelect == ObjItems.Count)
                {
                    for (int i = 0; i < nSelect; i++)
                    {
                        string[] array = ((dynamic)ObjItems[i]).ToArray();
                        if (array.Length == this.SelectedItems[i].SubItems.Count)
                        {
                            for (int j = 0; j < array.Length; j++)
                            {
                                this.SelectedItems[i].SubItems[j].Text = array[j];
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal bool deleteSelectedItems()
        {
            if (this.countSelectedItems() > 0)
            {
                var count = 0;
                foreach (ListViewItem lvi in this.SelectedItems)
                {
                    this.Items.RemoveAt(lvi.Index);
                    count--;
                }
                if (count < 0) { ItemChanged(this, new ItemChangedArgs(count)); }
                return true;
            }
            return false;
        }

        internal bool deleteUnselectedItems()
        {
            if (this.countSelectedItems() > 0)
            {
                var count = 0;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Selected == false)
                    {
                        this.Items[i].Remove();
                        count--;
                    }
                }
                if (count < 0) { ItemChanged(this, new ItemChangedArgs(count)); }
                return true;
            }
            return false;
        }

        internal bool deleteCheckedItems()
        {
            var count = this.countCheckedItems();
            if (this.CheckBoxes == true && count > 0)
            {
                foreach (ListViewItem lvi in this.CheckedItems)
                {
                    this.Items.RemoveAt(lvi.Index);
                }
                ItemChanged(this, new ItemChangedArgs(0 - count));
                return true;
            }
            return false;
        }

        internal bool deleteUncheckedItems()
        {
            if (this.CheckBoxes == true)
            {
                var count = this.countUncheckedItems();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Checked == false)
                    {
                        this.Items[i].Remove();
                    }
                }
                if (count > 0) { ItemChanged(this, new ItemChangedArgs(0 - count)); }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// remove all rows in this listview
        /// </summary>
        internal void clearItems()
        {
            var count = this.Items.Count;
            this.Items.Clear();
            if (count > 0) { ItemChanged(this, new ItemChangedArgs(count)); }
        }

        internal bool updateList<T>() where T : new()
        {
            try
            {
                foreach (ListViewItem i in this.Items)
                {
                    if (i.Tag != null)
                    {
                        string[] arr = ((dynamic)i.Tag).ToArray();
                        for (int index = 0; index < arr.Length; index++)
                        {
                            i.SubItems[index].Text = arr[index];
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

    }

    public class ItemChangedArgs : EventArgs
    {
        private int _count;
        public ItemChangedArgs(int c) { this._count = c; }
        public int Count { get { return this._count; } }
    }
}
