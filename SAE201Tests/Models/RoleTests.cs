using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE201.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models.Tests
{
    [TestClass()]
    public class RoleTests
    {
        [TestMethod()]
        public void RoleTest()
        {
           
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void AucunRole_Donnée()
        {
            Role emp = new Role("  ");
        }
    }
}