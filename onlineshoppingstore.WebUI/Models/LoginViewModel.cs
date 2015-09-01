using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace onlineshoppingstore.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="User Name is Empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [StringLength(50,MinimumLength =6)]
        public string Password { get; set; }

    }
}