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
    public partial class ProfilBilgileri : Form
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public ProfilBilgileri()
        {
            InitializeComponent();
        }

        private void btnMenuDon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void AdresGuncelle() {
            string query = "SELECT  \"Adres\".\"id\", \"Adres\".\"adres\" AS \"Adres\"," +
                 "\"Ilce\".\"ilceAdi\" AS \"İlçe\"," +
                 "\"Il\".\"ilAdi\" AS \"İl\"" +
                 "FROM     \"Ilce\" " +
                 "INNER JOIN \"Adres\"  ON \"Ilce\".\"ilceNo\" = \"Adres\".\"ilce\" " +
                 "INNER JOIN \"Il\"  ON \"Il\".\"ilNo\" = \"Ilce\".\"ilNo\" " +
                 "WHERE    ( \"Adres\".\"kullaniciId\" = " + lblKullaniciId.Text + ")";
            Yazdir(query, dgvAdreslerim);
        }
        private void ProfilBilgileri_Load(object sender, EventArgs e)
        {
            AdresGuncelle();
            ComboBoxDoldur("SELECT * FROM \"Il\" ORDER BY \"ilNo\" ASC",cboxIl,"ilAdi");

            string bilgiQuery = "SELECT * FROM \"Kullanici\" where \"id\"="+ lblKullaniciId.Text;
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(bilgiQuery, connection);
                OdbcDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    txtAd.Text = reader["ad"].ToString();
                    txtSoyad.Text = reader["soyad"].ToString();
                    txtKadi.Text = reader["kullaniciAdi"].ToString();
                    txtMail.Text = reader["mail"].ToString();
                    txtPass.Text = reader["sifre"].ToString();
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        int IdDon(string query,string ifade)
        {
            int id = 0;
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader[ifade].ToString());
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
        private void Yazdir(string query, DataGridView dv)
        {
            try
            {
                connection.Open();
                OdbcDataAdapter dadapter = new OdbcDataAdapter();
                dadapter.SelectCommand = new OdbcCommand(query, connection);
                DataTable table = new DataTable();
                dadapter.Fill(table);


                connection.Close();
                dv.DataSource = table;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void ComboBoxDoldur(string query, ComboBox cbox,string ifade)
        {
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbox.Items.Add(reader[ifade].ToString());
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void btnBilgilerimiGuncelle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string pass = txtPass.Text;
            int id = Convert.ToInt32(lblKullaniciId.Text);
            string query = "UPDATE \"Kullanici\" SET \"ad\"='" + ad+ "', \"soyad\"='" + soyad+ "', \"sifre\"='" + pass + "'" +
                "WHERE \"id\"='" + id + "';";
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Bilgileriniz Güncellendi. Bir Sonraki Girişte Aktif Edilecek");
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void cboxIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ara = "SELECT * FROM \"Il\" where \"ilAdi\"='" + cboxIl.SelectedItem.ToString() + "'";
            int id = IdDon(ara,"ilNo");
            string query = "SELECT * FROM \"Ilce\" where \"ilNo\" = " + id.ToString() + " order by \"ilceAdi\" asc";
            cboxIlce.Items.Clear();
            ComboBoxDoldur(query, cboxIlce, "ilceAdi");
        }

        private void btnAdresEkle_Click(object sender, EventArgs e)
        {
            int kullaniciId = Convert.ToInt32(lblKullaniciId.Text);
            string ilce = cboxIlce.SelectedItem.ToString();
            string adres = txtAdres.Text;
            int ilceId = IdDon("SELECT * FROM \"Ilce\" where \"ilceAdi\"='" + ilce + "'", "ilceNo");
            string query = "INSERT INTO \"Adres\" ( \"kullaniciId\", \"ilce\", \"adres\") " +
                "VALUES("+ kullaniciId.ToString() + "," + ilceId + ",'" + adres + "');";
            
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                AdresGuncelle();
                txtAdres.Text = "";
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void dgvAdreslerim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
                dgvAdreslerim.Rows[e.RowIndex].Selected = true;

            int id = Convert.ToInt32(dgvAdreslerim.Rows[e.RowIndex].Cells[0].Value.ToString());
            string adres = dgvAdreslerim.Rows[e.RowIndex].Cells[1].Value.ToString();
            string ilce = dgvAdreslerim.Rows[e.RowIndex].Cells[2].Value.ToString();

            lblSilinecekAdres.Text = id.ToString();
            txtSilinecekAdres.Text = adres;
        }
      
        private void btnAdresSil_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("'" + txtSilinecekAdres.Text + "' adresini silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                int id = Convert.ToInt32(lblSilinecekAdres.Text);
                string query = "DELETE FROM \"Adres\" WHERE \"id\"='" + id + "';";

                try
                {
                    connection.Open();
                    OdbcCommand command = new OdbcCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();

                    AdresGuncelle();
                    txtSilinecekAdres.Text = "";
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                MessageBox.Show("İptal Edildi");
            }
        }
    }
}
