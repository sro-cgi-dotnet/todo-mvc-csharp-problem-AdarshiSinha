using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace helloworld.Models
{ 
    public class Label
    {
        [Key]
        public int labelid{get; set;}
        [Required]
        [MaxLength(200)]
        public string text { get; set; }
        
        // [MaxLength(500)]
        public int id{get; set;}
        
    }
}