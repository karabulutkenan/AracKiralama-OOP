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
    public partial class FrmAracKayit : Form
    {   AracKiralama arackiralama = new AracKiralama(); 
        public FrmAracKayit()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxModel.Items.Clear();
                if (comboBoxMarka.SelectedIndex==0)
                {
                    comboBoxModel.Items.Add("Clio");
                    comboBoxModel.Items.Add("Megane");
                    comboBoxModel.Items.Add("Fluence");
                    comboBoxModel.Items.Add("Kadjar");

                }
                if (comboBoxMarka.SelectedIndex == 1)
                {
                    comboBoxModel.Items.Add("2008");
                    comboBoxModel.Items.Add("3008");
                    comboBoxModel.Items.Add("5008");
                    comboBoxModel.Items.Add("508");
                }
                if (comboBoxMarka.SelectedIndex == 2)
                {
                    comboBoxModel.Items.Add("Passat");
                    comboBoxModel.Items.Add("Golf");
                    comboBoxModel.Items.Add("Polo");
                    comboBoxModel.Items.Add("Tiguan");
                }
                if (comboBoxMarka.SelectedIndex == 3)
                {
                    comboBoxModel.Items.Add("CLA 180D");
                    comboBoxModel.Items.Add("C 200");
                    comboBoxModel.Items.Add("GLA 180");
                    comboBoxModel.Items.Add("S500");
                }
            }
            catch 
            {

                ;
            }
        }

        private void buttonAracEkle_Click(object sender, EventArgs e)
        {
            if (textPlaka.Text != "")
            {
                string text = "insert into araclar (plaka,marka,seri,yil,renk,km,yakitTipi,kiraUcreti,resim,tarih,durum) values (@plaka,@marka,@seri,@yil,@renk,@km,@yakitTipi,@kiraUcreti,@resim,@tarih,@durum)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@plaka", textPlaka.Text);
                komut2.Parameters.AddWithValue("@marka", comboBoxMarka.Text);
                komut2.Parameters.AddWithValue("@seri", comboBoxModel.Text);
                komut2.Parameters.AddWithValue("@yil", textYil.Text);
                komut2.Parameters.AddWithValue("@renk", textRenk.Text);
                komut2.Parameters.AddWithValue("@km", int.Parse(textKm.Text)); 
                komut2.Parameters.AddWithValue("@yakitTipi", comboBoxYakit.Text);
                komut2.Parameters.AddWithValue("@kiraUcreti", int.Parse(textUcret.Text));
                komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
                komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut2.Parameters.AddWithValue("@durum", "BOS");
                arackiralama.ekleSilGuncelle(komut2,text);
                comboBoxModel.Items.Clear();
                foreach (Control item in bunifuGradientPanel1.Controls) if (item is TextBox) item.Text = "";
                foreach (Control item in bunifuGradientPanel1.Controls) if (item is ComboBox) item.Text ="";
            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz!");
            }
        }
    }
}
