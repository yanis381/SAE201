using SAE201.Models;
using System;
using System.Windows;

namespace SAE201.Pages
{
    public partial class ModifierCommande : Window
    {

        private Commande CommandeCreee;

        public Commande CommandeCreee1
        {
            get
            {
                return this.CommandeCreee;
            }

            set
            {
                this.CommandeCreee = value;
            }
        }

        public ModifierCommande(Commande commande)
        {
            InitializeComponent();
            this.CommandeCreee1 = commande;
            this.DataContext = CommandeCreee1;

            // Initialiser l'affichage
            InitialiserInterface();
        }

        private void InitialiserInterface()
        {
            // Afficher les informations de la commande (lecture seule)
            lblNumCommande.Text = CommandeCreee1.IdCommande.ToString();
            lblDateCommande.Text = CommandeCreee1.DateCommande.ToString("dd/MM/yyyy");
            lblDateRetrait.Text = CommandeCreee1.DateRetraitPrevue.ToString("dd/MM/yyyy");
            lblPrixTotal.Text = CommandeCreee1.PrixTotal.ToString("N2") + " €";

            // Initialiser le statut payée
            checkPayee.IsChecked = CommandeCreee1.Payee;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            // Récupère l'état de la case à cocher "payée" (true si cochée, false sinon)
            CommandeCreee1.Payee = checkPayee.IsChecked == true;

            // Prépare un texte en fonction du nouveau statut
            string statut = CommandeCreee1.Payee ? "payée" : "non payée";

            // Affiche une confirmation à l'utilisateur
            MessageBox.Show("La commande est maintenant marquée comme " + statut + ".", "Statut modifié");

            // Ferme la fenêtre avec un résultat positif (la modif est validée)
            DialogResult = true;
        }


        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}