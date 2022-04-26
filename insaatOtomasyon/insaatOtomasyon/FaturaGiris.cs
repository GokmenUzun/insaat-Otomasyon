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
    public partial class FaturaGiris : Form
    {
        public FaturaGiris()
        {
            InitializeComponent();
        }

        sqlBaglantisi baglanti = new sqlBaglantisi();
        public void faturaListele()
        {
            DataTable faturaTablo = new DataTable();
            SqlDataAdapter faturaListele = new SqlDataAdapter("select * from Fatura_Kayit", baglanti.baglan());
            faturaListele.Fill(faturaTablo);
            dataGridView1.DataSource = faturaTablo;


        }
        public void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;

        }



        private void FaturaGiris_Load(object sender, EventArgs e)
        {
            faturaListele();
            SqlCommand komut1 = new SqlCommand("select * from Firma_Kayit", baglanti.baglan());
            SqlDataReader oku = komut1.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku.GetValue(1));
            }
            oku.Close(); 
            SqlCommand komut2 = new SqlCommand("select * from Malzeme_Kayit", baglanti.baglan());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2.GetValue(1));
            }
            oku2.Close();


            comboBox3.Items.Add("KG");
            comboBox3.Items.Add("TON");
            comboBox4.Items.Add("%8");
            comboBox4.Items.Add("%18");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("select * from Malzeme_Kayit where Malzeme_Adi='" + comboBox2.Text + "'", baglanti.baglan());

                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    textBox7.Text=oku.GetValue(2).ToString();

                }
            }
            catch
            {

                ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kgtutar = 0;
            int tontutar = 0;
            if (comboBox3.Text=="KG")
            {
                 kgtutar = Convert.ToInt32(textBox3.Text.ToString()) * Convert.ToInt32(textBox7.Text.ToString());
                        if (comboBox4.Text == "%8")
                        {
                           
                            float yüzdetutar1 =float.Parse(kgtutar.ToString()) * 8 / 100;
                             textBox5.Text = Convert.ToString(yüzdetutar1);
                            textBox6.Text = Convert.ToString(yüzdetutar1+kgtutar);
                        }
                        else
                        {
                             float yüzdetutar2 = float.Parse(kgtutar.ToString()) * 18 / 100;
                            textBox5.Text = Convert.ToString(yüzdetutar2);
                            textBox6.Text = Convert.ToString(yüzdetutar2 + kgtutar);
                        }

            }
            else
            {
                 tontutar = Convert.ToInt32(textBox3.Text.ToString()) * 1000 * Convert.ToInt32(textBox7.Text.ToString());
                        if (comboBox4.Text == "%8")
                        {

                            float yüzdetutar1 = float.Parse(tontutar.ToString()) * 8 / 100;
                            textBox5.Text = Convert.ToString(yüzdetutar1);
                            textBox6.Text = Convert.ToString(yüzdetutar1 + tontutar);
                    
                        }
                        else
                        {
                            float yüzdetutar2 = float.Parse(tontutar.ToString()) * 18 / 100;
                            textBox5.Text = Convert.ToString(yüzdetutar2);
                            textBox6.Text = Convert.ToString(yüzdetutar2 + tontutar);
                        }




            }



           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand EkleSorgu = new SqlCommand("insert into Fatura_Kayit " +
                    "(Firma_Adi,Fatura_No,Fatura_Tarihi,irsaliye_No,irsaliye_Tarih," +
                    "Malzeme_Adi,Malzeme_Miktari,Malzeme_Birimi,Malzeme_Birim_Fiyat," +
                    "Kdv_Orani,Kdv_Tutari,Fatura_Toplami)  values (@e1,@e2,@e3,@e4,@e5,@e6,@e7,@e8,@e9,@e10,@e11,@e12)", baglanti.baglan());
                EkleSorgu.Parameters.AddWithValue("@e1", comboBox1.Text);
                EkleSorgu.Parameters.AddWithValue("@e2", int.Parse(textBox1.Text));
                EkleSorgu.Parameters.AddWithValue("@e3", dateTimePicker1.Value); 
                EkleSorgu.Parameters.AddWithValue("@e4", int.Parse(textBox2.Text));
                EkleSorgu.Parameters.AddWithValue("@e5", dateTimePicker2.Value);
                EkleSorgu.Parameters.AddWithValue("@e6", comboBox2.Text); 
                EkleSorgu.Parameters.AddWithValue("@e7", int.Parse(textBox3.Text));
                EkleSorgu.Parameters.AddWithValue("@e8", comboBox3.Text);
                EkleSorgu.Parameters.AddWithValue("@e9", int.Parse(textBox7.Text));
                EkleSorgu.Parameters.AddWithValue("@e10", comboBox4.Text);
                EkleSorgu.Parameters.AddWithValue("@e11", float.Parse(textBox5.Text));
                EkleSorgu.Parameters.AddWithValue("@e12", float.Parse(textBox6.Text));

                EkleSorgu.ExecuteNonQuery();
                MessageBox.Show("Fatura  Bilgileriniz Sisteme Kayıt Edilmiştir.", "Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                faturaListele();
                Temizle();
            }
            catch (Exception hata )
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand GuncelleSorgu = new SqlCommand("update Fatura_Kayit set Firma_Adi=@p2,Fatura_No=@p3,Fatura_Tarihi=@p4,irsaliye_No=@p5,irsaliye_Tarih=@p6," +
                    "Malzeme_Adi=@p7,Malzeme_Miktari=@p8,Malzeme_Birimi=@p9,Malzeme_Birim_Fiyat=@p10,Kdv_Orani=@p11,Kdv_Tutari=@p12,Fatura_Toplami=@p13 where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglanti.baglan());
                GuncelleSorgu.Parameters.AddWithValue("@p2", comboBox1.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p3", int.Parse(textBox1.Text));
                GuncelleSorgu.Parameters.AddWithValue("@p4", dateTimePicker1.Value);
                GuncelleSorgu.Parameters.AddWithValue("@p5", int.Parse(textBox2.Text));
                GuncelleSorgu.Parameters.AddWithValue("@p6", dateTimePicker2.Value);
                GuncelleSorgu.Parameters.AddWithValue("@p7", comboBox2.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p8", int.Parse(textBox3.Text));
                GuncelleSorgu.Parameters.AddWithValue("@p9", comboBox3.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p10", int.Parse(textBox7.Text));
                GuncelleSorgu.Parameters.AddWithValue("@p11", comboBox4.Text);
                GuncelleSorgu.Parameters.AddWithValue("@p12", float.Parse(textBox5.Text));
                GuncelleSorgu.Parameters.AddWithValue("@p13", float.Parse(textBox6.Text));
                GuncelleSorgu.ExecuteNonQuery();
                MessageBox.Show("Fatura Bilgileriniz Güncellenmiştir.", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                faturaListele();
                Temizle();
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
                SqlCommand SilSorgu = new SqlCommand("delete from Fatura_Kayit where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglanti.baglan());
                SilSorgu.ExecuteNonQuery();
                MessageBox.Show("Fatura Bilgisi Silinmiştir", "Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                faturaListele();
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
