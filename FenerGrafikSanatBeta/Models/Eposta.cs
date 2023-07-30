using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.Models
{
    public class Eposta
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="{0} Alanı Zorunludur.")]
        [StringLength(30,ErrorMessage ="{0} Alanı En Fazla {1} Karakter İçerebilir.")]
        public string AdSoyad { get; set; }

        [Display(Name = "Konu")]
        [Required(ErrorMessage = "{0} Alanı Zorunludur.")]
        [StringLength(50, ErrorMessage = "{0} Alanı En Fazla {1} Karakter İçerebilir.")]
        public string Konu { get; set; }

        [Display(Name = "E-posta Adresi")]
        [Required(ErrorMessage = "{0} Alanı Zorunludur.")]
        public string EpostaAdresi { get; set; }

        [Display(Name = "Mesaj")]
        [Required(ErrorMessage = "{0} Alanı Zorunludur.")]
        [StringLength(1000, ErrorMessage = "{0} Alanı En Fazla {1} Karakter İçerebilir.")]
        public string Mesaj { get; set; }

    }
}