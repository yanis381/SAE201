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
            Clients cll = new Clients(2, "SAVY", "Alexandre", "0785835105", "nom de la rue", "1", "Annecy");
            Assert.AreEqual("SAVY", cll.NomClient, "pas le bon nom");
            Assert.AreEqual("Alexandre", cll.PrenomClient, "pas bon le prenom");
            Assert.AreEqual("nom de la rue", cll.AdresseRue, "pas la bonne rue");

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
             Clients c1 = new Clients(1, "A", "B", "0606060606", "Rue", "75000", "Paris");
             Clients c2 = new Clients(1, "A", "B", "0606060606", "Rue", "75000", "Paris");
            Assert.IsTrue(c1.Equals(c2));
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void CodepostalEgalAzero()
        {
            Clients cll = new Clients(2, "SAVY", "Alexandre", "0785835105", "nom de la rue ", "0", "Annecy");
        }
        

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void numtelmoinsdedixNum()
        {
            Clients cll = new Clients(2, "SAVY", "Alexandre", "078580", "nom de la rue ", "3", "Annecy");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void numtelAudessusDeDixNum()
        {
            Clients cll = new Clients(2, "SAVY", "Alexandre", "0785851454151514514545454545454545454545454505", "nom de la rue ", "3", "Annecy");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void numtelvide()
        {
            Clients cll = new Clients(2, "SAVY", "Alexandre", "  ", "nom de la rue ", "3", "Annecy");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void numtel_QuiEstPasEnNombre()
        {
            Clients cll = new Clients(2, "SAVY", "Alexandre", "zero six", "nom de la rue ", "3", "Annecy");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void AdreeseVille_Vide()
        {
            Clients cll = new Clients(2, "SAVY", "Alexandre", "0785735105", "nom de la rue ", "3", "  ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void Prenom_Vide()
        {
            Clients cll = new Clients(2, "SAVY", "", "0785735105", "nom de la rue ", "3", "Annecy");
        }
    }
}