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

        public string NomPlat
        {
            get
            {
                return this.nomPlat;
            }

            set
            {
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
                this.nbPersonne = value;
            }
        }
    }
}
