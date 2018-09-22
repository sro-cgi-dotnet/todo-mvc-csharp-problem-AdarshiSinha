using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace helloworld.Models
{ 
    public class Checklist
    {
        [Key]
        public int checkid{get; set;}
        [Required]
        [MaxLength(200)]
        public string write { get; set; }
        [Required]
        // [MaxLength(500)]
        public bool ischecked { get; set; }
        public int id{get; set;}
        
    }
}