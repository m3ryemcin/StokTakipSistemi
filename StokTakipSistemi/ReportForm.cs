using StokTakipSistemi.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StokTakipSistemi
{
    public partial class ReportForm : Form
    {
        ProductBLL _productBLL = new ProductBLL();
        SaleBLL _saleBLL = new SaleBLL();
        CustomerBLL _customerBLL = new CustomerBLL();

        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new string[] { "Tüm Ürünler", "Klavyeler", "Mouselar", "Laptoplar" });
            cmbCategory.SelectedIndex = 0;
            RaporuGoster();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            RaporuGoster();
        }

        private void RaporuGoster()
        {
            try
            {
                DateTime bas = dtpStart.Value;
                DateTime bit = dtpEnd.Value;
                string kat = cmbCategory.Text;

                
                DataTable dt = _saleBLL.GetSalesReport(bas, bit, kat);
                dgvReportList.DataSource = dt;

                
                decimal toplamTutar = 0;
                int toplamAdet = 0;

                foreach (DataRow row in dt.Rows)
                {
                    toplamTutar += Convert.ToDecimal(row["Tutar"]);
                    toplamAdet += Convert.ToInt32(row["Adet"]);
                }
                lblKar.Text = toplamTutar.ToString("C2"); // "Kar/Zarar" başlığı silinmez
                lblAdet.Text = toplamAdet.ToString(); // "Satış Adedi" başlığı silinmez
                lblMüşteri.Text = _customerBLL.GetList().Count.ToString(); // "Müşteri Sayısı"
                lblStok.Text = _productBLL.GetAll().Count(x => x.StokAdedi < 10).ToString(); // "Kritik Stok"


                GrafigiGuncelle(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor hatası: " + ex.Message);
            }
        }

        private void GrafigiGuncelle(DataTable dt)
        {
            chartTopProducts.Series.Clear();
            Series seri = new Series("Satışlar");
            seri.ChartType = SeriesChartType.Column;

            var grafikVerisi = dt.AsEnumerable()
                .GroupBy(r => r.Field<string>("Ürün"))
                .Select(g => new { UrunAdi = g.Key, Adet = g.Sum(x => x.Field<int>("Adet")) })
                .OrderByDescending(x => x.Adet).Take(5);

            foreach (var item in grafikVerisi)
            {
                seri.Points.AddXY(item.UrunAdi, item.Adet);
            }

            chartTopProducts.Series.Add(seri);
        }

        private void pnlTotalProfit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShowReport_Click_1(object sender, EventArgs e)
        {
            RaporuGoster();
        }
    }
}