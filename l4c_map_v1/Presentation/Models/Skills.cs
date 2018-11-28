

using System.Runtime.Serialization;

namespace Presentation.Models
{
    public class Skills
    {
        public int idSkills { get; set; }

        [IgnoreDataMember]
        public int idP { get; set; }

        public string degree { get; set; }

        public int experience { get; set; }

        public string name { get; set; }

        public string specialty { get; set; }
    }
}