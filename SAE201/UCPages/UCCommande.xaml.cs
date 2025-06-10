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
    /// Logique d'interaction pour UCCommande.xaml
    /// </summary>
    public partial class UCCommande : UserControl
    {
        private List<Commande> lesCommandes = new List<Commande>();


        public UCCommande()
        {
            InitializeComponent();
            ChargerCommandes();
        }

        private void ChargerCommandes()
        {
            lesCommandes = Commande.FindAll();
            dgCommandes.ItemsSource = lesCommandes;
        }

        private void textMotClefCommande_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtre = textMotClefCommande.Text.ToLower();
            List<Commande> resultat = new List<Commande>();

            foreach (Commande c in lesCommandes)
            {
                if (c.IdCommande.ToString().Contains(filtre) ||
                    c.DateCommande.ToString("dd/MM/yyyy").ToLower().Contains(filtre) ||
                    c.PrixTotal.ToString().ToLower().Contains(filtre))
                {
                    resultat.Add(c);
                }
            }

            dgCommandes.ItemsSource = resultat;
        }


        private void btnsupp_Click(object sender, RoutedEventArgs e)
        {
            if (dgCommandes.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une commande à supprimer.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Commande commandeASupprimer = (Commande)dgCommandes.SelectedItem;
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette commande ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        commandeASupprimer.Delete();
                        lesCommandes.Remove(commandeASupprimer);
                        dgCommandes.ItemsSource = null;
                        dgCommandes.ItemsSource = lesCommandes;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("La commande n’a pas pu être supprimée.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void bouttonAjoutDsBd_Click(object sender, RoutedEventArgs e)
        {
            Commande uneCommande = new Commande();
            CreationCommande wCommande = new CreationCommande(uneCommande);
            bool? result = wCommande.ShowDialog();
            if (result == true)
            {
                try
                {
                    uneCommande.IdCommande = uneCommande.Create();
                    lesCommandes.Add(uneCommande);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La commande n’a pas pu être ajoutée.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void editButon_Click(object sender, RoutedEventArgs e)
        {
            if (dgCommandes.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une commande à modifier.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Commande commandeSelectionnee = (Commande)dgCommandes.SelectedItem;
                Commande copie = new Commande(commandeSelectionnee.IdCommande, commandeSelectionnee.DateCommande, commandeSelectionnee.DateRetraitPrevue, commandeSelectionnee.Payee, commandeSelectionnee.Retiree, commandeSelectionnee.PrixTotal);
                CreationCommande wCommande = new CreationCommande(copie);
                bool? result = wCommande.ShowDialog();
                if (result == true)
                {
                    try
                    {
                        copie.Update();
                        commandeSelectionnee.DateCommande = copie.DateCommande;
                        commandeSelectionnee.DateRetraitPrevue = copie.DateRetraitPrevue;
                        commandeSelectionnee.Payee = copie.Payee;
                        commandeSelectionnee.Retiree = copie.Retiree;
                        commandeSelectionnee.PrixTotal = copie.PrixTotal;
                        dgCommandes.ItemsSource = null;
                        dgCommandes.ItemsSource =lesCommandes;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("La commande n’a pas pu être modifiée.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
