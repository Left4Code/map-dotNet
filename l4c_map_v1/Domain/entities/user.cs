namespace Domain.entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.user")]
    public partial class user
    {
        public int id { get; set; }

        [StringLength(255)]
        public string lastname { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string picture { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        /*public virtual applicant applicant { get; set; }

        public virtual client client { get; set; }

        public virtual responsable responsable { get; set; }

        public virtual ressource ressource { get; set; }*/
    }
}
