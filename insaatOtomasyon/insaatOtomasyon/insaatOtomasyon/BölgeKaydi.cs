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
    public partial class BölgeKaydi : Form
    {
        public BölgeKaydi()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglanti = new sqlBaglantisi();
        public void ListeleBölgeTablo()
        {
            DataTable BölgeTablo = new DataTable();
            SqlDataAdapter Listele = new SqlDataAdapter("select * from Bölge_Kayit", baglanti.baglan());
            Listele.Fill(BölgeTablo);
            dataGridView1.DataSource = BölgeTablo;

            
        }
        public void ListeleMalzemeTablo() {
            DataTable BölgeMalzemeTablo = new DataTable();
            SqlDataAdapter ListeleMalzeme = new SqlDataAdapter("select * from Bölge_Malzeme_Kaydi", baglanti.baglan());
            ListeleMalzeme.Fill(BölgeMalzemeTablo);
            dataGridView2.DataSource = BölgeMalzemeTablo;

        }
        public void ListeleGiderTablo() {
            DataTable MalzemeGiderTablo = new DataTable();
            SqlDataAdapter ListeleGider = new SqlDataAdapter("select * from Bölge_Gider_Kayit",baglanti.baglan());
            ListeleGider.Fill(MalzemeGiderTablo);
            dataGridView3.DataSource = MalzemeGiderTablo;
        
        }
        public void Temizle()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Clear();
            comboBox2.SelectedItem = null;
            comboBox1.SelectedItem = null;
            textBox6.Clear();
            comboBox3.SelectedItem = null;
            textBox5.Clear();
            textBox8.Clear();
            textBox9.Clear();


        }
        public DataTable tablo = new DataTable();
        private void BölgeKaydi_Load(object sender, EventArgs e)
        {
            ListeleBölgeTablo();
            ListeleMalzemeTablo();
            ListeleGiderTablo();
            SqlCommand komut1 = new SqlCommand("select * from Bölge_Kayit", baglanti.baglan());
            SqlDataReader oku = komut1.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku.GetValue(1));
                comboBox2.Items.Add(oku.GetValue(1));
            }
            oku.Close();

            SqlCommand komut2 = new SqlCommand("select * from Malzeme_Kayit", baglanti.baglan());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox3.Items.Add(oku2.GetValue(1));
            }
            oku2.Close();

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
                SqlCommand EkleSorgu = new SqlCommand("insert into Bölge_Kayit (Bölge_Adi,Adres,Aciklama)values (@p2,@p3,@p4)", baglanti.baglan());

                EkleSorgu.Parameters.AddWithValue("@p2", textBox2.Text);
                EkleSorgu.Parameters.AddWithValue("@p3", textBox3.Text);
                EkleSorgu.Parameters.AddWithValue("@p4", textBox4.Text);
                EkleSorgu.ExecuteNonQuery();
                MessageBox.Show("Bölge  Bilgileriniz Sisteme Kayıt Edilmiştir.", "Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleBölgeTablo();
                ListeleMalzemeTablo();

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
                SqlCommand GuncelleSorgu = new SqlCommand("update Bölge_Kayit set Bölge_Adi=@p2,Adres=@p3,Aciklama=@p4 where Bölge_Adi='" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'", baglanti.baglan());
                GuncelleSorgu.Parameters.AddWithValue("@p2", textBox2.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p3", textBox3.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p4", textBox4.Text);
                GuncelleSorgu.ExecuteNonQuery();
                MessageBox.Show("Bölge Bilgileriniz Güncellenmiştir.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleBölgeTablo();
                ListeleMalzemeTablo();
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
                SqlCommand SilSorgu = new SqlCommand("delete from Bölge_Kayit where Bölge_Adi=@alansil", baglanti.baglan());
                SilSorgu.Parameters.AddWithValue("@alansil", textBox2.Text);
                SilSorgu.ExecuteNonQuery();
                MessageBox.Show("Bölge Bilgileriniz Silinmiştir", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleBölgeTablo();
                ListeleMalzemeTablo();
                Temizle();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From Bölge_Kayit where Bölge_Adi like'" + textBox1.Text + "%'", baglanti.baglan());
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Menü menü = new Menü();
            menü.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
           comboBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox6.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand EkleSorgu = new SqlCommand("insert into Bölge_Malzeme_Kaydi (Bölge_Adi,Malzeme_Adi,Miktar)values (@p2,@p3,@p4)", baglanti.baglan());
                EkleSorgu.Parameters.AddWithValue("@p2", comboBox1.Text);
                EkleSorgu.Parameters.AddWithValue("@p3", comboBox3.Text);
                EkleSorgu.Parameters.AddWithValue("@p4", textBox6.Text);
                EkleSorgu.ExecuteNonQuery();
                MessageBox.Show("Bölge  Malzeme Bilgileriniz Sisteme Kayıt Edilmiştir.", "Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleMalzemeTablo();
                Temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand GuncelleSorgu = new SqlCommand("update Bölge_Malzeme_Kaydi set Bölge_Adi=@p2,Malzeme_Adi=@p3,Miktar=@p4 where Bölge_Adi='" + dataGridView2.CurrentRow.Cells[1].Value.ToString() + "'", baglanti.baglan());
                GuncelleSorgu.Parameters.AddWithValue("@p2", comboBox1.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p3", textBox6.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p4", comboBox3.Text);
                GuncelleSorgu.ExecuteNonQuery();
                MessageBox.Show("Bölge Malzeme Bilgileriniz Güncellenmiştir.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleMalzemeTablo();
                Temizle();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand SilSorgu = new SqlCommand("delete from Bölge_Malzeme_Kaydi where id='"+ dataGridView2.CurrentRow.Cells[0].Value.ToString() + "'", baglanti.baglan());
                SilSorgu.ExecuteNonQuery();
                MessageBox.Show("Bölge Malzeme Bilgileriniz Silinmiştir", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleMalzemeTablo();
                Temizle();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand EkleSorgu = new SqlCommand("insert into Bölge_Gider_Kayit(Bölge_Adi,iscilik,Elektrik,Su)values (@p1,@p2,@p3,@p4)", baglanti.baglan());
                EkleSorgu.Parameters.AddWithValue("@p1", comboBox2.Text);
                EkleSorgu.Parameters.AddWithValue("@p4", textBox9.Text);
                EkleSorgu.Parameters.AddWithValue("@p2", textBox8.Text);
                EkleSorgu.Parameters.AddWithValue("@p3", textBox5.Text);
                EkleSorgu.ExecuteNonQuery();
                MessageBox.Show("Malzeme Gider Bilgileriniz Sisteme Kayıt Edilmiştir.", "Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleGiderTablo();
                Temizle();
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!!");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.Close();
            Menü menü = new Menü();
            menü.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            this.Close();
            Menü menü = new Menü();
            menü.Show();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox2.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox5.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox8.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox9.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand GuncelleSorgu = new SqlCommand("update Bölge_Gider_Kayit set Bölge_Adi=@p1,iscilik=@p2,Elektrik=@p3,Su=@p4 where Bölge_Adi='" + dataGridView3.CurrentRow.Cells[1].Value.ToString() + "'", baglanti.baglan());
                GuncelleSorgu.Parameters.AddWithValue("@p1", comboBox2.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p2", textBox8.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p3", textBox5.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p4", textBox9.Text);
                GuncelleSorgu.ExecuteNonQuery();
                MessageBox.Show(" Malzeme Gider Bilgileriniz Güncellenmiştir.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleGiderTablo();
                ListeleBölgeTablo();
                ListeleMalzemeTablo();
                Temizle();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand SilSorgu = new SqlCommand("delete from Bölge_Gider_Kayit where id='" + dataGridView3.CurrentRow.Cells[0].Value.ToString() + "'", baglanti.baglan());
                SilSorgu.ExecuteNonQuery();
                MessageBox.Show(" Malzeme Gider Bilgileriniz Silinmiştir", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleGiderTablo();
                Temizle();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA!!!");
            }
        }
    }
}
