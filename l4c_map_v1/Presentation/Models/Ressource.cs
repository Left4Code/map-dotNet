﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class Ressource
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String cv { get; set; }

        public String LastName { get; set; }
        public float cost { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateFin { get; set; }
        public int note { get; set; }
        public int seniority { get; set; }
        public string specialty { get; set; }
        public string typeContrat { get; set; }
        public virtual List<Skills> skills { get; set; }
      


    }
}