using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DOMAIN
{
    public class Sale : BaseEntity
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int Adet { get; set; }
        public decimal ToplamFiyat { get; set; }
    }
}
