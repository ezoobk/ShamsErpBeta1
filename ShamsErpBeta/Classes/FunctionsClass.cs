﻿using ShamsErpBeta.Classes;
using ShamsErpBeta.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShamsErpBeta.Classes
{
    class FunctionsClass
    {
        public static bool checkDgvError(DataGridView dgv)
        {
            try
            {
                if (dgv.CurrentRow == null) return true;
                if (dgv.CurrentRow.Index == dgv.Rows.Count
                    | dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value == null
                    | dgv.Rows[dgv.CurrentRow.Index].Selected == false)
                    return true;
            }
            catch
            {
                return true;
            }
            return false;
        }
        public static void msgTool(string msg, int style)
        {
            FrmMain frmMain = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            if (frmMain != null)
            {
                if (style == 1)//succesfull
                    frmMain.statusStrip1.BackColor = Color.FromArgb(128, 255, 128);
                else if (style == 2)//warning
                    frmMain.statusStrip1.BackColor = Color.FromArgb(255, 255, 128);
                else if (style == 0)// Error
                    frmMain.statusStrip1.BackColor = Color.FromArgb(255, 128, 128);

                frmMain.tslMessage.Visible = true;
                frmMain.tslMessage.Text = msg;

                frmMain.timer1.Tag = 1;
            }
        }

        public static bool dsHasTables(DataSet ds)
        {
            if (ds == null)
                return false;

            if (ds.Tables.Count > 0)
                return true;
            else
                return false;
        }

        public static void clear(GroupBox g)
        {
            ComboBox cmb;
            PictureBox p;

            foreach (Control c in g.Controls)
            {
                int tagVal = 0;

                if (c is TextBox)
                {
                    if (c.Tag != null)
                        int.TryParse(c.Tag.ToString(), out tagVal);
                    if (tagVal != 1)
                        c.Text = "";
                }

                else if (c is ComboBox)
                {
                    cmb = (ComboBox)c;
                    if (cmb.Tag != null)
                        int.TryParse(cmb.Tag.ToString(), out tagVal);
                    if (tagVal != 1)
                        cmb.SelectedIndex = -1;
                }
                else if (c is PictureBox)
                {
                    p = (PictureBox)c;
                    if (p.Tag != null)
                        int.TryParse(p.Tag.ToString(), out tagVal);
                    if (tagVal != 1)
                        p.Image = null;
                }
            }
        }

        public static void clearPanel(Panel p)
        {
            ComboBox cmb;
            PictureBox px;
            ListBox lst;
            DateTimePicker dtp;

            foreach (Control c in p.Controls)
            {
                int tagVal = 0;

                if (c is TextBox)
                {
                    if (c.Tag != null)
                        int.TryParse(c.Tag.ToString(), out tagVal);
                    if (tagVal != 1)
                        c.Text = "";
                }

                else if (c is ComboBox)
                {
                    cmb = (ComboBox)c;
                    if (cmb.Tag != null)
                        int.TryParse(cmb.Tag.ToString(), out tagVal);
                    if (tagVal != 1)
                        cmb.SelectedIndex = -1;
                }
                else if (c is PictureBox)
                {
                    px = (PictureBox)c;
                    if (px.Tag != null)
                        int.TryParse(p.Tag.ToString(), out tagVal);
                    if (tagVal != 1)
                        px.Image = null;
                }
                else if (c is ListBox)
                {
                    lst = (ListBox)c;
                    if (lst.Tag != null)
                        int.TryParse(lst.ToString(), out tagVal);
                    if (tagVal!= 1)
                        lst.SelectedIndex = -1;
                }
                else if (c is DateTimePicker)
                {
                    dtp = (DateTimePicker)c;
                    if (dtp.Tag != null)
                        int.TryParse(dtp.ToString(), out tagVal);
                    if (tagVal != 1)
                        dtp.Value = DateTime.Now;
                }
            }
        }

        public static void barMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                VariablesClass.sw = true;
                VariablesClass.pos = e.Location;
            }
        }

        public static void barMouseMove(Form f, MouseEventArgs e)
        {
            if (VariablesClass.sw == true)
                f.Location = new Point(f.Location.X + (e.X - VariablesClass.pos.X), f.Location.Y + (e.Y - VariablesClass.pos.Y));
        }

        public static void barMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                VariablesClass.sw = false;
        }


        public static bool isPositiveIntNum(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) | (Keys)e.KeyChar == Keys.Back)
                return true;
            else
                return false;
        }

        public static bool isPositiveRealNum(TextBox sender, KeyPressEventArgs e)
        {
            if (char.IsNumber((char)e.KeyChar) | (Keys)e.KeyChar == Keys.Back | ((Keys)e.KeyChar == (Keys)46 & sender.Text.IndexOf(".") == -1 & sender.Text.Length != 0))
                return true;
            else
                return false;

        }


        public static bool isRealNum(TextBox sender, KeyPressEventArgs e)
        {
            if (char.IsNumber((char)e.KeyChar)
                | (Keys)e.KeyChar == Keys.Back
                | ((Keys)e.KeyChar == (Keys)46 & sender.Text.IndexOf(".") == -1 & sender.Text.Length != 0)
                | ((Keys)e.KeyChar == (Keys)45 & sender.Text.Length == 0))
                return true;
            else
                return false;

        }
        public static DataTable columnHeaderMouseClick(DataGridView dgv, DataTable dt)
        {
            if (dgv.SortOrder.ToString() == "Ascending")
                dt.DefaultView.Sort = dgv.SortedColumn.Name + " ASC";
            else if (dgv.SortOrder.ToString() == "Descending")
                dt.DefaultView.Sort = dgv.SortedColumn.Name + " DESC";

            dgv.ClearSelection();
            return dt.DefaultView.ToTable();
        }
        public static Image byteToImage(byte[] img)
        {
            var ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }

        public static bool dshasTablesAndData(DataSet ds)
        {
            if (ds == null)
                return false;

            if (ds.Tables.Count > 0)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    if (dt.Rows.Count == 0)
                        return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public static bool dthasData(DataTable dt)
        {
            if (dt == null)
                return false;

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool checkEmptyInput(GroupBox g) // tag=2 for exception
        {
            ComboBox cmb = default;

            foreach (Control c in g.Controls)
            {
                int tagVal = 0;
                if (c is TextBox)
                {
                    if (c.Tag != null)
                        int.TryParse(c.Tag.ToString(), out tagVal);

                    if (c.Text.Trim() == "" & tagVal != 2)
                    {
                        c.Focus();
                        return true;
                    }
                }

                else if (c is ComboBox)
                {
                    cmb = (ComboBox)c;

                    if (cmb.Tag != null)
                        int.TryParse(cmb.Tag.ToString(), out tagVal);

                    if (cmb.SelectedIndex == -1 & tagVal != 2)
                    {
                        c.Focus();
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool checkEmptyInputp(Panel p) // tag=2 for exception
        {
            ComboBox cmb = default;

            foreach (Control c in p.Controls)
            {
                int tagVal = 0;
                if (c is TextBox)
                {
                    if (c.Tag != null)
                        int.TryParse(c.Tag.ToString(), out tagVal);

                    if (c.Text.Trim() == "" & tagVal != 2)
                    {
                        c.Focus();
                        return true;
                    }
                }

                else if (c is ComboBox)
                {
                    cmb = (ComboBox)c;

                    if (cmb.Tag != null)
                        int.TryParse(cmb.Tag.ToString(), out tagVal);

                    if (cmb.SelectedIndex == -1 & tagVal != 2)
                    {
                        c.Focus();
                        return true;
                    }
                }
            }
            return false;
        }
        public static byte[] imageToByte(PictureBox pic)
        {
            var ms = new MemoryStream();
            if (!(pic.Image == null))
                pic.Image.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
