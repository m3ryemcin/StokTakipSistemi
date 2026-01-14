using StokTakipSistemi.BLL;
using StokTakipSistemi.DOMAIN;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace StokTakipSistemi
{
    public partial class ProductForm : Form
    {
        // Senin BLL sınıfın
        ProductBLL _productBLL = new ProductBLL();
        int secilenId = 0;

        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            UrunleriListele();
        }

        // 1. LİSTELEME VE RENKLENDİRME
        private void UrunleriListele()
        {
            // Panel içindeki dataGridView1'i tazeliyoruz
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = _productBLL.GetAll();
            Renklendir();
        }

        private void Renklendir()
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.Cells["StokAdedi"].Value != null)
                {
                    int stok = Convert.ToInt32(row.Cells["StokAdedi"].Value);
                    if (stok < 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        // 2. KAYDET (EKLE) BUTONU
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Product yeniUrun = new Product
                {
                    UrunAdi = txtUrunAdi.Text,
                    StokAdedi = int.TryParse(txtStok.Text, out int s) ? s : 0,
                    Fiyat = decimal.TryParse(txtFiyat.Text, out decimal f) ? f : 0
                };

                string mesaj = _productBLL.AddProduct(yeniUrun);
                MessageBox.Show(mesaj);

                UrunleriListele();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // 3. GÜNCELLE BUTONU
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (secilenId == 0)
            {
                MessageBox.Show("Lütfen listeden bir ürün seçin!");
                return;
            }

            try
            {
                Product guncelUrun = new Product
                {
                    Id = secilenId,
                    UrunAdi = txtUrunAdi.Text,
                    StokAdedi = int.TryParse(txtStok.Text, out int s) ? s : 0,
                    Fiyat = decimal.TryParse(txtFiyat.Text, out decimal f) ? f : 0
                };

                string sonuc = _productBLL.EditProduct(guncelUrun);
                MessageBox.Show(sonuc);

                UrunleriListele();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme Hatası: " + ex.Message);
            }
        }

        // 4. SİL BUTONU
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenId == 0)
            {
                MessageBox.Show("Lütfen silinecek ürünü seçin!");
                return;
            }

            var onay = MessageBox.Show("Silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (onay == DialogResult.Yes)
            {
                string sonuc = _productBLL.RemoveProduct(secilenId);
                MessageBox.Show(sonuc);
                UrunleriListele();
                Temizle();
            }
        }

        // 5. GRID'DEN VERİ SEÇME (dataGridView1 için)
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Hücre isimleri DOMAIN modelindeki isimlerle aynı olmalı
                secilenId = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["Id"].Value);
                txtUrunAdi.Text = dgvProducts.Rows[e.RowIndex].Cells["UrunAdi"].Value.ToString();
                txtStok.Text = dgvProducts.Rows[e.RowIndex].Cells["StokAdedi"].Value.ToString();
                txtFiyat.Text = dgvProducts.Rows[e.RowIndex].Cells["Fiyat"].Value.ToString();
            }
        }

        private void Temizle()
        {
            txtUrunAdi.Clear();
            txtStok.Clear();
            txtFiyat.Clear();
            secilenId = 0;
            txtUrunAdi.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (dgvProducts.Columns[e.ColumnIndex].Name == "StokAdedi" && e.Value != null)
            {
                
                if (int.TryParse(e.Value.ToString(), out int stok))
                {
                    if (stok <= 10) 
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else if (stok < 10)
                    {
                        e.CellStyle.BackColor = Color.Yellow;
                        e.CellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }
    }
}