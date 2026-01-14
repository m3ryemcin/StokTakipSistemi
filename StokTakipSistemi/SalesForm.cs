using StokTakipSistemi.BLL;
using StokTakipSistemi.DOMAIN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace StokTakipSistemi
{
    public partial class SalesForm : Form
    {
        ProductBLL _productBLL = new ProductBLL();
        CustomerBLL _customerBLL = new CustomerBLL();
        SaleBLL _saleBLL = new SaleBLL();
        User _activeUser;

        public SalesForm(User user)
        {
            InitializeComponent();
            _activeUser = user;

            
            this.Activated += (s, e) => VerileriYukle();
        }

        private void VerileriYukle()
        {
            try
            {
                
                string eskiUrunText = cmbProduct.Text;
                string eskiMusteriText = cmbCustomer.Text;

                
                var urunListesi = _productBLL.GetAll();
                cmbProduct.DataSource = null;
                cmbProduct.DataSource = urunListesi;
                cmbProduct.DisplayMember = "UrunAdi";
                cmbProduct.ValueMember = "Id";

               
                cmbProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbProduct.AutoCompleteSource = AutoCompleteSource.ListItems;

                
                var musteriListesi = _customerBLL.GetList();
                cmbCustomer.DataSource = null;
                cmbCustomer.DataSource = musteriListesi;
                cmbCustomer.DisplayMember = "AdSoyad";
                cmbCustomer.ValueMember = "Id";

                
                cmbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;

               
                cmbProduct.Text = eskiUrunText;
                cmbCustomer.Text = eskiMusteriText;

               
                if (string.IsNullOrEmpty(eskiUrunText)) cmbProduct.SelectedIndex = -1;
                if (string.IsNullOrEmpty(eskiMusteriText)) cmbCustomer.SelectedIndex = -1;

                
                // cmbProduct.SelectionStart = cmbProduct.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken hata: " + ex.Message);
            }
        }



        private void btnSell_Click(object sender, EventArgs e)
        {
            try
            {
                string yazilanUrun = cmbProduct.Text.Trim();
                string yazilanMusteri = cmbCustomer.Text.Trim();

                if (string.IsNullOrEmpty(yazilanUrun) || string.IsNullOrEmpty(yazilanMusteri))
                {
                    MessageBox.Show("Ürün ve Müşteri alanları boş bırakılamaz!");
                    return;
                }

                
                Product secilenUrun = cmbProduct.Items.Cast<Product>()
                    .FirstOrDefault(p => p.UrunAdi.Trim().Equals(yazilanUrun, StringComparison.OrdinalIgnoreCase));

                if (secilenUrun == null)
                {
                    DialogResult dr = MessageBox.Show($"'{yazilanUrun}' sistemde yok. Yeni ürün olarak eklensin mi?", "Yeni Ürün", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        // Referans eklediğin için Interaction artık sorunsuz çalışır
                        string girilenFiyat = Microsoft.VisualBasic.Interaction.InputBox("Lütfen yeni ürünün fiyatını giriniz:", "Ürün Fiyatı", "0");
                        decimal yeniFiyat = decimal.TryParse(girilenFiyat, out decimal f) ? f : 0;

                        Product yeniP = new Product { UrunAdi = yazilanUrun, Fiyat = yeniFiyat, StokAdedi = 100 };

                        string bllSonuc = _productBLL.AddProduct(yeniP);
                        if (bllSonuc == "Başarılı")
                        {
                            VerileriYukle();
                            
                            secilenUrun = _productBLL.GetAll().FirstOrDefault(x => x.UrunAdi.Trim().Equals(yazilanUrun, StringComparison.OrdinalIgnoreCase));
                        }
                    }
                    else return;
                }

                
                Customer secilenMusteri = cmbCustomer.Items.Cast<Customer>()
                    .FirstOrDefault(c => c.AdSoyad.Trim().Equals(yazilanMusteri, StringComparison.OrdinalIgnoreCase));

                if (secilenMusteri == null)
                {
                    DialogResult dr = MessageBox.Show($"'{yazilanMusteri}' sistemde yok. Yeni müşteri olarak eklensin mi?", "Yeni Müşteri", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Customer yeniC = new Customer { AdSoyad = yazilanMusteri, MusteriTuru = "Perakende" };
                        _customerBLL.AddCustomer(yeniC);
                        VerileriYukle();
                        
                        secilenMusteri = _customerBLL.GetList().FirstOrDefault(x => x.AdSoyad.Trim().Equals(yazilanMusteri, StringComparison.OrdinalIgnoreCase));
                    }
                    else return;
                }

               
                if (secilenUrun == null || secilenMusteri == null)
                {
                    MessageBox.Show("Eşleşme sağlanamadı. Lütfen tekrar 'SATIŞ YAP' butonuna basın.");
                    return;
                }

               
                if (!int.TryParse(txtQuantity.Text, out int adet) || adet <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir adet giriniz!");
                    return;
                }

                Sale yeniSatis = new Sale
                {
                    ProductId = secilenUrun.Id,
                    CustomerId = secilenMusteri.Id,
                    UserId = _activeUser.Id,
                    Adet = adet,
                    ToplamFiyat = secilenUrun.Fiyat * adet
                };

                string sonuc = _saleBLL.ProcessSale(yeniSatis);
                MessageBox.Show(sonuc);

                if (sonuc == "Satış Başarılı")
                {
                    
                    txtQuantity.Clear();

                   
                    cmbProduct.SelectedIndex = -1;
                    cmbCustomer.SelectedIndex = -1;

                    
                    cmbProduct.Text = "";
                    cmbCustomer.Text = "";

                    
                    lblPrice.Text = "Toplam Fiyat: 0 TL";

                    
                    VerileriYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        
        private void FiyatHesapla()
        {
            if (int.TryParse(txtQuantity.Text, out int adet) && cmbProduct.SelectedItem is Product p)
            {
                
                lblPrice.Text = $"Toplam Fiyat: {p.Fiyat * adet:N2} TL";
            }
            else
            {
               
                lblPrice.Text = "Toplam Fiyat: 0.00 TL";
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e) => FiyatHesapla();
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e) => FiyatHesapla();
        private void SalesForm_Load(object sender, EventArgs e)
        {
            VerileriYukle();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}