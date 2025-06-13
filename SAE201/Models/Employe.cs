using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SAE201.Models
{
    public class Employe
    {
        private string nomEmploye;
        private string prenomEmploye;
        private string password;
        private string login;
        //private Role RoleEmploye; 

        public Employe(string nomEmploye, string prenomEmploye, string password, string login)
        {
            this.NomEmploye = nomEmploye;
            this.PrenomEmploye = prenomEmploye;
            this.Password = password;
            this.Login = login;
        }

        public string NomEmploye
        {
            get
            {
                return this.nomEmploye;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("met un nom a l'employe");

                }
                this.nomEmploye = value;
            }
        }


        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("met un nom a l'employe");

                }
                this.password = value;
            }
        }

        public string Login
        {
            get
            {
                return this.login;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("met un nom a l'employe");

                }
                this.login = value;
            }
        }

        public string PrenomEmploye
        {
            get
            {
                return this.prenomEmploye;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("met un prenom a l'employe");

                }
                this.prenomEmploye = value;
            }
        }

        public static bool VerifierConnexion(string login, string password)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM employe WHERE login = @login AND password = @password";
                NpgsqlCommand cmd = new NpgsqlCommand(sql);
                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("password", password);

                object res = DataAccess.Instance.ExecuteSelectUneValeur(cmd);
                return res != null && Convert.ToInt32(res) > 0;
            }
            catch (Exception ex)
            {
                LogError.Log(ex, "Erreur lors de la vérification de l'employé.");
                throw;
            }
        }

    }
}
