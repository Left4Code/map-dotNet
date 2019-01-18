using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Formation.Presentation.Models
{
    public class FilmVm
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Genre { get; set; }
    }
}