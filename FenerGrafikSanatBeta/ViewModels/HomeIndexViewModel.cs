using FenerGrafikSanatBeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Kategori> Kategoriler { get; set; }
        public List<Tasarim> Tasarimlar { get; set; }
        public int ToplamTasarimAdet { get; set; }
        public int ToplamIndirilmeAdet { get; set; }
        public int KategoriAdet { get; set; }
    }
}