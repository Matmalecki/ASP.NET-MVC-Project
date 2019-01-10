using DotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^([A-Z][a-zA-Z""'\s-]+)$")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^([A-Z][a-zA-Z""'\s-]+)$")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfBirth { get; set; }


        [Display(Name = "Email address")]
        [EmailAddress]
        public string Email { get; set; }


        public string FullName
        {
            get { return LastName + " " + FirstName; }
        }




    }
}