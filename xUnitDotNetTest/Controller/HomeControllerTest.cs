using System;
using Xunit;
using DotNet.Controllers;
using Microsoft.AspNetCore.Mvc;

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
    }
}
