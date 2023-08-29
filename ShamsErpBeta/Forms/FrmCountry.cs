using System;
using ShamsErpBeta.Forms;
using ShamsErpBeta.Classes;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShamsErpBeta.Forms
{
    public partial class FrmCountry : Form
    {
        public FrmCountry()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        int cr, id;

        private void FrmCountry_Load(object sender, EventArgs e)
        {
            getFillData();
        }

        void getFillData()
        {
            var Sql = new SQLConClass();
            ds = Sql.SelectData("Select Id, ROW_NUMBER() OVER (ORDER BY (SELECT 1)) ت, [Name] from TblCountry Where Del = 0", 0, default);
            if (FunctionsClass.dsHasTables(ds))
            {
                dgvCountry.DataSource = ds.Tables[0];
                dgvCountry.Columns[0].Visible = false;
                dgvCountry.Columns[1].Width = 40;
                dgvCountry.Columns[2].HeaderText = "البلد";

                dgvCountry.ClearSelection();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("يرجى اختيار البلد", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveCountry();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (id != 0) return;

            SaveCountry();
        }

        void SaveCountry()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("يرجى إادخال كافة البيانات","تنبيه",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtName.Focus();
                return;
            }

            var sql = new SQLConClass();
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", txtName.Text.ToString()) };

            VariablesClass.Save = sql.cmdExecute("SaveCountry", 1, parm);

            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            getFillData();
            id = 0;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("يرجى تحديد البلاد المراد حذفها","تنبيه",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                btnRefresh.PerformClick();

                return;
            }

            var sql = new SQLConClass();
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@Id", id) };

            VariablesClass.Save = sql.cmdExecute("DeleteCountry", 1, parm);

            btnRefresh.PerformClick();

        }

        private void dgvCountry_Click(object sender, EventArgs e)
        {
            if (!FunctionsClass.checkDgvError(dgvCountry))
                return;

            cr = dgvCountry.CurrentRow.Index;
            id = (int)dgvCountry.Rows[cr].Cells[0].Value;
            txtName.Text = dgvCountry.Rows[cr].Cells[2].Value.ToString();
            txtName.Focus();
        }
    }
}
