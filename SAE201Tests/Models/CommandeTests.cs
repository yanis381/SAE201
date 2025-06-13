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
    public class CommandeTests
    {
        [TestMethod()]
        public void CommandeTest()
        {

        }

        [TestMethod()]
        public void CommandeTest1()
        {

        }

        [TestMethod()]
        public void CommandeTest2()
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

        [TestMethod()]
        public void TrouverParClientTest()
        {

        }

        [TestMethod()]
        public void calculPrixTotalTest()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void PrixAZero()
        {
            Commande cmd = new Commande(2, new DateTime(2025 ,06 ,13), new DateTime(2025, 06 ,16), true, false, 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void PrixInfAZero()
        {
            Commande cmd = new Commande(2, new DateTime(2025, 06, 13), new DateTime(2025, 06, 16), true, false, -6);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void IdCommandeInfA0()
        {
            Commande cmd = new Commande(-2, new DateTime(2025, 06, 13), new DateTime(2025, 06, 16), true, false, -6);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void CommandePrevueApresDateRetrait()
        {
            Commande cmd = new Commande(-2, new DateTime(2025, 06, 13), new DateTime(2025, 06, 16), true, false, -6);
        }
    }
}