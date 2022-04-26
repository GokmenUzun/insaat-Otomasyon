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
    public partial class FirmaKaydi : Form
    {
        public FirmaKaydi()
        {
            InitializeComponent();
        }
        sqlBaglantisi baglanti = new sqlBaglantisi();
        public void Listele()
        {
            DataTable firmaTablo = new DataTable();
            SqlDataAdapter Listele = new SqlDataAdapter("select * from Firma_Kayit",baglanti.baglan());
            Listele.Fill(firmaTablo);
            dataGridView1.DataSource = firmaTablo;


        }
        public void Temizle()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Clear();

        }

        private void FirmaKaydi_Load(object sender, EventArgs e)
        {
            Listele();
        }
        public DataTable tablo = new DataTable();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From Firma_Kayit where Firma_Adi like'" + textBox1.Text + "%'", baglanti.baglan());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand EkleSorgu = new SqlCommand("insert into Firma_Kayit (Firma_Adi,Kategori,Aciklama)values (@p2,@p3,@p4)", baglanti.baglan());
                
                EkleSorgu.Parameters.AddWithValue("@p2", textBox2.Text);
                EkleSorgu.Parameters.AddWithValue("@p3", textBox3.Text);
                EkleSorgu.Parameters.AddWithValue("@p4", textBox4.Text);
                EkleSorgu.ExecuteNonQuery();
                MessageBox.Show("Firma  Bilgileriniz Sisteme Kayıt Edilmiştir.", "Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand GuncelleSorgu = new SqlCommand("update Firma_Kayit set Firma_Adi=@p2,Kategori=@p3,Aciklama=@p4 where Firma_Adi='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", baglanti.baglan());
                GuncelleSorgu.Parameters.AddWithValue("@p2", textBox2.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p3", textBox3.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p4", textBox4.Text);
                GuncelleSorgu.ExecuteNonQuery();
                MessageBox.Show("Firma Bilgileriniz Güncellenmiştir.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
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
                SqlCommand SilSorgu = new SqlCommand("delete from Firma_Kayit where Firma_Adi=@alansil", baglanti.baglan());
                SilSorgu.Parameters.AddWithValue("@alansil", textBox2.Text);
                SilSorgu.ExecuteNonQuery();
                MessageBox.Show("Firma Bilgileriniz Silinmiştir", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
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
    }
}
