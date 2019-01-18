namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.ressource")]
    public partial class ressource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ressource()
        {
            mandates = new HashSet<mandate>();
            skills = new HashSet<skill>();
            sponsors = new HashSet<sponsor>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string lastname { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string businessSector { get; set; }

        public float cost { get; set; }

        [StringLength(255)]
        public string cv { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateDebut { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateFin { get; set; }

        public int note { get; set; }

        public float rateSelling { get; set; }

        public int seniority { get; set; }

        [StringLength(255)]
        public string specialty { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        [StringLength(255)]
        public string typeContrat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mandate> mandates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skill> skills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sponsor> sponsors { get; set; }
    }
}
