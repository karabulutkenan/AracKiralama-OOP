using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralama
{
    public partial class FormŞifre : Form
    {
        public FormŞifre()
        {
            InitializeComponent();
        }
        Kullanici k = new Kullanici();
        private void sifreGuncelleButton_Click(object sender, EventArgs e)
        {
            
            k.Sifre(textKullaniciSifre, textSoruSifre, textCevapSifre, textSifreSifre, textTekrarSifre,groupBoxSifre);
        }

        private void FormŞifre_Load(object sender, EventArgs e)
        {
            
        }

        private void textKullaniciSifre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
