using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    class AracKiralama
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-82T154B\SQLEXPRESS;Initial Catalog=AracKiralama;Integrated Security=True");
        DataTable tablo;

        public IEnumerable<Control> Controls { get; private set; }

        public void ekleSilGuncelle(SqlCommand komut, string sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Tamamlandı");
            

        }
        public DataTable listele(SqlDataAdapter adtr,string sorgu)
        {
            tablo = new DataTable();
            adtr = new SqlDataAdapter(sorgu, baglanti);
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
      
    }
}
