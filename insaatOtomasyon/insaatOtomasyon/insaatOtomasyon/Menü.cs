using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insaatOtomasyon
{
    public partial class Menü : Form
    {
        public Menü()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FirmaKaydi firmaKaydi = new FirmaKaydi();
            firmaKaydi.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BölgeKaydi BölgeKaydi = new BölgeKaydi();
            BölgeKaydi.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PersonelKaydi PersonelKaydi = new PersonelKaydi();
            PersonelKaydi.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MalzemeKaydi MalzemeKaydi = new MalzemeKaydi();
            MalzemeKaydi.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OdemeTakip OdemeTakip = new OdemeTakip();
            OdemeTakip.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FaturaGiris FaturaGiris = new FaturaGiris();
            FaturaGiris.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FirmaRapor FirmaRapor = new FirmaRapor();
            FirmaRapor.Show();
            this.Hide();
        }
    }
}
