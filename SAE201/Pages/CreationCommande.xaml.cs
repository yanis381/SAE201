using SAE201.Models;
using System;
using System.Windows;

namespace SAE201.Pages
{
    public partial class CreationCommande : Window
    {
        
        public Commande CommandeCreee { get; private set; }

        public CreationCommande(Commande commande)
        {
            InitializeComponent();
            this.CommandeCreee = commande;
            this.DataContext = CommandeCreee;

            // Initialiser l'affichage
            InitialiserInterface();
        }

        private void InitialiserInterface()
        {
            // Afficher les informations de la commande (lecture seule)
            lblNumCommande.Text = CommandeCreee.IdCommande.ToString();
            lblDateCommande.Text = CommandeCreee.DateCommande.ToString("dd/MM/yyyy");
            lblDateRetrait.Text = CommandeCreee.DateRetraitPrevue.ToString("dd/MM/yyyy");
            lblPrixTotal.Text = CommandeCreee.PrixTotal.ToString("N2") + " €";

            // Initialiser le statut payée
            checkPayee.IsChecked = CommandeCreee.Payee;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Mettre à jour uniquement le statut "Payée"
                CommandeCreee.Payee = checkPayee.IsChecked ?? false;

                // Confirmation visuelle
                string message = CommandeCreee.Payee
                    ? "La commande est maintenant marquée comme payée."
                    : "La commande est maintenant marquée comme non payée.";

                MessageBox.Show(message, "Statut modifié", MessageBoxButton.OK, MessageBoxImage.Information);

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}