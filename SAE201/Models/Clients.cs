using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class Clients : INotifyPropertyChanged
    {
        private int numClient;
        private string nomClient;
        private string prenomClient;
        private string telClient;
        private string adresseRue;
        private string adresseCodePostal;
        private string adresseVille;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Clients()
        {
        }

        public Clients(int id, string nom, string prenom, string tel, string rue, string cp, string ville)
        {
            this.numClient = id;
            this.nomClient = nom;
            this.prenomClient = prenom;
            this.telClient = tel;
            this.adresseRue = rue;
            this.adresseCodePostal = cp;
            this.adresseVille = ville;
        }

        public Clients(string nom, string prenom, string tel, string rue, string cp, string ville)
        {
            this.nomClient = nom;
            this.prenomClient = prenom;
            this.telClient = tel;
            this.adresseRue = rue;
            this.adresseCodePostal = cp;
            this.adresseVille = ville;
        }

        public int NumClient
        {
            get
            {
                return this.numClient;
            }

            set
            {
                this.numClient = value;
            }
        }


        public string NomClient
        {
            get
            {
                return this.nomClient;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("met un nom au client");

                }
                this.nomClient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NomClient)));
            }
        }

        public string PrenomClient
        {
            get
            {
                return this.prenomClient;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("met un prenom au client");

                }
                this.prenomClient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PrenomClient)));
            }
        }

        public string TelClient
        {
            get
            {
                return this.telClient;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("vous devez donnez un numero de tel ");

                }
                else if (value.Length > 10)
                {
                    throw new ArgumentException("le num de tel est trop long");
                }
                else if (value.Length < 10)
                {
                    throw new ArgumentException(" le num de tel est trop cout");
                }
                this.telClient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TelClient)));
            }
        }

        public string AdresseRue
        {
            get
            {
                return this.adresseRue;
            }

            set
            {
                this.adresseRue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AdresseRue)));
            }
        }

        public string AdresseCodePostal
        {
            get
            {
                return this.adresseCodePostal;
            }

            set
            {
                this.adresseCodePostal = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AdresseCodePostal)));
            }
        }

        public string AdresseVille
        {
            get
            {
                return this.adresseVille;
            }

            set
            {
                this.adresseVille = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AdresseVille)));
            }
        }
        public int Create()
        {
            using var cmd = new NpgsqlCommand(@"INSERT INTO client 
                (nomclient, prenomclient, tel, adresserue, adressecp, adresseville) 
                VALUES (@nom, @prenom, @tel, @rue, @cp, @ville) RETURNING numclient");

            cmd.Parameters.AddWithValue("nom", this.NomClient);
            cmd.Parameters.AddWithValue("prenom", this.PrenomClient);
            cmd.Parameters.AddWithValue("tel", this.TelClient);
            cmd.Parameters.AddWithValue("rue", this.AdresseRue);
            cmd.Parameters.AddWithValue("cp", this.AdresseCodePostal);
            cmd.Parameters.AddWithValue("ville", this.AdresseVille);

            this.NumClient = DataAccess.Instance.ExecuteInsert(cmd);
            return this.NumClient;
        }

        public void Read()
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM client WHERE numclient = @id;");
            cmd.Parameters.AddWithValue("id", this.NumClient);

            DataTable dt = DataAccess.Instance.ExecuteSelect(cmd);
            if (dt.Rows.Count > 0)
            {
                this.NomClient = dt.Rows[0]["nomclient"].ToString();
                this.PrenomClient = dt.Rows[0]["prenomclient"].ToString();
                this.TelClient = dt.Rows[0]["tel"].ToString();
                this.AdresseRue = dt.Rows[0]["adresserue"].ToString();
                this.AdresseCodePostal = dt.Rows[0]["adressecp"].ToString();
                this.AdresseVille = dt.Rows[0]["adresseville"].ToString();
            }
        }

        public int Update()
        {
            using var cmd = new NpgsqlCommand(@"UPDATE client SET 
                nomclient = @nom, prenomclient = @prenom, tel = @tel, 
                adresserue = @rue, adressecp = @cp, adresseville = @ville 
                WHERE numclient = @id");

            cmd.Parameters.AddWithValue("nom", this.NomClient);
            cmd.Parameters.AddWithValue("prenom", this.PrenomClient);
            cmd.Parameters.AddWithValue("tel", this.TelClient);
            cmd.Parameters.AddWithValue("rue", this.AdresseRue);
            cmd.Parameters.AddWithValue("cp", this.AdresseCodePostal);
            cmd.Parameters.AddWithValue("ville", this.AdresseVille);
            cmd.Parameters.AddWithValue("id", this.NumClient);

            return DataAccess.Instance.ExecuteSet(cmd);
        }

        public int Delete()
        {
            using var cmd = new NpgsqlCommand("DELETE FROM client WHERE numclient = @id;");
            cmd.Parameters.AddWithValue("id", this.NumClient);
            return DataAccess.Instance.ExecuteSet(cmd);
        }

        public static List<Clients> FindAll()
        {
            List<Clients> lesClients = new List<Clients>();
            using (NpgsqlCommand cmdSelect = new NpgsqlCommand("SELECT * FROM client;"))
            {
                DataTable dt = DataAccess.Instance.ExecuteSelect(cmdSelect);
                foreach (DataRow row in dt.Rows)
                    lesClients.Add(new Clients((Int32)row["numclient"], (String)row["nomclient"],
                   (String)row["prenomclient"], (String)row["tel"], (String)row["adresserue"],
                   (String)row["adressecp"], (String)row["adresseville"]));
            }

            return lesClients;
        }

        public override bool Equals(object? obj)
        {
            return obj is Clients client &&
                   NumClient == client.NumClient &&
                   NomClient == client.NomClient &&
                   PrenomClient == client.PrenomClient &&
                   TelClient == client.TelClient &&
                   AdresseRue == client.AdresseRue &&
                   AdresseCodePostal == client.AdresseCodePostal &&
                   AdresseVille == client.AdresseVille;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NumClient, NomClient, PrenomClient, TelClient, AdresseRue, AdresseCodePostal, AdresseVille);
        }
    }
}
