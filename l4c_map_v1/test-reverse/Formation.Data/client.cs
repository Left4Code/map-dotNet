namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.client")]
    public partial class client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public client()
        {
            requests = new HashSet<request>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string lastname { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string logo { get; set; }

        public int nbOfProjectActive { get; set; }

        public int nbOfRessource { get; set; }

        [StringLength(255)]
        public string typeCategory { get; set; }

        [StringLength(255)]
        public string typeClient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests { get; set; }
    }
}
