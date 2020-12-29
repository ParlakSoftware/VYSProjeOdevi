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
    public partial class Menu : Form
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");

        public Menu()
        {
            InitializeComponent();
            Yazdir();
        }

        public void Yazdir()
        {
            string query = "SELECT  \"Kullanici\".\"ad\",\"Kullanici\".\"soyad\",\"Score\".\"score\" " +
                "FROM \"Kullanici\"" +
                "INNER JOIN \"Score\"  ON \"Kullanici\".\"id\" = \"Score\".\"kullaniciId\"" +
                "ORDER BY \"Score\".\"score\" DESC limit 10";

            try
            {
                connection.Open();
                OdbcDataAdapter dadapter = new OdbcDataAdapter();
                dadapter.SelectCommand = new OdbcCommand(query, connection);
                DataTable table = new DataTable();
                dadapter.Fill(table);

                connection.Close();
                dgvScoreTable.DataSource = table;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void btnOyna_Click(object sender, EventArgs e)
        {
            Oyun oyun = new Oyun();
            oyun.lblKullaniciId.Text = lblKullaniciId.Text;
            if (Application.OpenForms["ProfilBilgileri"] == null && Application.OpenForms["SoruOner"] == null)
            {
                if (Application.OpenForms["Oyun"] == null)
                {
                    oyun.Show();
                }
                else
                {
                    oyun.Activate();
                }
            }
            else
            {
                MessageBox.Show("Başka Sayfa Açılamaz");
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Oyun"] == null && Application.OpenForms["SoruOner"] == null)
            {
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Önce Diğer Sayfaları Kapatınız");
            }
        }
        private void btnSoruOner_Click(object sender, EventArgs e)
        {
            SoruOner soruOner = new SoruOner();
            soruOner.lblKullaniciId.Text = lblKullaniciId.Text;
            if (Application.OpenForms["Oyun"] == null && Application.OpenForms["ProfilBilgileri"] == null)
            {
                if (Application.OpenForms["SoruOner"] == null)
                {
                    soruOner.Show();
                }
                else
                {
                    soruOner.Activate();
                }
            }
            else
            {
                MessageBox.Show("Başka Sayfa Açılamaz");
            }
            
        }

        private void btnProfilBilgilerim_Click(object sender, EventArgs e)
        {
            ProfilBilgileri profilBilgileri = new ProfilBilgileri();
            profilBilgileri.lblKullaniciId.Text = lblKullaniciId.Text;

            if (Application.OpenForms["Oyun"] == null && Application.OpenForms["SoruOner"] == null)
            {
                if (Application.OpenForms["ProfilBilgileri"] == null)
                {
                    profilBilgileri.Show();
                }
                else
                {
                    profilBilgileri.Activate();
                }
            }
            else
            {
                MessageBox.Show("Başka Sayfa Açılamaz");
            }
        }
    }
}