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
    public partial class FormYeniKayit : Form
    {
        public FormYeniKayit()
        {
            InitializeComponent();
        }
        Kullanici k = new Kullanici();
        private void kayitButton_Click(object sender, EventArgs e)
        {
           
          k.YeniKullanici(textAdSoyadKayit, textKullaniciKayit, textSifreKayit, textSifreTekrar, textSoru, textCevap, groupBoxKayit);
            
        }

        private void FormYeniKayit_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textSoru_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCevap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
