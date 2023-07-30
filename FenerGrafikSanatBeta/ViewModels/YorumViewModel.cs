using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.ViewModels
{
    public class YorumViewModel
    {
        [Required, StringLength(1000)]
        public string Icerik { get; set; }

        public int? ParentId { get; set; }
    }
}