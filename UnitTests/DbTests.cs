using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VendorPortal.Data;
namespace UnitTests
{
    [TestClass]
    public class DbTests
    { 
        [TestMethod]
        public void TableExists()
        {
            bool actual = DbUtils.TableExists("AspNetRoles");
            Assert.IsTrue(actual);
        }
    } 
}
