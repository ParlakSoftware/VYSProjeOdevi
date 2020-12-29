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
    public partial class Login : Form
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");

        public Login()
        {
            InitializeComponent();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM admingetir('"+ txtAdminKullaniciAdi.Text.ToString() + "','"+ txtAdminPass.Text.ToString() + "')";
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Hatalı Giriş");
                }
                else
                {
                    string adSoyad = string.Concat(reader["adsutun"].ToString()," ",reader["soyadsutun"].ToString());
                    YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
                    yoneticiPaneli.lblAdmin.Text = "Hoşgeldiniz " + adSoyad;
                    yoneticiPaneli.Show();
                    this.Hide();
                }
               
                reader.Close();
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        int IdCek(string query) {
            int id=0;
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
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
        private void btnUyeOl_Click(object sender, EventArgs e)
        {        
            try
            {
                connection.Open();
                string query = "INSERT INTO \"Kullanici\" ( \"ad\", \"soyad\", \"kullaniciAdi\", \"sifre\", \"mail\", \"tur\") " +
                "VALUES('" + txtAd.Text + "', '" + txtSoyad.Text + "', '" + txtKadi.Text + "', '" + txtPass.Text + "', '" + txtMail.Text + "', 'U')";
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                int id = IdCek("SELECT * FROM \"Kullanici\" order by \"id\" DESC limit 1");
                connection.Open();
                string query2 = "INSERT INTO \"Uye\" (\"kullaniciId\") VALUES('" + id + "')";
                OdbcCommand command2 = new OdbcCommand(query2, connection);
                command2.ExecuteNonQuery();

                txtAd.Text = "";
                txtSoyad.Text = "";
                txtKadi.Text = "";
                txtMail.Text = "";
                txtPass.Text = "";
                MessageBox.Show("Kayıt Başarılı...");

                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM \"Kullanici\" " +
                    "where \"kullaniciAdi\"='"+txtKadiLogin.Text+"' and \"sifre\"='"+txtPassLogin.Text+"' and \"tur\"='U'";
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                if(reader.Read()) { 
                    MessageBox.Show("Giriş Başarılı");
                    string adSoyad = string.Concat(reader["ad"].ToString(), " ", reader["soyad"].ToString());
                    Menu menu = new Menu();
                    menu.lblHosgeldin.Text = "Hoşgeldiniz " + adSoyad;
                    menu.lblKullaniciId.Text = reader["id"].ToString();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı Giriş");
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
