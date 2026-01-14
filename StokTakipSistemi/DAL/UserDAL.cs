using MySql.Data.MySqlClient;
using StokTakipSistemi.DOMAIN;
using System;

namespace StokTakipSistemi.DAL
{
    public class UserDAL
    {
        public User Login(string username, string password)
        {
            User user = null;
            using (MySqlConnection conn = DbConnection.GetConnection())
            {
                conn.Open();

                // DİKKAT: 'users' değil 'Users' (Büyük U)
                string query = "SELECT * FROM Users WHERE Username=@user AND Password=@pass";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            user = new User();
                            // Sütun isimleri de veritabanında büyük harfle başlar:
                            user.Id = Convert.ToInt32(dr["Id"]);
                            user.Username = dr["Username"].ToString();
                            user.RoleId = Convert.ToInt32(dr["RoleId"]);
                        }
                    }
                }
            }
            return user;
        }
    }
}