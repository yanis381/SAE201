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
    public class PlatTests
    {
        [TestMethod()]
        public void PlatTest()
        {

        }

        [TestMethod()]
        public void PlatTest1()
        {

        }

        [TestMethod()]
        public void FindAllTest()
        {

        }

        [TestMethod()]
        public void CreateTest()
        {

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void IdPlats_Negatif()
        {
            SousCategorie sscat = new SousCategorie(1, "charcuterie");
            Categorie cat = new Categorie();
            Plat plat = new Plat(-1, "nomdeplat", 22, 2, 2, cat, sscat);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void nomplatvide_Negatif()
        {
            SousCategorie sscat = new SousCategorie(1, "charcuterie");
            Categorie cat = new Categorie();
            Plat plat = new Plat(1, "    ", 22, 2, 2, cat, sscat);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void Prix_Negatif()
        {
            SousCategorie sscat = new SousCategorie(1, "charcuterie");
            Categorie cat = new Categorie();
            Plat plat = new Plat(1, "test", -22, 2, 2, cat, sscat);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void Prix_egalAZero()
        {
            SousCategorie sscat = new SousCategorie(1, "charcuterie");
            Categorie cat = new Categorie();
            Plat plat = new Plat(1, "test", 0, 2, 2, cat, sscat);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void Preparation_egalAZero()
        {
            SousCategorie sscat = new SousCategorie(1, "charcuterie");
            Categorie cat = new Categorie();
            Plat plat = new Plat(1, "test", 22, 0, 2, cat, sscat);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void Preparation_inferieurAZero()
        {
            SousCategorie sscat = new SousCategorie(1, "charcuterie");
            Categorie cat = new Categorie();
            Plat plat = new Plat(1, "test", 22, -3, 2, cat, sscat);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void NbPersonne_inferieurAZero()
        {
            SousCategorie sscat = new SousCategorie(1, "charcuterie");
            Categorie cat = new Categorie();
            Plat plat = new Plat(1, "test", 22, 3, -1, cat, sscat);



        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void NbPersonne_AZero()
        {
            SousCategorie sscat = new SousCategorie(1, "charcuterie");
            Categorie cat = new Categorie();
            Plat plat = new Plat(1, "test", 22, 3, 0, cat, sscat);
        }
    }
}