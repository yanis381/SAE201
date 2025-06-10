using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
        private Categorie categorie2;
        private SousCategorie sousCategorie3;
        

        public Plat(string nomPlat, decimal prixUnitaire, int delaiPreparation, int nbPersonne)
        {
            this.nomPlat = nomPlat;
            this.prixUnitaire = prixUnitaire;
            this.delaiPreparation = delaiPreparation;
            this.nbPersonne = nbPersonne;
        }

        public Plat(string nomPlat, decimal prixUnitaire, int delaiPreparation, int nbPersonne, Categorie categorie2, SousCategorie sousCategorie3) : this(nomPlat, prixUnitaire, delaiPreparation, nbPersonne)
        {
            this.categorie2 = categorie2;
            this.sousCategorie3 = sousCategorie3;
        }

        public string NomPlat
        {
            get
            {
                return this.nomPlat;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("le plat doit etre nomé");

                }
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
                if(value <= 0)
                {
                    throw new ArgumentException("le prix peut pas etre negatif ou a 0 ");
                }
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
                if(value < 0)
                {
                    throw new ArgumentException("le temps de prepa doit etre positif");
                }
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
                if(value <= 0)
                {
                    throw new ArgumentException(" il doit etre au moins pour une personne");
                }
                this.nbPersonne = value;
            }
        }

        public Categorie Categorie2
        {
            get
            {
                return this.categorie2;
            }

            set
            {
                this.categorie2 = value;
            }
        }

        public SousCategorie SousCategorie3
        {
            get
            {
                return this.sousCategorie3;
            }

            set
            {
                this.sousCategorie3 = value;
            }
        }

        public static List<Plat> FindAll()
        {
            List<Plat> lesPlats = new List<Plat>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from plat P join SousCategorie SC on Sc.numSousCategorie = P.numSousCategorie join Categorie CT on CT.numCategorie = SC.numCategorie join periode Pe on Pe.numPeriode =  P.numPeriode;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow row in dt.Rows)
                    lesPlats.Add(new Plat((String)row["nomplat"], (Decimal)row["prixunitaire"],
                   (int)row["delaipreparation"], (int)row["nbpersonnes"] , new Categorie((int)row["numsouscategorie"], (string)row["nomsouscategorie"] ), new SousCategorie( (int) );
            }

            return lesPlats;
        }
    }
}
