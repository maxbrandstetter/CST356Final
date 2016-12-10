using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CST356Final.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(32)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(32)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [StringLength(64)]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Years Experience")]
        [RegularExpression(@"^\d+$")]
        public string YearsExperience { get; set; }

        public List<Class> Classes { get; set; }

        public string User { get; set; }

        [NotMapped]
        public bool Senior { get; set; }
    }
}