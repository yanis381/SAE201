using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SAE201.Models
{
    public class Employe
    {
        private string nomEmploye;
        private string PrenomEmploye;
        private string password;
        private string login;

        public string NomEmploye
        {
            get
            {
                return this.nomEmploye;
            }

            set
            {
                this.nomEmploye = value;
            }
        }

        public string PrenomEmploye1
        {
            get
            {
                return this.PrenomEmploye;
            }

            set
            {
                this.PrenomEmploye = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        public string Login
        {
            get
            {
                return this.login;
            }

            set
            {
                this.login = value;
            }
        }
    }
}
