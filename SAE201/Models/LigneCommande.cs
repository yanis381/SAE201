using System;

namespace SAE201.Models
{
    public class LigneCommande
    {
        public Plat Plat { get; set; }
        public int Quantite { get; set; }
        public decimal Prix { get; set; }

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