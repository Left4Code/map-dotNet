namespace Domain.entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("mapds.demand_time_off")]
    public partial class demand_time_off
    {
        [Key]
        [DataMember(Name = "idDemandeTimeOff")]
        public int idDemandTimeOff { get; set; }
        [IgnoreDataMember]

        public int Duration { get; set; }

        [Column(TypeName = "date")]
        [DataMember(Name = "DateBegin")]

        public DateTime? dateBegin { get; set; }

        [Column(TypeName = "date")]
        [DataMember(Name = "DateEnd")]

        public DateTime? dateEnd { get; set; }

        [StringLength(255)]
        [DataMember(Name = "StateDemande")]

        public string stateDemandTimeOff { get; set; }
        [DataMember(Name = "idresponsable")]

        public int? responsable_id { get; set; }
        [IgnoreDataMember]

        public int? ressource_id { get; set; }
        [IgnoreDataMember]

        public virtual ressource ressource { get; set; }
        [IgnoreDataMember]

        public virtual responsable responsable { get; set; }
    }
}
