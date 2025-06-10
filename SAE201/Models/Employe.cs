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
        private string prenomEmploye;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("met un nom a l'employe");

                }
                this.nomEmploye = value;
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

        public string PrenomEmploye
        {
            get
            {
                return this.prenomEmploye;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("met un prennom a l'employe");

                }
                this.prenomEmploye = value;
            }
        }
    }
}
