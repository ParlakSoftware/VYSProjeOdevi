using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace BilgiYarismasi
{
    public partial class Oyun : Form
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        int soruSayisi = 1;
        int maxSoruSayisi = 10;
        int soruTime = 15;
        int cevapTime = 1;
        int score = 0;
        bool isTrue = false;
        List<Button> butonlar = new List<Button>();
        List<Soru> sorular = new List<Soru>();

        public Oyun()
        {
            InitializeComponent();
            
            SoruGetir("Kolay", 3);
            SoruGetir("Orta", 3);
            SoruGetir("Zor", 3);
            SoruGetir("En Zor", 1);

            sorular[0].SoruYazdir(lblSoru, btnA, btnB, btnC, btnD, lblCevap);

            lblZaman.Text = soruTime.ToString();
            lblCevapTime.Text = cevapTime.ToString();
            tmrSoru.Start();
            butonlar.Add(btnA);
            butonlar.Add(btnB);
            butonlar.Add(btnC);
            butonlar.Add(btnD);
        }

        void SoruGetir(string tablo,int limit) {
            connection.Close();
           
                string query = "";
                int index = 0;
                if (tablo == "Kolay")
                {
                    index = 0;
                    query = "SELECT * FROM \"Kolay\" ORDER BY RANDOM() LIMIT "+limit;
                }
                else if (tablo == "Orta")
                {
                    index = 3;
                    query = "SELECT * FROM \"Orta\" ORDER BY RANDOM() LIMIT " + limit;
                }
                else if (tablo == "Zor")
                {
                    index = 6;
                    query = "SELECT * FROM \"Zor\" ORDER BY RANDOM() LIMIT " + limit;
                }
                else if (tablo == "En Zor")
                {
                    index = 9;
                    query = "SELECT * FROM \"EnZor\" ORDER BY RANDOM() LIMIT " + limit;
                }
                connection.Open();

                OdbcCommand command = new OdbcCommand(query, connection);
            OdbcDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //MessageBox.Show("Index : "+index+" "+reader["soru"].ToString()+" "+ reader["a"].ToString()+" "+ reader["b"].ToString()+" "+ reader["c"].ToString()+" " + reader["d"].ToString()+" " + Convert.ToChar(reader["cevap"]));
                Soru soru = new Soru();
                soru.SoruEkle(reader["soru"].ToString(), reader["a"].ToString(), reader["b"].ToString(), reader["c"].ToString(), reader["d"].ToString(), Convert.ToChar(reader["cevap"]));
                
                sorular.Add(soru);
            }

            connection.Close();
            reader.Close();
        }
        private void CevapVer(object sender, EventArgs e) {
            Button btn = (Button)sender;
            tmrSoru.Stop();
            if (btn.Tag.ToString() == lblCevap.Text.ToString()) { 
                btn.BackColor = Color.Green;
                isTrue = true;
                soruSayisi++;

                score += soruTime;
                lblScore.Text = score.ToString();
            }
            else
            {
                btn.BackColor = Color.Red;
                isTrue = false;
            }
            for (int i = 0; i < butonlar.Count; i++)
            {
                butonlar[i].Enabled = false;
            }
            tmrCevap.Start();
        }

        private void tmrSoru_Tick(object sender, EventArgs e)
        {
            if (soruTime > 0)
            {
                soruTime--;
                lblZaman.Text = soruTime.ToString();
            }
            else
            {
                tmrSoru.Stop();
                ScoreKaydet();
            }
        }

        private void tmrCevap_Tick(object sender, EventArgs e)
        {
            if (cevapTime > 0)
            {
                cevapTime--;
                lblCevapTime.Text = cevapTime.ToString();
            }
            else
            {
                tmrCevap.Stop();
                if (isTrue) SonrakiSoru(soruSayisi);
                else ScoreKaydet();
            }
        }

        void SonrakiSoru(int soruSayisi)
        {
            if (soruSayisi-1 != maxSoruSayisi)
            {
                for (int i = 0; i < butonlar.Count; i++)
                {
                    butonlar[i].BackColor = default(Color);
                }
                sorular[soruSayisi - 1].SoruYazdir(lblSoru, btnA, btnB, btnC, btnD, lblCevap);
                tmrSoru.Start();
                if (soruSayisi <= 3)
                    soruTime = 15;
                else if (soruSayisi <= 6)
                    soruTime = 30;
                else if (soruSayisi <= 9)
                    soruTime = 45;
                else
                    soruTime = 90;
                lblZaman.Text = soruTime.ToString();
                lblAktifSoru.Text = soruSayisi + ".SORU";
                for (int i = 0; i < butonlar.Count; i++)
                {
                    butonlar[i].Enabled = true;
                }
            }
            else
            {
                tmrSoru.Stop();
                ScoreKaydet();
            }
        }
        void ScoreKaydet() { 
            DialogResult dialog = MessageBox.Show(score + " Puan Yaptınız...\n Puanınızı Kaydetmek İster misiniz?", "Puan Kaydet", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dialog)
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO \"Score\" ( \"kullaniciId\", \"score\") " +
                        "VALUES(" + Convert.ToInt32(lblKullaniciId.Text) + "," + score + ");";
                    string query2 = "SELECT * FROM \"Uye\" where \"kullaniciId\"=" + Convert.ToInt32(lblKullaniciId.Text);
                    string query3 = "UPDATE \"Uye\" SET \"maxScore\"=" + score + " where \"kullaniciId\"=" + Convert.ToInt32(lblKullaniciId.Text);

                    OdbcCommand command = new OdbcCommand(query, connection);
                    command.ExecuteNonQuery();

                    OdbcCommand command2 = new OdbcCommand(query2, connection);
                    OdbcDataReader reader = command2.ExecuteReader();

                    if (reader.Read())
                    {
                        if (Convert.ToInt32(reader["maxScore"].ToString()) < score)
                        {
                            OdbcCommand command3 = new OdbcCommand(query3, connection);
                            command3.ExecuteNonQuery();
                        }
                    }
                    reader.Close();
                    connection.Close();
                    MessageBox.Show("Kayıt Başarılı Şekilde Eklendi");
                    Menu menu = (Menu)Application.OpenForms["Menu"];
                    menu.Yazdir();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            
            YenidenOyna();

        }
        void YenidenOyna() {
            DialogResult durum = MessageBox.Show("Yeniden Oyna ?", "Yeniden Oyna", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                Oyun oyun = new Oyun();
                oyun.Show();
                oyun.lblKullaniciId.Text = lblKullaniciId.Text;
            }
            else
            {
                MessageBox.Show("Çıkış Yapılıyor");
            }
            this.Close();
        }
        private void btnMenuDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
