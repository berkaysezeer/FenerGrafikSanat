using FenerGrafikSanatBeta.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FenerGrafikSanatBeta.Controllers
{
    public class IletisimController : Controller
    {
        public class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }

        // GET: Iletisim
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(Eposta e)
        {
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Mesajınız Başarılı Bir Şekilde İletildi";
                return RedirectToAction("Index", "Iletisim");
            }
            else
            {
                TempData["ErrorMessage"] = "Lütfen güvenliği doğrulayınız.";
            }

            return View();
        }
    }
}