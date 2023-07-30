using FenerGrafikSanatBeta.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.Models
{
    [Table("Tasarimlar")]
    public class Tasarim
    {
        public int Id { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "{0} bilgisi zorunludur")]
        public int KategoriId { get; set; }

        [Display(Name = "Tasarım Adı")]
        [Required(ErrorMessage = "{0} bilgisi zorunludur")]
        [MaxLength(60, ErrorMessage = "{0} en fazla {1} karakter içerebilir.")]
        public string TasarimAdi { get; set; }

        [Display(Name = "Tasarımcı")]
        [Required(ErrorMessage = "{0} bilgisi zorunludur")]
        [MaxLength(30, ErrorMessage = "{0} en fazla {1} karakter içerebilir.")]
        public string TasarimciAdSoyad { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Url Adresi")]
        public string Slug { get; set; }

        public int BegeniAdet { get; set; }
        public int IndirilmeAdet { get; set; }
        public decimal TasarimBoyut { get; set; }
        public string TasarimCozunurluk { get; set; }

        public DateTime YuklenmeTarihi { get; set; }

        [MaxLength(200)]
        public string ResimYolu { get; set; }

        [MaxLength(200)]
        public string OnizlemeResimYolu { get; set; }

        [NotMapped]
        [Display(Name = "Tasarım Görseli")]
        [TasarimResmi] //custom attribute
        public HttpPostedFileBase Resim { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual ICollection<Yorum> Yorumlar { get; set; }

        //public virtual ICollection<ApplicationUser> Kullanicilar { get; set; }
        public virtual ICollection<KullaniciTasarim> KullaniciTasarimlar { get; set; }
    }

}