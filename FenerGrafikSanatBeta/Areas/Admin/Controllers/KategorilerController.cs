using FenerGrafikSanatBeta.Helpers;
using FenerGrafikSanatBeta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FenerGrafikSanatBeta.Areas.Admin.Controllers
{
    public class KategorilerController : AdminBaseController
    {
        // GET: Kategoriler
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());
        }

        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Yeni(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                kategori.Slug = UrlService.URLFriendly(kategori.Slug);
                kategori.KategoriAd = CultureInfo.CurrentCulture.TextInfo.ToTitleCase((kategori.KategoriAd).Trim());
                db.Kategoriler.Add(kategori);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Kategori Başarılı Bir Şekilde Eklendi.";
                return RedirectToAction("Index","Kategoriler");
            }
            return View();
        }

        public ActionResult Duzenle(int? id)
        {
            //var kategori = db.Kategoriler.Find(id);
            //if (kategori == null) return RedirectToAction("Hata404", "Hatalar");

            //return View(kategori);

            if (id == null)
            {
                return RedirectToAction("Hata404", "Hatalar");
            }

            Kategori category = db.Kategoriler.Find(id);

            if (category == null)
            {
                return RedirectToAction("Hata404", "Hatalar");
            }

            return View(category);
        }

        
            

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(Kategori kategori)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(kategori).State = System.Data.Entity.EntityState.Modified;
            //    db.SaveChanges();
            //    TempData["SuccessMessage"] = "Kategori Başarılı Bir Şekilde Düzenlendi";
            //    return RedirectToAction("Index","Kategoriler");
            //}

            //return View(db.Kategoriler.Find(kategori.Id));

            if (ModelState.IsValid)
            {
                kategori.Slug = UrlService.URLFriendly(kategori.Slug);
                kategori.KategoriAd= CultureInfo.CurrentCulture.TextInfo.ToTitleCase((kategori.KategoriAd).Trim());
                db.Entry(kategori).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Kategori Başarılı Bir Şekilde Düzenlendi";
                return RedirectToAction("Index","Kategoriler");
            }

            return View(db.Kategoriler.Find(kategori.Id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Sil(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            if (kategori == null) return RedirectToAction("Hata404", "Hatalar");

            if (kategori.Tasarimlar.Any())
            {
                TempData["ErrorMessage"] = $"Silmek istediğiniz {kategori.KategoriAd} kategorisinde tasarımlar mevcut olduğu için silinememiştir.";
                return RedirectToAction("Index", "Kategoriler");
            }

            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            TempData["SuccessMessage"] = "Kategori Başarılı Bir Şekilde Silindi";
            return RedirectToAction("Index", "Kategoriler");
        }
    }
}