using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class ProjectVM
    {
        public int idProject { get; set; }

        public float Budget { get; set; }

        [StringLength(255)]
        public string adresse { get; set; }


        public DateTime? dateBegin { get; set; }


        public DateTime? dateEnd { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int nbRessources { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        public int score { get; set; }

        [StringLength(255)]
        public string typeProject { get; set; }

        [StringLength(255)]
        public string typeRessourceDemande { get; set; }

        public int? idClient { get; set; }

        public virtual ClientVM client { get; set; }

        public virtual ICollection<MandateVM> mandates { get; set; }
        public virtual ICollection<ProfitabilityVM> profitabilities { get; set; }


    }
}