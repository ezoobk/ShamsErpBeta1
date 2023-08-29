namespace ShamsErpBeta
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnPurchases = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnItem = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlButtons.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlButtons.Controls.Add(this.btnItem);
            this.pnlButtons.Controls.Add(this.btnPurchases);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.Font = new System.Drawing.Font("Ara Hamah Homs", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pnlButtons.Location = new System.Drawing.Point(1301, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlButtons.Size = new System.Drawing.Size(184, 808);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnPurchases
            // 
            this.btnPurchases.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPurchases.Location = new System.Drawing.Point(0, 0);
            this.btnPurchases.Name = "btnPurchases";
            this.btnPurchases.Size = new System.Drawing.Size(184, 45);
            this.btnPurchases.TabIndex = 0;
            this.btnPurchases.Text = "المشتريات";
            this.btnPurchases.UseVisualStyleBackColor = true;
            this.btnPurchases.Click += new System.EventHandler(this.btnPurchases_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1301, 775);
            this.pnlMain.TabIndex = 1;
            // 
            // btnItem
            // 
            this.btnItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnItem.Location = new System.Drawing.Point(0, 45);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(184, 45);
            this.btnItem.TabIndex = 1;
            this.btnItem.Text = "الأصناف";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(209)))), ((int)(((byte)(155)))));
            this.statusStrip1.Font = new System.Drawing.Font("Ara Hamah Homs", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslDateTime,
            this.tslUser,
            this.tslMessage});
            this.statusStrip1.Location = new System.Drawing.Point(0, 775);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1301, 33);
            this.statusStrip1.TabIndex = 358;
            this.statusStrip1.Text = "statusStrip2";
            // 
            // tslDateTime
            // 
            this.tslDateTime.Margin = new System.Windows.Forms.Padding(10, 3, 20, 2);
            this.tslDateTime.Name = "tslDateTime";
            this.tslDateTime.Size = new System.Drawing.Size(109, 28);
            this.tslDateTime.Text = "الساعة والتاريخ";
            // 
            // tslUser
            // 
            this.tslUser.Name = "tslUser";
            this.tslUser.Size = new System.Drawing.Size(132, 28);
            this.tslUser.Text = "مستخدم المنظومة";
            // 
            // tslMessage
            // 
            this.tslMessage.Margin = new System.Windows.Forms.Padding(250, 5, 0, 5);
            this.tslMessage.Name = "tslMessage";
            this.tslMessage.Size = new System.Drawing.Size(94, 28);
            this.tslMessage.Text = "تأكيد الحفظ";
            this.tslMessage.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 808);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shams";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.pnlButtons.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnPurchases;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnItem;
        internal System.Windows.Forms.StatusStrip statusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel tslDateTime;
        private System.Windows.Forms.ToolStripStatusLabel tslUser;
        internal System.Windows.Forms.ToolStripStatusLabel tslMessage;
        public System.Windows.Forms.Timer timer1;
    }
}

