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
    public partial class PersonelKaydi : Form
    {
        public PersonelKaydi()
        {
            InitializeComponent();
        }
        public void ListelePersonel() {
            DataTable PersonelTablo = new DataTable();
            SqlDataAdapter Listele = new SqlDataAdapter("select * from Personel",baglanti.baglan());
            Listele.Fill(PersonelTablo);
            dataGridView1.DataSource = PersonelTablo;
        }
        public void Temizle() {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        sqlBaglantisi baglanti = new sqlBaglantisi();
        private void PersonelKaydi_Load(object sender, EventArgs e)
        {
            ListelePersonel();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            this.Close();
            Menü menü = new Menü();
            menü.Show();

        }
        DataTable tablo = new DataTable();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Personel where Personel_Adi like'"+textBox1.Text+"%'",baglanti.baglan());
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adapter.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand EkleSorgu = new SqlCommand("insert into Personel (Personel_Adi,Personel_Soyadi,Personel_Maas,Personel_Departman,Personel_Sgk_Fiyat)values (@p2,@p3,@p4,@p5,@p6)", baglanti.baglan());

                EkleSorgu.Parameters.AddWithValue("@p2", textBox2.Text);
                EkleSorgu.Parameters.AddWithValue("@p3", textBox3.Text);
                EkleSorgu.Parameters.AddWithValue("@p4", textBox4.Text);
                EkleSorgu.Parameters.AddWithValue("@p5", textBox5.Text);
                EkleSorgu.Parameters.AddWithValue("@p6", textBox6.Text);
                EkleSorgu.ExecuteNonQuery();
                MessageBox.Show("Personel  Bilgileriniz Sisteme Kayıt Edilmiştir.", "Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListelePersonel();
                Temizle();
            }
            catch (Exception hata )
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand GuncelleSorgu = new SqlCommand("update Personel set Personel_Adi=@p2,Personel_Soyadi=@p3,Personel_Maas=@p4,Personel_Departman=@p5,Personel_Sgk_Fiyat=@p6 where Personel_Adi='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", baglanti.baglan());
                GuncelleSorgu.Parameters.AddWithValue("@p2", textBox2.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p3", textBox3.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p4", textBox4.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p5", textBox5.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p6", textBox6.Text);
                GuncelleSorgu.ExecuteNonQuery();
                MessageBox.Show("Personel Kayıtlarınız Güncellenmiştir.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListelePersonel();
                Temizle();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand SilSorgu = new SqlCommand("delete from Personel where Personel_Adi=@alansil", baglanti.baglan());
                SilSorgu.Parameters.AddWithValue("@alansil", textBox2.Text);
                SilSorgu.ExecuteNonQuery();
                MessageBox.Show("Personel Kayıtlarınız Silinmiştir", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListelePersonel();
                Temizle();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!!");
            }
        }
    }
}
