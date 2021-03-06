namespace Formation.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.applicant")]
    public partial class applicant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public applicant()
        {
            sponsors = new HashSet<sponsor>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string lastname { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        public int age { get; set; }

        [StringLength(255)]
        public string applicantState { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        public int? idArrival { get; set; }

        public int? idDemand { get; set; }

        public virtual arrival arrival { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sponsor> sponsors { get; set; }

        public virtual demand demand { get; set; }
    }
}
