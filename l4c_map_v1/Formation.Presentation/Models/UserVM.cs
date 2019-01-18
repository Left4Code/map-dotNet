using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class UserVM
    {

        public int id { get; set; }

        [StringLength(255)]
        public string lastname { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        [StringLength(255)]
        public string username { get; set; }


        public virtual ClientVM client { get; set; }


        public virtual RessourceVM ressource { get; set; }
    }

}
