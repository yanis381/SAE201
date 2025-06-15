using SAE201.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SAE201.UCPages
{
    public partial class UCCreerCommande : UserControl
    {
        private Clients clientSelectionne;
        private List<Plat> tousLesPlats;
        private ObservableCollection<LigneCommande> lignesCommande;
        private decimal prixTotal;

        public UCCreerCommande()
        {
            InitializeComponent();
            InitialiserInterface();
        }

        private void InitialiserInterface()
        {
            // Initialiser les collections
            lignesCommande = new ObservableCollection<LigneCommande>();
            tousLesPlats = Plat.FindAll();

            // Configurer les contrôles
            dataGridPlatsDisponibles.ItemsSource = tousLesPlats;
            dataLignes.ItemsSource = lignesCommande;

            // Initialiser les ComboBox de filtrage
            comboCategorieFiltrer.SelectedIndex = 0;
            comboSousCategorieFiltrer.SelectedIndex = 0;

            // Dates par défaut
            dateCommande.SelectedDate = DateTime.Now;
            dateRetrait.SelectedDate = DateTime.Now.AddDays(1);

            // Initialiser le total
            MettreAJourTotal();
        }

        // - Méthode de filtrage comme dans UCPlats
        private void textBoxPlats_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filtrer();
        }

        private void comboboxcategorie_LostFocus(object sender, RoutedEventArgs e)
        {
            Filtrer();
        }

        private void comboxsouscategorie_LostFocus(object sender, RoutedEventArgs e)
        {
            Filtrer();
        }

        // - Logique de filtrage identique à UCPlats
        private void Filtrer()
        {
            string filtreNom = textBoxNomPlat.Text.ToLower();
            string filtrePrix = textBoxPrixPlat.Text.ToLower();
            string filtreCategorie = comboCategorieFiltrer.Text;
            string filtreSousCategorie = comboSousCategorieFiltrer.Text;
            string filtreTempsPrep = textBoxDelaiPlat.Text;

            List<Plat> resultats = new List<Plat>();

            foreach (Plat p in tousLesPlats)
            {
                bool ok = true;

                // Filtre nom
                if (!string.IsNullOrWhiteSpace(filtreNom) &&
                    !p.NomPlat.ToLower().Contains(filtreNom))
                    ok = false;

                // Filtre prix
                if (!string.IsNullOrWhiteSpace(filtrePrix))
                {
                    if (!p.PrixUnitaire.ToString("N2").ToLower().Contains(filtrePrix))
                        ok = false;
                }

                // Filtre catégorie
                if (filtreCategorie != "Tout")
                {
                    if (p.Categorie2.NomCategorie != filtreCategorie)
                        ok = false;
                }

                // Filtre sous-catégorie
                if (filtreSousCategorie != "Tout")
                {
                    if (p.SousCategorie3.NomSousCategorie != filtreSousCategorie)
                        ok = false;
                }

                // Filtre délai
                if (!string.IsNullOrWhiteSpace(filtreTempsPrep))
                {
                    if (p.DelaiPreparation.ToString() != filtreTempsPrep)
                        ok = false;
                }

                if (ok) resultats.Add(p);
            }

            dataGridPlatsDisponibles.ItemsSource = resultats;
        }

        //  - Effacer les filtres
        private void btnEffacerFiltres_Click(object sender, RoutedEventArgs e)
        {
            textBoxNomPlat.Text = "";
            textBoxPrixPlat.Text = "";
            textBoxDelaiPlat.Text = "";
            comboCategorieFiltrer.SelectedIndex = 0;
            comboSousCategorieFiltrer.SelectedIndex = 0;
        }

        //  - Double-clic sur la grille
        private void DataGridPlatsDisponibles_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dataGridPlatsDisponibles.SelectedItem is Plat platSelectionne)
            {
                AjouterPlatALaCommande(platSelectionne);
            }
        }

        // - Ajouter le plat sélectionné
        private void btnAjouterPlatSelectionne_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPlatsDisponibles.SelectedItem is Plat platSelectionne)
            {
                AjouterPlatALaCommande(platSelectionne);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un plat dans la liste.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //  - Logique commune d'ajout de plat
        private void AjouterPlatALaCommande(Plat platSelectionne)
        {
            if (!int.TryParse(txtQuantite.Text, out int quantite) || quantite <= 0)
            {
                MessageBox.Show("Veuillez saisir une quantité valide.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Vérifier si le plat est déjà dans la liste
            LigneCommande ligneExistante = null;

            foreach (LigneCommande ligne in lignesCommande)
            {
                if (ligne.Plat.IdPlat == platSelectionne.IdPlat)
                {
                    ligneExistante = ligne;
                    break;
                }
            }

            // Si le plat est déjà présent, on augmente la quantité
            if (ligneExistante != null)
            {
                ligneExistante.Quantite += quantite;
                ligneExistante.CalculerPrix();
            }
            else
            {
                // Sinon on ajoute une nouvelle ligne
                LigneCommande nouvelleLigne = new LigneCommande();
                nouvelleLigne.Plat = platSelectionne;
                nouvelleLigne.Quantite = quantite;
                nouvelleLigne.CalculerPrix();

                lignesCommande.Add(nouvelleLigne);
            }

            // Réinitialise la zone de saisie
            txtQuantite.Text = "1";

            // Met à jour le prix total de la commande
            MettreAJourTotal();
        }

        private void btnSelectionnerClient_Click(object sender, RoutedEventArgs e)
        {
            // Ouvrir la fenêtre de recherche client
            Window fenetreClient = new Window
            {
                Title = "Sélectionner un client",
                Width = 900,
                Height = 600,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize
            };

            UCRechercheClient ucClient = new UCRechercheClient();
            fenetreClient.Content = ucClient;

            bool? result = fenetreClient.ShowDialog();

            if (result == true && ucClient.ClientSelectionne != null)
            {
                clientSelectionne = ucClient.ClientSelectionne;
                lblClient.Content = clientSelectionne.NomClient + " " + clientSelectionne.PrenomClient;
            }
        }

        private void btnSupprimerLigne_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            LigneCommande ligne = btn.DataContext as LigneCommande;

            if (ligne != null)
            {
                lignesCommande.Remove(ligne);
                MettreAJourTotal();
            }
        }

        private void MettreAJourTotal()
        {
            prixTotal = 0;
            foreach (LigneCommande ligne in lignesCommande)
            {
                prixTotal += ligne.Prix;
            }
            textPrixTotal.Text = prixTotal.ToString("N2") + " €";
        }

        private void btnValiderCommande_Click(object sender, RoutedEventArgs e)
        {
            // Vérifications
            if (clientSelectionne == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dateCommande.SelectedDate == null)
            {
                MessageBox.Show("Veuillez sélectionner une date de commande.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dateRetrait.SelectedDate == null)
            {
                MessageBox.Show("Veuillez sélectionner une date de retrait.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (dateRetrait.SelectedDate <= dateCommande.SelectedDate)
            {
                MessageBox.Show("La date de retrait doit être postérieure à la date de commande.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (lignesCommande.Count == 0)
            {
                MessageBox.Show("Veuillez ajouter au moins un plat à la commande.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Créer la commande
                Commande nouvelleCommande = new Commande
                {
                    NumClient = clientSelectionne.NumClient,
                    NumEmploye = 1, // À adapter selon votre système de connexion
                    DateCommande = dateCommande.SelectedDate.Value,
                    DateRetraitPrevue = dateRetrait.SelectedDate.Value,
                    Payee = checkPayee.IsChecked ?? false,
                    Retiree = checkRetiree.IsChecked ?? false,
                    PrixTotal = prixTotal,
                    NbpersonnePrevue = CalculerNbPersonnesTotal()
                };

                // Sauvegarder en base
                int idCommande = nouvelleCommande.Create();

                MessageBox.Show($"Commande n°{idCommande} créée avec succès !\nTotal : {prixTotal:N2} €",
                               "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                // Réinitialiser l'interface
                ReinitialiserInterface();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création de la commande : " + ex.Message,
                               "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                LogError.Log(ex, "Erreur création commande depuis UCCreerCommande");
            }
        }

        private void btnReinitialiser_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir réinitialiser ? Toutes les données seront perdues.",
                                                      "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ReinitialiserInterface();
            }
        }

        private int CalculerNbPersonnesTotal()
        {
            int totalPersonnes = 0;
            foreach (LigneCommande ligne in lignesCommande)
            {
                totalPersonnes += ligne.Quantite * ligne.Plat.NbPersonne;
            }
            return totalPersonnes;
        }

        private void ReinitialiserInterface()
        {
            clientSelectionne = null;
            lblClient.Content = "";
            dateCommande.SelectedDate = DateTime.Now;
            dateRetrait.SelectedDate = DateTime.Now.AddDays(1);
            lignesCommande.Clear();
            txtQuantite.Text = "1";
            checkPayee.IsChecked = false;
            checkRetiree.IsChecked = false;

            // Réinitialiser les filtres
            textBoxNomPlat.Text = "";
            textBoxPrixPlat.Text = "";
            textBoxDelaiPlat.Text = "";
            comboCategorieFiltrer.SelectedIndex = 0;
            comboSousCategorieFiltrer.SelectedIndex = 0;

            // Remettre tous les plats
            dataGridPlatsDisponibles.ItemsSource = tousLesPlats;

            MettreAJourTotal();
        }
    }
}