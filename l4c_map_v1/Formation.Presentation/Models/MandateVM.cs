using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class MandateVM
    {

        public int idProject { get; set; }
        public int idRessource { get; set; }
        public bool? archive { get; set; }
        public float cost { get; set; }
        public string dateBegin { get; set; }
        public string dateEnd { get; set; }
        public int duration { get; set; }
        public string mandateType { get; set; }
        public virtual ProjectVM project { get; set; }
        public virtual RessourceVM ressource { get; set; }

    }
}