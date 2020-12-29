namespace BilgiYarismasi
{
    partial class SoruOner
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
            this.label7 = new System.Windows.Forms.Label();
            this.cboxKategori = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboxCevap = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtSoru = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblKullaniciId = new System.Windows.Forms.Label();
            this.btnMenuDon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSoruOner
            // 
            this.btnSoruOner.Location = new System.Drawing.Point(12, 273);
            this.btnSoruOner.Name = "btnSoruOner";
            this.btnSoruOner.Size = new System.Drawing.Size(480, 42);
            this.btnSoruOner.TabIndex = 33;
            this.btnSoruOner.Text = "Soru Öner";
            this.btnSoruOner.UseVisualStyleBackColor = true;
            this.btnSoruOner.Click += new System.EventHandler(this.btnSoruOner_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Soru Kategorisi";
            // 
            // cboxKategori
            // 
            this.cboxKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxKategori.FormattingEnabled = true;
            this.cboxKategori.Location = new System.Drawing.Point(255, 234);
            this.cboxKategori.Name = "cboxKategori";
            this.cboxKategori.Size = new System.Drawing.Size(237, 21);
            this.cboxKategori.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Cevap";
            // 
            // cboxCevap
            // 
            this.cboxCevap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCevap.FormattingEnabled = true;
            this.cboxCevap.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cboxCevap.Location = new System.Drawing.Point(12, 234);
            this.cboxCevap.Name = "cboxCevap";
            this.cboxCevap.Size = new System.Drawing.Size(237, 21);
            this.cboxCevap.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(252, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "D";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(255, 194);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(237, 20);
            this.txtD.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "C";
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(12, 194);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(237, 20);
            this.txtC.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "B";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(255, 152);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(237, 20);
            this.txtB.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "A";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(12, 152);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(237, 20);
            this.txtA.TabIndex = 19;
            // 
            // txtSoru
            // 
            this.txtSoru.Location = new System.Drawing.Point(12, 72);
            this.txtSoru.Multiline = true;
            this.txtSoru.Name = "txtSoru";
            this.txtSoru.Size = new System.Drawing.Size(480, 58);
            this.txtSoru.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Soru";
            // 
            // lblKullaniciId
            // 
            this.lblKullaniciId.AutoSize = true;
            this.lblKullaniciId.Location = new System.Drawing.Point(9, 9);
            this.lblKullaniciId.Name = "lblKullaniciId";
            this.lblKullaniciId.Size = new System.Drawing.Size(16, 13);
            this.lblKullaniciId.TabIndex = 34;
            this.lblKullaniciId.Text = "Id";
            this.lblKullaniciId.Visible = false;
            // 
            // btnMenuDon
            // 
            this.btnMenuDon.Location = new System.Drawing.Point(413, 12);
            this.btnMenuDon.Name = "btnMenuDon";
            this.btnMenuDon.Size = new System.Drawing.Size(80, 28);
            this.btnMenuDon.TabIndex = 35;
            this.btnMenuDon.Text = "Menü";
            this.btnMenuDon.UseVisualStyleBackColor = true;
            this.btnMenuDon.Click += new System.EventHandler(this.btnMenuDon_Click);
            // 
            // SoruOner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 338);
            this.Controls.Add(this.btnMenuDon);
            this.Controls.Add(this.lblKullaniciId);
            this.Controls.Add(this.btnSoruOner);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboxKategori);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboxCevap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtSoru);
            this.Controls.Add(this.label1);
            this.Name = "SoruOner";
            this.Text = "SoruOner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSoruOner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboxKategori;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboxCevap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtSoru;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblKullaniciId;
        private System.Windows.Forms.Button btnMenuDon;
    }
}