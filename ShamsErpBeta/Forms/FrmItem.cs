using System;
using ShamsErpBeta.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShamsErpBeta.Forms
{
    public partial class FrmItem : Form
    {
        public FrmItem()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        DataTable dtCategoryLst = new DataTable();
        int itemId;

        private void FrmItem_VisibleChanged(object sender, EventArgs e)
        {
            getData();
        }
        public void getData()
        {
            var sqlCon = new SQLConClass();
            SQLConClass.sqlQuery = "SELECT Id,[Num],ItemName,CatgoryId FROM TblItem WHERE Del='FALSE' ORDER BY ItemName " +
                "SELECT Id,[Name] FROM TblCatgory WHERE Del='FALSE' ORDER BY [Name] " +
                "SELECT * FROM TblCountry ORDER BY [Name] SELECT * FROM TblUnite ORDER BY [Name] " +
                "SELECT Id,[Name] From TblStore ";
            ds = sqlCon.SelectData(SQLConClass.sqlQuery, 0, null);

            if (FunctionsClass.dsHasTables(ds))
                fillData();
            else
                this.Close();

            txtItemNum.Focus();
        }
        void fillData()
        {
            cmbName.DataSource = ds.Tables[0];
            cmbName.DisplayMember = "ItemName";
            cmbName.ValueMember = "Id";
            cmbName.SelectedIndex = -1;

            cmbCatgory.DataSource = ds.Tables[1];
            cmbCatgory.DisplayMember = "Name";
            cmbCatgory.ValueMember = "Id";
            cmbCatgory.SelectedIndex = -1;

            dtCategoryLst = ds.Tables[1].Copy();

            lstCatgory.DataSource = dtCategoryLst; // ds.Tables[1].Copy()
            lstCatgory.DisplayMember = "Name";
            lstCatgory.ValueMember = "Id";
            lstCatgory.SelectedIndex = -1;

            cmbCountry.DataSource = ds.Tables[2];
            cmbCountry.DisplayMember = "Name";
            cmbCountry.ValueMember = "Id";
            cmbCountry.SelectedIndex = -1;

            cmbUnite.DataSource = ds.Tables[3];
            cmbUnite.DisplayMember = "Name";
            cmbUnite.ValueMember = "Id";
            cmbUnite.SelectedIndex = -1;

            cmbStore.DataSource = ds.Tables[4];
            cmbStore.DisplayMember = "Name";
            cmbStore.ValueMember = "Id";
            cmbStore.SelectedIndex = -1;
        }

        private void txtItemNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataRow[] itemRows = ds.Tables[0].Select("Num=" + txtItemNum.Text);
                if (itemRows.Length > 0)
                    btnFindItem.PerformClick();
                else
                {
                    btnRefresh.PerformClick();
                    cmbName.Focus();
                }

            }
        }

        private void txtItemNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !FunctionsClass.isPositiveIntNum(e);
        }

        private void txtItemNum_TextChanged(object sender, EventArgs e)
        {
            lblBarCode.Text = txtItemNum.Text;
            lblBarCode.Text = "*" + txtItemNum.Text + "*";
        }

        private void btnFindItem_Click(object sender, EventArgs e)
        {
            if (txtItemNum.Text.Trim() == string.Empty)
                return;

            DataRow[] itemRows = ds.Tables[0].Select("Num=" + txtItemNum.Text.Trim());
            if (itemRows.Length > 0)
            {
                itemId = (int)itemRows[0][0];
                cmbName.SelectedValue = itemId;
                cmbName_SelectionChangeCommitted(sender, e);
                txtItemNum.SelectAll();
                txtItemNum.Focus();
            }
            else
            {
                FunctionsClass.msgTool("الصنف عير موجود", 0);
                btnRefresh.PerformClick();
            }
        }

        private void cmbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & cmbName.Text != "")
                cmbName_SelectionChangeCommitted(sender, e);
        }

        private void cmbName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbName.SelectedValue == null)
            {
                MessageBox.Show("الصنف عير موجود", "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbName.Text = "";
                return;
            }

            DataRow[] itemRows = ds.Tables[0].Select("Id=" + cmbName.SelectedValue);

            lstCatgory.SelectedValue = itemRows[0][3];
            lstCatgory_Click(sender, e);
            lstItems.SelectedValue = itemRows[0][0];
            lstItems_Click(sender, e);
        }

        private void txtStoreQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !FunctionsClass.isRealNum(txtStoreQ, e);
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            SaveItem(sender, e);
        }
        private void txtAddItem_Click(object sender, EventArgs e)
        {
            if (itemId != 0) itemId = 0;

            SaveItem(sender, e);
        }

        void SaveItem(object sender, EventArgs e)
        {
            if (FunctionsClass.checkEmptyInputp(pnlAddItem) == true) // cmbName.Tag=2
            {
                MessageBox.Show("الرجاء إدخال كافة بيانات الصنف", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cmbName.Text.Trim() == string.Empty)  // cmbName.Tag=2
            {
                MessageBox.Show("الرجاء إدخال اسم الصنف", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (itemId != 0)
            {

            }



            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id", itemId),
                new SqlParameter("@Num", txtItemNum.Text.Trim()),
                new SqlParameter("@Name", cmbName.Text.Trim()),
                new SqlParameter("@Describe", txtitemDesc.Text.Trim()),
                new SqlParameter("@Size", txtItemSize.Text.Trim()),
                new SqlParameter("@categoryId", cmbCatgory.SelectedValue),
                new SqlParameter("@CountryID", cmbCountry.SelectedValue),
                new SqlParameter("@UnitID", cmbUnite.SelectedValue),
                new SqlParameter("@StoreId", cmbStore.SelectedValue),
                new SqlParameter("@StoreQuantity", txtStoreQ.Text),
                new SqlParameter("@LowQuantity", txtLowQ.Text),
                new SqlParameter("@PurchasePrice", txtPurchasePrice.Text),
                new SqlParameter("@SalePrice", txtSalePrice.Text)
            };

            SQLConClass sqlCon = new SQLConClass();
            ds = sqlCon.cmdExecuteData("SaveItem", param);

            if (ds.Tables.Count == 5)
            {
                clearItem();
                clearCategories();
                fillData();
                cmbName.SelectedValue = ds.Tables[4].Rows[0][0];
                cmbName_SelectionChangeCommitted(sender, e);
            }
        }
        void clearItem()
        {
            FunctionsClass.clearPanel(pnlAddItem);// tag=1 for exception
            itemId = 0;
        }
        void clearCategories()
        {
            txtUpdateCatgory.Text = string.Empty;
            txtAddCatgory.Clear();
            lstCatgory.DataSource = null;
            lstItems.DataSource = null;
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (itemId == 0)
                return;

            if (MessageBox.Show("هل أنت متأكد تريد حذف هذا الصنف", "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLConClass sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", itemId) };

                if (sqlCon.cmdExecute("DeleteItem", 1, param) == 3)
                    FunctionsClass.msgTool("تم إخفاءالصنف فقط ولم يتم الحذف نهائي  ", 2);

                btnRefresh.PerformClick();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearItem();
            clearCategories();
            getData();
        }

        private void txtAddCatgory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddCatgory.PerformClick();
        }

        private void btnAddCatgory_Click(object sender, EventArgs e)
        {
            if (txtAddCatgory.Text.Trim() == string.Empty)
                return;

            SQLConClass sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Category", txtAddCatgory.Text.Trim()) };
            SQLConClass.sqlQuery = "IF NOT EXISTS(select Category from TblCategories where Category=@Category) INSERT INTO TblCategories(Category)VALUES(@Category)";
            sqlCon.cmdExecute(SQLConClass.sqlQuery, 0, param);

            btnRefresh.PerformClick();
            txtAddCatgory.Focus();
        }

        private void lstCatgory_Click(object sender, EventArgs e)
        {
            if (lstCatgory.SelectedValue == null)
                return;

            clearItem();
            lstItems.DataSource = null;
            txtUpdateCatgory.Text = lstCatgory.Text;

            DataRow[] itemRows = ds.Tables[0].Select("catgoryId=" + lstCatgory.SelectedValue, "ItemName ASC");
            if (itemRows.Length > 0)
            {
                lstItems.DataSource = itemRows.CopyToDataTable();
                lstItems.DisplayMember = "ItemName";
                lstItems.ValueMember = "Id";
            }
            lstItems.ClearSelected();
        }

        private void btnDelCatgory_Click(object sender, EventArgs e)
        {
            if (lstCatgory.SelectedValue == null)
                return;

            if (MessageBox.Show("هل أنت متأكد تريد حذف المجموعة", "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@Id", lstCatgory.SelectedValue) };

                if (sqlCon.cmdExecute("DeleteCategory", 1, param) == 3)
                    MessageBox.Show("تم إخفاءالمجموعة لأنها تحتوي أصناف " + Environment.NewLine + "تم إخفاء جميع الأصناف التي ضمن تصنيف هذه المجموعة" + Environment.NewLine + "من خلال نافذة إدارة البيانات المحذوفة يمكنك إسترجاع المجموعة والأصناف المحذوفة", "ارسال بيانات الى سلة المحذوفات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnRefresh.PerformClick();
        }

        private void btnUpdateCatgory_Click(object sender, EventArgs e)
        {
            if (lstCatgory.SelectedValue == null | txtUpdateCatgory.Text.Trim() == "" | txtUpdateCatgory.Text.Length < 3)
                return;

            SQLConClass sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id", lstCatgory.SelectedValue),
                new SqlParameter("@Category", txtUpdateCatgory.Text.Trim()) };

            SQLConClass.sqlQuery = "IF NOT EXISTS(select * from TblCategories where Category= @Category AND Id<>@Id) UPDATE TblCategories Set Category=@Category WHERE Id=@Id";
            sqlCon.cmdExecute(SQLConClass.sqlQuery, 0, param);

            btnRefresh.PerformClick();
        }

        private void lstItems_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedValue == null)
                return;

            SQLConClass sqlCon = new SQLConClass();
            SQLConClass.sqlQuery = "SELECT * FROM TblItem WHERE Id=" + lstItems.SelectedValue;
            DataSet dsItem = sqlCon.SelectData(SQLConClass.sqlQuery, 0, null);
            if (FunctionsClass.dshasTablesAndData(dsItem))
            {
                var row = dsItem.Tables[0].Rows[0];

                itemId = (int)row[0];
                txtItemNum.Text = row[1].ToString();
                cmbName.Text = row[4].ToString();
                txtitemDesc.Text = row[5].ToString();
                txtItemSize.Text = row[6].ToString();
                cmbCatgory.SelectedValue = row[2];
                cmbCountry.SelectedValue = row[3];
                cmbUnite.SelectedValue = row[7];
                cmbStore.SelectedValue = row[8];

                txtStoreQ.Text = row[9].ToString();
                txtLowQ.Text = row[10].ToString();
                txtPurchasePrice.Text = row[11].ToString();
                txtSalePrice.Text = row[12].ToString();

                txtItemNum.SelectAll();
                txtItemNum.Focus();
            }
        }

        private void btnAddCountry_Click(object sender, EventArgs e)
        {
            Form fc = new FrmCountry();
            fc.ShowDialog();
        }

        private void btnAddUnite_Click(object sender, EventArgs e)
        {
            Form fu = new FrmUnite();
            fu.ShowDialog();
        }

        private void btnAddStore_Click(object sender, EventArgs e)
        {
            Form fs = new FrmStore();
            fs.ShowDialog();
        }
    }
}
