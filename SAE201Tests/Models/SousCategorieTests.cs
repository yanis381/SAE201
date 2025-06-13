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
    public class SousCategorieTests
    {
        [TestMethod()]
        public void SousCategorieTest()
        {

        }

        [TestMethod()]
        public void SousCategorieTest1()
        {

        }

        [TestMethod()]
        public void FindAllTest()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void IdSousCat_Negatif()
        {
           SousCategorie sscat = new SousCategorie(-1, "charcuterie");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void NomSousCategorie_Vide()
        {
            SousCategorie sscat = new SousCategorie(4, "  ");
        }

    }
}

namespace SAE201Tests.Models
{
    internal class SousCategorieTests
    {
    }
}
