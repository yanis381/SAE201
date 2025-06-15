using SAE201.Models;
using SAE201.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
    /// Logique d'interaction pour UCPlats.xaml
    /// </summary>
    public partial class UCPlats : UserControl
    {

        private List<Plat> lesPlats = new List<Plat>();
        private readonly Employe employe;

        public UCPlats()
        {
            InitializeComponent(); // Initialise les composants graphiques XAML
            ChargerPlats(); // Charge tous les plats au lancement
            comboboxcategorie.SelectedIndex = 0; // Sélectionne "Tout" par défaut dans les filtres
            comboxsouscategorie.SelectedIndex = 0;
        }


        private void ChargerPlats()
        {
            lesPlats = Plat.FindAll(); // Appelle une méthode du modèle pour récupérer tous les plats
            dataPlats.ItemsSource = lesPlats; // Remplit le DataGrid
        }


        // Filtre combiné sur tout
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

        private void comboTempsPrep_LostFocus(object sender, RoutedEventArgs e)
        {
            Filtrer();
        }



        private void Filtrer()
        {
            string filtreNom = textBoxPlats.Text.ToLower();
            string filtrePrix = textBoxPlatsPrix.Text.ToLower();
            string filtreCategorie = comboboxcategorie.Text;
            string filtreSousCategorie = comboxsouscategorie.Text;
            string filtreTempsPrep = textBoxTempsPrep.Text;



            List<Plat> resultats = new List<Plat>();

            foreach (Plat p in lesPlats)
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

                // Si le plat passe tous les filtres, on l’ajoute à la liste
                if (ok) resultats.Add(p);


            }

            dataPlats.ItemsSource = resultats; // Mise à jour du DataGrid avec les plats filtrés
        }

        private void creerproduit_Click(object sender, RoutedEventArgs e)
        {
            // Création d’un objet Plat vide
            Plat unPlat = new Plat();

            // Ouverture de la fenêtre de création avec le plat en paramètre
            CreationPlats wPlat = new CreationPlats(unPlat);
            bool? result = wPlat.ShowDialog(); // Attend la fermeture de la fenêtre

            if (result == true)
            {
                try
                {
                    // Crée le plat dans la base, puis l’ajoute à la liste locale
                    int id = unPlat.Create(wPlat.NumSousCategorie, wPlat.NumPeriode);
                    lesPlats.Add(unPlat);

                    // Rafraîchit l’affichage
                    dataPlats.ItemsSource = null;
                    dataPlats.ItemsSource = lesPlats;
                }
                catch (Exception)
                {
                    // En cas d’erreur à la création
                    MessageBox.Show("Le plat n’a pas pu être créé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}


        

     
    

