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
    public class ClientsTests
    {
        [TestMethod()]
        public void ClientsTest()
        {

        }

        [TestMethod()]
        public void ClientsTest1()
        {

        }

        [TestMethod()]
        public void ClientsTest2()
        {

        }

        [TestMethod()]
        public void CreateTest()
        {

        }

        [TestMethod()]
        public void ReadTest()
        {

        }

        [TestMethod()]
        public void UpdateTest()
        {

        }

        [TestMethod()]
        public void DeleteTest()
        {

        }

        [TestMethod()]
        public void FindAllTest()
        {

        }

        [TestMethod()]
        public void EqualsTest()
        {

        }

        [TestMethod()]
        public void GetHashCodeTest()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "categorie nom ")]
        public void IdclientNegatif()
        {
            Clients cl = new Clients(-1, "test", "test", "test", "test", "test", "test");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "categorie nom ")]
        public void NomNull()
        {
            Clients cll = new Clients(2, null, "test", "test", "test", "test", "test");
            
        }


    }
}