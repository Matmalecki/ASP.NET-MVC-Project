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
        [RegularExpression(@"^[A-Za-z0-9\s\-_,\.;:()]+$")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required]
        [YearOfRelease]
        [Display(Name = "Year of release")]
        public int YearOfRelease { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(100, ErrorMessage = "Country name cannot be longer than 100 characters.")]
        public string Country { get; set; }



        [Required]
        [Display(Name = "ISBN")]
        [Isbn]
        public string Isbn { get; set; }

        [Genre]
        [StringLength(200, ErrorMessage = "Genres cannot be longer than 200 characters.")]
        [DisplayFormat(NullDisplayText = "No Genres specified")]
        public string Genre { get; set; }

        public int AuthorID { get; set; }
        public Author Author { get; set; }

    }
}
