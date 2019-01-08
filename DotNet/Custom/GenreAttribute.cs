﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Custom
{
    public class GenreAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            /* Category category = (Category)validationContext.ObjectInstance;

             if (Regex.Match(category.Subcategories, "(^[A-Z][a-z]+;)+$").Success)
             {
                 return new ValidationResult(GetErrorMessage());
             }
             */
            return ValidationResult.Success;
        }
        private string GetErrorMessage()
        {
            return $"Digits should be separated by colon(;).";
        }
    }
}
