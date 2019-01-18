namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.time_off")]
    public partial class time_off
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idDemandTimeOff { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idResponsable { get; set; }

        public int Duration { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEnd { get; set; }

        public virtual demand_time_off demand_time_off { get; set; }

        public virtual responsable responsable { get; set; }
    }
}
