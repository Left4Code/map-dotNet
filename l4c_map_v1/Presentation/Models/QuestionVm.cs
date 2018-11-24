using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentation.Models
{
    public enum numberChosed
    {
        first,
        second,
        third
    }
    public class QuestionVm
    {
        [Key]
        [JsonIgnore]
        public int idQuestion { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [StringLength(255)]
        public string task { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [StringLength(255)]
        public string syn1 { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [StringLength(255)]
        public string syn2 { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [StringLength(255)]
        public string syn3 { get; set; }
        [StringLength(255)]
        public string correct { get; set; }
        public virtual TestVm test { get; set; }
        [JsonIgnore]
        [Required(ErrorMessage = "this field is required")]
        public numberChosed numberChosed { get; set; }
    }
}