using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class Clients
    {
        private string nomClient;
        private string prenomClient;
        private string telClient;
        private string adresseRue; 
        private string adresseCodePostal;
        private string adresseVille;

        public Clients(string nomClient, string prenomClient, string telClient, string adresseRue, string adresseCodePostal, string adresseVille)
        {
            this.NomClient = nomClient;
            this.PrenomClient = prenomClient;
            this.TelClient = telClient;
            this.AdresseRue = adresseRue;
            this.AdresseCodePostal = adresseCodePostal;
            this.AdresseVille = adresseVille;
        }

        public string NomClient
        {
            get
            {
                return this.nomClient;
            }

            set
            {
                this.nomClient = value;
            }
        }

        public string PrenomClient
        {
            get
            {
                return this.prenomClient;
            }

            set
            {
                this.prenomClient = value;
            }
        }

        public string TelClient
        {
            get
            {
                return this.telClient;
            }

            set
            {
                this.telClient = value;
            }
        }

        public string AdresseRue
        {
            get
            {
                return this.adresseRue;
            }

            set
            {
                this.adresseRue = value;
            }
        }

        public string AdresseCodePostal
        {
            get
            {
                return this.adresseCodePostal;
            }

            set
            {
                this.adresseCodePostal = value;
            }
        }

        public string AdresseVille
        {
            get
            {
                return this.adresseVille;
            }

            set
            {
                this.adresseVille = value;
            }
        }
    }
}
