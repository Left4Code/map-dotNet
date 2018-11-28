using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class RequestVM
    {
        public RequestVM()
        {
            requiredSkills = new List<SkillsVM>();
        }

        public int idRequest { get; set; }

        public float cout { get; set; }

        public DateTime? dateBegin { get; set; }

        public DateTime? dateEnd { get; set; }

        public string status { get; set; }

        public virtual ICollection<SkillsVM> requiredSkills { get; set; }


        //  public virtual ClientVM client { get; set; }

        //public virtual ProjectVM project { get; set; }

        //public virtual ResponsableVM responsable { get; set; }
    }
}