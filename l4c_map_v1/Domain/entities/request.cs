namespace Domain.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.request")]
    public partial class request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public request()
        {
            required_skills = new HashSet<required_skills>();
        }

        [Key]
        public int idRequest { get; set; }

        public float cout { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEnd { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        public int? idClient { get; set; }

        public int? idProject { get; set; }

        public int? idResponsable { get; set; }

        public virtual client client { get; set; }

        public virtual project project { get; set; }

        public virtual responsable responsable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<required_skills> required_skills { get; set; }
    }
}
