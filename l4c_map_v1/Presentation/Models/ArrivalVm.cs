using Domain.entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class ArrivalVm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArrivalVm()
        {
            applicants = new HashSet<applicant>();
        }

        [Key]
        [JsonIgnore]
        public int idArrival { get; set; }

        [DataType(DataType.Date)]
        public DateTime? arrivalDate { get; set; }

        public int flightNumber { get; set; }

        public int? responsable_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<applicant> applicants { get; set; }

        public virtual responsable responsable { get; set; }
    }
}