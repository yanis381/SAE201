using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class Categorie
    {
        private int idcategorie; 
        private string nomCategorie;

        public Categorie(int idcategorie, string nomCategorie)
        {
            this.Idcategorie = idcategorie;
            this.nomCategorie = nomCategorie;
        }

        public string NomCategorie
        {
            get
            {
                return this.nomCategorie;
            }

            set
            {
                this.nomCategorie = value;
            }
        }

        

        public int Idcategorie
        {
            get
            {
                return this.idcategorie;
            }

            set
            {
                this.idcategorie = value;
            }
        }
    }
}
