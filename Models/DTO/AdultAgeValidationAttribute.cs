using System.ComponentModel.DataAnnotations;
namespace StudentMngmt.Models.DTO
{
    public class AdultAgeValidationAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var age = int.Parse(value.ToString());
            if (age > 18)
            {
                return true;
            }
            return false;
        }
    }
}