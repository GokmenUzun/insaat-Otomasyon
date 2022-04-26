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
    public partial class girisAnimasyon : Form
    {
        Timer timer = new Timer();
        public girisAnimasyon()
        {
            InitializeComponent();
            timer.Interval = 4000;
            timer.Tick += new EventHandler( Timer_Tick);
            timer.Start();

        }

         void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Menü menü = new Menü();
            menü.Show();
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
