namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.profitability")]
    public partial class profitability
    {
        [Key]
        public int idProfitability { get; set; }

        public float gain { get; set; }

        public float lost { get; set; }

        [Column("profitability")]
        public float profitability1 { get; set; }

        public int? idProject { get; set; }

        public virtual project project { get; set; }
    }
}
