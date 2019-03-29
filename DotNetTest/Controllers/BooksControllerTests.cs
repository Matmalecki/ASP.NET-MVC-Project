using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Controllers;

namespace DotNetTest.Controllers
{

    [TestClass]
    class BooksControllerTests
    {

        [TestMethod]
        public void testIndexController()
        {
            var controller = new BooksController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }


    }
}
