using FenerGrafikSanatBeta.Areas.Admin.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FenerGrafikSanatBeta.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var vm = new DashboardViewModel
            {
                KategoriSayisi = db.Kategoriler.Count(),
                TasarimSayisi = db.Tasarimlar.Count(),
                KullaniciSayisi = db.Users.Count(),
                YorumSayisi = db.Yorumlar.Count()

            };

            return View(vm);
        }
    }
}