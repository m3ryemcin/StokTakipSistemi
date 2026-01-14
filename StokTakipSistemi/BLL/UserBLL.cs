using System;
using StokTakipSistemi.DAL;    // DAL klasöründeki metotlara erişmek için
using StokTakipSistemi.DOMAIN; // User sınıfını tanımak için

namespace StokTakipSistemi.BLL
{
    public class UserBLL
    {
        // DAL katmanındaki sınıftan bir nesne üretiyoruz
        UserDAL _userDAL = new UserDAL();

        public User CheckLogin(string username, string password)
        {
            // İş Kuralları (Business Rules) burada yazılır:
            
            // 1. Kural: Kullanıcı adı veya şifre boş bırakılamaz
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Kullanıcı adı veya şifre boş geçilemez!");
            }

            // 2. Kural: Şifre çok kısa olmasın (örnek)
            if (password.Length < 3)
            {
                throw new Exception("Şifre en az 3 karakter olmalıdır!");
            }

            // Tüm kontrollerden geçtiyse DAL'daki Login metodunu çağırıyoruz
            return _userDAL.Login(username, password);
        }
    }
}