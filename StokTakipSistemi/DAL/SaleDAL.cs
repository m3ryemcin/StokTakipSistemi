using MySql.Data.MySqlClient;
using StokTakipSistemi.DOMAIN;
using System;
using System.Data;

namespace StokTakipSistemi.DAL
{
    public class SaleDAL
    {
        // Raporlama ekranı için filtreli ana sorgu
        public DataTable GetFilteredSalesReport(DateTime start, DateTime end, string category)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                // Kategori "Tüm Ürünler" değilse sorguya kategori filtresi ekliyoruz
                string categoryFilter = category != "Tüm Ürünler" ? " AND p.UrunAdi LIKE @cat" : "";

                string query = $@"SELECT 
                            s.Id AS 'No', 
                            p.UrunAdi AS 'Ürün', 
                            c.AdSoyad AS 'Müşteri', 
                            s.Adet, 
                            s.ToplamFiyat AS 'Tutar', 
                            s.SatisTarihi AS 'Tarih'
                         FROM Sales s
                         JOIN Products p ON s.ProductId = p.Id
                         JOIN Customers c ON s.CustomerId = c.Id
                         WHERE s.SatisTarihi BETWEEN @start AND @end {categoryFilter}
                         ORDER BY s.SatisTarihi DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@start", start.ToString("yyyy-MM-dd 00:00:00"));
                cmd.Parameters.AddWithValue("@end", end.ToString("yyyy-MM-dd 23:59:59"));

                if (category != "Tüm Ürünler")
                    cmd.Parameters.AddWithValue("@cat", "%" + category + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Mevcut satış yapma metodun (Stoktan düşme dahil)
        public int MakeSale(Sale s)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Sales (ProductId, CustomerId, UserId, Adet, ToplamFiyat) VALUES (@pid, @cid, @uid, @adet, @fiyat)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pid", s.ProductId);
                cmd.Parameters.AddWithValue("@cid", s.CustomerId);
                cmd.Parameters.AddWithValue("@uid", s.UserId);
                cmd.Parameters.AddWithValue("@adet", s.Adet);
                cmd.Parameters.AddWithValue("@fiyat", s.ToplamFiyat);
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    string updateStock = "UPDATE Products SET StokAdedi = StokAdedi - @adet WHERE Id = @pid";
                    MySqlCommand cmd2 = new MySqlCommand(updateStock, conn);
                    cmd2.Parameters.AddWithValue("@adet", s.Adet);
                    cmd2.Parameters.AddWithValue("@pid", s.ProductId);
                    cmd2.ExecuteNonQuery();
                }
                return result;
            }
        }
    }
}