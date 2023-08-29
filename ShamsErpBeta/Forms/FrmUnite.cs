using ShamsErpBeta.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShamsErpBeta.Forms
{
    public partial class FrmUnite : Form
    {
        public FrmUnite()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        int cr, id;

        private void FrmUnite_Load(object sender, EventArgs e)
        {
            getFillData();
        }

        void getFillData()
        {
            var Sql = new SQLConClass();
            ds = Sql.SelectData("Select Id, ROW_NUMBER() OVER (ORDER BY (SELECT 1)) ت, [Name] from TblUnite Where Del = 0", 0, default);
            if (FunctionsClass.dsHasTables(ds))
            {
                dgvUnite.DataSource = ds.Tables[0];
                dgvUnite.Columns[0].Visible = false;
                dgvUnite.Columns[1].Width = 40;
                dgvUnite.Columns[2].HeaderText = "الوحدة";

                dgvUnite.ClearSelection();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (id != 0) return;

            SaveCountry();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("يرجى اختيار الوحدة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveCountry();
        }

        void SaveCountry()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("يرجى إادخال كافة البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtName.Focus();
                return;
            }

            var sql = new SQLConClass();
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", txtName.Text.ToString()) };

            VariablesClass.Save = sql.cmdExecute("SaveUnite", 1, parm);

            btnRefresh.PerformClick();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("يرجى تحديد الوحدة المراد حذفها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnRefresh.PerformClick();

                return;
            }

            var sql = new SQLConClass();
            SqlParameter[] parm = new SqlParameter[]{
                new SqlParameter("@Id", id) };

            VariablesClass.Save = sql.cmdExecute("DeleteUnite", 1, parm);

            btnRefresh.PerformClick();
        }

        private void dgvCountry_Click(object sender, EventArgs e)
        {
            if (!FunctionsClass.checkDgvError(dgvUnite))
                return;

            cr = dgvUnite.CurrentRow.Index;
            id = (int)dgvUnite.Rows[cr].Cells[0].Value;
            txtName.Text = dgvUnite.Rows[cr].Cells[2].Value.ToString();
            txtName.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            getFillData();
            id = 0;
        }



       
    }
}
