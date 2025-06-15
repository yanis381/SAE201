using System;

namespace SAE201.Models
{
    public class LigneCommande
    {
        private Plat plat;
        private int quantite;
        private decimal prix;

        public Plat Plat
        {
            get
            {
                return this.plat;
            }

            set
            {
                this.plat = value;
            }
        }

        public int Quantite
        {
            get
            {
                return this.quantite;
            }

            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(Quantite), "La quantité doit être comprise entre 1 et 100.");
                }
                this.quantite = value;
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
                this.prix = value;
            }
        }
        // Calcule le prix total de la ligne à partir de la quantité et du prix du plat.
        public void CalculerPrix()
        {
            if (Plat != null)
            {
                Contient contient = new Contient(Quantite);
                Prix = contient.PrixProduit(contient, Plat);
            }
        }
    }
}