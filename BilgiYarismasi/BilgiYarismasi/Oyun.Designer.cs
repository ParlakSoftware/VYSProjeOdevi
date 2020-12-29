namespace BilgiYarismasi
{
    partial class Oyun
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
            this.lblAktifSoru = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblZaman = new System.Windows.Forms.Label();
            this.lblSoru = new System.Windows.Forms.Label();
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.btnD = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.lblCevap = new System.Windows.Forms.Label();
            this.tmrSoru = new System.Windows.Forms.Timer(this.components);
            this.tmrCevap = new System.Windows.Forms.Timer(this.components);
            this.lblCevapTime = new System.Windows.Forms.Label();
            this.lblKullaniciId = new System.Windows.Forms.Label();
            this.btnMenuDon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAktifSoru
            // 
            this.lblAktifSoru.AutoSize = true;
            this.lblAktifSoru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAktifSoru.Location = new System.Drawing.Point(192, 32);
            this.lblAktifSoru.Name = "lblAktifSoru";
            this.lblAktifSoru.Size = new System.Drawing.Size(73, 20);
            this.lblAktifSoru.TabIndex = 0;
            this.lblAktifSoru.Text = "1. SORU";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblScore.Location = new System.Drawing.Point(218, 4);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(29, 20);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "00";
            // 
            // lblZaman
            // 
            this.lblZaman.AutoSize = true;
            this.lblZaman.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblZaman.Location = new System.Drawing.Point(218, 63);
            this.lblZaman.Name = "lblZaman";
            this.lblZaman.Size = new System.Drawing.Size(29, 20);
            this.lblZaman.TabIndex = 6;
            this.lblZaman.Text = "00";
            // 
            // lblSoru
            // 
            this.lblSoru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoru.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSoru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSoru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoru.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblSoru.Location = new System.Drawing.Point(39, 97);
            this.lblSoru.Name = "lblSoru";
            this.lblSoru.Size = new System.Drawing.Size(385, 120);
            this.lblSoru.TabIndex = 7;
            this.lblSoru.Text = "SORU";
            this.lblSoru.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnA
            // 
            this.btnA.Location = new System.Drawing.Point(39, 229);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(385, 47);
            this.btnA.TabIndex = 8;
            this.btnA.Tag = "A";
            this.btnA.Text = "A";
            this.btnA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnA.UseVisualStyleBackColor = true;
            this.btnA.Click += new System.EventHandler(this.CevapVer);
            // 
            // btnB
            // 
            this.btnB.Location = new System.Drawing.Point(39, 282);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(385, 47);
            this.btnB.TabIndex = 9;
            this.btnB.Tag = "B";
            this.btnB.Text = "B";
            this.btnB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnB.UseVisualStyleBackColor = true;
            this.btnB.Click += new System.EventHandler(this.CevapVer);
            // 
            // btnD
            // 
            this.btnD.Location = new System.Drawing.Point(39, 388);
            this.btnD.Name = "btnD";
            this.btnD.Size = new System.Drawing.Size(385, 47);
            this.btnD.TabIndex = 11;
            this.btnD.Tag = "D";
            this.btnD.Text = "D";
            this.btnD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnD.UseVisualStyleBackColor = true;
            this.btnD.Click += new System.EventHandler(this.CevapVer);
            // 
            // btnC
            // 
            this.btnC.Location = new System.Drawing.Point(39, 335);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(385, 47);
            this.btnC.TabIndex = 10;
            this.btnC.Tag = "C";
            this.btnC.Text = "C";
            this.btnC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnC.UseVisualStyleBackColor = true;
            this.btnC.Click += new System.EventHandler(this.CevapVer);
            // 
            // lblCevap
            // 
            this.lblCevap.AutoSize = true;
            this.lblCevap.Location = new System.Drawing.Point(12, 9);
            this.lblCevap.Name = "lblCevap";
            this.lblCevap.Size = new System.Drawing.Size(35, 13);
            this.lblCevap.TabIndex = 12;
            this.lblCevap.Text = "label3";
            this.lblCevap.Visible = false;
            // 
            // tmrSoru
            // 
            this.tmrSoru.Interval = 1000;
            this.tmrSoru.Tick += new System.EventHandler(this.tmrSoru_Tick);
            // 
            // tmrCevap
            // 
            this.tmrCevap.Interval = 1000;
            this.tmrCevap.Tick += new System.EventHandler(this.tmrCevap_Tick);
            // 
            // lblCevapTime
            // 
            this.lblCevapTime.AutoSize = true;
            this.lblCevapTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCevapTime.Location = new System.Drawing.Point(358, 63);
            this.lblCevapTime.Name = "lblCevapTime";
            this.lblCevapTime.Size = new System.Drawing.Size(29, 20);
            this.lblCevapTime.TabIndex = 13;
            this.lblCevapTime.Text = "00";
            this.lblCevapTime.Visible = false;
            // 
            // lblKullaniciId
            // 
            this.lblKullaniciId.AutoSize = true;
            this.lblKullaniciId.Location = new System.Drawing.Point(12, 28);
            this.lblKullaniciId.Name = "lblKullaniciId";
            this.lblKullaniciId.Size = new System.Drawing.Size(16, 13);
            this.lblKullaniciId.TabIndex = 14;
            this.lblKullaniciId.Text = "Id";
            this.lblKullaniciId.Visible = false;
            // 
            // btnMenuDon
            // 
            this.btnMenuDon.Location = new System.Drawing.Point(378, 9);
            this.btnMenuDon.Name = "btnMenuDon";
            this.btnMenuDon.Size = new System.Drawing.Size(80, 28);
            this.btnMenuDon.TabIndex = 36;
            this.btnMenuDon.Text = "Menü";
            this.btnMenuDon.UseVisualStyleBackColor = true;
            this.btnMenuDon.Click += new System.EventHandler(this.btnMenuDon_Click);
            // 
            // Oyun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 491);
            this.Controls.Add(this.btnMenuDon);
            this.Controls.Add(this.lblKullaniciId);
            this.Controls.Add(this.lblCevapTime);
            this.Controls.Add(this.lblCevap);
            this.Controls.Add(this.btnD);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.lblSoru);
            this.Controls.Add(this.lblZaman);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblAktifSoru);
            this.Name = "Oyun";
            this.Text = "Oyun";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAktifSoru;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblZaman;
        private System.Windows.Forms.Label lblSoru;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Button btnD;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Label lblCevap;
        private System.Windows.Forms.Timer tmrSoru;
        private System.Windows.Forms.Timer tmrCevap;
        private System.Windows.Forms.Label lblCevapTime;
        public System.Windows.Forms.Label lblKullaniciId;
        private System.Windows.Forms.Button btnMenuDon;
    }
}