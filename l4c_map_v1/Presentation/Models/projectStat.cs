using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class projectStat
    {
    
        public int idProfitability { get; set; }

        
        public float profitability { get; set; }
        public float gain { get; set; }
        public float lost { get; set; }
   

    
        public Projet project { get; set; }

     
    }
}