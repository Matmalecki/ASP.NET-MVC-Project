﻿using DotNet.Controllers;
using DotNet.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace xUnitDotNetTest.Controller
{
    public class AuthorControllerTest
    {
        private AuthorsController _author;

        [Fact]
        void TestCreatingAuthorsController()
        {

            var context = new Mock<IApplicationDbContext>();

            _author = new AuthorsController(context.Object);
            Assert.NotNull(_author);
        }

        [Fact]
        void TestGettingAllAuthors()
        {
            var authors = new List<Author>
            {
                new Author() { FirstName ="A", LastName="B", DateOfBirth= new DateTime(1990,11,11)},
                new Author() { FirstName ="D", LastName="Q", DateOfBirth= new DateTime(1977,01,21)},
                new Author() { FirstName ="C", LastName="W", DateOfBirth= new DateTime(1960,11,13) },
            }.AsQueryable();
            var context = new Mock<IApplicationDbContext>();
            context.Setup(x => x.Authors).Returns(authors);

            _author = new AuthorsController(context.Object);

            var result = _author.Index("") as ViewResult;

            Assert.Equal(typeof(List<Author>), result.Model.GetType());

        }

        [Fact]
        void TestGettingDetailsOfAuthorByModel()
        {

            Author author = new Author()
            {
                FirstName = "Test", LastName = "Tests", DateOfBirth = new DateTime(1999, 01, 01)
            };
            var context = new Mock<IApplicationDbContext>();
            context.Setup(a => a.FindAuthorById(1)).Returns(author);
            _author = new AuthorsController(context.Object);
            var result = _author.Details(1) as ViewResult;

            Assert.Equal(author, result.Model);
        }

        [Fact]
        void TestDeleteAuthorByModel()
        {
            Author author = new Author()
            {
                FirstName = "Test",
                LastName = "Tests",
                DateOfBirth = new DateTime(1999, 01, 01)
            };
            var context = new Mock<IApplicationDbContext>();
            context.Setup(a => a.FindAuthorById(1)).Returns(author);
            _author = new AuthorsController(context.Object);
            var result = _author.Delete(1) as ViewResult;

            Assert.Equal(author, result.Model);
        }

        [Fact]
        void TestRedirectingAfterDeleting()
        {
            Author author = new Author()
            {
                FirstName = "Test",
                LastName = "Tests",
                DateOfBirth = new DateTime(1999, 01, 01)
            };
            var context = new Mock<IApplicationDbContext>();
            context.Setup(a => a.FindAuthorById(1)).Returns(author);
            _author = new AuthorsController(context.Object);
            var result = _author.DeleteConfirmed(1) as RedirectToActionResult;

            Assert.Equal("Index", result.ActionName);


        }

    }
}
