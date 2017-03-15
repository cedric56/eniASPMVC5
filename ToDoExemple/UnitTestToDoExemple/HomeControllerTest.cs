using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoExemple.Controllers;

namespace UnitTestToDoExemple
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public void UnitTestMethod()
        {
            HomeController c = new HomeController();
            string s = c.UnitTest();
            Assert.AreEqual(s, "Hello Test");
        }
    }
}
