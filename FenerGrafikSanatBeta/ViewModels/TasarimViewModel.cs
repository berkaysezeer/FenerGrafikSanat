using FenerGrafikSanatBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.ViewModels
{
    public class TasarimViewModel
    {
        public Tasarim Tasarim { get; set; }
        public YorumViewModel YorumViewModel { get; set; }
        public ApplicationUser Kullanici { get; set; }
    }
}