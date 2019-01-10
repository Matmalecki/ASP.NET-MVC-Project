using DotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Custom
{
    public class IsbnAttribute : ValidationAttribute
    {
        private string _country;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Book book = (Book)validationContext.ObjectInstance;
            _country = book.Country;

            if (!checkIsbn(book.Isbn))
            {
                return new ValidationResult(GetErrorMessage());
            }
            if (!checkCountry(book.Isbn))
            {
                return new ValidationResult(GetErrorMessage());
            }
            
            return ValidationResult.Success;
        }

        private bool checkIsbn(string isbn)
        {
            isbn = new string((from c in isbn where char.IsDigit(c) select c).ToArray());
            if (isbn.Length != 10)
                return false;
            int sum = 0, pom;        
            for (int i = 0; i < 9; i++)
            {
                if (!int.TryParse(isbn[i].ToString(), out pom))
                    return false;
                sum += (i + 1) * pom;
            }
                
            int remainder = sum % 11;
            if (remainder == 10)
                return isbn[9] == 'X';
            else
                return isbn[9] == (char)('0' + remainder);

        }

        bool checkCountry(string isbn)
        {
            string iCountry ="";
            switch(isbn[0])
            {
                case '0':
                    iCountry = "Usa";
                    break;
                case '1':
                    iCountry = "Usa";
                    break;
                case '2':
                    iCountry = "France";
                    break;
                case '3':
                    iCountry = "Germany";
                    break;
                default:
                    break;
            }
            if (iCountry != _country)
                return false;
            return true;
        }

        private string GetErrorMessage()
        {
            return $"Incorrect 10 digit ISBN code.";
        }

    }
}
