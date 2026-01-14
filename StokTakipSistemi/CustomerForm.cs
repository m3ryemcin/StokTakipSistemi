using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StokTakipSistemi.BLL;
using StokTakipSistemi.DOMAIN;

namespace StokTakipSistemi
{
    public partial class CustomerForm : Form
    {
        CustomerBLL _customerBLL = new CustomerBLL();
        int secilenId = 0;
        public CustomerForm()
        {
            InitializeComponent();
        }
        private void MusterileriListele()
        {
            dgvCustomers.DataSource = _customerBLL.GetList();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                secilenId = Convert.ToInt32(row.Cells["Id"].Value);
                txtAdSoyad.Text = row.Cells["AdSoyad"].Value.ToString();
                txtTelefon.Text = row.Cells["Telefon"].Value.ToString();
                txtAdres.Text = row.Cells["Adres"].Value.ToString();
                cmbMusteriTuru.SelectedItem = row.Cells["MusteriTuru"].Value.ToString();
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            MusterileriListele();
            // ComboBox varsayılan seçim (opsiyonel)
            if (cmbMusteriTuru.Items.Count > 0) cmbMusteriTuru.SelectedIndex = 0;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Customer c = new Customer
                {
                    AdSoyad = txtAdSoyad.Text,
                    Telefon = txtTelefon.Text,
                    Adres = txtAdres.Text,
                    MusteriTuru = cmbMusteriTuru.SelectedItem?.ToString()
                };

                string sonuc = _customerBLL.AddCustomer(c);
                MessageBox.Show(sonuc);

                if (sonuc == "Başarılı")
                {
                    MusterileriListele();
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void Temizle()
        {
            txtAdSoyad.Clear();
            txtTelefon.Clear();
            txtAdres.Clear();
            secilenId = 0;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (secilenId > 0)
            {
                var onay = MessageBox.Show("Müşteriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);
                if (onay == DialogResult.Yes)
                {
                    string sonuc = _customerBLL.RemoveCustomer(secilenId);
                    MessageBox.Show(sonuc);
                    MusterileriListele();
                    Temizle();
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Customer c = new Customer
            {
                Id = secilenId,
                AdSoyad = txtAdSoyad.Text,
                Telefon = txtTelefon.Text,
                Adres = txtAdres.Text,
                MusteriTuru = cmbMusteriTuru.SelectedItem?.ToString()
            };

            string sonuc = _customerBLL.EditCustomer(c);
            MessageBox.Show(sonuc);
            if (sonuc == "Başarılı")
            {
                MusterileriListele();
                Temizle();
            }
        }
    }
}
