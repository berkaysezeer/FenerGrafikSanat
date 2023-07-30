using FenerGrafikSanatBeta.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.Models
{
    [Table("Yorumlar")]
    public class Yorum
    {
        public int Id { get; set; }

        [Required]
        public string KullaniciId { get; set; }

        public int? ParentId { get; set; }

        public int TasarimId { get; set; }

        [Required]
        public string Icerik { get; set; }

        [Required]
        public DateTime? OlusturulmaTarihi { get; set; }

        [Required]
        public DateTime? DuzenlemeTarihi { get; set; }

        public YorumDurumu Durum { get; set; }

        [ForeignKey("KullaniciId")]
        public virtual ApplicationUser Kullanici { get; set; }

        public virtual Tasarim Tasarim { get; set; }

        public virtual Yorum Parent { get; set; }

        public virtual ICollection<Yorum> Children { get; set; }
    }
}