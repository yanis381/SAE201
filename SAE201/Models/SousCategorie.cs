using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class SousCategorie
    {
        private int idsoucategorie; 
        private string nomSousCategorie;

        public SousCategorie() { }

        public SousCategorie(int idsoucategorie, string nomSousCategorie)
        {
            this.Idsoucategorie = idsoucategorie;
            this.NomSousCategorie = nomSousCategorie;
        }

        public int Idsoucategorie
        {
            get
            {
                
                return this.idsoucategorie;
            }

            set
            {
                if(value <0)
                {
                    throw new ArgumentException("sous categorie ");
                }
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("il faut donner un nom de sous categorie ");
                }
                    this.nomSousCategorie = value;
            }
        }
        public static List<SousCategorie> FindAll()
        {
            List<SousCategorie> lesSousCatgories = new List<SousCategorie>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from  SousCategorie;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow row in dt.Rows)
                    lesSousCatgories.Add(new SousCategorie((int)row["numsouscategorie"], (String)row["nomsouscategorie"] ));
            }

            return lesSousCatgories;
        }
    }
}
