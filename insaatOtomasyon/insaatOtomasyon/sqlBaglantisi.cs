using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace insaatOtomasyon
{
    class sqlBaglantisi
    {
        public SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-G79G7E9; initial Catalog=insaatOtomasyon; Integrated Security=true");
            baglanti.Open();
            return baglanti;
        }
    }
}
