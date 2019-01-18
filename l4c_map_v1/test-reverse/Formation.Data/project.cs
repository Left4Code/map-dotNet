namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.project")]
    public partial class project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project()
        {
            mandates = new HashSet<mandate>();
            messages = new HashSet<message>();
            profitabilities = new HashSet<profitability>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idProject { get; set; }

        [StringLength(255)]
        public string adresse { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEnd { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int nbRessources { get; set; }

        public int nbRessourcesLevio { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mandate> mandates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message> messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<profitability> profitabilities { get; set; }
    }
}
