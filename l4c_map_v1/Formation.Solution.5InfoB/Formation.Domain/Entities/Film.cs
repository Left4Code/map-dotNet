using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formation.Domain.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
        public int? ProducerId { get; set; } // Nullable

        // prop de navig relation zero one fil producer
        public virtual Producer Producer { get; set; }


    }
}
