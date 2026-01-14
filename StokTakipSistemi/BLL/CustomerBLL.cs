using MySql.Data.MySqlClient;
using StokTakipSistemi.DAL;
using StokTakipSistemi.DOMAIN;
using System.Collections.Generic;

namespace StokTakipSistemi.BLL
{
    public class CustomerBLL
    {
        CustomerDAL _customerDAL = new CustomerDAL();

        // Rapor ekranı 'GetAll' ismini aradığı için bu ismi kullanıyoruz
        public List<Customer> GetAll()
        {
            return _customerDAL.GetAll();
        }

        // Mevcut metodun da kalsın, zarar gelmez
        public List<Customer> GetList() => _customerDAL.GetAll();

        public string AddCustomer(Customer c)
        {
            if (string.IsNullOrEmpty(c.AdSoyad)) return "Müşteri adı boş olamaz!";
            return _customerDAL.Insert(c) > 0 ? "Başarılı" : "Hata oluştu!";
        }

        public string RemoveCustomer(int id)
        {
            if (id <= 0) return "Lütfen silinecek müşteriyi seçin!";
            return _customerDAL.Delete(id) > 0 ? "Başarılı" : "Hata oluştu!";
        }

        public string EditCustomer(Customer c)
        {
            if (string.IsNullOrEmpty(c.AdSoyad)) return "Ad Soyad boş olamaz!";
            if (c.Id <= 0) return "Güncellenecek müşteri seçilmedi!";
            return _customerDAL.Update(c) > 0 ? "Başarılı" : "Hata oluştu!";
        }
    }
}