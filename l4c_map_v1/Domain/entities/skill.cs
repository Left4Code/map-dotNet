
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Domain.entities
{


    [Table("mapds.skills")]
    public partial class skill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public skill()
        {
            ressources = new HashSet<ressource>();
            projects = new HashSet<project>();
            projects1 = new HashSet<project>();
        }

        [Key]
        public int idSkills { get; set; }

        [StringLength(255)]
        public string degree { get; set; }

        [StringLength(255)]
        public string document { get; set; }

        public int experience { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string specialty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ressource> ressources { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project> projects1 { get; set; }
    }
}
