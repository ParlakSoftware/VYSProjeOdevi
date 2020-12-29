namespace BilgiYarismasi
{
    partial class Menu
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
            this.btnSoruOner = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnOyna = new System.Windows.Forms.Button();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.lblHosgeldin = new System.Windows.Forms.Label();
            this.lblKullaniciId = new System.Windows.Forms.Label();
            this.dgvScoreTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProfilBilgilerim = new System.Windows.Forms.Button();
            this.pnlGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScoreTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSoruOner
            // 
            this.btnSoruOner.Location = new System.Drawing.Point(15, 64);
            this.btnSoruOner.Name = "btnSoruOner";
            this.btnSoruOner.Size = new System.Drawing.Size(126, 40);
            this.btnSoruOner.TabIndex = 1;
            this.btnSoruOner.Text = "SORU ÖNER";
            this.btnSoruOner.UseVisualStyleBackColor = true;
            this.btnSoruOner.Click += new System.EventHandler(this.btnSoruOner_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(15, 156);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(126, 40);
            this.btnCikis.TabIndex = 2;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnOyna
            // 
            this.btnOyna.Location = new System.Drawing.Point(15, 18);
            this.btnOyna.Name = "btnOyna";
            this.btnOyna.Size = new System.Drawing.Size(126, 40);
            this.btnOyna.TabIndex = 3;
            this.btnOyna.Text = "OYUNA BAŞLA";
            this.btnOyna.UseVisualStyleBackColor = true;
            this.btnOyna.Click += new System.EventHandler(this.btnOyna_Click);
            // 
            // pnlGame
            // 
            this.pnlGame.Controls.Add(this.btnProfilBilgilerim);
            this.pnlGame.Controls.Add(this.btnOyna);
            this.pnlGame.Controls.Add(this.btnSoruOner);
            this.pnlGame.Controls.Add(this.btnCikis);
            this.pnlGame.Location = new System.Drawing.Point(65, 86);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(155, 269);
            this.pnlGame.TabIndex = 7;
            // 
            // lblHosgeldin
            // 
            this.lblHosgeldin.AutoSize = true;
            this.lblHosgeldin.Location = new System.Drawing.Point(12, 9);
            this.lblHosgeldin.Name = "lblHosgeldin";
            this.lblHosgeldin.Size = new System.Drawing.Size(54, 13);
            this.lblHosgeldin.TabIndex = 8;
            this.lblHosgeldin.Text = "Hoşgeldin";
            // 
            // lblKullaniciId
            // 
            this.lblKullaniciId.AutoSize = true;
            this.lblKullaniciId.Location = new System.Drawing.Point(12, 32);
            this.lblKullaniciId.Name = "lblKullaniciId";
            this.lblKullaniciId.Size = new System.Drawing.Size(16, 13);
            this.lblKullaniciId.TabIndex = 9;
            this.lblKullaniciId.Text = "Id";
            this.lblKullaniciId.Visible = false;
            // 
            // dgvScoreTable
            // 
            this.dgvScoreTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScoreTable.Location = new System.Drawing.Point(274, 86);
            this.dgvScoreTable.Name = "dgvScoreTable";
            this.dgvScoreTable.Size = new System.Drawing.Size(345, 269);
            this.dgvScoreTable.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(420, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "İLK 10";
            // 
            // btnProfilBilgilerim
            // 
            this.btnProfilBilgilerim.Location = new System.Drawing.Point(15, 110);
            this.btnProfilBilgilerim.Name = "btnProfilBilgilerim";
            this.btnProfilBilgilerim.Size = new System.Drawing.Size(126, 40);
            this.btnProfilBilgilerim.TabIndex = 4;
            this.btnProfilBilgilerim.Text = "PROFİL BİLGİLERİM";
            this.btnProfilBilgilerim.UseVisualStyleBackColor = true;
            this.btnProfilBilgilerim.Click += new System.EventHandler(this.btnProfilBilgilerim_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 390);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvScoreTable);
            this.Controls.Add(this.lblKullaniciId);
            this.Controls.Add(this.lblHosgeldin);
            this.Controls.Add(this.pnlGame);
            this.Name = "Menu";
            this.ShowInTaskbar = false;
            this.Text = "Menü";
            this.pnlGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScoreTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSoruOner;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnOyna;
        private System.Windows.Forms.Panel pnlGame;
        public System.Windows.Forms.Label lblHosgeldin;
        public System.Windows.Forms.Label lblKullaniciId;
        private System.Windows.Forms.DataGridView dgvScoreTable;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProfilBilgilerim;
    }
}

