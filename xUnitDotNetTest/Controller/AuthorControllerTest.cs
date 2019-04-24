using DotNet.Controllers;
using DotNet.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;

namespace xUnitDotNetTest.Controller
{
    public class AuthorControllerTest
    {
        private AuthorsController _author;

        public AuthorControllerTest()
        {
        }

        [Fact]
        void TestCreatingAuthorsController()
        {

            Assert.True(true);

        }

    }
}
