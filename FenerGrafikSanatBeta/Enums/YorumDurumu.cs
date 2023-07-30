using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.Enums
{
    public enum YorumDurumu
    {
        [Display(Name = "Beklemede")]
        Beklemede,
        [Display(Name = "Yayında")]
        Yayinda,
        [Display(Name = "Yayında Değil")]
        YayindaDegil
    }
}