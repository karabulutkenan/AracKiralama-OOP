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
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "Excel Dosyaları";
            save.DefaultExt = "xlsx";
            save.Filter = "xlsx Dosyaları (*.xlsx)|*.xlsx|Tüm Dosyalar(*.*)|*.*";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sayfa1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Excel Dışa Aktarım";
                for (int i = 1; i < bunifuDataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = bunifuDataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < bunifuDataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < bunifuDataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = bunifuDataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(save.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
            }
        }
    }
}
