using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SignalRMvcChat.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Panjang {0} paling tidak {2} karakter", MinimumLength =3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Kata sandi dan kata sandi konfirmasi tidak cocok.")]
        public string ConfirmPassword { get; set; }
    }
}