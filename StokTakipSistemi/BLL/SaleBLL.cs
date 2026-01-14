using System;
using System.Data;
using StokTakipSistemi.DAL;
using StokTakipSistemi.DOMAIN;
using System.Linq; 

namespace StokTakipSistemi.BLL
{
    public class SaleBLL
    {
        SaleDAL _saleDAL = new SaleDAL();
        ProductDAL _productDAL = new ProductDAL(); 

        public string ProcessSale(Sale s)
        {
           
            var urunler = _productDAL.GetAllProducts();
            var mevcutUrun = urunler.FirstOrDefault(p => p.Id == s.ProductId);

            
            if (mevcutUrun == null) return "Hata: Ürün bulunamadı!";

           
            if (mevcutUrun.StokAdedi < s.Adet)
            {
                return $"Yetersiz Stok! Mevcut: {mevcutUrun.StokAdedi}, İstenen: {s.Adet}";
            }

           
            int sonuc = _saleDAL.MakeSale(s);
            return sonuc > 0 ? "Satış Başarılı" : "Hata Oluştu";
        }

        public DataTable GetSalesReport(DateTime start, DateTime end, string category)
        {
            return _saleDAL.GetFilteredSalesReport(start, end, category);
        }
    }
}