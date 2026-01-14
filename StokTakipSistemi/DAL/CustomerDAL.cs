using MySql.Data.MySqlClient;
using StokTakipSistemi.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL
{
    public class CustomerDAL
    {
        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Customers";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new Customer
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            AdSoyad = dr["AdSoyad"].ToString(),
                            Telefon = dr["Telefon"].ToString(),
                            Adres = dr["Adres"].ToString(),
                            MusteriTuru = dr["MusteriTuru"].ToString()
                        });
                    }
                }
            }
            return list;
        }
        public int Insert(Customer c)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Customers (AdSoyad, Telefon, Adres, MusteriTuru) VALUES (@ad, @tel, @adres, @tur)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ad", c.AdSoyad);
                cmd.Parameters.AddWithValue("@tel", c.Telefon);
                cmd.Parameters.AddWithValue("@adres", c.Adres);
                cmd.Parameters.AddWithValue("@tur", c.MusteriTuru);
                return cmd.ExecuteNonQuery();
            }
        }
        public int Delete(int id)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.GetConnection())
                {
                    conn.Open();
                    // Müşteriyi silmeye çalışıyoruz
                    string query = "DELETE FROM Customers WHERE Id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery(); // Hata oluşursa direkt catch bloğuna zıplar
                }
            }
            catch (MySqlException ex)
            {
                // 1451 hatası: İlişkili kayıt (satış) var demek
                if (ex.Number == 1451)
                {
                    System.Windows.Forms.MessageBox.Show("Bu müşteriyi silemezsiniz! Müşterinin geçmiş satış kayıtları bulunmaktadır. Önce müşteriye ait satışları silmelisiniz.");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Müşteri silinirken hata oluştu: " + ex.Message);
                }
                return 0;
            }
        }
        public int Update(Customer c)
        {
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Customers SET AdSoyad=@ad, Telefon=@tel, Adres=@adres, MusteriTuru=@tur WHERE Id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ad", c.AdSoyad);
                cmd.Parameters.AddWithValue("@tel", c.Telefon);
                cmd.Parameters.AddWithValue("@adres", c.Adres);
                cmd.Parameters.AddWithValue("@tur", c.MusteriTuru);
                cmd.Parameters.AddWithValue("@id", c.Id);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}

