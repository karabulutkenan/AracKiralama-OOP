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
    public partial class FrmAracListele : Form
    {
        public FrmAracListele()
        {
            InitializeComponent();
            YenileListele();
        }
        AracKiralama aracKirala = new AracKiralama();   
        private void YenileListele()
        {
            string txt = "select *from araclar";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            DataGridViewListe.DataSource = aracKirala.listele(adtr2, txt);
            DataGridViewListe.RowHeadersVisible = false;
            DataGridViewListe.Columns[0].HeaderText = "Plaka";
            DataGridViewListe.Columns[1].HeaderText = "Marka";
            DataGridViewListe.Columns[2].HeaderText = "Model";
            DataGridViewListe.Columns[3].HeaderText = "Yıl";
            DataGridViewListe.Columns[4].HeaderText = "Renk";
            DataGridViewListe.Columns[5].HeaderText = "Km";
            DataGridViewListe.Columns[6].Visible = false;   
            DataGridViewListe.Columns[7].Visible = false;
            DataGridViewListe.Columns[8].Visible = false;
            DataGridViewListe.Columns[9].Visible = false;
            DataGridViewListe.Columns[10].HeaderText = "Durum";
        }
        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DataGridViewListe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = DataGridViewListe.CurrentRow;
            comboPlakaListe.Text = satır.Cells[0].Value.ToString();
            comboBoxMarkaListe.Text = satır.Cells[1].Value.ToString();
            comboBoxModelListe.Text = satır.Cells[2].Value.ToString();
            textYilListe.Text = satır.Cells[3].Value.ToString();
            textRenkListe.Text = satır.Cells[4].Value.ToString();
            textKmListe.Text = satır.Cells[5].Value.ToString();
            comboBoxYakitListe.Text = satır.Cells[6].Value.ToString();
            textUcretListe.Text = satır.Cells[7].Value.ToString();
            pictureBoxListe.ImageLocation=satır.Cells["resim"].Value.ToString();
        }

        private void buttonAracListe_Click(object sender, EventArgs e)
        {
            string text = "update araclar set marka=@marka, seri=@seri, yil=@yil, renk=@renk, km=@km, yakitTipi=@yakitTipi, kiraUcreti=@kiraUcreti,resim=@resim, tarih=@tarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", comboPlakaListe.Text);
            komut2.Parameters.AddWithValue("@marka", comboBoxMarkaListe.Text);
            komut2.Parameters.AddWithValue("@seri", comboBoxModelListe.Text);
            komut2.Parameters.AddWithValue("@yil", textYilListe.Text);
            komut2.Parameters.AddWithValue("@renk", textRenkListe.Text);
            komut2.Parameters.AddWithValue("@km", int.Parse(textKmListe.Text));
            komut2.Parameters.AddWithValue("@yakitTipi", comboBoxYakitListe.Text);
            komut2.Parameters.AddWithValue("@kiraUcreti", int.Parse(textUcretListe.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBoxListe.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            komut2.Parameters.AddWithValue("@durum", "BOŞ");
            aracKirala.ekleSilGuncelle(komut2, text);
            comboBoxModelListe.Items.Clear();
            foreach (Control item in GradientPanelListe.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in GradientPanelListe.Controls) if (item is ComboBox) item.Text = "";
            pictureBoxListe.ImageLocation = "";
            YenileListele();
        }

        private void buttonResimGuncelleListe_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBoxListe.ImageLocation = openFileDialog1.FileName;
        }

        private void buttonSilListe_Click(object sender, EventArgs e)
        {
            DataGridViewRow satir = DataGridViewListe.CurrentRow;
            string txtSil = "delete from araclar where plaka='" + satir.Cells["plaka"].Value.ToString() + "'";
            SqlCommand komut3 = new SqlCommand();
            aracKirala.ekleSilGuncelle(komut3, txtSil);
            foreach (Control item in GradientPanelListe.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in GradientPanelListe.Controls) if (item is ComboBox) item.Text = "";
            YenileListele();
        }

        private void comboBoxAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
