using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class Plat
    {
        private string nomPlat;
        private decimal prixUnitaire;
        private int delaiPreparation;
        private int nbPersonne;

        public Plat(string nomPlat, decimal prixUnitaire, int delaiPreparation, int nbPersonne)
        {
            this.nomPlat = nomPlat;
            this.prixUnitaire = prixUnitaire;
            this.delaiPreparation = delaiPreparation;
            this.nbPersonne = nbPersonne;
        }

        public string NomPlat
        {
            get
            {
                return this.nomPlat;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("le plat doit etre nomé");

                }
                this.nomPlat = value;
            }
        }

        public decimal PrixUnitaire
        {
            get
            {
                return this.prixUnitaire;
            }

            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("le prix peut pas etre negatif ou a 0 ");
                }
                this.prixUnitaire = value;
            }
        }

        public int DelaiPreparation
        {
            get
            {
                return this.delaiPreparation;
            }

            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("le temps de prepa doit etre positif");
                }
                this.delaiPreparation = value;
            }
        }

        public int NbPersonne
        {
            get
            {
                return this.nbPersonne;
            }

            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(" il doit etre au moins pour une personne");
                }
                this.nbPersonne = value;
            }
        }
    }
}
