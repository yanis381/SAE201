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
            try
            {
                // Mettre à jour uniquement le statut "Payée"
                CommandeCreee1.Payee = checkPayee.IsChecked ?? false;

                // Confirmation visuelle
                string message = CommandeCreee1.Payee
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