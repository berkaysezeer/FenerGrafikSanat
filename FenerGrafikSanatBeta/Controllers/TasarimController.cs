using FenerGrafikSanatBeta.Models;
using FenerGrafikSanatBeta.Enums;
using FenerGrafikSanatBeta.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace FenerGrafikSanatBeta.Controllers
{
    public class TasarimController : BaseController
    {
        // GET: Tasarim
        [Route("tasarim/{slug?}-{id}")]
        public ActionResult Index(int? id, string slug)
        {
            var adminRol = db.Roles.FirstOrDefault(x => x.Name == "admin");
            TempData["roleId"] = adminRol.Id;

            var kullanici = new ApplicationUser();

            if (User.Identity.IsAuthenticated)
            {
                kullanici = db.Users.Find(User.Identity.GetUserId());
            }


            if (!db.Tasarimlar.Any(x => x.Id == id))
            {
                return RedirectToAction("Hata404", "Hatalar");
            }

            var tasarim = db.Tasarimlar.Find(id);

            if (tasarim.Slug != slug)
            {
                return RedirectToAction("Index", new { id = id, slug = tasarim.Slug });
            }

            var vm = new TasarimViewModel
            {
                Tasarim = tasarim,
                YorumViewModel = new YorumViewModel(),
                Kullanici = kullanici
            };


            return View(vm);
        }

        [Route("tasarim/{slug?}-{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(int? id, string slug, YorumViewModel yorumViewModel)
        {
            var adminRol = db.Roles.FirstOrDefault(x => x.Name == "admin");
            TempData["roleId"] = adminRol.Id;

            var kullanici = new ApplicationUser();

            if (User.Identity.IsAuthenticated)
            {
                kullanici = db.Users.Find(User.Identity.GetUserId());
            }

            if (!db.Tasarimlar.Any(x => x.Id == id))
            {
                return RedirectToAction("Hata404", "Hatalar");
            }

            var tasarim = db.Tasarimlar.Find(id);

            if (tasarim.Slug != slug)
            {
                return RedirectToAction("Index", new { id = id, slug = tasarim.Slug });
            }

            if (ModelState.IsValid)
            {
                var userRoles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

                var yorum = new Yorum
                {
                    KullaniciId = User.Identity.GetUserId(),
                    Icerik = yorumViewModel.Icerik,
                    ParentId = yorumViewModel.ParentId,
                    OlusturulmaTarihi = DateTime.Now,
                    DuzenlemeTarihi = DateTime.Now,
                    TasarimId = id.Value
                };

                if (userRoles.Contains("admin"))
                {
                    yorum.Durum = YorumDurumu.Yayinda;
                }
                else
                {
                    yorum.Durum = YorumDurumu.YayindaDegil;
                }

                db.Yorumlar.Add(yorum);
                db.SaveChanges();

                return Redirect(Url.RouteUrl(new { controller = "Tasarim", action = "Index", id = id, slug = slug, commentSuccess = true }) + "#yorum-yap");

            }

            var vm = new TasarimViewModel
            {
                Tasarim = tasarim,
                YorumViewModel = yorumViewModel,
                Kullanici = kullanici

            };

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Indir(Tasarim tasarim)
        {
            var dbTasarim = db.Tasarimlar.Find(tasarim.Id);
            dbTasarim.IndirilmeAdet += 1;
            db.SaveChanges();
            int noktaIndex = dbTasarim.ResimYolu.IndexOf(".");
            string tasarimUzanti = dbTasarim.ResimYolu.Substring(noktaIndex + 1);
            var imgPath = Server.MapPath("~/Upload/" + dbTasarim.ResimYolu);
            return File(imgPath, "image/" + tasarimUzanti, dbTasarim.ResimYolu);


            //return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult FavorilereEkle(Tasarim tasarim)
        {
            var kullanici = db.Users.Find(User.Identity.GetUserId());
            var dbTasarim = db.Tasarimlar.Find(tasarim.Id);


            if (!kullanici.KullaniciTasarimlar.Any(x => x.TasarimId == dbTasarim.Id))
            {
                var favori = new KullaniciTasarim
                {
                    KullaniciId = kullanici.Id,
                    TasarimId = dbTasarim.Id,
                    EklenmeTarihi = DateTime.Now
                };

                kullanici.KullaniciTasarimlar.Add(favori);
                TempData["SuccessMessage"] = "Tasarım Favorilere Eklendi.";
                db.SaveChanges();
            }
            else
            {
                var favori = kullanici.KullaniciTasarimlar.FirstOrDefault(x => x.TasarimId == dbTasarim.Id);
                kullanici.KullaniciTasarimlar.Remove(favori);

                TempData["SuccessMessage"] = "Tasarım Favorilerden Çıkartıldı.";
                db.SaveChanges();

            }

            return Redirect("https://demo.fgsanat.com/tasarim/" + dbTasarim.Slug + "-" + dbTasarim.Id);
        }

    }
}