﻿using DotNet.Controllers;
using DotNet.Data;
using DotNet.Models;
using DotNetTest.Repository;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DotNetTest.Controller
{
    public class BookControllerTest
    {

        private BooksController booksController;


        public BookControllerTest()
        {
           
        }

        [Fact]
        void TestShowingIndexOfBooksByType()
        {
            var dbContext = new FakeContext();
            dbContext.Books = new[]
            {
                new Book(), new Book(), new Book()
            }.AsQueryable();

            booksController = new BooksController(dbContext);
            var result = booksController.Index("") as ViewResult;
            Assert.Equal(typeof(List<Book>), result.Model.GetType());

        }

        [Fact]
        void TestShowingIndexOfBooksByCount()
        {
            var dbContext = new FakeContext();
            dbContext.Books = new[]
            {
                new Book(), new Book(), new Book()
            }.AsQueryable();

            booksController = new BooksController(dbContext);
            var result = booksController.Index("") as ViewResult;
            var booksResult = (result.Model as IEnumerable<Book>);
            Assert.Equal(3, booksResult.Count());

        }

        [Fact]
        void TestShowingOnlySearchedBooks()
        {
            Author testAuthor = new Author() { FirstName = "aaa", LastName = "bbb" };
            var dbContext = new FakeContext();
            dbContext.Books = new[]
            {
                new Book() { Title="Abc", Author = testAuthor, Isbn="1122334455", Country="Usa",
                    },
                new Book()
                    { Title="BCC", Author = testAuthor, Isbn="1122334455", Country="Usa", },
                new Book(){ Title = "Abcab", Author = testAuthor, Isbn="1122334455", Country="Usa", }
            }.AsQueryable();

            booksController = new BooksController(dbContext);
            var result = booksController.Index("Ab") as ViewResult;
            var booksResult = (result.Model as IEnumerable<Book>);
            Assert.Equal(2, booksResult.Count());
        }
    }
}
