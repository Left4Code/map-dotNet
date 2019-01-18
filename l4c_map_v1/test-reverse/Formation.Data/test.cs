namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.test")]
    public partial class test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public test()
        {
            files = new HashSet<file>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idTest { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateOfPassing { get; set; }

        public int difficulty { get; set; }

        public int mark { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string specialty { get; set; }

        public int? idResponsable { get; set; }

        public virtual responsable responsable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<file> files { get; set; }
    }
}
