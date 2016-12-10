using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST356Final.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        
        [Required]
        [Display(Name = "Subject")]
        [StringLength(64)]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "Class Number")]
        [RegularExpression(@"^\d+$")]
        public string ClassNumber { get; set; }

        [Required]
        [Display(Name = "Class Name")]
        [StringLength(32)]
        public string ClassName { get; set; }

        public List<Student> Students { get; set; }
    }
}