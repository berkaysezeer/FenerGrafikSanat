using FenerGrafikSanatBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.ViewModels
{
    public class FavoriIndexViewModel
    {
        public ApplicationUser Kullanici { get; set; }
        public List<Tasarim> Tasarim { get; set; }
        public int FavoriAdet { get; set; }

    }
}