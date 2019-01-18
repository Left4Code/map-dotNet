namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.message")]
    public partial class message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idMessage { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string fromTo { get; set; }

        public int id_reciever { get; set; }

        public int id_sender { get; set; }

        [StringLength(255)]
        public string messageType { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public int? id_project { get; set; }

        public virtual project project { get; set; }
    }
}
