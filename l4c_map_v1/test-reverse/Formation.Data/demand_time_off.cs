namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.demand_time_off")]
    public partial class demand_time_off
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public demand_time_off()
        {
            time_off = new HashSet<time_off>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDemandTimeOff { get; set; }

        public int Duration { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEnd { get; set; }

        [StringLength(255)]
        public string stateDemandTimeOff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<time_off> time_off { get; set; }
    }
}
