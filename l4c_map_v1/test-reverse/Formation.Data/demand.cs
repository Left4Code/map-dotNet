namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.demand")]
    public partial class demand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public demand()
        {
            applicants = new HashSet<applicant>();
            meetings = new HashSet<meeting>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDemand { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateDemand { get; set; }

        [StringLength(255)]
        public string demandState { get; set; }

        [StringLength(255)]
        public string specialty { get; set; }

        public int? idFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<applicant> applicants { get; set; }

        public virtual file file { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<meeting> meetings { get; set; }
    }
}
