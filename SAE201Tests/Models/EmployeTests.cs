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
    public class EmployeTests
    {
        [TestMethod()]
        public void EmployeTest()
        {

        }

        [TestMethod()]
        public void VerifierConnexionTest()
        {

        }
        

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void Prenom_Vide()
        {
            Employe emp = new Employe("savy", "   ", "lol", "totologin");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void nom_Vide()
        {
            Employe emp = new Employe("  ", "alexandre ", "lol", "totologin");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void password_Vide()
        {
            Employe emp = new Employe("savy ", "alexandre ", "", "totologin");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "categorie cp -1 ")]
        public void login_Vide()
        {
            Employe emp = new Employe("savy ", "alexandre ", "fefeeffefe", "  ");
        }
    }
}