using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Core.ValidationAttributes
{   
    public class IBookValidationAttributes
    {
        // test attribute
        //[checkCountry(AllowLetters= "hh", ErrorMessage = ("Please choose a valid country eg.(India,Pakistan,Nepal"))]
        public sealed class checkCountry : ValidationAttribute
        {
            public String AllowLetters { get; set; }
            public new String ErrorMessage { get; set; }
            protected override ValidationResult IsValid(object bookName, ValidationContext validationContext)
            {
                //string[] myarr = AllowCountry.ToString().Split(',');
                if (((String)bookName).Contains(AllowLetters))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
        }

        // test attribute
        //[isEqual("CategoryId")]
        public class isEqual : ValidationAttribute
        {
            private readonly string _comparisonProperty;

            public isEqual(string comparisonProperty)
            {
                _comparisonProperty = comparisonProperty;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                ErrorMessage = ErrorMessageString;
                int rating = (int)value;

                var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

                if (property == null)
                    throw new ArgumentException("Property with this name not found");

                int comparisonValue = (int)property.GetValue(validationContext.ObjectInstance);

                if (rating > comparisonValue)
                    return new ValidationResult(ErrorMessage);

                return ValidationResult.Success;
            }
        }
    }      
}
