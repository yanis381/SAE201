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
            tousLesClients = Clients.FindAll();  // Récupère tous les clients depuis la base
            dataGridClients.ItemsSource = tousLesClients;  // Affiche les clients dans le DataGrid
        }


        private void textBoxRechercheClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtre = textBoxRechercheClient.Text.ToLower();  // Récupère le texte de recherche en minuscule
            var resultat = tousLesClients
                .Where(c =>
                    c.NomClient.ToLower().Contains(filtre) ||         // Recherche dans le nom
                    c.PrenomClient.ToLower().Contains(filtre) ||      // ou le prénom
                    c.TelClient.ToLower().Contains(filtre))           // ou le numéro de téléphone
                .ToList();

            dataGridClients.ItemsSource = resultat;  // Met à jour le DataGrid avec les résultats filtrés
        }


        private void btnSelectionner_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridClients.SelectedItem is Clients c)  // Vérifie qu’un client est sélectionné
            {
                ClientSelectionne = c;  // Stocke le client sélectionné

                // Ferme la fenêtre parente si c’est une boîte de dialogue
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    parentWindow.DialogResult = true;  // Permet de retourner le client à l’appelant
                }
                else
                {
                    MessageBox.Show("Client sélectionné : " + c.NomClient + " " + c.PrenomClient);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client.");
            }
        }


        private void btnCreerClient_Click(object sender, RoutedEventArgs e)
        {
            Clients unClient = new Clients();  // Crée un client vide
            CreationClient wClient = new CreationClient(unClient);  // Ouvre une fenêtre pour saisir les infos

            bool? result = wClient.ShowDialog();  // Attend la fermeture de la fenêtre

            if (result == true)
            {
                try
                {
                    unClient.NumClient = unClient.Create();  // Enregistre le client dans la base
                    tousLesClients.Add(unClient);            // L’ajoute à la liste locale
                    dataGridClients.ItemsSource = null;      // Rafraîchit le DataGrid
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
                var commandes = Commande.TrouverParClient(c.NumClient);  // Récupère les commandes du client

                if (commandes.Count == 0)
                {
                    MessageBox.Show("Ce client n’a encore aucune commande.");  // Aucune commande trouvée
                }
                else
                {
                    MessageBox.Show("Historique trouvé pour " + c.NomClient);  // Historique existant
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

            // Création d’une copie pour l’édition
            Clients copie = new Clients(
                clientSelectionne.NumClient,
                clientSelectionne.NomClient,
                clientSelectionne.PrenomClient,
                clientSelectionne.TelClient,
                clientSelectionne.AdresseRue,
                clientSelectionne.AdresseCodePostal,
                clientSelectionne.AdresseVille
            );

            // Ouvre la fenêtre d’édition avec la copie
            CreationClient f = new CreationClient(copie);
            bool? result = f.ShowDialog();

            if (result == true)
            {
                try
                {
                    copie.Update();  // Met à jour la base avec les nouvelles valeurs

                    // Met à jour l’objet original
                    clientSelectionne.NomClient = copie.NomClient;
                    clientSelectionne.PrenomClient = copie.PrenomClient;
                    clientSelectionne.TelClient = copie.TelClient;
                    clientSelectionne.AdresseRue = copie.AdresseRue;
                    clientSelectionne.AdresseCodePostal = copie.AdresseCodePostal;
                    clientSelectionne.AdresseVille = copie.AdresseVille;

                    // Rafraîchit le DataGrid
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
                    clientASupprimer.Delete();  // Supprime le client en base
                    tousLesClients.Remove(clientASupprimer);  // Supprime de la liste locale

                    // Rafraîchit le DataGrid
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
    

