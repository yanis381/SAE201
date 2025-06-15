using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class Contient
    {
        private int quantiter;
        private decimal prix;
        private Plat unplat;

        public Contient(int quantiter)
        {
            this.quantiter = quantiter;
        }

        public Contient(int quantiter, decimal prix)
        {
            this.Quantiter = quantiter;
            this.Prix = prix;
        }

        public int Quantiter
        {
            get
            {
                return this.quantiter;
            }

            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("La quantité doit être comprise entre 1 et 100.");
                }
                this.quantiter = value;
            }
        }

        public decimal Prix
        {
            
            get
            {
                return this.prix;
            }

            set
            {

                if (value <= 0)
                {
                    throw new ArgumentException("valeur Prix inferieur ou egal a 0");

                }

                this.prix = value ;
                    
            }
        }

        public Plat Unplat
        {
            get
            {
                return this.unplat;
            }

            set
            {
                this.unplat = value;
            }
        }
        // calculer le prix de 1 produit avec sa quantiter
        public decimal PrixProduit(Contient contientplat , Plat unplat)
        {
            decimal augmentation = 1;
            decimal prixproduit = unplat.PrixUnitaire; 
            if(contientplat.quantiter > unplat.NbPersonne)
            {
                augmentation = contientplat.quantiter / unplat.NbPersonne;
                  augmentation = 1 +  Math.Round(augmentation, 3)  ;
            }
            return prixproduit * augmentation;  
        }
    }

}
