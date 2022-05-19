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
    public partial class formMusteriListeleme : Form
    {
        AracKiralama aracKirala = new AracKiralama();
        public formMusteriListeleme()
        {
            InitializeComponent();
        }

        private void formMusteriListeleme_Load(object sender, EventArgs e)
        {
            YenileListele();
        }

        private void YenileListele()
        {
            string txt = "select *from musteri";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = aracKirala.listele(adtr2, txt);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].HeaderText = "Ad Soyad";
            dataGridView1.Columns[1].HeaderText = "Tc Kimlik";
            dataGridView1.Columns[2].HeaderText = "Telefon";
            dataGridView1.Columns[3].HeaderText = "Adres";
            dataGridView1.Columns[4].HeaderText = "E-Posta";
            dataGridView1.Columns[5].Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string txt = "select *from musteri where tc like '%"+textBox1.Text+"%'";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = aracKirala.listele(adtr2, txt);
        }

        private void iptalButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void guncelleButton_Click(object sender, EventArgs e)
        {
            string txt = "update musteri set adSoyad=@adSoyad,telefon=@telefon,adres=@adres,eposta=@eposta where tc=@tc";
            SqlCommand komut3 = new SqlCommand();
            komut3.Parameters.AddWithValue("@adSoyad", textAdSoyad.Text);
            komut3.Parameters.AddWithValue("@tc", textTc.Text);
            komut3.Parameters.AddWithValue("@telefon", textTel.Text);
            komut3.Parameters.AddWithValue("@adres", textAdres.Text);
            komut3.Parameters.AddWithValue("@eposta", textEposta.Text);
            aracKirala.ekleSilGuncelle(komut3, txt);
            foreach (Control items in bunifuGradientPanel1.Controls) if (items is TextBox)
                {
                    items.Text = "";
                }
            YenileListele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            textTc.Text = satır.Cells[1].Value.ToString();
            textAdSoyad.Text = satır.Cells[0].Value.ToString();
            textTel.Text = satır.Cells[2].Value.ToString();
            textAdres.Text = satır.Cells[3].Value.ToString();
            textEposta.Text = satır.Cells[4].Value.ToString();
        }

        private void silButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            string txtSil ="delete from musteri where tc='"+satir.Cells["tc"].Value.ToString()+"'";
            SqlCommand komut3 = new SqlCommand();
            aracKirala.ekleSilGuncelle(komut3, txtSil);
            foreach (Control items in bunifuGradientPanel1.Controls) if (items is TextBox)
                {
                    items.Text = "";
                }
            YenileListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
