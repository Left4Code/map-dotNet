using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Formation.Presentation.Models
{   
    public enum GenreVM
    {
        drama,
        comedie
    }
    public class FilmVm
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public GenreVM Genre { get; set; }
        //public IEnumerable<SelectListItems> Producers { get; set; }
    }
}