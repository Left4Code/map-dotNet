using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class MandatePK
    {
        public int idProject { get; set; }
        public int idRessource { get; set; }
    }
    public class MandateVM
    {
        public MandatePK mandatepk { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateBegin { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime dateEnd { get; set; }

        public bool? archive { get; set; }
        public float cost { get; set; }
     
        public int duration { get; set; }
        public string mandateType  { get; set; }
        public virtual ProjetMv project { get; set; }
        //public virtual ressource ressource { get; set; }

    }
}