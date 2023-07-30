using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace FenerGrafikSanatBeta.Helpers
{
    public class TasarimResmiAttribute:ValidationAttribute
    {
        public string IzinVerilenUzantilar { get; set; } = ".jpeg, .jpg, .png"; //izin verilen uzantilari kontrol etmek icin property
        public int MaxFileSizeMb { get; set; } = 10; //max boyutu belirleme

        public override bool IsValid(object value)
        {
            if (value == null || !(value is HttpPostedFileBase)) return true; // eger gorsel yoksa bos don

            string[] izinliUzantilar = IzinVerilenUzantilar.ToLower(CultureInfo.InvariantCulture).Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var resim = (HttpPostedFileBase)value;
            var ext = Path.GetExtension(resim.FileName);//dosya uzantisini alma

            //eger resimin tipi image ile baslamiyorsa veya izin verilen uzantilardan birine sahip degilse
            if (!resim.ContentType.StartsWith("image/") || !izinliUzantilar.Contains(ext.ToLower(CultureInfo.InvariantCulture)))
            {
                ErrorMessage = "Kabul edilen dosya türleri: " + IzinVerilenUzantilar;
                return false;
            }
            else if (resim.ContentLength > MaxFileSizeMb * 1024 * 1024)
            {
                ErrorMessage = $"Resim {MaxFileSizeMb} MB'den büyük olamaz.";
                return false;
            }
            return true;

        }
    }
}