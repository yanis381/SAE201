using SAE201.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

            // Initialiser les valeurs dans les contrôles
            InitialiserInterface();
        }

        private void InitialiserInterface()
        {
            // S'assurer que les dates sont affichées correctement
            dateCommandePicker.SelectedDate = CommandeCreee.DateCommande;
            dateRetraitPicker.SelectedDate = CommandeCreee.DateRetraitPrevue;
            checkPayee.IsChecked = CommandeCreee.Payee;
            checkRetiree.IsChecked = CommandeCreee.Retiree;
            textPrix.Text = CommandeCreee.PrixTotal.ToString("N2");
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Récupérer les valeurs des contrôles
                if (dateCommandePicker.SelectedDate.HasValue)
                {
                    CommandeCreee.DateCommande = dateCommandePicker.SelectedDate.Value;
                }

                if (dateRetraitPicker.SelectedDate.HasValue)
                {
                    CommandeCreee.DateRetraitPrevue = dateRetraitPicker.SelectedDate.Value;
                }

                CommandeCreee.Payee = checkPayee.IsChecked ?? false;
                CommandeCreee.Retiree = checkRetiree.IsChecked ?? false;

                // Validation du prix
                if (decimal.TryParse(textPrix.Text, out decimal prix))
                {
                    CommandeCreee.PrixTotal = prix;
                }
                else
                {
                    MessageBox.Show("Veuillez saisir un prix valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validation des dates
                if (CommandeCreee.DateRetraitPrevue <= CommandeCreee.DateCommande)
                {
                    MessageBox.Show("La date de retrait doit être postérieure à la date de commande.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la validation : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}