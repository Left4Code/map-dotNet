using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class ProfitabilityVM
    {
        public int idProfitability { get; set; }

        public float gain { get; set; }

        public float lost { get; set; }


        public float profitability1 { get; set; }

        public int? idProject { get; set; }

        public virtual ProjectVM project { get; set; }
    }
}