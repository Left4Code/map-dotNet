using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class ResponseVM
    {
        public int idResponse { get; set; }

        public string contenu { get; set; }

        public string reaction { get; set; }

        public int sender { get; set; }

        public string status { get; set; }

        public string who { get; set; }

        public virtual ClientVM client1 { get; set; }

        public virtual MessageVM message { get; set; }
    }
}