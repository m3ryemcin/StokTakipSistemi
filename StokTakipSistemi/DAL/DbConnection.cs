using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace StokTakipSistemi.DAL
{
	public class DbConnection
	{
		// MySQL bağlantı cümlesi (XAMPP/WAMP varsayılan bilgileridir)
		private static string connectionString = "Server=172.21.54.253; DataBase=26_132430023; User ID=26_132430023; Password=İnif123.;";

		public static MySqlConnection GetConnection()
		{
			return new MySqlConnection(connectionString);
		}
	}
}
