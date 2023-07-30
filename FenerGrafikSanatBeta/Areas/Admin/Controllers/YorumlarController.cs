using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FenerGrafikSanatBeta.Enums;

namespace FenerGrafikSanatBeta.Areas.Admin.Controllers
{
    public class YorumlarController : AdminBaseController
    {
        // GET: Admin/Yorumlar
        public ActionResult Index()
        {
            return View(db.Yorumlar.ToList());
        }

        [HttpPost]
        public ActionResult DurumDegistir(int id, bool isPublished)
        {
            var yorum = db.Yorumlar.Find(id);
            yorum.Durum = isPublished ? YorumDurumu.Yayinda : YorumDurumu.YayindaDegil;
            db.SaveChanges();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Sil(int id)
        {
            var yorum = db.Yorumlar.Find(id);
            db.Yorumlar.RemoveRange(yorum.Children);
            db.Yorumlar.Remove(yorum);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}