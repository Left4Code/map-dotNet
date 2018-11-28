using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class ProjectVM
    {

        public int idProject { get; set; }

        public float Budget { get; set; }

        public string adresse { get; set; }

        public DateTime? dateBegin { get; set; }

        public DateTime? dateEnd { get; set; }

        public string name { get; set; }

        public int nbRessources { get; set; }

        public string picture { get; set; }

        public int score { get; set; }

        public string typeProject { get; set; }

        public string typeRessourceDemande { get; set; }

        public int? idClient { get; set; }

        public virtual ClientVM client { get; set; }


    }
}