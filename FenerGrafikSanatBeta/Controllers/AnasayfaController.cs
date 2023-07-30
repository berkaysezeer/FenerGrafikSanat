using FenerGrafikSanatBeta.Models;
using FenerGrafikSanatBeta.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FenerGrafikSanatBeta.Controllers
{
    public class AnasayfaController : BaseController
    {
        // GET: Home
        public ActionResult Index() //kategorilere tikladiginde kategoriye gore tasarimlar gelecek
        {
            IQueryable<Tasarim> sorgu = db.Tasarimlar.OrderByDescending(x => x.YuklenmeTarihi).Take(6);


            var vm = new HomeIndexViewModel
            {
                Kategoriler = db.Kategoriler.Where(x => x.Tasarimlar.Count > 0).OrderBy(x => x.KategoriAd).ToList(),
                Tasarimlar = sorgu.ToList(),
                ToplamTasarimAdet = db.Tasarimlar.Count(),
                KategoriAdet = db.Kategoriler.Count(),
                //ToplamIndirilmeAdet = db.Tasarimlar.Sum(x => x.IndirilmeAdet)
            };

            return View(vm);
        }
    }
}