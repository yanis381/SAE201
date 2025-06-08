using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAE201.Models;

namespace SAE201.Models
{
    public class Commande
    {
        private DateTime dateCommande;
        private DateTime dateRetraitprevue;
        private bool paiyee;
        private bool retiree;
        private decimal prixTotal;
        private int idCommande;
       

        public Commande()
        {
        }

        public Commande(DateTime dateCommande, DateTime dateRetraitprevue, bool paiyee, bool retiree, decimal prixTotal)
        {

            this.DateCommande = dateCommande;
            this.DateRetraitprevue = dateRetraitprevue;
            this.Paiyee = paiyee;
            this.Retiree = retiree;
            this.PrixTotal = prixTotal;
        }

        public Commande(DateTime dateCommande, DateTime dateRetraitprevue, bool paiyee, bool retiree, decimal prixTotal, int idCommande) : this(dateCommande, dateRetraitprevue, paiyee, retiree, prixTotal)
        {
            this.idCommande = idCommande;
        }

        

        public DateTime DateCommande
        {
            get
            {
                return this.dateCommande;
            }

            set
            {
                this.dateCommande = value;
            }
        }

        public DateTime DateRetraitprevue
        {
            get
            {
                return this.dateRetraitprevue;
            }

            set
            {
                this.dateRetraitprevue = value;
            }
        }

        public bool Paiyee
        {
            get
            {
                return this.paiyee;
            }

            set
            {
                this.paiyee = value;
            }
        }

        public bool Retiree
        {
            get
            {
                return this.retiree;
            }

            set
            {
                this.retiree = value;
            }
        }

        public decimal PrixTotal
        {
            get
            {
                return this.prixTotal;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("le prix doit etre superieur a 0");
                }
                this.prixTotal = value;
            }
        }

        public int IdCommande
        {
            get
            {
                return this.idCommande;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("l'id Commande ne peut etre negatif");
                }
                this.idCommande = value;
            }
        }

        

        public List<Commande> FindAll()
        {
            List<Commande> lesCommandes = new List<Commande>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("select * from commande ;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                    lesCommandes.Add(new Commande(DateTime.Parse((string)dr["datecommande"]), DateTime.Parse( (string)dr["dateretraitprevue"]),
                   (Boolean)dr["payee"], (Boolean)dr["retiree"], Decimal.Parse((string)dr["prixtotal"]), (int)dr["numcommande"]));
            }
            return lesCommandes;
        }

    }
}
