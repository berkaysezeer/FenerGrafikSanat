using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.Models
{
    [Table("Kategoriler")]
    public class Kategori
    {
        [Display(Name = "Kategori")]
        public int Id { get; set; }

        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "{0} zorunludur.")]
        [MaxLength(30, ErrorMessage = "{0} en fazla {1} karakter içerebilir.")]
        public string KategoriAd { get; set; }

        [Required]
        [Display(Name = "Url Adresi")]
        [StringLength(30)]
        public string Slug { get; set; }

        public virtual List<Tasarim> Tasarimlar { get; set; }
    }
}