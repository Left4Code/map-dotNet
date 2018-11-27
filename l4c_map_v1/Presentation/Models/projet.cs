using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class Projet
    {
        [JsonIgnore]
        public int? idClient { get; set; }

        public int score { get; set; }
        public int idProject { get; set; }

        public float Budget { get; set; }


        public string adresse { get; set; }

        [DataType(DataType.Date)]
        public string dateBegin { get; set; }
        [DataType(DataType.Date)]
        public string dateEnd { get; set; }


        public string name { get; set; }

        public int nbRessources { get; set; }

        public string picture { get; set; }




        public string typeProject { get; set; }


        public string typeRessourceDemande { get; set; }
    }
}