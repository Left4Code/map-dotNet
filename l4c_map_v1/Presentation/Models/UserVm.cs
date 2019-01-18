using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class UserVm
    {
        public int id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "this field is required")]
        public string lastname { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "this field is required")]
        public string name { get; set; }

        [StringLength(60, MinimumLength = 8)]
        [Required(ErrorMessage = "this field is required")]
        public string password { get; set; }

        public string picture { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "this field is required")]
        public string username { get; set; }

        /*public virtual applicant applicant { get; set; }

        public virtual client client { get; set; }

        public virtual responsable responsable { get; set; }

        public virtual ressource ressource { get; set; }*/
    }
}