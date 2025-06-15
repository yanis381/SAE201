using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE201.Models;
using System;

namespace SAE201.Models.Tests
{
    [TestClass()]
    public class RoleTests
    {
        [TestMethod()]
        public void RoleTest_Valid()
        {
            Role r = new Role("Responsable magasin");
            Assert.AreEqual("Responsable magasin", r.NomRole);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Le rôle ne peut pas être vide.")]
        public void RoleTest_Vide()
        {
            Role r = new Role("   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Le rôle ne peut pas être null.")]
        public void RoleTest_Null()
        {
            Role r = new Role(null);
        }
    }
}
