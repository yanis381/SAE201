using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class Categorie
    {
        private string nomCategorie;

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
    }
}
