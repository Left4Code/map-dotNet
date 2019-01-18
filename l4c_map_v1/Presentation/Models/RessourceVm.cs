using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class RessourceVm
    {
        public RessourceVm()
        {

        }
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public float cost { get; set; }
        public IEnumerable<SkillVM> skills { get; set; }
        public IEnumerable<MandateVM> listemandate { get; set; }
    }
}