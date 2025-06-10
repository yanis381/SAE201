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
        public Clients ClientSelectionne { get; private set; }
        private List<Clients> tousLesClients;

        public UCRechercheClient()
        {
            InitializeComponent();

            Clients unClient = new Clients();
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
            if (dataClients.SelectedItem != null)
            {
                Clients c = (Clients)dataClients.SelectedItem;
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
            CreationClient f = new CreationClient(new Clients(), "Créer");

            bool? result = f.ShowDialog();
            if (result == true)
            {
                tousLesClients = Clients.FindAll();
                dataClients.ItemsSource = tousLesClients;
            }
        }

       /* private void VoirHistorique_Click(object sender, RoutedEventArgs e)
        {
            if (dataClients.SelectedItem != null)
            {
                Clients c = (Clients)dataClients.SelectedItem;

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

        }*/
    }
}
