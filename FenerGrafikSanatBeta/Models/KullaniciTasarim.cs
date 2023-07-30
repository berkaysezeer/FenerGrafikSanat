using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.Models
{
    public class KullaniciTasarim
    {
        public int TasarimId { get; set; }
        public string KullaniciId { get; set; }

        public DateTime? EklenmeTarihi { get; set; }

        public ApplicationUser Kullanici { get; set; }
        public Tasarim Tasarim { get; set; }
    }
}