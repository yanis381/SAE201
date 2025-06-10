using SAE201.Models;
using SAE201.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE201.UCPages
{
    /// <summary>
    /// Logique d'interaction pour UCRechercheClient.xaml
    /// </summary>
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
            dataClients.ItemsSource = tousLesClients;
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtre = searchBox.Text.ToLower();
            List<Clients> resultat = new List<Clients>();

            foreach (Clients c in tousLesClients)
            {
                if (c.NomClient.ToLower().Contains(filtre) ||
                    c.PrenomClient.ToLower().Contains(filtre) ||
                    c.TelClient.ToLower().Contains(filtre))
                {
                    resultat.Add(c);
                }
            }

            dataClients.ItemsSource = resultat;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if (dataClients.SelectedItem is Clients c)
            {
                ClientSelectionne = c;
                MessageBox.Show("Client sélectionné : " + c.NomClient + " " + c.PrenomClient);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client.");
            }
        }

        private void Creer_Click(object sender, RoutedEventArgs e)
        {
            Clients unClient = new Clients();
            CreationClient wClient = new CreationClient(unClient);

            bool? result = wClient.ShowDialog();

            if (result == true)
            {
                try
                {
                    unClient.NumClient = unClient.Create(); // Sauvegarde en base
                    tousLesClients.Add(unClient);           // Ajout à la liste affichée
                    dataClients.ItemsSource = null;         // Forcer le refresh
                    dataClients.ItemsSource = tousLesClients;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Le client n'a pas pu être créé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void VoirHistorique_Click(object sender, RoutedEventArgs e)
        {
            if (dataClients.SelectedItem is Clients c)
            {
                List<Commande> commandes = Commande.TrouverParClient(c.NumClient);

                if (commandes.Count == 0)
                {
                    MessageBox.Show("Ce client n’a encore aucune commande.");
                    dataHistorique.Visibility = Visibility.Collapsed;
                }
                else
                {
                    dataHistorique.ItemsSource = commandes;
                    dataHistorique.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client.");
            }
        }
    }
}
