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
    public partial class YoneticiPaneli : Form
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public YoneticiPaneli()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {
            Yazdir("SELECT \"Kolay\".\"id\",\"Kolay\".\"soru\",\"Kolay\".\"a\",\"Kolay\".\"b\",\"Kolay\".\"c\",\"Kolay\".\"d\",\"Kolay\".\"cevap\",\"Kategoriler\".\"kategoriAdi\" " +
                "FROM \"Kategoriler\" INNER JOIN \"Kolay\" ON \"Kategoriler\".\"id\"= \"Kolay\".\"kategoriId\"", dgvSorular);

            string SoruOnerQuery = "SELECT \"Kullanici\".\"kullaniciAdi\" AS " +
                "\"Öneren Kullanıcı\",\"SoruOner\".\"soru\",\"SoruOner\".\"a\"," +
                "\"SoruOner\".\"b\",\"SoruOner\".\"c\",\"SoruOner\".\"d\",\"SoruOner\".\"cevap\" " +
                "FROM \"Kullanici\" INNER JOIN \"SoruOner\"  ON \"Kullanici\".\"id\" = \"SoruOner\".\"kullaniciId\"";

            string TumSorular = "select * from (select 'Kolay', id, soru, a, b, c, d, cevap from \"Kolay\""+
            "union select 'Orta', id, soru, a, b, c, d, cevap from \"Orta\""+
            "union select 'Zor', id, soru, a, b, c, d, cevap from \"Zor\""+
            "union select 'EnZor', id, soru, a, b, c, d, cevap from \"EnZor\") as Sorular";

            Yazdir("SELECT * FROM \"Kullanici\" where \"tur\"='U'", dgvUyeler);
            Yazdir(SoruOnerQuery, dgvOnerilenSorular);
            Yazdir(TumSorular, dgvTumSorular);
            dgvTumSorular.Columns[0].HeaderText = "Bulunduğu Tablo";
            ComboBoxDoldur("SELECT * FROM \"Kategoriler\"",cboxKategori);
            ComboBoxDoldur("SELECT * FROM \"Kategoriler\"", cboxKategoriGuncelle);
            lblZorluk.Text = "Kolay";
            lblSilZorluk.Text = "Kolay";
        }
        private void ComboBoxDoldur(string query, ComboBox cbox) {
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
        private void Yazdir(string query,DataGridView dv) {
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
        private void btnKolay_Click(object sender, EventArgs e)
        {
            Yazdir("SELECT \"Kolay\".\"id\",\"Kolay\".\"soru\",\"Kolay\".\"a\",\"Kolay\".\"b\",\"Kolay\".\"c\",\"Kolay\".\"d\",\"Kolay\".\"cevap\",\"Kategoriler\".\"kategoriAdi\" " +
                "FROM \"Kategoriler\" INNER JOIN \"Kolay\" ON \"Kategoriler\".\"id\"= \"Kolay\".\"kategoriId\"", dgvSorular);
            lblZorluk.Text = "Kolay";
            lblSilZorluk.Text = "Kolay";
        }

        private void btnOrta_Click(object sender, EventArgs e)
        {
            Yazdir("SELECT \"Orta\".\"id\",\"Orta\".\"soru\",\"Orta\".\"a\",\"Orta\".\"b\",\"Orta\".\"c\",\"Orta\".\"d\",\"Orta\".\"cevap\",\"Kategoriler\".\"kategoriAdi\" " +
                "FROM \"Kategoriler\" INNER JOIN \"Orta\" ON \"Kategoriler\".\"id\"= \"Orta\".\"kategoriId\"", dgvSorular);
            lblZorluk.Text = "Orta";
            lblSilZorluk.Text = "Orta";
        }

        private void btnZor_Click(object sender, EventArgs e)
        {
            Yazdir("SELECT \"Zor\".\"id\",\"Zor\".\"soru\",\"Zor\".\"a\",\"Zor\".\"b\",\"Zor\".\"c\",\"Zor\".\"d\",\"Zor\".\"cevap\",\"Kategoriler\".\"kategoriAdi\" " +
                "FROM \"Kategoriler\" INNER JOIN \"Zor\" ON \"Kategoriler\".\"id\"= \"Zor\".\"kategoriId\"", dgvSorular);
            lblZorluk.Text = "Zor";
            lblSilZorluk.Text = "Zor";
        }

        private void btnEnZor_Click(object sender, EventArgs e)
        {
            Yazdir("SELECT \"EnZor\".\"id\",\"EnZor\".\"soru\",\"EnZor\".\"a\",\"EnZor\".\"b\",\"EnZor\".\"c\",\"EnZor\".\"d\",\"EnZor\".\"cevap\",\"Kategoriler\".\"kategoriAdi\" " +
                "FROM \"Kategoriler\" INNER JOIN \"EnZor\" ON \"Kategoriler\".\"id\"= \"EnZor\".\"kategoriId\"", dgvSorular);
            lblZorluk.Text = "En Zor";
            lblSilZorluk.Text = "En Zor";
        }
        private void SorulariGuncelle(string table) {
            if (table == "Kolay")
                Yazdir("SELECT \"Kolay\".\"id\",\"Kolay\".\"soru\",\"Kolay\".\"a\",\"Kolay\".\"b\",\"Kolay\".\"c\",\"Kolay\".\"d\",\"Kolay\".\"cevap\",\"Kategoriler\".\"kategoriAdi\" " +
                "FROM \"Kategoriler\" INNER JOIN \"Kolay\" ON \"Kategoriler\".\"id\"= \"Kolay\".\"kategoriId\"", dgvSorular);
            else if (table == "Orta")
                Yazdir("SELECT \"Orta\".\"id\",\"Orta\".\"soru\",\"Orta\".\"a\",\"Orta\".\"b\",\"Orta\".\"c\",\"Orta\".\"d\",\"Orta\".\"cevap\",\"Kategoriler\".\"kategoriAdi\" " +
                "FROM \"Kategoriler\" INNER JOIN \"Orta\" ON \"Kategoriler\".\"id\"= \"Orta\".\"kategoriId\"", dgvSorular);
            else if (table == "Zor")
                Yazdir("SELECT \"Zor\".\"id\",\"Zor\".\"soru\",\"Zor\".\"a\",\"Zor\".\"b\",\"Zor\".\"c\",\"Zor\".\"d\",\"Zor\".\"cevap\",\"Kategoriler\".\"kategoriAdi\" " +
                "FROM \"Kategoriler\" INNER JOIN \"Zor\" ON \"Kategoriler\".\"id\"= \"Zor\".\"kategoriId\"", dgvSorular);
            else if (table == "En Zor")
                Yazdir("SELECT \"EnZor\".\"id\",\"EnZor\".\"soru\",\"EnZor\".\"a\",\"EnZor\".\"b\",\"EnZor\".\"c\",\"EnZor\".\"d\",\"EnZor\".\"cevap\",\"Kategoriler\".\"kategoriAdi\" " +
                "FROM \"Kategoriler\" INNER JOIN \"EnZor\" ON \"Kategoriler\".\"id\"= \"EnZor\".\"kategoriId\"", dgvSorular);
        }
        private void btnSoruEkle_Click(object sender, EventArgs e)
        {
            string soru = txtSoru.Text;
            string a = txtA.Text;
            string b = txtB.Text;
            string c = txtC.Text;
            string d = txtD.Text;
            char cevap = Convert.ToChar(cboxCevap.SelectedItem.ToString());
            string zorluk = cboxZorluk.SelectedItem.ToString();
            string kategori = cboxKategori.SelectedItem.ToString();
            int kategoriId = IdDon("SELECT * FROM \"Kategoriler\" where \"kategoriAdi\"='" + kategori + "'");

            SoruEkle(zorluk,soru,a,b,c,d,cevap,kategoriId);
        }
        private void Temizle() {
            txtSoru.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            txtSilinecekSoru.Text = "";
            cboxCevap.SelectedIndex = 0;
            cboxZorluk.SelectedIndex = 0;
            cboxKategori.SelectedIndex = 0;
        }
        void SoruEkle(string table, string soru, string a, string b, string c, string d, char cevap, int kategori)
        {
            string query = "";
            if (table == "Kolay")
                query = "INSERT INTO \"Kolay\" ( \"kategoriId\", \"soru\", \"a\", \"b\", \"c\", \"d\", \"cevap\") " +
            "VALUES(" + kategori + ",'" + soru + "','" + a + "','" + b + "','" + c + "','" + d + "','" + cevap + "');";
            else if (table == "Orta")
                query = "INSERT INTO \"Orta\" ( \"kategoriId\", \"soru\", \"a\", \"b\", \"c\", \"d\", \"cevap\") " +
            "VALUES(" + kategori + ",'" + soru + "','" + a + "','" + b + "','" + c + "','" + d + "','" + cevap + "');";
            else if (table == "Zor")
                query = "INSERT INTO \"Zor\" ( \"kategoriId\", \"soru\", \"a\", \"b\", \"c\", \"d\", \"cevap\") " +
            "VALUES(" + kategori + ",'" + soru + "','" + a + "','" + b + "','" + c + "','" + d + "','" + cevap + "');";
            else if (table == "En Zor")
                query = "INSERT INTO \"EnZor\" ( \"kategoriId\", \"soru\", \"a\", \"b\", \"c\", \"d\", \"cevap\") " +
            "VALUES(" + kategori + ",'" + soru + "','" + a + "','" + b + "','" + c + "','" + d + "','" + cevap + "');";
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                SorulariGuncelle(table);
                Temizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        void SoruGuncelle(string table, string soru, string a, string b, string c, string d, char cevap, int kategori,int id)
        {
            string query = "";
            if (table == "Kolay")
                query = "UPDATE \"Kolay\" SET \"kategoriId\"='"+kategori+"', \"soru\"='"+soru+"', \"a\"='"+a+"', \"b\"='"+b+"', \"c\"='"+c+"', \"d\"='"+d+"', \"cevap\"='"+cevap+"' " +
                "WHERE \"id\"='"+id+"';";
            else if (table == "Orta")
                query = "UPDATE \"Orta\" SET \"kategoriId\"='" + kategori + "', \"soru\"='" + soru + "', \"a\"='" + a + "', \"b\"='" + b + "', \"c\"='" + c + "', \"d\"='" + d + "', \"cevap\"='" + cevap + "' " +
                "WHERE \"id\"='" + id + "';";
            else if (table == "Zor")
                query = "UPDATE \"Zor\" SET \"kategoriId\"='" + kategori + "', \"soru\"='" + soru + "', \"a\"='" + a + "', \"b\"='" + b + "', \"c\"='" + c + "', \"d\"='" + d + "', \"cevap\"='" + cevap + "' " +
                "WHERE \"id\"='" + id + "';";
            else if (table == "En Zor")
                query = "UPDATE \"EnZor\" SET \"kategoriId\"='" + kategori + "', \"soru\"='" + soru + "', \"a\"='" + a + "', \"b\"='" + b + "', \"c\"='" + c + "', \"d\"='" + d + "', \"cevap\"='" + cevap + "'" +
                "WHERE \"id\"='" + id + "';";

            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                SorulariGuncelle(table);
                Temizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void dgvSorular_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
                dgvSorular.Rows[e.RowIndex].Selected = true;
            
            int id = Convert.ToInt32(dgvSorular.Rows[e.RowIndex].Cells[0].Value.ToString());
            string soru = dgvSorular.Rows[e.RowIndex].Cells[1].Value.ToString();
            string a = dgvSorular.Rows[e.RowIndex].Cells[2].Value.ToString();
            string b = dgvSorular.Rows[e.RowIndex].Cells[3].Value.ToString();
            string c = dgvSorular.Rows[e.RowIndex].Cells[4].Value.ToString();
            string d = dgvSorular.Rows[e.RowIndex].Cells[5].Value.ToString();
            char cevap = Convert.ToChar(dgvSorular.Rows[e.RowIndex].Cells[6].Value.ToString());
            string kategori = dgvSorular.Rows[e.RowIndex].Cells[7].Value.ToString();

            lblSoruGuncelleId.Text = id.ToString();
            lblSilId.Text = id.ToString();
            txtSoruGuncelle.Text = soru;
            txtSilinecekSoru.Text = soru;
            txtAGuncelle.Text = a;
            txtBGuncelle.Text = b;
            txtCGuncelle.Text = c;
            txtDGuncelle.Text = d;

            int cevapIndex = cboxCevapGuncelle.Items.IndexOf(cevap.ToString());
            cboxCevapGuncelle.SelectedIndex = cevapIndex;

            int zorlukIndex = cboxZorlukGuncelle.Items.IndexOf(lblZorluk.Text);
            cboxZorlukGuncelle.SelectedIndex = zorlukIndex;

            int kategoriIndex = cboxKategoriGuncelle.Items.IndexOf(kategori);
            cboxKategoriGuncelle.SelectedIndex = kategoriIndex;

        }

        private void btnSoruGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lblSoruGuncelleId.Text);
            string soru = txtSoruGuncelle.Text;
            string a = txtAGuncelle.Text;
            string b = txtBGuncelle.Text;
            string c = txtCGuncelle.Text;
            string d = txtDGuncelle.Text;
            char cevap = Convert.ToChar(cboxCevapGuncelle.SelectedItem.ToString());
            string zorluk = cboxZorlukGuncelle.SelectedItem.ToString();
            string kategori = cboxKategoriGuncelle.SelectedItem.ToString();
            int kategoriId = IdDon("SELECT * FROM \"Kategoriler\" where \"kategoriAdi\"='" + kategori + "'");

            SoruGuncelle(zorluk, soru, a, b, c, d, cevap, kategoriId,id);
        }

        private void btnSoruSil_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("'"+txtSilinecekSoru.Text +"' sorusunu silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == durum)
            {
                int id = Convert.ToInt32(lblSilId.Text);
                string zorluk = lblZorluk.Text;

                string query = "";
                if (zorluk == "Kolay")
                    query = "DELETE FROM \"Kolay\" WHERE \"id\"='" + id + "';";
                else if (zorluk == "Orta")
                    query = "DELETE FROM \"Orta\" WHERE \"id\"='" + id + "';";
                else if (zorluk == "Zor")
                    query = "DELETE FROM \"Zor\" WHERE \"id\"='" + id + "';";
                else if (zorluk == "En Zor")
                    query = "DELETE FROM \"EnZor\" WHERE \"id\"='" + id + "';";

                try
                {
                    connection.Open();
                    OdbcCommand command = new OdbcCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();

                    SorulariGuncelle(zorluk);
                    Temizle();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else {
                MessageBox.Show("İptal Edildi");
            }
        }

        private void btnSoruAra_Click(object sender, EventArgs e)
        {
            string TumSorular = "select * from (select 'Kolay', id, soru, a, b, c, d, cevap from \"Kolay\"" +
            "union select 'Orta', id, soru, a, b, c, d, cevap from \"Orta\"" +
            "union select 'Zor', id, soru, a, b, c, d, cevap from \"Zor\"" +
            "union select 'EnZor', id, soru, a, b, c, d, cevap from \"EnZor\") as Sorular WHERE \"soru\" LIKE '%"+txtKelime.Text+"%'";

            Yazdir(TumSorular, dgvTumSorular);
        }
    }
}
