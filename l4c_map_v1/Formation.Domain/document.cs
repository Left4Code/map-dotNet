namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.document")]
    public partial class document
    {
        [Key]
        public int idDocument { get; set; }

        [StringLength(255)]
        public string documentType { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public int? idFile { get; set; }

        public virtual file file { get; set; }
    }
}
