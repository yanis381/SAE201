using SAE201.Models;
using SAE201.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SAE201.UCPages
{
    public partial class UCRechercheClient : UserControl
    {
        private List<Clients> tousLesClients;
        public Clients ClientSelectionne { get; private set; }

        public UCRechercheClient()
        {
            InitializeComponent();
            ChargerTousLesClients();
        }

        private void ChargerTousLesClients()
        {
            tousLesClients = Clients.FindAll();
            dataGridClients.ItemsSource = tousLesClients;
        }

        private void textBoxRechercheClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtre = textBoxRechercheClient.Text.ToLower();
            var resultat = tousLesClients
                .Where(c =>
                    c.NomClient.ToLower().Contains(filtre) ||
                    c.PrenomClient.ToLower().Contains(filtre) ||
                    c.TelClient.ToLower().Contains(filtre))
                .ToList();

            dataGridClients.ItemsSource = resultat;
        }

        private void btnSelectionner_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridClients.SelectedItem is Clients c)
            {
                ClientSelectionne = c;
                MessageBox.Show("Client sélectionné : " + c.NomClient + " " + c.PrenomClient);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client.");
            }
        }

        private void btnCreerClient_Click(object sender, RoutedEventArgs e)
        {
            Clients unClient = new Clients();
            CreationClient wClient = new CreationClient(unClient);

            bool? result = wClient.ShowDialog();

            if (result == true)
            {
                try
                {
                    unClient.NumClient = unClient.Create();
                    tousLesClients.Add(unClient);
                    dataGridClients.ItemsSource = null;
                    dataGridClients.ItemsSource = tousLesClients;
                }
                catch (Exception)
                {
                    MessageBox.Show("Le client n'a pas pu être créé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnVoirHistorique_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridClients.SelectedItem is Clients c)
            {
                var commandes = Commande.TrouverParClient(c.NumClient);

                if (commandes.Count == 0)
                {
                    MessageBox.Show("Ce client n’a encore aucune commande.");
                    // Tu peux ignorer ou cacher une section ici si elle existe
                }
                else
                {
                    MessageBox.Show("Historique trouvé pour " + c.NomClient);
                    // À compléter si tu as un tableau ou une vue pour l'historique
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client.");
            }
        }

        private void editButon_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridClients.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un client à modifier.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Clients clientSelectionne = (Clients)dataGridClients.SelectedItem;

            Clients copie = new Clients(
                clientSelectionne.NumClient,
                clientSelectionne.NomClient,
                clientSelectionne.PrenomClient,
                clientSelectionne.TelClient,
                clientSelectionne.AdresseRue,
                clientSelectionne.AdresseCodePostal,
                clientSelectionne.AdresseVille
            );

            CreationClient f = new CreationClient(copie);
            bool? result = f.ShowDialog();

            if (result == true)
            {
                try
                {
                    copie.Update();

                    clientSelectionne.NomClient = copie.NomClient;
                    clientSelectionne.PrenomClient = copie.PrenomClient;
                    clientSelectionne.TelClient = copie.TelClient;
                    clientSelectionne.AdresseRue = copie.AdresseRue;
                    clientSelectionne.AdresseCodePostal = copie.AdresseCodePostal;
                    clientSelectionne.AdresseVille = copie.AdresseVille;

                    dataGridClients.ItemsSource = null;
                    dataGridClients.ItemsSource = tousLesClients;
                }
                catch (Exception)
                {
                    MessageBox.Show("Le client n’a pas pu être modifié.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnsupp_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridClients.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Clients clientASupprimer = (Clients)dataGridClients.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce client ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    clientASupprimer.Delete();
                    tousLesClients.Remove(clientASupprimer);
                    dataGridClients.ItemsSource = null;
                    dataGridClients.ItemsSource = tousLesClients;
                }
                catch (Exception)
                {
                    MessageBox.Show("Le client n’a pas pu être supprimé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
