using Npgsql;
using SAE201.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class Commande : INotifyPropertyChanged
    {
        private int idCommande;
        private DateTime dateCommande;
        private DateTime dateRetraitPrevue;
        private bool payee;
        private bool retiree;
        private decimal prixTotal;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Commande() { }

        public Commande(DateTime dateCommande, DateTime dateRetraitPrevue, bool payee, bool retiree, decimal prixTotal)
        {
            DateCommande = dateCommande;
            DateRetraitPrevue = dateRetraitPrevue;
            Payee = payee;
            Retiree = retiree;
            PrixTotal = prixTotal;
        }
        public Commande(int idCommande, DateTime dateCommande, DateTime dateRetraitPrevue, bool payee, bool retiree, decimal prixTotal)
            : this(dateCommande, dateRetraitPrevue, payee, retiree, prixTotal)
        {
            IdCommande = idCommande;
        }

        public int IdCommande
        {
            get
            {
                return this.idCommande;
            }
            set
            {
                if (value < 0) throw new ArgumentException("L'ID de commande ne peut pas être négatif.");
                idCommande = value;
                OnPropertyChanged(nameof(IdCommande));
            }
        }

        public DateTime DateCommande
        {
            get
            {
                return this.dateCommande;
            }
            set
            {
                dateCommande = value;
                OnPropertyChanged(nameof(DateCommande));
            }
        }

        public DateTime DateRetraitPrevue
        {
            get
            {
                return this.dateRetraitPrevue;
            }
            set
            {
                dateRetraitPrevue = value;
                OnPropertyChanged(nameof(DateRetraitPrevue));
            }
        }

        public bool Payee
        {
            get
            {
                return this.payee;
            }
            set
            {
                payee = value;
                OnPropertyChanged(nameof(Payee));
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
                retiree = value;
                OnPropertyChanged(nameof(Retiree));
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
                if (value <= 0) throw new ArgumentException("Le prix total doit être supérieur à zéro.");
                prixTotal = value;
                OnPropertyChanged(nameof(PrixTotal));
            }
        }

        private void OnPropertyChanged(string nom)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nom));
        }

        public int Create()
        {
            int nb = 0;
            using (var cmdInsert = new NpgsqlCommand("INSERT INTO commande (datecommande, dateretraitprevue, payee, retiree, prixtotal) VALUES (@date, @retrait, @payee, @retiree, @prix) RETURNING numcommande"))
            {
                cmdInsert.Parameters.AddWithValue("date", this.DateCommande);
                cmdInsert.Parameters.AddWithValue("retrait", this.DateRetraitPrevue);
                cmdInsert.Parameters.AddWithValue("payee", this.Payee);
                cmdInsert.Parameters.AddWithValue("retiree", this.Retiree);
                cmdInsert.Parameters.AddWithValue("prix", this.PrixTotal);
                nb = DataAccess.Instance.ExecuteInsert(cmdInsert);
            }
            this.IdCommande = nb;
            return nb;
        }

        public void Read()
        {
            using (var cmdSelect = new NpgsqlCommand("SELECT * FROM commande WHERE numcommande = @id;"))
            {
                cmdSelect.Parameters.AddWithValue("id", this.idCommande);
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                this.DateCommande = (DateTime)dt.Rows[0]["datecommande"];
                this.DateRetraitPrevue = (DateTime)dt.Rows[0]["dateretraitprevue"];
                this.Payee = (bool)dt.Rows[0]["payee"];
                this.Retiree = (bool)dt.Rows[0]["retiree"];
                this.PrixTotal = (decimal)dt.Rows[0]["prixtotal"];
            }
        }

        public int Update()
        {
            using (var cmdUpdate = new NpgsqlCommand("UPDATE commande SET datecommande = @date, dateretraitprevue = @retrait, payee = @payee, retiree = @retiree, prixtotal = @prix WHERE numcommande = @id"))
            {
                cmdUpdate.Parameters.AddWithValue("date", this.DateCommande);
                cmdUpdate.Parameters.AddWithValue("retrait", this.DateRetraitPrevue);
                cmdUpdate.Parameters.AddWithValue("payee", this.Payee);
                cmdUpdate.Parameters.AddWithValue("retiree", this.Retiree);
                cmdUpdate.Parameters.AddWithValue("prix", this.PrixTotal);
                cmdUpdate.Parameters.AddWithValue("id", this.IdCommande);
                return DataAccess.Instance.ExecuteSet(cmdUpdate);
            }
        }

        public int Delete()
        {
            using (var cmdDelete = new NpgsqlCommand("DELETE FROM commande WHERE numcommande = @id;"))
            {
                cmdDelete.Parameters.AddWithValue("id", this.IdCommande);
                return DataAccess.Instance.ExecuteSet(cmdDelete);
            }
        }

        public static List<Commande> FindAll()
        {
            List<Commande> lesCommandes = new List<Commande>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM commande;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow dr in dt.Rows)
                {
                    lesCommandes.Add(new Commande(
                        (int)dr["numcommande"],
                        (DateTime)dr["datecommande"],
                        (DateTime)dr["dateretraitprevue"],
                        (bool)dr["payee"],
                        (bool)dr["retiree"],
                        (decimal)dr["prixtotal"]
                    ));
                }
            }
            return lesCommandes;
        }

        public override bool Equals(object? obj)
        {
            return obj is Commande c &&
                   this.IdCommande == c.IdCommande &&
                   this.DateCommande == c.DateCommande &&
                   this.DateRetraitPrevue == c.DateRetraitPrevue &&
                   this.Payee == c.Payee &&
                   this.Retiree == c.Retiree &&
                   this.PrixTotal == c.PrixTotal;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.IdCommande, this.DateCommande, this.DateRetraitPrevue, this.Payee, this.Retiree, this.PrixTotal);
        }

        public static List<Commande> TrouverParClient(int idClient)
        {
            List<Commande> commandes = new List<Commande>();
            using (var cmd = new NpgsqlCommand("SELECT * FROM commande WHERE numclient = @id;"))
            {
                cmd.Parameters.AddWithValue("id", idClient);
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmd);

                foreach (DataRow row in dt.Rows)
                {
                    commandes.Add(new Commande(
                        (int)row["numcommande"],
                        (DateTime)row["datecommande"],
                        (DateTime)row["dateretraitprevue"],
                        (bool)row["payee"],
                        (bool)row["retiree"],
                        (decimal)row["prixtotal"]
                    ));
                }
            }
            return commandes;
        }
    }
}
