using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama

{
    public partial class formMusteriEkleme : Form
    {

        AracKiralama aracKirala = new AracKiralama();
        public formMusteriEkleme()


        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iptalButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ekleButton_Click(object sender, EventArgs e)
        {
            if (textAdSoyad.Text!=""){
            string text = "insert into musteri (adSoyad,tc,telefon,adres,eposta) values (@adSoyad,@tc,@telefon,@adres,@eposta)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@adSoyad", textAdSoyad.Text);
            komut2.Parameters.AddWithValue("@tc", textTc.Text);
            komut2.Parameters.AddWithValue("@telefon", textTel.Text);
            komut2.Parameters.AddWithValue("@adres", textAdres.Text);
            komut2.Parameters.AddWithValue("@eposta", textEposta.Text);
            aracKirala.ekleSilGuncelle(komut2, text);
            foreach (Control items in Controls) if (items is TextBox)
                {
                    items.Text = "";
                } 
}
            else
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz!");
            }

        }

        private void formMusteriEkleme_Load(object sender, EventArgs e)
        {

        }

        private void textAdres_TextChanged(object sender, EventArgs e)
        {

        }

        private void textAdSoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
