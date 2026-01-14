using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakipSistemi;

namespace StokTakipSistemi.DOMAIN
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime KayitTarihi { get; set; } = DateTime.Now;
    }
}
