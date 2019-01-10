using DotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNet.Custom
{
    public class GenreAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Book book = (Book)validationContext.ObjectInstance;

             if (!Regex.Match(book.Genre, "^([A-Z][a-z]+[ ]?)+([;]([A-Z][a-z]+[ ]?)+)*$").Success || !checkGenres(book.Genre))
             {
                 return new ValidationResult(GetErrorMessage());
             }
             
            return ValidationResult.Success;
        }
        private string GetErrorMessage()
        {
            return $"More than 1 genre should be seperated with colon. Multiple genres mustn't have duplicates.";
        }

        private bool checkGenres(string genre)
        {
            var list = genre.Split(";");
            var duplicates = list.GroupBy(s => s).SelectMany(g => g.Skip(1));

            if (duplicates.Count() > 0)
                return false;
            return true;
        }
    }
}
