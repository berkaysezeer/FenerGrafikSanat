using FenerGrafikSanatBeta.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.Areas.Admin.AdminViewModels
{
    public class DashboardViewModel
    {
        public int KategoriSayisi { get; set; }
        public int TasarimSayisi { get; set; }
        public int KullaniciSayisi { get; set; }
        public int YorumSayisi { get; set; }
    }
}