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
    public partial class OdemeTakip : Form
    {
        public OdemeTakip()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {

                    label5.Text = comboBox1.Text;
                    DataTable tablo = new DataTable();
                    tablo.Clear();
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from Fatura_Kayit where Firma_Adi='" + comboBox1.Text + "'", baglanti.baglan());
                    adapter.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    adapter.Dispose();

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.RowHeadersVisible = false;




                    dataGridView1.Columns[1].HeaderText = "Firma Adı";
                    dataGridView1.Columns[2].HeaderText = "Fatura No";
                    dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                    dataGridView1.Columns[4].HeaderText = "İrsaliye No";
                    dataGridView1.Columns[5].HeaderText = "İrsaliye Tarihi";
                    dataGridView1.Columns[10].HeaderText = "KDV Oranı";
                    dataGridView1.Columns[11].HeaderText = "KDV Tutarı";
                    dataGridView1.Columns[12].HeaderText = "Fatura Tutarı";

                    dataGridView1.Columns[1].Width = 75;
                    dataGridView1.Columns[2].Width = 75;
                    dataGridView1.Columns[3].Width = 105;
                    dataGridView1.Columns[4].Width = 75;
                    dataGridView1.Columns[5].Width = 105;
                    dataGridView1.Columns[10].Width = 75;
                    dataGridView1.Columns[11].Width = 75;
                    dataGridView1.Columns[12].Width = 75;

                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message + "ASFALSFASLFL");
            }

        }

        sqlBaglantisi baglanti = new sqlBaglantisi();
        private void OdemeTakip_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand firmalistele = new SqlCommand("select * from Firma_Kayit ", baglanti.baglan());
            SqlDataReader oku = firmalistele.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["firma_adi"].ToString());

            }

            comboBox2.Items.Add("Mart");
            comboBox2.Items.Add("Ocak");
            comboBox2.Items.Add("Ocak");
            comboBox2.Items.Add("Ocak");
            comboBox2.Items.Add("Ocak");
            comboBox2.Items.Add("Ocak");
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ay = "";
            switch (comboBox2.Text)
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
            try
            {
                DataTable tablo = new DataTable();
                tablo.Clear();

                SqlDataAdapter adtr = new SqlDataAdapter("select * From Fatura_Kayit where  Firma_Adi ='" + comboBox1.Text + "'and month(Fatura_Tarihi)='" + Convert.ToInt32(ay.ToString()) + "'", baglanti.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.RowHeadersVisible = false;




                dataGridView1.Columns[1].HeaderText = "Firma Adı";
                dataGridView1.Columns[2].HeaderText = "Fatura No";
                dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                dataGridView1.Columns[4].HeaderText = "İrsaliye No";
                dataGridView1.Columns[5].HeaderText = "İrsaliye Tarihi";
                dataGridView1.Columns[10].HeaderText = "KDV Oranı";
                dataGridView1.Columns[11].HeaderText = "KDV Tutarı";
                dataGridView1.Columns[12].HeaderText = "Fatura Tutarı";

                dataGridView1.Columns[1].Width = 75;
                dataGridView1.Columns[2].Width = 75;
                dataGridView1.Columns[3].Width = 105;
                dataGridView1.Columns[4].Width = 75;
                dataGridView1.Columns[5].Width = 105;
                dataGridView1.Columns[10].Width = 75;
                dataGridView1.Columns[11].Width = 75;
                dataGridView1.Columns[12].Width = 75;


            }
            catch (Exception)
            {

                throw;
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ay = "";
            switch (comboBox2.Text)
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
            try
            {
                DataTable tablo = new DataTable();
                SqlDataAdapter adtr = new SqlDataAdapter("select * From Fatura_Kayit where  Firma_Adi ='" + comboBox1.Text + "'and month(Fatura_Tarihi)='" + Convert.ToInt32(ay.ToString()) + "'and YEAR(Fatura_Tarihi)='" + comboBox3.Text + "'", baglanti.baglan());
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr.Dispose();

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;   
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.RowHeadersVisible = false;




                dataGridView1.Columns[1].HeaderText = "Firma Adı";
                dataGridView1.Columns[2].HeaderText = "Fatura No";
                dataGridView1.Columns[3].HeaderText = "Fatura Tarihi";
                dataGridView1.Columns[4].HeaderText = "İrsaliye No";
                dataGridView1.Columns[5].HeaderText = "İrsaliye Tarihi";
                dataGridView1.Columns[10].HeaderText = "KDV Oranı";
                dataGridView1.Columns[11].HeaderText = "KDV Tutarı";
                dataGridView1.Columns[12].HeaderText = "Fatura Tutarı";

                dataGridView1.Columns[1].Width = 75;
                dataGridView1.Columns[2].Width = 75;
                dataGridView1.Columns[3].Width = 105;
                dataGridView1.Columns[4].Width = 75;
                dataGridView1.Columns[5].Width = 105;
                dataGridView1.Columns[10].Width = 75;
                dataGridView1.Columns[11].Width = 75;
                dataGridView1.Columns[12].Width = 75;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            label6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label8.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            label10.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            label12.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            label14.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            label16.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString() + "₺";
            label18.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString() + "₺";

            try
            {
                string ay = "";
                switch (comboBox2.Text)
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
                SqlCommand kod = new SqlCommand("select SUM(Fatura_Toplami) from Fatura_Kayit where month(Fatura_Tarihi)='"+Convert.ToInt32(ay.ToString())+"' and Firma_Adi='"+comboBox1.Text+"'",baglanti.baglan());
                object sum = kod.ExecuteScalar();
                label20.Text = sum.ToString() + "TL";

            }
            catch
            {
                ;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Close();
            Menü menü = new Menü();
            menü.Show();
        }
    }
}
