using DotNet.Custom;
using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Title")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Year of release")]
        public int YearOfRelease { get; set; }

        [Required]
        [Display(Name = "ISBN")]
        [Isbn]
        public string Isbn { get; set; }

        [Genre]
        public string Genre { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

    }
}
