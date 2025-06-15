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
            public void ContientTest_ConstructeurQuantite()
            {
                var contient = new Contient(3);
                Assert.AreEqual(3, contient.Quantiter);
            }

            [TestMethod()]
            public void ContientTest_ConstructeurComplet()
            {
                var contient = new Contient(5, 25m);
                Assert.AreEqual(5, contient.Quantiter);
                Assert.AreEqual(25m, contient.Prix);
            }

            [TestMethod()]
            public void PrixProduitTest_NormalCase()
            {
                var plat = new Plat()
                {
                    PrixUnitaire = 10,
                    NbPersonne = 2
                };

                var contient = new Contient(4);
                decimal prix = contient.PrixProduit(contient, plat);
                Assert.IsTrue(prix > 0);
            }
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