namespace Domain.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.sponsor")]
    public partial class sponsor
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idApplicant { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idResponsable { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [StringLength(255)]
        public string language { get; set; }

        public int? role { get; set; }

        [Column(TypeName = "date")]
        public DateTime? timeBegin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? timeEnd { get; set; }

        public int? ressource_id { get; set; }

        public virtual applicant applicant { get; set; }

        public virtual responsable responsable { get; set; }

        public virtual ressource ressource { get; set; }
    }
}
