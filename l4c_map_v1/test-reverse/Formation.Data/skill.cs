namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.skills")]
    public partial class skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idSkills { get; set; }

        [StringLength(255)]
        public string degree { get; set; }

        [StringLength(255)]
        public string document { get; set; }

        public int experience { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string specialty { get; set; }

        public int? idRessource { get; set; }

        public virtual ressource ressource { get; set; }
    }
}
