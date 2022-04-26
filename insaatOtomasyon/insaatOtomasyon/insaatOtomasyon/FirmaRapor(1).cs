using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace insaatOtomasyon
{
    public partial class FirmaRapor : Form
    {
        public FirmaRapor()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglanti = new sqlBaglantisi();

        public void temizle() {

            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
        }
        public void malzeme() {
            SqlCommand kdvlistele = new SqlCommand("select * from Malzeme_Kayit ", baglanti.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();
            while (oku.Read())
            {

                comboBox4.Items.Add(oku[1]);

            }

        }
        public void firma() {
            SqlCommand kdvlistele = new SqlCommand("select * from Firma_Kayit ", baglanti.baglan());
            SqlDataReader oku = kdvlistele.ExecuteReader();

            while (oku.Read())
            {

                comboBox1.Items.Add(oku[1]);

            }
        }
        public void doldur()
        {
            try
            {

                string ay = "";
                switch (comboBox3.Text)
                {
                    case "Ocak":
                        ay = "1";
                        break;
                    case "Şubat":
                        ay = "2";
                        break;
                    case "Mart":
                        ay = "3";
                        break;
                    case "Nisan":
                        ay = "4";
                        break;

                    case "Mayıs":
                        ay = "5";
                        break;
                    case "Haziran":
                        ay = "6";
                        break;
                    case "Temmuz":
                        ay = "7";
                        break;
                    case "Ağustos":
                        ay = "8";
                        break;
                    case "Eylül":
                        ay = "9";
                        break;
                    case "Ekim":
                        ay = "10";
                        break;
                    case "Kasım":
                        ay = "11";
                        break;
                    case "Aralık":
                        ay = "12";
                        break;

                }


                SqlCommand adtr = new SqlCommand("select sum(Malzeme_Miktari) From Fatura_Kayit where month(Fatura_Tarihi)='" + ay + "' and Firma_Adi='" + comboBox1.Text + "' and YEAR(Fatura_Tarihi)='" + comboBox3.Text + "'", baglanti.baglan());
                SqlDataReader oku = adtr.ExecuteReader();
                while (oku.Read())
                {

                    label6.Text = oku[0].ToString();
                }


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }



        }
        public void dolduryilagore()
        {
            SqlCommand adtr = new SqlCommand("select sum(Malzeme_Miktari) From Fatura_Kayit where  Firma_Adi='" + comboBox1.Text + "' and YEAR(Fatura_Tarihi)='" + comboBox3.Text + "'", baglanti.baglan());
            SqlDataReader oku = adtr.ExecuteReader();
            while (oku.Read())
            {

                label7.Text = oku[0].ToString();
            }
        }
        public void doldur2()
        {
            SqlCommand adtr = new SqlCommand("select sum(Malzeme_Miktari) From Fatura_Kayit where  Firma_Adi='" + comboBox1.Text + "' and YEAR(Fatura_Tarihi)='" + comboBox3.Text + "' and Malzeme_Adi='" + comboBox4.Text + "'", baglanti.baglan());
            SqlDataReader oku = adtr.ExecuteReader();
            while (oku.Read())
            {

                label2.Text = oku[0].ToString();
            }
        }
       
        private void FirmaRapor_Load(object sender, EventArgs e)
        {
            firma();
            malzeme();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox4.Text == "")
            {

                MessageBox.Show("Gerekli Alanları doldurunuz");
            }
            else
            {

                doldur2();
                try
                {
                    tablo.Clear();
                    SqlDataAdapter adtr = new SqlDataAdapter("select * From Fatura_Kayit where Firma_Adi ='" + comboBox1.Text + "'and YEAR(Fatura_Tarihi)='" + comboBox2.Text + "'and Malzeme_Adi='" + comboBox4.Text + "' order by id desc", baglanti.baglan());
                    adtr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    adtr.Dispose();


                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[11].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.RowHeadersVisible = false;


                    dataGridView1.Columns[6].HeaderText = "Malzeme Adı";
                    dataGridView1.Columns[7].HeaderText = "Malzeme Miktarı";
                    dataGridView1.Columns[8].HeaderText = "Malzeme Birimi";
                    dataGridView1.Columns[9].HeaderText = "Birim Fiyatı";

                    dataGridView1.Columns[6].Width = 138;
                    dataGridView1.Columns[7].Width = 138;
                    dataGridView1.Columns[8].Width = 138;
                    dataGridView1.Columns[9].Width = 138;


                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);

                }
                temizle();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            dolduryilagore();
            try
            {
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From Fatura_Kayit where Firma_Adi ='" + comboBox1.Text + "'and YEAR(Fatura_Tarihi)='" + comboBox2.Text + "' order by id desc", baglanti.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.RowHeadersVisible = false;


                dataGridView1.Columns[6].HeaderText = "Malzeme Adı";
                dataGridView1.Columns[7].HeaderText = "Malzeme Miktarı";
                dataGridView1.Columns[8].HeaderText = "Malzeme Birimi";
                dataGridView1.Columns[9].HeaderText = "Birim Fiyatı";

                dataGridView1.Columns[6].Width = 138;
                dataGridView1.Columns[7].Width = 138;
                dataGridView1.Columns[8].Width = 138;
                dataGridView1.Columns[9].Width = 138;


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
            temizle();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            tablo.Clear();

            SqlDataAdapter adtr = new SqlDataAdapter("select * From Fatura_Kayit order by id desc", baglanti.baglan());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[1].HeaderText = "Firma Adı";
            dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
            dataGridView1.Columns[6].HeaderText = "Malzeme Adı";
            dataGridView1.Columns[7].HeaderText = "Malzeme Miktarı";
            dataGridView1.Columns[8].HeaderText = "Malzeme Birimi";
            dataGridView1.Columns[9].HeaderText = "Birim Fiyatı";

            dataGridView1.Columns[1].Width = 96;
            dataGridView1.Columns[3].Width = 96;
            dataGridView1.Columns[6].Width = 96;
            dataGridView1.Columns[7].Width = 96;
            dataGridView1.Columns[8].Width = 96;
            dataGridView1.Columns[9].Width = 96;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ay = "";
            switch (comboBox3.Text)
            {
                case "Ocak":
                    ay = "1";
                    break;
                case "Şubat":
                    ay = "2";
                    break;
                case "Mart":
                    ay = "3";
                    break;
                case "Nisan":
                    ay = "4";
                    break;

                case "Mayıs":
                    ay = "5";
                    break;
                case "Haziran":
                    ay = "6";
                    break;
                case "Temmuz":
                    ay = "7";
                    break;
                case "Ağustos":
                    ay = "8";
                    break;
                case "Eylül":
                    ay = "9";
                    break;
                case "Ekim":
                    ay = "10";
                    break;
                case "Kasım":
                    ay = "11";
                    break;
                case "Aralık":
                    ay = "12";
                    break;
            }
            doldur();

            try
            {
                DataTable tablo = new DataTable();
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From Fatura_Kayit where Firma_Adi ='" + comboBox1.Text + "'and YEAR(Fatura_Tarihi)='" + comboBox2.Text + "'and month(Fatura_Tarihi)='" + Convert.ToInt32(ay.ToString()) + "' order by id desc", baglanti.baglan()); ;
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();


                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //datagridview1'deki tüm satırı seç    
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.RowHeadersVisible = false;


                dataGridView1.Columns[6].HeaderText = "Malzeme Adı";
                dataGridView1.Columns[7].HeaderText = "Malzeme Miktarı";
                dataGridView1.Columns[8].HeaderText = "Malzeme Birimi";
                dataGridView1.Columns[9].HeaderText = "Birim Fiyatı";

                dataGridView1.Columns[6].Width = 138;
                dataGridView1.Columns[7].Width = 138;
                dataGridView1.Columns[8].Width = 138;
                dataGridView1.Columns[9].Width = 138;


            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);

            }
            temizle();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Close();
            Menü menü = new Menü();
            menü.Show();
        }
    }
}
