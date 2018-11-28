using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class MessageVM
    {
        public int idMessage { get; set; }

        public string Status { get; set; }

        public string contenu { get; set; }

        public DateTime? date { get; set; }

        public string fromTo { get; set; }



        public int level { get; set; }

        public string messageType { get; set; }

        public int reciver { get; set; }

        public int sender { get; set; }


        public virtual ICollection<ResponseVM> responses { get; set; }

        public virtual ProjectVM project { get; set; }
    }
}