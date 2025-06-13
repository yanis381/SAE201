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
    public class ContientTests
    {
        [TestMethod()]
        public void ContientTest()
        {

        }

        [TestMethod()]
        public void ContientTest1()
        {

        }

        [TestMethod()]
        public void PrixProduitTest()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void PrixAZero()
        {
           Contient ct = new Contient(2 , 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void PrixInferieurAZero()
        {
            Contient ct = new Contient(2, -1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void QuantiterAZero()
        {
            Contient ct = new Contient(0, 2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void QuantiterInferieurAZero()
        {
            Contient ct = new Contient(-2, 2);
        }
    }
}