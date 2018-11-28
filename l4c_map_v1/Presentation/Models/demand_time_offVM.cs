using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class demand_time_offVM
    {
        public int idDemandeTimeOff { get; set; }

        public DateTime? DateBegin { get; set; }

        public DateTime? DateEnd { get; set; }
        public String StateDemande { get; set; }
    }
}