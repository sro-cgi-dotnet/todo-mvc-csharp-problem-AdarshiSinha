using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace helloworld.Models
{ 
    public class Notes
    {
        [Key]
        public int id{get; set;}
      //  [Required]
        [MaxLength(200)]
        public string title { get; set; }
      //  [Required]
        [MaxLength(500)]
        public string text { get; set; }
      //  [Required]
        // [MaxLength(500)]
        public List<Checklist> checklist  { get; set; }
       // [Required]
        // [MaxLength(500)]
        public Label label{get; set;}
       // [Required]
        public bool pinned {get; set;}
    }
}