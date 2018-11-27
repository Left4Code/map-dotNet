using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class Credential
    {
        
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "this field is required")]
        public string username { get; set; }
        [StringLength(60, MinimumLength = 8)]
        [Required(ErrorMessage = "this field is required")]
        public string password { get; set; }
    }
}