using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FenerGrafikSanatBeta.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Eposta")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Bu tarayıcıda hatırla")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Eposta")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "Eposta")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Sadece harfler ve rakamlar")]
        public string UserName { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "{0}, {2} karakterden fazla {1} karakterden az olmalı.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Şifre")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Şifre Onay")]
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
    public string ConfirmPassword { get; set; }
}

public class ResetPasswordViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Eposta")]
    public string Email { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "{0}, {2} karakterden fazla olmalı", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Şifre")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Şifre Onay")]
    [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
    public string ConfirmPassword { get; set; }

    public string Code { get; set; }
}

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Eposta")]
    public string Email { get; set; }
}
}
