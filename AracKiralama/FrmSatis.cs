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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace AracKiralama
{
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }
        AracKiralama aracSatis = new AracKiralama();
        private void FrmSatis_Load(object sender, EventArgs e)
        {
            string sorguSatis = "select * from satislar";
            SqlDataAdapter adtrSatis = new SqlDataAdapter();
            bunifuDataGridView1.DataSource = aracSatis.listele(adtrSatis, sorguSatis);
            bunifuDataGridView1.RowHeadersVisible = false;
            bunifuDataGridView1.Columns[0].HeaderText = "TC";
            bunifuDataGridView1.Columns[1].HeaderText = "AdSoyad";
            bunifuDataGridView1.Columns[2].HeaderText = "Plaka";
            bunifuDataGridView1.Columns[3].Visible = false;
            bunifuDataGridView1.Columns[4].Visible = false;
            bunifuDataGridView1.Columns[5].Visible = false;
            bunifuDataGridView1.Columns[6].Visible = false;
            
            bunifuDataGridView1.Columns[7].HeaderText = "Süre";
            bunifuDataGridView1.Columns[8].Visible = false;
            bunifuDataGridView1.Columns[9].HeaderText = "Toplam";
            bunifuDataGridView1.Columns[10].HeaderText = "Çıkış";
            bunifuDataGridView1.Columns[11].HeaderText = "Dönüş";
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
