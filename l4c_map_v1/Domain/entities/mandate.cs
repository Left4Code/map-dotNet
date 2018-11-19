namespace Domain.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.mandate")]
    public partial class mandate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mandate()
        {
            historical_mandate = new HashSet<historical_mandate>();
            historicalmandates = new HashSet<historicalmandate>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idProject { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idRessource { get; set; }

        [Column(TypeName = "bit")]
        public bool? archive { get; set; }

        public float cost { get; set; }

        public DateTime? dateBegin { get; set; }

        public DateTime? dateEnd { get; set; }

        public int duration { get; set; }

        [StringLength(255)]
        public string mandateType { get; set; }

        public virtual project project { get; set; }

        public virtual ressource ressource { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historical_mandate> historical_mandate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historicalmandate> historicalmandates { get; set; }
    }
}
