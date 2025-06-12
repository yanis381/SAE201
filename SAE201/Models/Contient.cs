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
            this.quantiter = quantiter;
            this.prix = prix;
        }

        public int Quantiter
        {
            get
            {
                return this.quantiter;
            }

            set
            {
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
