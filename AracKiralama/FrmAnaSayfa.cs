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
    public partial class FrmAnaSayfa : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-82T154B\SQLEXPRESS;Initial Catalog=AracKiralama;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader read;

        public void yenile(Label label, string text, SqlDataReader read)
        {
            baglanti.Open();
            komut = new SqlCommand(text, baglanti);
            read = komut.ExecuteReader();
            while (read.Read())
            {
                label.Text = Text = read[0].ToString();
            }
            baglanti.Close();
        }
        string musteriSayisi = "select count(*) From musteri";
        string aracSayisi = "select count(*) From araclar";
        string sozlesmeSayisi = "select count(*) From sozlesmeler";
        public FrmAnaSayfa()
        {



            InitializeComponent();
            
            //yenile(label3, musteriSayisi, read);
            //yenile(label2, aracSayisi, read);
            //yenile(label5, sozlesmeSayisi, read);
        }

        
    
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cikisButton_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Programdan Çıkmak İstediğinizden Emin Misiniz?", "Çıkış Mesajı!", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {

                Application.Exit();

            }
            else if (x == DialogResult.No)
            {

                x=DialogResult.Cancel;
            }
        }

        private void musteriEkleButton_Click(object sender, EventArgs e)
        {
            formMusteriEkleme frm = new formMusteriEkleme();
            frm.ShowDialog();
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {

        }

        private void musteriListeleButton_Click(object sender, EventArgs e)
        {
            formMusteriListeleme frm = new formMusteriListeleme();
            frm.ShowDialog();
        }

        private void aracKayitButon_Click(object sender, EventArgs e)
        {
            FrmAracKayit frm = new FrmAracKayit();
            frm.ShowDialog();
        }

        private void aracListeleButton_Click(object sender, EventArgs e)
        {
            FrmAracListele frm = new FrmAracListele();
            frm.ShowDialog();
        }

        private void sozlesmeButton_Click(object sender, EventArgs e)
        {
            FrmSozlesme frm = new FrmSozlesme();
            frm.ShowDialog();
        }

        private void satislarButton_Click(object sender, EventArgs e)
        {
            FrmSatis frm = new FrmSatis();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
            timer1.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            yenile(label3, musteriSayisi, read);
            yenile(label2, aracSayisi, read);
            yenile(label5, sozlesmeSayisi, read);
        }
    }
}
