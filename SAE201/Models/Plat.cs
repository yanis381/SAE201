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

        private int numSousCategorie;
        private int numPeriode;

        public Plat() { }

        public Plat(int idPlat, string nomPlat, decimal prixUnitaire, int delaiPreparation, int nbPersonne, Categorie categorie2, SousCategorie sousCategorie3)
        {
            this.IdPlat = idPlat;
            this.NomPlat = nomPlat;
            this.PrixUnitaire = prixUnitaire;
            this.DelaiPreparation = delaiPreparation;
            this.NbPersonne = nbPersonne;
            this.Categorie2 = categorie2;
            this.SousCategorie3 = sousCategorie3;
        }

        // GETTERS ET SETTERS
        

        public string NomPlat
        {
            get => nomPlat;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Nom vide");
                nomPlat = value;
            }
        }

        public decimal PrixUnitaire
        {
            get => prixUnitaire;
            set
            {
                if (value <= 0) throw new ArgumentException("Prix <= 0");
                prixUnitaire = value;
            }
        }

        public int DelaiPreparation
        {
            get => delaiPreparation;
            set
            {
                if (value <= 0) throw new ArgumentException("Délai négatif");
                delaiPreparation = value;
            }
        }

        public int NbPersonne
        {
            get => nbPersonne;
            set
            {
                if (value <= 0) throw new ArgumentException("Nb personnes <= 0");
                nbPersonne = value;
            }
        }

        public Categorie Categorie2 { get => categorie2; set => categorie2 = value; }

        public SousCategorie SousCategorie3 { get => sousCategorie3; set => sousCategorie3 = value; }

        public int NumSousCategorie { get => numSousCategorie; set => numSousCategorie = value; }

        

        public int IdPlat
        {
            get
            {
                return this.idPlat;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("pas d'id negatif");
                }
                
                this.idPlat = value;
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
                if (value < 0)
                {
                    throw new ArgumentException("pas de numero de periodes");
                }
                this.numPeriode = value;
            }
        }

        public static List<Plat> FindAll()
        {
            List<Plat> lesPlats = new List<Plat>();

            using (NpgsqlCommand cmd = new NpgsqlCommand(
                "SELECT P.numplat, P.nomplat, P.prixunitaire, P.delaipreparation, P.nbpersonnes, " +
                "SC.numSousCategorie, SC.nomSousCategorie, C.numCategorie, C.nomCategorie " +
                "FROM plat P JOIN souscategorie SC ON P.numSousCategorie = SC.numSousCategorie " +
                "JOIN categorie C ON SC.numCategorie = C.numCategorie"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmd);

                foreach (DataRow row in dt.Rows)
                {
                    Categorie cat = new Categorie((int)row["numCategorie"], (string)row["nomCategorie"]);
                    SousCategorie sousCat = new SousCategorie((int)row["numSousCategorie"], (string)row["nomSousCategorie"]);

                    Plat p = new Plat(
                        (int)row["numplat"],
                        (string)row["nomplat"],
                        (decimal)row["prixunitaire"],
                        (int)row["delaipreparation"],
                        (int)row["nbpersonnes"],
                        cat,
                        sousCat
                    );

                    lesPlats.Add(p);
                }
            }
            return lesPlats;
        }

        public int Create(int sousCat, int periode)
        {
            int id;
            using (NpgsqlCommand cmd = new NpgsqlCommand(
                "INSERT INTO plat (nomplat, prixunitaire, delaipreparation, nbpersonnes, numsouscategorie, numperiode) " +
                "VALUES (@nom, @prix, @delai, @nb, @souscat, @periode) RETURNING numplat"))
            {
                cmd.Parameters.AddWithValue("nom", NomPlat);
                cmd.Parameters.AddWithValue("prix", PrixUnitaire);
                cmd.Parameters.AddWithValue("delai", DelaiPreparation);
                cmd.Parameters.AddWithValue("nb", NbPersonne);
                cmd.Parameters.AddWithValue("souscat", sousCat);
                cmd.Parameters.AddWithValue("periode", periode);

                id = DataAccess.Instance.ExecuteInsert(cmd);
            }
            IdPlat = id;
            return id;
        }
    }
}
