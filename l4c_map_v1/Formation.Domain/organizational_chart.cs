namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("map.organizational_chart")]
    public partial class organizational_chart
    {
        [Key]
        public int idOrganizational_Chart { get; set; }
    }
}
