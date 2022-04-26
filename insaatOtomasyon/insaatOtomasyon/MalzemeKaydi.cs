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
    public partial class MalzemeKaydi : Form
    {
        public MalzemeKaydi()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglanti = new sqlBaglantisi();
        public void listeleMalzeme() {
            DataTable MalzemeTablo = new DataTable();
            SqlDataAdapter listele = new SqlDataAdapter("select * from Malzeme_Kayit",baglanti.baglan());
            listele.Fill(MalzemeTablo);
            dataGridView1.DataSource = MalzemeTablo;
        
        }
        public void temizle() {
            textBox8.Clear();
            textBox5.Clear();
            textBox9.Clear();
        }
        private void MalzemeKaydi_Load(object sender, EventArgs e)
        {
            listeleMalzeme();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand EkleSorgu = new SqlCommand("insert into Malzeme_Kayit (Malzeme_Adi,Malzeme_Birim_Fiyat,Aciklama)values (@p2,@p3,@p4)", baglanti.baglan());

                EkleSorgu.Parameters.AddWithValue("@p2", textBox8.Text);
                EkleSorgu.Parameters.AddWithValue("@p3", textBox5.Text);
                EkleSorgu.Parameters.AddWithValue("@p4", textBox9.Text);
                EkleSorgu.ExecuteNonQuery();
                MessageBox.Show("Malzeme Bilgileriniz Sisteme Kayıt Edilmiştir.", "Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listeleMalzeme();
                temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand GuncelleSorgu = new SqlCommand("update Malzeme_Kayit set Malzeme_Adi=@p2,Malzeme_Birim_Fiyat=@p3,Aciklama=@p4 where Malzeme_Adi='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", baglanti.baglan());
                GuncelleSorgu.Parameters.AddWithValue("@p2", textBox8.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p3", textBox5.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p4", textBox9.Text);
                GuncelleSorgu.ExecuteNonQuery();
                MessageBox.Show("Malzeme Bilgileriniz Güncellenmiştir.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listeleMalzeme();
                temizle();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand SilSorgu = new SqlCommand("delete from Malzeme_Kayit where Malzeme_Adi=@alansil", baglanti.baglan());
                SilSorgu.Parameters.AddWithValue("@alansil", textBox8.Text);
                SilSorgu.ExecuteNonQuery();
                MessageBox.Show("Malzeme Bilgileriniz Silinmiştir", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listeleMalzeme();
                temizle();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!!");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Menü menü = new Menü();
            menü.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From Malzeme_Kayit where Malzeme_Adi like'" + textBox1.Text + "%'", baglanti.baglan());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();
        }
    }
}
