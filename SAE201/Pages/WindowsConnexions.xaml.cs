using SAE201.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SAE201.Pages;


namespace SAE201.Pages
{
    /// <summary>
    /// Logique d'interaction pour WindowsConnexions.xaml
    /// </summary>
    public partial class PageConnexion : Window
    {



        public PageConnexion()
        {
            InitializeComponent();

        }

        // Événement déclenché lors du clic sur le bouton "Employé" (pour se connecter)
        private void btnEmploye_Click(object sender, RoutedEventArgs e)
        {
            // Récupère le login et le mot de passe entrés par l'utilisateur
                string login = tbLogin.Text;
                string mdp = tbPassword.Password;

            // Appelle la méthode statique du modèle Employe pour vérifier si l'utilisateur existe en base
            if (Employe.VerifierConnexion(login, mdp))
            {
                MessageBox.Show("Connexion réussie !");
                this.Close(); // Ferme la fenêtre de connexion

                
            }
            else
            {
                MessageBox.Show("Identifiants incorrects.");
            }
        }
    }
}



    


    

