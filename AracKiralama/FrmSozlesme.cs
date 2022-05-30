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
    public partial class FrmSozlesme : Form
    {
        public FrmSozlesme()
        {
            InitializeComponent();
        }
        AracKiralama aracSozlesme = new AracKiralama();
        
        private void FrmSozlesme_Load(object sender, EventArgs e)
        {
            BosAraclarGetir();
            YenileListele();
        }

        private void BosAraclarGetir()
        {
            string sorguSozlesme = "select * from araclar where durum='BOS' ";
            aracSozlesme.bosAraclar(comboBoxAraclar, sorguSozlesme);
        }

        private void YenileListele()
        {
            string sorguSozlesmeListe = "select * from sozlesmeler";
            SqlDataAdapter adtrSozlesme = new SqlDataAdapter();
            dataGridViewSozlesme.DataSource = aracSozlesme.listele(adtrSozlesme, sorguSozlesmeListe);

            dataGridViewSozlesme.RowHeadersVisible = false;
            dataGridViewSozlesme.Columns[0].HeaderText = "TC";
            dataGridViewSozlesme.Columns[1].HeaderText = "AdSoyad";
            dataGridViewSozlesme.Columns[2].Visible = false;
            dataGridViewSozlesme.Columns[3].Visible = false;
            dataGridViewSozlesme.Columns[4].Visible = false;
            dataGridViewSozlesme.Columns[5].Visible = false;
            dataGridViewSozlesme.Columns[6].HeaderText = "Plaka";
            dataGridViewSozlesme.Columns[7].Visible = false;
            dataGridViewSozlesme.Columns[8].Visible = false;
            dataGridViewSozlesme.Columns[9].Visible = false;
            dataGridViewSozlesme.Columns[10].Visible = false;
            dataGridViewSozlesme.Columns[11].HeaderText = "KiraTipi";
            dataGridViewSozlesme.Columns[12].Visible = false;
            dataGridViewSozlesme.Columns[13].HeaderText = "Süre";
            dataGridViewSozlesme.Columns[14].HeaderText = "Toplam";
            dataGridViewSozlesme.Columns[15].HeaderText = "Çıkış";
            dataGridViewSozlesme.Columns[16].HeaderText = "Dönüş";
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEkle_Click(object sender, EventArgs e)
        {
            if (textTc.Text != "" && textMarka.Text!="")
            {
                string text = "insert into sozlesmeler (tc,adSoyad,tel,ehliyetNo,ehliyetTarih,ehliyetYer,plaka,marka,seri,yil,renk,kiraTipi,kiraUcreti,kiraSure,tutar,cikisTarih,donusTarih) values (@tc,@adSoyad,@tel,@ehliyetNo,@ehliyetTarih,@ehliyetYer,@plaka,@marka,@seri,@yil,@renk,@kiraTipi,@kiraUcreti,@kiraSure,@tutar,@cikisTarih,@donusTarih)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@tc", textTc.Text);
                komut2.Parameters.AddWithValue("@adSoyad", textAdSoyad.Text);
                komut2.Parameters.AddWithValue("@tel", textTel.Text);
                komut2.Parameters.AddWithValue("@ehliyetNo", textEhlNo.Text);
                komut2.Parameters.AddWithValue("@ehliyetTarih", textEhlVerTarih.Text);
                komut2.Parameters.AddWithValue("@ehliyetYer", textEhlVeryer.Text);
                komut2.Parameters.AddWithValue("@plaka", comboBoxAraclar.Text);
                komut2.Parameters.AddWithValue("@marka", textMarka.Text);
                komut2.Parameters.AddWithValue("@seri", textModel.Text);
                komut2.Parameters.AddWithValue("@yil", textYil.Text);
                komut2.Parameters.AddWithValue("@renk", textRenk.Text);
                komut2.Parameters.AddWithValue("@kiraTipi", comboBoxKiraTipi.Text);
                komut2.Parameters.AddWithValue("@kiraUcreti", int.Parse(textKiraUcreti.Text));
                komut2.Parameters.AddWithValue("@kiraSure", int.Parse(textGun.Text));
                komut2.Parameters.AddWithValue("@tutar", int.Parse(textTutar.Text));
                komut2.Parameters.AddWithValue("@cikisTarih", tarihBasla.Text);
                komut2.Parameters.AddWithValue("@donusTarih", tarihBitis.Text);
                aracSozlesme.ekleSilGuncelle(komut2, text);
                string sorguDurum = "update araclar set durum='DOLU' where plaka='" + comboBoxAraclar.Text + "' ";
                SqlCommand komut10 = new SqlCommand();
                aracSozlesme.ekleSilGuncelle(komut10, sorguDurum);
                comboBoxAraclar.Items.Clear();
                YenileListele();
                Temizle();
                BosAraclarGetir();
            }
            else
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz!");
            }
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorguPlaka = "select * from araclar where plaka like'" + comboBoxAraclar.Text + "'";
            aracSozlesme.aracComboListeleme(comboBoxAraclar, textMarka, textModel, textYil,textRenk,sorguPlaka);
        }

        private void textTc_TextChanged(object sender, EventArgs e)
        {
            if (textTc.Text== "")
            {
                foreach (Control item in groupBox1.Controls) if (item is TextBox)
                    {
                        item.Text = "";
                    }
                {

                }
            }
            string sorguTc = "select * from musteri where tc like'"+textTc.Text+"'";
            aracSozlesme.kontrolTc(textAdSoyad,textTc,textTel,sorguTc);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void comboBoxKiraTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                string sorguKira = "select * from araclar where plaka like'" + comboBoxAraclar.Text + "'";
                aracSozlesme.aracUcretListeleme(comboBoxAraclar, textKiraUcreti, sorguKira);
                if (comboBoxKiraTipi.SelectedIndex is 1)
                {
                    string ucret = (Convert.ToInt32(textKiraUcreti.Text) * 0.8).ToString();
                    textKiraUcreti.Text = ucret;
                    
                }
                else if (comboBoxKiraTipi.SelectedIndex is 2)
                {
                    string ucret = (Convert.ToInt32(textKiraUcreti.Text) * 0.70).ToString();
                    textKiraUcreti.Text = ucret;
                    
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Araç Seçiniz");
            }
            

            
        }

        private string ToString(int ucret)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan gun = DateTime.Parse(tarihBitis.Text) - DateTime.Parse(tarihBasla.Text);
                string gun2 = gun.Days.ToString();
                textGun.Text = gun2;
                string tutar = (Convert.ToInt32(textKiraUcreti.Text) * Convert.ToInt32(textGun.Text)).ToString();
                textTutar.Text = tutar;
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Kira Tipi Belirleyiniz");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox) item.Text = "";
                if (item is ComboBox) item.Text = "";

            }
            tarihBasla.Text=DateTime.Now.ToShortDateString();    
            tarihBitis.Text=DateTime.Now.ToShortDateString();    

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox) item.Text = "";
                

            }
        }

        private void dataGridViewSozlesme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridViewSozlesme.CurrentRow;
            textTc.Text = satır.Cells[0].Value.ToString();
            textAdSoyad.Text = satır.Cells[1].Value.ToString();
            textTel.Text = satır.Cells[2].Value.ToString();
            textEhlNo.Text = satır.Cells[3].Value.ToString();
            textEhlVerTarih.Text = satır.Cells[4].Value.ToString();
            textEhlVeryer.Text = satır.Cells[5].Value.ToString();
            comboBoxAraclar.Text = satır.Cells[6].Value.ToString();
            textMarka.Text = satır.Cells[7].Value.ToString();
            textModel.Text = satır.Cells[8].Value.ToString();
            textYil.Text = satır.Cells[9].Value.ToString();
            textRenk.Text = satır.Cells[10].Value.ToString();
            comboBoxKiraTipi.Text = satır.Cells[11].Value.ToString();
            textKiraUcreti.Text = satır.Cells[12].Value.ToString();
            textGun.Text = satır.Cells[13].Value.ToString();
            textTutar.Text = satır.Cells[14].Value.ToString();
            tarihBasla.Text = satır.Cells[15].Value.ToString();
            tarihBitis.Text = satır.Cells[16].Value.ToString();
        }

        private void buttonGuncelle_Click(object sender, EventArgs e)
        {
            string txt = "update sozlesmeler set tc=@tc, adSoyad=@adSoyad,tel=@tel,ehliyetNo=@ehliyetNo,ehliyetTarih=@ehliyetTarih, ehliyetYer=@ehliyetYer, marka=@marka, seri=@seri, yil=@yil, renk=@renk, kiraTipi=@kiraTipi, kiraUcreti=@kiraUcreti, kiraSure=@kiraSure, tutar=@tutar, cikisTarih=@cikisTarih, donusTarih=@donusTarih where plaka=@plaka";
            SqlCommand komutGuncel = new SqlCommand();
            komutGuncel.Parameters.AddWithValue("@tc", textTc.Text);
            komutGuncel.Parameters.AddWithValue("@adSoyad", textAdSoyad.Text);
            komutGuncel.Parameters.AddWithValue("@tel", textTel.Text);
            komutGuncel.Parameters.AddWithValue("@ehliyetNo", textEhlNo.Text);
            komutGuncel.Parameters.AddWithValue("@ehliyetTarih", textEhlVerTarih.Text);
            komutGuncel.Parameters.AddWithValue("@ehliyetYer", textEhlVeryer.Text);
            komutGuncel.Parameters.AddWithValue("@plaka", comboBoxAraclar.Text);
            komutGuncel.Parameters.AddWithValue("@marka", textMarka.Text);
            komutGuncel.Parameters.AddWithValue("@seri", textModel.Text);
            komutGuncel.Parameters.AddWithValue("@yil", textYil.Text);
            komutGuncel.Parameters.AddWithValue("@renk", textRenk.Text);
            komutGuncel.Parameters.AddWithValue("@kiraTipi", comboBoxKiraTipi.Text);
            komutGuncel.Parameters.AddWithValue("@kiraUcreti", int.Parse(textKiraUcreti.Text));
            komutGuncel.Parameters.AddWithValue("@kiraSure", int.Parse(textGun.Text));
            komutGuncel.Parameters.AddWithValue("@tutar", int.Parse(textTutar.Text));
            komutGuncel.Parameters.AddWithValue("@cikisTarih", tarihBasla.Text);
            komutGuncel.Parameters.AddWithValue("@donusTarih", tarihBitis.Text);
            aracSozlesme.ekleSilGuncelle(komutGuncel, txt);
            YenileListele();
            Temizle();
            BosAraclarGetir();
        }

        private void Temizle()
        {
            foreach (Control items in groupBox1.Controls) if (items is TextBox)
                {
                    items.Text = "";

                }
            foreach (Control items in groupBox1.Controls) if (items is ComboBox)
                {
                    items.Text = "";
                }
            foreach (Control items in groupBox2.Controls) if (items is TextBox)
                {
                    items.Text = "";
                }
            foreach (Control items in groupBox2.Controls) if (items is ComboBox)
                {
                    items.Text = "";
                }
            tarihBasla.Text = DateTime.Now.ToShortDateString();
            tarihBitis.Text = DateTime.Now.ToShortDateString();
        }

        private void dataGridViewSozlesme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridViewSozlesme.CurrentRow;
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime teslim = DateTime.Parse(satir.Cells["donusTarih"].Value.ToString());
            int ucret = int.Parse(satir.Cells["kiraUcreti"].Value.ToString());
            TimeSpan gunFarki = bugun - teslim;
            int gunFarkiSon = gunFarki.Days;
            int ucretFarki = gunFarkiSon * ucret;
            textUcretFarki.Text= ucretFarki.ToString();



        }

        private void buttonTeslim_Click(object sender, EventArgs e)
        {
            if (textUcretFarki.Text!="" )
            {
                DataGridViewRow satir = dataGridViewSozlesme.CurrentRow;
                DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
                int ucret = int.Parse(satir.Cells["kiraUcreti"].Value.ToString());
                int tutar = int.Parse(satir.Cells["tutar"].Value.ToString());
                int fark = int.Parse(textUcretFarki.Text);
                DateTime alis = DateTime.Parse(satir.Cells["cikisTarih"].Value.ToString());
                TimeSpan gun = bugun - alis;
                int gunSon = gun.Days;
                int toplamTutar = tutar+fark;
                
                string sorguTeslim1 = "delete from sozlesmeler where plaka='" + satir.Cells["plaka"].Value.ToString() + "' ";
                SqlCommand komutTeslim1 = new SqlCommand();
                aracSozlesme.ekleSilGuncelle(komutTeslim1,sorguTeslim1);
                
                string sorguTeslim2 = "update araclar set durum='BOS' where plaka='" + satir.Cells["plaka"].Value.ToString() + "' ";
                SqlCommand komutTeslim2 = new SqlCommand();
                aracSozlesme.ekleSilGuncelle(komutTeslim2, sorguTeslim2);

                
                string sorguTeslim3 = "insert into satislar (tc,adSoyad,plaka,marka,seri,yil,renk,sure,fiyat,tutar,ilkTarih,sonTarih) values (@tc,@adSoyad,@plaka,@marka,@seri,@yil,@renk,@sure,@fiyat,@tutar,@ilkTarih,@sonTarih)";
                SqlCommand komutTeslim3 = new SqlCommand();
                komutTeslim3.Parameters.AddWithValue("@tc", satir.Cells["tc"].Value.ToString());
                komutTeslim3.Parameters.AddWithValue("@adSoyad", satir.Cells["adSoyad"].Value.ToString());
                komutTeslim3.Parameters.AddWithValue("@plaka", satir.Cells["plaka"].Value.ToString());
                komutTeslim3.Parameters.AddWithValue("@marka", satir.Cells["marka"].Value.ToString());
                komutTeslim3.Parameters.AddWithValue("@seri", satir.Cells["seri"].Value.ToString());
                komutTeslim3.Parameters.AddWithValue("@yil", satir.Cells["yil"].Value.ToString());
                komutTeslim3.Parameters.AddWithValue("@renk", satir.Cells["renk"].Value.ToString());
                komutTeslim3.Parameters.AddWithValue("@sure", gunSon);
                komutTeslim3.Parameters.AddWithValue("@fiyat", satir.Cells["kiraUcreti"].Value.ToString());
                komutTeslim3.Parameters.AddWithValue("@tutar", toplamTutar);
                komutTeslim3.Parameters.AddWithValue("@ilkTarih", satir.Cells["cikisTarih"].Value.ToString());
                komutTeslim3.Parameters.AddWithValue("@sonTarih", DateTime.Now.ToShortDateString());
                aracSozlesme.ekleSilGuncelle(komutTeslim3, sorguTeslim3);

                comboBoxAraclar.Text = "";
                YenileListele();
                Temizle();
                BosAraclarGetir();
                textUcretFarki.Text = "";

            }
            
            else
            {
                MessageBox.Show("Lütfen Listeden Seçim Yapınız");
            }
            

        }
    }
}
