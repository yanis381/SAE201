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






        // Méthode statique permettant de vérifier la connexion d’un employé à la base
        public static bool VerifierConnexion(string login, string password)
        {
            try
            {
                // Requête SQL avec des paramètres pour éviter les injections SQL
                string sql = "SELECT COUNT(*) FROM employe WHERE login = @login AND password = @password";
                // Création d'une commande SQL en utilisant la requête stockée dans la variable 'sql'
                NpgsqlCommand cmd = new NpgsqlCommand(sql);

                // Ajout du paramètre 'login' à la commande pour remplacer @login dans la requête SQL
                cmd.Parameters.AddWithValue("login", login);

                // Ajout du paramètre 'password' à la commande pour remplacer @password dans la requête SQL
                cmd.Parameters.AddWithValue("password", password);


                // Exécution de la requête via une méthode personnalisée
                object res = DataAccess.Instance.ExecuteSelectUneValeur(cmd);

                // Si le résultat est supérieur à 0, alors l'utilisateur existe
                return res != null && Convert.ToInt32(res) > 0;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, log l'exception et relance l'erreur
                LogError.Log(ex, "Erreur lors de la vérification de l'employé.");
                throw;
            }
        }
    }
}


    

