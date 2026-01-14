using System;
using System.Collections.Generic;
using StokTakipSistemi.DAL;
using StokTakipSistemi.DOMAIN;

namespace StokTakipSistemi.BLL
{
    public class ProductBLL
    {
        ProductDAL _productDAL = new ProductDAL();

        public List<Product> GetAll()
        {
            return _productDAL.GetAllProducts();
        }

        public string AddProduct(Product p)
        {
            // İş Kuralı: Ürün adı boş olamaz ve fiyat 0'dan büyük olmalı
            if (string.IsNullOrEmpty(p.UrunAdi)) return "Ürün adı boş olamaz!";
            if (p.Fiyat <= 0) return "Fiyat 0'dan büyük olmalıdır!";

            int sonuc = _productDAL.InsertProduct(p);
            return sonuc > 0 ? "Başarılı" : "Hata oluştu";
        }
        public string RemoveProduct(int id)
        {
            if (id <= 0) return "Geçersiz ürün ID!";

            int sonuc = _productDAL.DeleteProduct(id);
            return sonuc > 0 ? "Ürün silindi" : "Silme işlemi başarısız";
        }
        public string EditProduct(Product p)
        {
            if (string.IsNullOrEmpty(p.UrunAdi)) return "Ürün adı boş olamaz!";
            if (p.Id <= 0) return "Güncellenecek ürün bulunamadı!";

            return _productDAL.UpdateProduct(p) > 0 ? "Başarılı" : "Güncelleme hatası!";
        }
    }

}