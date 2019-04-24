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

        private Book _book;
        private List<ValidationResult> _results;

        public BookTest()
        {
            _book = new Book()
            {
                Title = "A book title",
                YearOfRelease = 1999,
                Country = "Usa",
                Isbn = "0254802273"
            };
            _results = new List<ValidationResult>();
        }

        [Fact]
        public void TestCorrectTitle()
        {
            _book.Title = "A book title";
            var validationContext = new ValidationContext(_book);

            Assert.True(Validator.TryValidateObject(_book, validationContext, _results, true));
        }

        [Fact]
        public void TestInCorrectTitle()
        {
            _book.Title = "\n";
            var validationContext = new ValidationContext(_book);

            Assert.False(Validator.TryValidateObject(_book, validationContext, _results, true));
        }

        [Fact]
        public void TestCorrectBook()
        {
            var validationContext = new ValidationContext(_book);

            Assert.True(Validator.TryValidateObject(_book, validationContext, _results, true));
        }


        [Fact]
        public void TestInCorrectISBNByNumberOfDigits()
        {
            _book.Isbn = "02";
            var validationContext = new ValidationContext(_book);

            Assert.False(Validator.TryValidateObject(_book, validationContext, _results, true));
        }

        [Fact]
        public void TestInCorrectISBNByWrongSum()
        {
            _book.Isbn = "0254803373";
            var validationContext = new ValidationContext(_book);

            Assert.False(Validator.TryValidateObject(_book, validationContext, _results, true));
        }

        [Fact]
        public void TestInCorrectISBNByWrongCountry()
        {
            _book.Isbn = "1254803323";
            var validationContext = new ValidationContext(_book);

            Assert.False(Validator.TryValidateObject(_book, validationContext, _results, true));
        }


    }
}
