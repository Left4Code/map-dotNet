namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.arrival")]
    public partial class arrival
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public arrival()
        {
            applicants = new HashSet<applicant>();
        }

        [Key]
        public int idArrival { get; set; }

        [Column(TypeName = "date")]
        public DateTime? arrivalDate { get; set; }

        public int flightNumber { get; set; }

        public int? responsable_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<applicant> applicants { get; set; }

        public virtual responsable responsable { get; set; }
    }
}
