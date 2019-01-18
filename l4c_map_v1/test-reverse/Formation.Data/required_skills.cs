namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.required_skills")]
    public partial class required_skills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idRequired_Skills { get; set; }

        [StringLength(255)]
        public string education { get; set; }

        public int experience { get; set; }

        public int? idRequest { get; set; }

        public virtual request request { get; set; }
    }
}
