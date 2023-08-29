using System;
using ShamsErpBeta.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShamsErpBeta
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        string title = "شركة شمس";

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
        private void OpenForm(Form f, Button b)
        {
            if (f.Visible == true) // إختبار إذا كان الفورم مفتوح
            {
                hideOpenForms();
            }
            else
            {
                hideOpenForms();
                f.TopLevel = false;
                f.Parent = pnlMain;
                f.BringToFront();
                f.Visible = true;
                f.Size = pnlMain.Size;
                f.Dock = DockStyle.Fill;

                this.Text = title + " - " + b.Text;

                b.BackColor = Color.FromArgb(8, 89, 54);
                b.ForeColor = Color.FromArgb(228, 209, 155);
                b.FlatAppearance.BorderSize = 0;
            }

        }
        private void hideOpenForms()
        {
            foreach (Button b in pnlButtons.Controls)
            {
                if (b.BackColor != Color.FromArgb(228, 209, 155))
                {
                    b.BackColor = Color.FromArgb(228, 209, 155);
                    b.ForeColor = Color.Black;
                    b.FlatAppearance.BorderSize = 1;
                }
            }
            this.Text = title;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name != "FrmMain")
                    f.Visible = false;
            }
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            FrmPurchases frmPurchases = Application.OpenForms.OfType<FrmPurchases>().FirstOrDefault();
            if (frmPurchases == null)
                frmPurchases = new FrmPurchases();


            OpenForm(frmPurchases, btnPurchases);
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            FrmItem frmItem = Application.OpenForms.OfType<FrmItem>().FirstOrDefault();
            if (frmItem == null)
                frmItem = new FrmItem();


            OpenForm(frmItem, btnPurchases);
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            //--------------------------------xxx-xxx----------------------------xxx-xxx
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) >= 1)
                timer1.Tag = (int)(timer1.Tag) + 1;

            if (Convert.ToInt32(timer1.Tag) == 5)
            {
                timer1.Tag = 0;
                tslMessage.Visible = false;
                statusStrip1.BackColor = Color.FromArgb(192, 192, 255);
            }
        }
    }
}
