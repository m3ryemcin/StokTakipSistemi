using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StokTakipSistemi.BLL;    // BLL'e ulaşmak için
using StokTakipSistemi.DOMAIN; // User nesnesi için

namespace StokTakipSistemi
{
    public partial class Form1 : Form
    {
        UserBLL _userBLL = new UserBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User loginUser = _userBLL.CheckLogin(txtUsername.Text, txtPassword.Text);

                if (loginUser != null)
                {
                    // MainForm'u oluştururken loginUser'ı (giriş yapan kişiyi) içine gönderiyoruz
                    MainForm anaMenu = new MainForm(loginUser);
                    anaMenu.Show(); // Ana menüyü aç
                    this.Hide();    // Login formunu gizle
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                }
            }
            catch (Exception ex)
            {
                // BLL'den fırlatılan hata mesajlarını burada yakalayıp kullanıcıya gösteriyoruz
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
