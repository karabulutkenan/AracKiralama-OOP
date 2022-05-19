using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AracKiralama
{
    class Kullanici
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-82T154B\SQLEXPRESS;Initial Catalog=AracKiralama;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader read;
        FrmAnaSayfa anaSayfa = new FrmAnaSayfa();
        public SqlDataReader KullaniciRead(Bunifu.UI.WinForms.BunifuTextBox kullaniciadi, Bunifu.UI.WinForms.BunifuTextBox sifre, Form frm)
        {
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select *from kullanici where kullaniciAdi='" + kullaniciadi.Text + "' and sifre='" + sifre.Text + "'";
            read = komut.ExecuteReader();

            if (read.Read()==true)
            {
                if (sifre.Text==read["sifre"].ToString())
                {
                    MessageBox.Show("Giriş Başarılı");
                    frm.Hide();
                    anaSayfa.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre","Hata1");
                }
            }
            else
            {
                    MessageBox.Show("Bilgilerinizi Kontrol Ediniz", "Hata2");
            }
            baglanti.Close();
            return read;
        }
        public void YeniKullanici(TextBox adsoyad, TextBox kullanıcıadı,TextBox sifre, TextBox tekrar, TextBox soru, TextBox cevap, GroupBox grup)
        {
            if (sifre.Text == tekrar.Text&&kullanıcıadı.Text!="")
                    {

                        baglanti.Open();
                        komut = new SqlCommand();
                        komut.Connection = baglanti;
                        komut.CommandText = "insert into kullanici (adSoyad,kullaniciAdi,sifre,soru,cevap) values ('" + adsoyad.Text + "','" + kullanıcıadı.Text + "','" + sifre.Text + "','" + soru.Text + "','" + cevap.Text + "')";
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Kullanıcı Eklendi");
                        foreach (Control item in grup.Controls)
                        {
                            if (item is TextBox)
                            {
                                item.Text = "";
                            }
                        }

                    }


                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmuyor Lütfen Tekrar Deneyiniz!");
                    }
                
            
        }
        public void Sifre(TextBox kullaniciadi, TextBox soru, TextBox cevap, TextBox sifre, TextBox sifretekrar, GroupBox grup)
        {
            if (sifre.Text == sifretekrar.Text)
            {
                baglanti.Open();
                komut = new SqlCommand("select *from kullanici where kullaniciAdi='" + kullaniciadi.Text + "'",baglanti);
                read = komut.ExecuteReader();
                if (read.Read() == true)
                {

                    if (soru.Text == read["soru"].ToString()&& cevap.Text == read["cevap"].ToString())
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut = new SqlCommand("update kullanici set sifre='" + sifre.Text + "' where kullaniciAdi='"+kullaniciadi.Text+"'" , baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Şifreniz Başarıyla Değiştirilmiştir");
                        foreach (Control item in grup.Controls)
                        {
                            if (item is TextBox)
                            {
                                item.Text = "";
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Soru ve Cevap Hatalı!");
                    }

                }
                else
                {
                    MessageBox.Show("Lütfen Kullanıcı adını doğru giriniz!", "Hata");
                }
                baglanti.Close();
            }

        }
        
    }
}
