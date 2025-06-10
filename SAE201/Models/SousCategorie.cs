using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class SousCategorie
    {
        private int idsoucategorie; 
        private string nomSousCategorie;

        public SousCategorie(int idsoucategorie, string nomSousCategorie)
        {
            this.idsoucategorie = idsoucategorie;
            this.nomSousCategorie = nomSousCategorie;
        }

        public int Idsoucategorie
        {
            get
            {
                return this.idsoucategorie;
            }

            set
            {
                this.idsoucategorie = value;
            }
        }

        public string NomSousCategorie
        {
            get
            {
                return this.nomSousCategorie;
            }

            set
            {
                this.nomSousCategorie = value;
            }
        }
    }
}
