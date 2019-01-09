using DotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Custom
{
    public class YearOfReleaseAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Book book = (Book)validationContext.ObjectInstance;

            if (book.YearOfRelease > DateTime.Now.Year || book.YearOfRelease < 1753)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
        private string GetErrorMessage()
        {
            return $"Year of release can't be in the future.";
        }


    }
}
