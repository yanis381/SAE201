using Npgsql;
using SAE201.Pages;
using SAE201.UCPages;
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
        private int idPlat;
        private string nomPlat;
        private decimal prixUnitaire;
        private int delaiPreparation;
        private int nbPersonne;
        private Categorie categorie2;
        private SousCategorie sousCategorie3;
        private string nomSousCategorie;
        private int numSousCategorie;
        private int numPeriode;

        public Plat()
        {
        }

        public Plat(string nomPlat, decimal prixUnitaire, int delaiPreparation, int nbPersonne)
        {
            this.nomPlat = nomPlat;
            this.prixUnitaire = prixUnitaire;
            this.delaiPreparation = delaiPreparation;
            this.nbPersonne = nbPersonne;
        }
        public Plat(int id, string nomPlat, decimal prixUnitaire, int delaiPreparation, int nbPersonne, Categorie categorie2, SousCategorie sousCategorie3)
    : this(nomPlat, prixUnitaire, delaiPreparation, nbPersonne, categorie2, sousCategorie3)
        {
            this.idPlat = id;
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

        public int NumSousCategorie
        {
            get
            {
                
                return this.numSousCategorie;
            }

            set
            {
                this.numSousCategorie = value;
            }
        }

        public int NumPeriode
        {
            get
            {
                return this.numPeriode;
            }

            set
            {
                this.numPeriode = value;
            }
        }

        public int IdPlat
        {
            get
            {
                return this.idPlat;
            }

            set
            {
                this.idPlat = value;
            }
        }

        public static List<Plat> FindAll()
        {
            /*List<Categorie> listC = Categorie.FindAll();*/
            List<SousCategorie> listSC = SousCategorie.FindAll();
            List<Plat> lesPlats = new List<Plat>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from plat P join SousCategorie SC on Sc.numSousCategorie = P.numSousCategorie join Categorie CT on CT.numCategorie = SC.numCategorie join periode Pe on Pe.numPeriode =  P.numPeriode;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow row in dt.Rows)
                    lesPlats.Add(new Plat(
                        (int)row["numplat"],
                        (string)row["nomplat"],
                        (decimal)row["prixunitaire"],
                        (int)row["delaipreparation"],
                        (int)row["nbpersonnes"],
                        new Categorie((int)row["numcategorie"], (string)row["nomcategorie"]),
                        new SousCategorie((int)row["numsouscategorie"], (string)row["nomsouscategorie"])
));
            }

            return lesPlats;
        }
        public int Create(int souscat , int numperiodess)
        {
            int nb = 0;
            
            using (var cmdInsert = new NpgsqlCommand("INSERT INTO plat (nomplat, prixunitaire, delaipreparation , nbpersonnes, numsouscategorie , numperiode) VALUES (@nomplat, @prixunitaire, @delaipreparation , @nbpersonnes, @numsouscategorie , @numperiode) RETURNING numplat"))
            {
                cmdInsert.Parameters.AddWithValue("nomplat", this.NomPlat ) ;
                cmdInsert.Parameters.AddWithValue("prixunitaire", this.PrixUnitaire);
                cmdInsert.Parameters.AddWithValue("delaipreparation",this.DelaiPreparation);
                cmdInsert.Parameters.AddWithValue("nbpersonnes", this.NbPersonne);

                cmdInsert.Parameters.AddWithValue("numsouscategorie", souscat);
                cmdInsert.Parameters.AddWithValue("numperiode", numperiodess);

                nb = DataAccess.Instance.ExecuteInsert(cmdInsert);
            }
            this.IdPlat = nb;
            return nb;
        }
        public override string ToString()
        {
            return $"{NomPlat} - {PrixUnitaire}€";
        }
    }
}
