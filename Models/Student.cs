using StudentMngmt.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMngmt.Models
{
    public class Student:IValidatableObject
    {
        public int id { get; set; }
        [Required]
        public string studentName { get; set; }
        public string studentAddress { get; set; }
//        [AdultAgeValidation(ErrorMessage ="Age must be 18 and above")]
        public int studentAge { get; set; }
        public ICollection<Books> books { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var Iage = new[] { "age" };
            if (studentAge < 18)
            {
                yield return new ValidationResult("age can not be less than 18", Iage);
            }
        }
    }
}