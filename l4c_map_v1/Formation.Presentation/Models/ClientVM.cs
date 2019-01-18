using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class ClientVM
    {

        public string logo { get; set; }

        public int nbOfProjectActive { get; set; }

        public int nbOfRessource { get; set; }

        public int score { get; set; }


        public string typeCategory { get; set; }


        public string typeClient { get; set; }


        public int id { get; set; }



        public virtual UserVM user { get; set; }

        public virtual ICollection<ProjectVM> projects { get; set; }
    }
}