﻿using FenerGrafikSanatBeta.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FenerGrafikSanatBeta.Areas.Admin.Controllers
{
    public class SlugController : Controller
    {
        [HttpPost]
        public string ConvertToSlug(string title)
        {
            return UrlService.URLFriendly(title);
        }
    }
}