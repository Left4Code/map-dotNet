namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.response")]
    public partial class response
    {
        [Key]
        public int idResponse { get; set; }

        [StringLength(255)]
        public string contenu { get; set; }

        [StringLength(255)]
        public string reaction { get; set; }

        public int sender { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        [StringLength(255)]
        public string who { get; set; }

        public int? client { get; set; }

        public int? id_message { get; set; }

        public virtual client client1 { get; set; }

        public virtual message message { get; set; }
    }
}
