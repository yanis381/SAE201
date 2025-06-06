using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class Commande
    {
        private DateTime dateCommande;
        private DateTime dateRetraitprevue;
        private bool paiyee;
        private bool retiree;
        private decimal prixTotal;

        public DateTime DateCommande
        {
            get
            {
                return this.dateCommande;
            }

            set
            {
                this.dateCommande = value;
            }
        }

        public DateTime DateRetraitprevue
        {
            get
            {
                return this.dateRetraitprevue;
            }

            set
            {
                this.dateRetraitprevue = value;
            }
        }

        public bool Paiyee
        {
            get
            {
                return this.paiyee;
            }

            set
            {
                this.paiyee = value;
            }
        }

        public bool Retiree
        {
            get
            {
                return this.retiree;
            }

            set
            {
                this.retiree = value;
            }
        }

        public decimal PrixTotal
        {
            get
            {
                return this.prixTotal;
            }

            set
            {
                this.prixTotal = value;
            }
        }
    }
}
