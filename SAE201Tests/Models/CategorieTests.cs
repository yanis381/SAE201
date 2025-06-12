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
    public class CategorieTests
    {
        [TestMethod()]
        public void CategorieTest()
        {

        }

        [TestMethod()]
        public void CategorieTest1()
        {

        }

        [TestMethod()]
        public void FindAllTest()
        {

        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "categorie nom ")]
        public void idcategorienegatif()
        {
            Categorie cat = new Categorie(-1 , "test");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "categorie nom ")] 
        public void NomNull()
        {
            Categorie cat = new Categorie(-1, "");

        }
        
    }
}