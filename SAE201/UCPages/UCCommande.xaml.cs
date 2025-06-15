using SAE201.Models;
using SAE201.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SAE201.UCPages
{
    public partial class UCCommande : UserControl
    {
        private List<Commande> lesCommandes = new List<Commande>();
        private List<Commande> commandesAffichees = new List<Commande>();
        private bool filtreJourActif = false;
        private bool filtreRecupereesActif = false;

        public UCCommande()
        {
            InitializeComponent();
            ChargerCommandes();
        }

        private void ChargerCommandes()
        {
            lesCommandes = Commande.FindAll();
            commandesAffichees = new List<Commande>(lesCommandes);
            dgCommandes.ItemsSource = commandesAffichees;
        }

        private void textMotClefCommande_TextChanged(object sender, TextChangedEventArgs e)
        {
            AppliquerFiltres();
        }

        private void btnCommandesDuJour_Click(object sender, RoutedEventArgs e)
        {
            ResetFiltres();
            filtreJourActif = true;
            textMotClefCommande.Text = "";
            AppliquerFiltres();
        }

        private void btnCommandesRecuperees_Click(object sender, RoutedEventArgs e)
        {
            ResetFiltres();
            filtreRecupereesActif = true;
            textMotClefCommande.Text = "";
            AppliquerFiltres();
        }

        private void btnToutesCommandes_Click(object sender, RoutedEventArgs e)
        {
            ResetFiltres();
            textMotClefCommande.Text = "";
            AppliquerFiltres();
        }

        private void ResetFiltres()
        {
            filtreJourActif = false;
            filtreRecupereesActif = false;
        }

        private void AppliquerFiltres()
        {
            string filtre = textMotClefCommande.Text.ToLower();
            List<Commande> resultat = new List<Commande>();

            foreach (Commande c in lesCommandes)
            {
                bool inclure = true;

                // Filtre par jour si activé
                if (filtreJourActif)
                {
                    if (c.DateCommande.Date != DateTime.Today)
                    {
                        inclure = false;
                    }
                }

                // Filtre par commandes récupérées si activé
                if (filtreRecupereesActif)
                {
                    if (!c.Retiree)
                    {
                        inclure = false;
                    }
                }

                // Filtre par texte si saisi
                if (inclure && !string.IsNullOrWhiteSpace(filtre))
                {
                    bool correspondanceTexte = false;

                    // Recherche dans différents champs
                    if (c.IdCommande.ToString().Contains(filtre) ||
                        c.DateCommande.ToString("dd/MM/yyyy").Contains(filtre) ||
                        c.DateRetraitPrevue.ToString("dd/MM/yyyy").Contains(filtre) ||
                        c.PrixTotal.ToString("N2").Contains(filtre))
                    {
                        correspondanceTexte = true;
                    }

                    // Recherche dans le nom de l'employé si disponible
                    if (c.EmployeCommande != null &&
                        c.EmployeCommande.NomEmploye.ToLower().Contains(filtre))
                    {
                        correspondanceTexte = true;
                    }

                    // Recherche dans le nom du client si disponible
                    if (c.ClientCommande != null &&
                        (c.ClientCommande.NomClient.ToLower().Contains(filtre) ||
                         c.ClientCommande.PrenomClient.ToLower().Contains(filtre)))
                    {
                        correspondanceTexte = true;
                    }

                    if (!correspondanceTexte)
                    {
                        inclure = false;
                    }
                }

                if (inclure)
                {
                    resultat.Add(c);
                }
            }

            commandesAffichees = resultat;
            dgCommandes.ItemsSource = commandesAffichees;
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (dgCommandes.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une commande à modifier.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Commande commandeSelectionnee = (Commande)dgCommandes.SelectedItem;

            // Créer une copie pour la modification
            Commande copie = new Commande(
                commandeSelectionnee.IdCommande,
                commandeSelectionnee.DateCommande,
                commandeSelectionnee.DateRetraitPrevue,
                commandeSelectionnee.Payee,
                commandeSelectionnee.Retiree,
                commandeSelectionnee.PrixTotal);

            // Ouvrir la fenêtre de modification
            ModifierCommande fenetreModif = new ModifierCommande(copie);
            bool? result = fenetreModif.ShowDialog();

            if (result == true)
            {
                try
                {
                    // Sauvegarder les modifications en base
                    copie.Update();

                    // Mettre à jour l'objet dans la liste
                    commandeSelectionnee.DateCommande = copie.DateCommande;
                    commandeSelectionnee.DateRetraitPrevue = copie.DateRetraitPrevue;
                    commandeSelectionnee.Payee = copie.Payee;
                    commandeSelectionnee.Retiree = copie.Retiree;
                    commandeSelectionnee.PrixTotal = copie.PrixTotal;

                    // Rafraîchir l'affichage
                    AppliquerFiltres();
                    MessageBox.Show("Commande modifiée avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la modification : " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCommandes.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une commande à supprimer.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Commande commandeASupprimer = (Commande)dgCommandes.SelectedItem;
            MessageBoxResult result = MessageBox.Show($"Supprimer la commande n°{commandeASupprimer.IdCommande} ?",
                                                      "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    commandeASupprimer.Delete();
                    lesCommandes.Remove(commandeASupprimer);
                    AppliquerFiltres();
                    MessageBox.Show("Commande supprimée !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur lors de la suppression.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}