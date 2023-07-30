using FenerGrafikSanatBeta.Helpers;
using FenerGrafikSanatBeta.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FenerGrafikSanatBeta.Areas.Admin.Controllers
{
    public class TasarimlarController : AdminBaseController
    {
        // GET: Tasarimlar
        public ActionResult Index()
        {
            return View(db.Tasarimlar.ToList());
        }

        public ActionResult Yeni()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Yeni(Tasarim tasarim)
        {
            if (ModelState.IsValid)
            {
                string info = this.TasarimKaydet(tasarim.Resim);
                string[] infoDetay = info.Split('*');

                Tasarim tasarimDb = new Tasarim
                {
                    TasarimAdi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tasarim.TasarimAdi),
                    TasarimciAdSoyad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tasarim.TasarimciAdSoyad),
                    KategoriId = tasarim.KategoriId,
                    ResimYolu = infoDetay[0],
                    TasarimBoyut = Convert.ToDecimal(infoDetay[1]),
                    TasarimCozunurluk = infoDetay[2],
                    YuklenmeTarihi = DateTime.Now,
                    Slug = UrlService.URLFriendly(tasarim.Slug)
                };

                db.Tasarimlar.Add(tasarimDb);
                TempData["SuccessMessage"] = "Tasarım Başarıyla Yüklendi.";
                db.SaveChanges();

                return RedirectToAction("Index", "Tasarimlar");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");
            return View();
        }

        public ActionResult Duzenle(int id)
        {
            var tasarim = db.Tasarimlar.Find(id);

            if (tasarim == null) return RedirectToAction("Hata404", "Hatalar");

            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");

            return View(tasarim);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(Tasarim tasarim)
        {
            if (ModelState.IsValid)
            {
                var dbTasarim = db.Tasarimlar.Find(tasarim.Id);
                string info = this.TasarimKaydet(tasarim.Resim);
                string[] infoDetay = info.Split('*');

                if (tasarim.Resim != null)
                {
                    this.TasarimResimSil(tasarim.ResimYolu);
                    dbTasarim.ResimYolu = infoDetay[0];
                    dbTasarim.TasarimBoyut = Convert.ToDecimal(infoDetay[1]);
                    dbTasarim.TasarimCozunurluk = infoDetay[2];
                }

                dbTasarim.TasarimAdi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tasarim.TasarimAdi);
                dbTasarim.Slug = UrlService.URLFriendly(tasarim.Slug);
                dbTasarim.TasarimciAdSoyad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tasarim.TasarimciAdSoyad);
                dbTasarim.KategoriId = tasarim.KategoriId;

                db.SaveChanges();
                TempData["SuccessMessage"] = "Tasarım Başarılı Bir Şekilde Güncellendi";
                return RedirectToAction("Index");
            }

            ViewBag.KategoriId = new SelectList(db.Kategoriler.ToList(), "Id", "KategoriAd");

            return View(tasarim);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Sil(int id)
        {

            var tasarim = db.Tasarimlar.Find(id);
            if (tasarim == null)
            {
                return RedirectToAction("Hata404", "Hatalar");
            }


            this.TasarimResimSil(tasarim.ResimYolu);

            db.Tasarimlar.Remove(tasarim);
            TempData["SuccessMessage"] = "Tasarım Başarılı Bir Şekilde Silindi";
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult TasarimResimSil(int id)
        {

            var tasarim = db.Tasarimlar.Find(id);
            if (tasarim == null)
            {
                return RedirectToAction("Hata404", "Hatalar");
            }


            this.TasarimResimSil(tasarim.ResimYolu);

            tasarim.ResimYolu = "";
            db.SaveChanges();

            return RedirectToAction("Duzenle", new { id = id });

        }
    }
}