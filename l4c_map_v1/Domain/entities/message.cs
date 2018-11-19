namespace Domain.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.message")]
    public partial class message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public message()
        {
            responses = new HashSet<response>();
        }

        [Key]
        public int idMessage { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        [StringLength(255)]
        public string contenu { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string fromTo { get; set; }

        public int id_reciever { get; set; }

        public int id_sender { get; set; }

        public int level { get; set; }

        [StringLength(255)]
        public string messageType { get; set; }

        public int reciver { get; set; }

        public int sender { get; set; }

        public int? id_project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<response> responses { get; set; }

        public virtual project project { get; set; }
    }
}
