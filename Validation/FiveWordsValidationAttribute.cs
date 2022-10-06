using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace la_mia_pizzeria_static.Validation
{
    public class FiveWordsValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            string fieldValue = (string) value;
            if (fieldValue == null) {
                return ValidationResult.Success;
            }
            string[] explosion = fieldValue.Split(' ');
            if (explosion.Length < 5) {
                return new ValidationResult("Il campo deve contenere almeno 5 parole");
            }
            return ValidationResult.Success;
        }

       
    }
}
