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
        SqlConnection baglanti = new SqlConnection(@"Data Source=KENAN\SQLEXPRESS01;Initial Catalog=AracKiralama;Integrated Security=True");
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
        public void bosAraclar(ComboBox combo, string text)
        {
            baglanti.Open();
            SqlCommand komut4=new SqlCommand(text,baglanti);
            SqlDataReader read1=komut4.ExecuteReader();
            while (read1.Read())
            {
                combo.Items.Add(read1["plaka"].ToString());
            }
            baglanti.Close();
        }
        public void kontrolTc(TextBox adSoyad, TextBox tc, TextBox tel, string text)
        {
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand(text, baglanti);
            SqlDataReader read2 = komut5.ExecuteReader();
            while (read2.Read())
            {
                adSoyad.Text= read2["adSoyad"].ToString();
                tel.Text = read2["telefon"].ToString();
            }
            baglanti.Close();
        }
        public void aracComboListeleme(ComboBox combo,TextBox marka, TextBox model, TextBox yil, TextBox renk, string text)
        {
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand(text, baglanti);
            SqlDataReader read6 = komut6.ExecuteReader();
            while (read6.Read())
            {
                marka.Text = read6["marka"].ToString();
                model.Text = read6["seri"].ToString();
                yil.Text = read6["yil"].ToString();
                renk.Text = read6["renk"].ToString();
                
            }
            baglanti.Close();
        }
        public void aracUcretListeleme(ComboBox combo, TextBox kiraUcreti, string text)
        {
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand(text, baglanti);
            SqlDataReader read7 = komut7.ExecuteReader();
            while (read7.Read())
            {
                kiraUcreti.Text = read7["kiraUcreti"].ToString();
                
            }
            baglanti.Close();
        }

    }
}
