using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AracKiralama
{
    public partial class FormKullanici : Form
    {
        public FormKullanici()
        {
            InitializeComponent();
        }
        Kullanici k = new Kullanici();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textCevap_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormŞifre frm = new FormŞifre();
            frm.ShowDialog();
        }

        private void girisButton_Click(object sender, EventArgs e)
        {
            k.KullaniciRead(textKullaniciGiris, textSifreGiris,this);
        }

        private void kayitButton_Click(object sender, EventArgs e)
        {
           
        }

        private void FormKullanici_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormYeniKayit frm = new FormYeniKayit();
            frm.ShowDialog();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            k.KullaniciRead(textKullaniciGiris, textSifreGiris, this);
        }

        private void textKullaniciGiris_TextChanged(object sender, EventArgs e)
        {

        }

        private void textKullaniciGiris_MouseClick(object sender, MouseEventArgs e)
        {
        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textSifreGiris_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
