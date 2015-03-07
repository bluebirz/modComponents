using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogistMate.Components
{
    class modTable : System.Windows.Forms.TableLayoutPanel
    {
        protected internal modRowStyle rowStyle;
        protected internal List<modColumnStyle> colStyle;
        private int _pad = 0;

        public modTable()
        {
            this.RowCount = 0;
            this.ColumnCount = 0;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            //Console.WriteLine("[{0}].create pad:{1}", this.Name, this.Padding.ToString());
            //this.Padding = new Padding(this._pad);
        }

        public modTable(int nRow, int nColumn, modRowStyle mrs, List<modColumnStyle> mcs)
        {
            this.RowCount = nRow;
            this.rowStyle = mrs;
            this.ColumnCount = nColumn;
            this.colStyle = mcs;
            for (int i = 0; i < nColumn; i++)
            {
                this.ColumnStyles.Add(new ColumnStyle(mcs[i].type, mcs[i].width));
                for (int j = 0; j < nRow; j++)
                {
                    this.RowStyles.Add(new RowStyle(mrs.type, mrs.height));
                }
            }
        }

        public modTable(modRowStyle mrs, List<modColumnStyle> mcs)
        {
            this.RowCount = 0;
            this.rowStyle = mrs;
            this.ColumnCount = mcs.Count;
            this.colStyle = mcs;
            for (int i = 0; i < this.ColumnCount; i++)
            {
                this.ColumnStyles.Add(new ColumnStyle(mcs[i].type, mcs[i].width));
                for (int j = 0; j < this.RowCount; j++)
                {
                    this.RowStyles.Add(new RowStyle(mrs.type, mrs.height));
                }
            }
        }

        public void AddRow(modRowStyle row = null)
        {
            row = row ?? rowStyle;
            this.RowCount++;
            this.RowStyles.Add(new RowStyle(row.type, row.height));
        }

        public void AddColumn(modColumnStyle mcs)
        {
            this.ColumnCount++;
            this.ColumnStyles.Add(new ColumnStyle(mcs.type, mcs.width));
        }

        public void InsertRow(int index)
        {
            this.RowCount++;
            this.RowStyles.Insert(index, new RowStyle(rowStyle.type, rowStyle.height));
        }

        public void InsertColumn(int index, modColumnStyle mcs)
        {
            this.ColumnCount++;
            this.ColumnStyles.Insert(index, new ColumnStyle(mcs.type, mcs.width));
        }

        public void RemoveRow(int index)
        {
            if (this.RowCount == 0 || this.RowCount < index) { return; }
            for (int i = 0; i < this.ColumnCount; i++)
            {
                this.Controls.Remove(this.GetControlFromPosition(i, index));
            }
            for (int i = index + 1; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    var c = this.GetControlFromPosition(j, i);
                    if (c != null) { this.SetRow(c, i - 1); }
                }
            }
            //this.RowStyles.RemoveAt(index);
            this.RowCount--;
        }

        public void RemoveColumn(int index)
        {
            if (this.ColumnCount == 0 || this.ColumnCount < index) { return; }
            for (int i = 0; i < this.RowCount; i++)
            {
                this.Controls.Remove(this.GetControlFromPosition(index, i));
            }
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = index + 1; j < this.ColumnCount; j++)
                {
                    this.SetColumn(this.GetControlFromPosition(j, i), j - 1);
                }
            }
            this.ColumnCount--;
        }

        public void AddControls<T>(List<T> items, int rowIndex) where T : System.Windows.Forms.Control
        {
            for (int i = 0; i < this.ColumnCount; i++)
            {
                this.Controls.Add(items[i], i, rowIndex);
            }
        }

        public void AddControls<T>(List<T> items) where T : System.Windows.Forms.Control
        {
            for (int i = 0, shift = 0; i < this.ColumnCount; i++)
            {
                for (int j = 0; j < this.RowCount; j++, shift++)
                {
                    this.Controls.Add(items[shift], i, j);
                    items[shift].Dock = DockStyle.Fill;
                }
            }
        }

        public void AddControls(Control item, int row, int column)
        {
            if (this.RowCount > row && this.ColumnCount > column)
            {
                this.Controls.Add(item, column, row);
            }
            else
            {
            }
        }

        public void RemoveControl(int row, int column)
        {
            var c = this.GetControlFromPosition(column, row);
            this.Controls.Remove(c);
            c.Dispose();
        }

        //internal void AddControls(object p1, int p2, object col_cb)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class modRowStyle
    {
        protected internal SizeType type { get; set; }
        protected internal float height { get; set; }

        public modRowStyle(SizeType type, float height)
        {
            this.type = type;
            this.height = height;
        }

    }
    public class modColumnStyle
    {
        protected internal SizeType type { get; set; }
        protected internal float width { get; set; }

        public modColumnStyle(SizeType type, float width)
        {
            this.type = type;
            this.width = width;
        }

    }

}
