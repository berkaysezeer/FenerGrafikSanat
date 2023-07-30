using FenerGrafikSanatBeta.Models;
using FenerGrafikSanatBeta.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FenerGrafikSanatBeta.Controllers
{
    public class GaleriController : BaseController
    {
        //https://www.gencayyildiz.com/blog/asp-net-mvc-jquery-ile-scroll-pagingsayfalama/
        int TasarimAdet = 8;
        // GET: Galeri
        [Route("Galeri", Order = 2, Name = "GaleriDefault")]
        [Route("c/{kid}/{slug}", Order = 1)]
        public ActionResult Index(int? kid, string slug, int? sayfano)
        {
            TempData["kategoriId"] = kid;
            IQueryable<Tasarim> sorgu = null;

            if (sayfano == null)
            {
                if (kid == null)
                {
                    sorgu = db.Tasarimlar.OrderByDescending(x => x.YuklenmeTarihi).Take(TasarimAdet);
                }
                else
                {
                    sorgu = db.Tasarimlar.OrderByDescending(x => x.YuklenmeTarihi).Where(x => x.KategoriId == kid).Take(TasarimAdet);
                }

            }
            else
            {
                if (kid == null)
                {
                    sorgu = db.Tasarimlar.OrderByDescending(x => x.YuklenmeTarihi).Skip(TasarimAdet * sayfano.Value).Take(TasarimAdet);
                }
                else
                {
                    sorgu = db.Tasarimlar.OrderByDescending(x => x.YuklenmeTarihi).Where(x => x.KategoriId == kid).Skip(TasarimAdet * sayfano.Value).Take(TasarimAdet);
                }

            }

            var vm = new HomeIndexViewModel
            {
                Kategoriler = db.Kategoriler.Where(x => x.Tasarimlar.Count > 0).OrderBy(x => x.KategoriAd).ToList(),
                Tasarimlar = sorgu.ToList(),
                ToplamTasarimAdet = db.Tasarimlar.Count()
            };

            if (Request.IsAjaxRequest())
            {
                return PartialView("~/Views/Galeri/_GaleriPartial.cshtml", vm);
            }

            return View(vm);
        }
    }
}