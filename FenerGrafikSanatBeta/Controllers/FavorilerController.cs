using FenerGrafikSanatBeta.Models;
using FenerGrafikSanatBeta.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FenerGrafikSanatBeta.Controllers
{
    [Authorize]
    public class FavorilerController : BaseController
    {
        // GET: Favoriler
        public ActionResult Index()
        {
            var kullanici = db.Users.Find(User.Identity.GetUserId());
            List<Tasarim> favoriler=new List<Tasarim>();

            foreach (var favori in kullanici.KullaniciTasarimlar.OrderByDescending(x=>x.EklenmeTarihi))
            {
                var tasarim = db.Tasarimlar.Find(favori.TasarimId);
                favoriler.Add(tasarim);
            }

            var vm = new FavoriIndexViewModel
            {
                Kullanici = kullanici,
                Tasarim=favoriler,
                FavoriAdet=favoriler.Count
            };

            return View(vm);
        }
    }
}