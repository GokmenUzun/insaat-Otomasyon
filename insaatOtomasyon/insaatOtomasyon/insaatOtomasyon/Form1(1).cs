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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        sqlBaglantisi baglanti = new sqlBaglantisi();
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand Giris = new SqlCommand("SELECT * FROM Kullanici_Giris where Kullanici_Adi=@kullaniciadi and Kullanici_Sifre=@sifre", baglanti.baglan());
            Giris.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
            Giris.Parameters.AddWithValue("@sifre", textBox2.Text);
            SqlDataReader girisOkuma = Giris.ExecuteReader();
            if (girisOkuma.Read())
            {
                girisAnimasyon menü = new girisAnimasyon();
                menü.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı veya Şifre Hatalı...", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
