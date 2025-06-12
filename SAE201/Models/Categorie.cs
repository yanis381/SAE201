using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class Categorie
    {
        private int idcategorie;
        private string nomCategorie;

        public Categorie() { }

        public Categorie(int idcategorie, string nomCategorie)
        {
            this.Idcategorie = idcategorie;
            this.NomCategorie = nomCategorie;
        }

        public string NomCategorie
        {
            get
            {
                return this.nomCategorie;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value)) { 
                    
                    throw new ArgumentNullException("il faut un nom de categorie");
                }
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
                if (value < 0) {
                    throw new ArgumentOutOfRangeException("il est en dessous de 0");
                        
                        }
                this.idcategorie = value;
            }
        }
        public static List<Categorie> FindAll()
        {
            List<Categorie> lesCatgories = new List<Categorie>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from Categorie;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow row in dt.Rows)
                    lesCatgories.Add(new Categorie((int)row["numcategorie"], (String)row["nomcategorie"]));
            }

            return lesCatgories;
        }
    }
}
