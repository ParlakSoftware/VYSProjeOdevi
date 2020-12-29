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
    public partial class SoruOner : Form
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public SoruOner()
        {
            InitializeComponent();
            ComboBoxDoldur("SELECT * FROM \"Kategoriler\"", cboxKategori);

        }
        private void ComboBoxDoldur(string query, ComboBox cbox)
        {
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbox.Items.Add(reader["kategoriAdi"].ToString());
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        int IdDon(string query)
        {
            int id = 0;
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"].ToString());
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            return id;
        }
        private void btnSoruOner_Click(object sender, EventArgs e)
        {
            string soru = txtSoru.Text;
            string a = txtA.Text;
            string b = txtB.Text;
            string c = txtC.Text;
            string d = txtD.Text;
            char cevap = Convert.ToChar(cboxCevap.SelectedItem.ToString());
            string kategori = cboxKategori.SelectedItem.ToString();
            int kategoriId = IdDon("SELECT * FROM \"Kategoriler\" where \"kategoriAdi\"='" + kategori + "'");

            SoruEkle(soru, a, b, c, d, cevap, kategoriId);
        }
        private void Temizle()
        {
            txtSoru.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            cboxCevap.SelectedIndex = 0;
            cboxKategori.SelectedIndex = 0;
        }
        void SoruEkle(string soru, string a, string b, string c, string d, char cevap, int kategori)
        {
            string query = "INSERT INTO \"SoruOner\" ( \"kategoriId\",\"kullaniciId\", \"soru\", \"a\", \"b\", \"c\", \"d\", \"cevap\") " +
                "VALUES('" + kategori + "','"+Convert.ToInt32(lblKullaniciId.Text) +"','" + soru + "','" + a + "','" + b + "','" + c + "','" + d + "','" + cevap + "');";           
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Sorunuz Başarılı Şekilde Önerildi");
                MessageBox.Show("Bize Soru Önerdiğiniz İçin Teşekkür Ederiz");
                Temizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void btnMenuDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
