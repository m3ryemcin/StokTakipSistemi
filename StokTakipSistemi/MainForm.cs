using StokTakipSistemi.DOMAIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakipSistemi
{
    
    public partial class MainForm : Form

    {
        ProductForm urunForm;
        CustomerForm musterForm;
        SalesForm satisForm;
        ReportForm raporForm;
        private User _loginUser;
        public MainForm(User user)
        {
            InitializeComponent();
            _loginUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Form açıldığında kimin geldiğini başlığa yazalım
            this.Text = "Stok Takip | Hoş Geldiniz: " + _loginUser.Username;

            // ROL KONTROLÜ: Görseldeki kurallara göre kısıtlama yapıyoruz
            if (_loginUser.RoleId == 2) // Satış Personeli ise
            {
                btnRaporlar.Visible = false; // Raporları göremez
            }
            else if (_loginUser.RoleId == 3) // Depo Görevlisi ise
            {
                btnRaporlar.Visible = false;
                btnSatis.Visible = false;
                btnMusteriler.Visible = false;
            }
        }
        private void FormuGetir(Form altForm)
        
        {
            pnlContent.Controls.Clear();
            altForm.TopLevel = false;
            altForm.FormBorderStyle = FormBorderStyle.None;

            // Panel içindeki nesnelerle çakışmaması için önce Dock'u kapatıp sonra açalım
            altForm.Dock = DockStyle.None;
            altForm.Bounds = pnlContent.DisplayRectangle; // Panelin gerçek iç alanına zorla oturt
            altForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(altForm);
            altForm.BringToFront();
            altForm.Show();
        }

   

        private void btnUrunler_Click(object sender, EventArgs e)
        {
            if (urunForm == null || urunForm.IsDisposed)
            {
                urunForm = new ProductForm();
            }
            FormuGetir(urunForm);
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            FormuGetir(new SalesForm(_loginUser));
        }

        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            FormuGetir(new CustomerForm());
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            if (raporForm == null || raporForm.IsDisposed)
            {
                raporForm = new ReportForm();
            }
            // MainForm'daki o meşhur metodumuzla panelin içine getir
            FormuGetir(raporForm);
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
