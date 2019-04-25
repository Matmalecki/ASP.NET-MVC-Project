using System;
using Xunit;
using DotNet.Controllers;
using Microsoft.AspNetCore.Mvc;
using DotNet.Models;

namespace xUnitDotNetTest
{
    public class HomeControllerTest
    {


        [Fact]
        public void TestHomeIndexController()
        {
            var controller = new HomeController();
            var result = controller.Index() as  ViewResult;
            Assert.Equal("Index", result.ViewName);

        }

        [Fact]
        public void TestHomeAboutByViewData()
        {
            var controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;
            Assert.Equal("Info", result.ViewData["Message"]);
        }

    }
}
