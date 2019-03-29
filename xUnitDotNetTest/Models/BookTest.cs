using DotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace xUnitDotNetTest.Models
{
    public class BookTest
    {

        Book book = new Book()
        {
            Title = "A book title",
            YearOfRelease = 1999,
            Country = "Usa",
            Isbn = "0254802273"
        };
        List<ValidationResult> results = new List<ValidationResult>();

        [Fact]
        public void TestCorrectTitle()
        {
            book.Title = "A book title";
            var validationContext = new ValidationContext(book);

            Assert.True(Validator.TryValidateObject(book, validationContext, results, false));
        }

        [Fact]
        public void TestInCorrectTitle()
        {
            book.Title = "\n";
            var validationContext = new ValidationContext(book);

            Assert.False(Validator.TryValidateObject(book, validationContext, results, false));
        }



    }
}
