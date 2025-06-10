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
