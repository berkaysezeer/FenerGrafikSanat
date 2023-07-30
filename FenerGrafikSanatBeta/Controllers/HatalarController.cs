using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FenerGrafikSanatBeta.Controllers
{
    public class HatalarController : Controller
    {
        // GET: Hatalar
        public ActionResult Hata404()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}