using MySql.Data.MySqlClient;
using System.Collections.Generic;
using StokTakipSistemi.DOMAIN;

namespace StokTakipSistemi.DAL
{
    public class ProductDAL
    {
        // Tüm ürünleri getiren metod
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Products";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        products.Add(new Product
                        {
                            Id = (int)dr["Id"],
                            UrunAdi = dr["UrunAdi"].ToString(),
                            StokAdedi = (int)dr["StokAdedi"],
                            Fiyat = (decimal)dr["Fiyat"]
                        });
                    }
                }
            }
            return products;
        }
        public int DeleteProduct(int id)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Products WHERE Id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                // 1451 hata kodu MySQL'de "Foreign Key" (İlişkili Kayıt) hatasıdır
                if (ex.Number == 1451)
                {
                    System.Windows.Forms.MessageBox.Show("Bu ürünü silemezsiniz! Çünkü bu ürüne ait geçmiş satış kayıtları var. Önce satışları silmeniz veya ürünü pasife çekmeniz gerekir.");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
                return 0;
            }
        }
        public int UpdateProduct(Product p)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Products SET UrunAdi=@ad, StokAdedi=@stok, Fiyat=@fiyat WHERE Id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ad", p.UrunAdi);
                cmd.Parameters.AddWithValue("@stok", p.StokAdedi);
                cmd.Parameters.AddWithValue("@fiyat", p.Fiyat);
                cmd.Parameters.AddWithValue("@id", p.Id);
                return cmd.ExecuteNonQuery();
            }
        }
        // Yeni ürün ekleyen metod
        public int InsertProduct(Product p)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Products (UrunAdi, StokAdedi, Fiyat) VALUES (@ad, @stok, @fiyat)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ad", p.UrunAdi);
                cmd.Parameters.AddWithValue("@stok", p.StokAdedi);
                cmd.Parameters.AddWithValue("@fiyat", p.Fiyat);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}