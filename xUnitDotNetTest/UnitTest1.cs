using System;
using Xunit;
using DotNet.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace xUnitDotNetTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void TestHomeIndexController()
        {
            var controller = new HomeController();
            var result = controller.Index() as  ViewResult;
            Assert.Equal("Index", result.ViewName);

        }
    }
}
