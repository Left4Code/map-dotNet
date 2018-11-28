using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class ClientVM
    {
        public string logo { get; set; }

        public int nbOfProjectActive { get; set; }

        public int nbOfRessource { get; set; }

        public int score { get; set; }

        public string typeCategory { get; set; }

        public string typeClient { get; set; }

        public int id { get; set; }

      //  public virtual ICollection<response> responses { get; set; }

   //     public virtual ICollection<request> requests { get; set; }

     //   public virtual user user { get; set; }

    //    public virtual ICollection<project> projects { get; set; }
    }
}