namespace StokTakipSistemi.DOMAIN
{
    public class Product : BaseEntity
    {
        public string UrunAdi { get; set; }
        public int StokAdedi { get; set; }
        public decimal Fiyat { get; set; }
        public int KategoriId { get; set; } // Şimdilik basit tutmak için direkt ID alıyoruz
    }
}