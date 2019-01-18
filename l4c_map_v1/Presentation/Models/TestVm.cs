using Domain.entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public class TestVm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestVm()
        {
            files = new HashSet<file>();
            questions = new Collection<QuestionVm>();
        }

        [Key]
        public int idTest { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? dateOfPassing { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public int difficulty { get; set; }
        public int mark { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [StringLength(255)]
        public string name { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [StringLength(255)]
        public string specialty { get; set; }

        public int? idResponsable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<file> files { get; set; }

        public virtual Collection<QuestionVm> questions{ get; set; }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                TestVm p = (TestVm)obj;
                return p.idTest == this.idTest;
            }
        }
    }
}