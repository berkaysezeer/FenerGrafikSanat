using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FenerGrafikSanatBeta.Helpers
{
    public static class TasarimIslemler
    {
        public static void TasarimResimSil(this Controller controller, string resimYolu)
        {
            if (!string.IsNullOrEmpty(resimYolu)) //resim yolu bos degilse
            {
                var resimTamYolu = Path.Combine(controller.Server.MapPath("~/Upload"), resimYolu); //resmin tam yolunu aliriz
                var OnizlemeResimTamYolu = Path.Combine(controller.Server.MapPath("~/UploadCroped"), resimYolu);

                if (File.Exists(resimTamYolu) && File.Exists(OnizlemeResimTamYolu))
                {
                    File.Delete(resimTamYolu);
                    File.Delete(OnizlemeResimTamYolu);
                }


            }
        }

        public static string TasarimKaydet(this Controller controller, HttpPostedFileBase resim)
        {
            if (resim == null) return "";

            string orjDizin = controller.Server.MapPath("~/Upload/");
            string onizlemeDizin = controller.Server.MapPath("~/UploadCroped/");
            string dosyaAd = Guid.NewGuid() + Path.GetExtension(resim.FileName); //uzantiyla beraber dosya adini alir
            string kaydetYol = Path.Combine(orjDizin, dosyaAd); //resmin kaydedilecegi yolu belirtir
            string OnizlemeKaydetYol = Path.Combine(onizlemeDizin, dosyaAd);

            WebImage img = new WebImage(resim.InputStream);
            string info;
            img.Save(kaydetYol);
            info = dosyaAd + "*" + (img.GetBytes().Length / 1024) + "*" + img.Width.ToString() + " x " + img.Height.ToString();
            img.Resize(540, 960);
            img.Save(OnizlemeKaydetYol);

            return info;
        }

        public static string TasarimResim(this UrlHelper urlHelper, string resimYolu) //extension metod
        {
            if (string.IsNullOrEmpty(resimYolu)) return urlHelper.Content("~/img/noimage.png"); //tasarimresmiyoksa
            else return urlHelper.Content("~/Upload/" + resimYolu);
        }

        public static string OnizlemeTasarimResim(this UrlHelper urlHelper, string resimYolu) //extension metod
        {
            if (string.IsNullOrEmpty(resimYolu)) return urlHelper.Content("~/img/noimage.png"); //tasarimresmiyoksa
            else return urlHelper.Content("~/UploadCroped/" + resimYolu);
        }

    }
}