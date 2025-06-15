using SAE201.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
using System.Windows.Shapes;

namespace SAE201.Pages
{
    /// <summary>
    /// Logique d'interaction pour CreationPlats.xaml
    /// </summary>
    public partial class CreationPlats : Window
    {
        public Plat MonPlat { get; private set; }

        public int NumSousCategorie { get; private set; }
        public int NumPeriode { get; private set; }

        public CreationPlats(Plat unPlat)
        {
            InitializeComponent();
            this.MonPlat = unPlat;
            this.DataContext = MonPlat;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;

            foreach (UIElement uie in stackPanelPlat.Children)
            {
                if (uie is TextBox txt)
                    txt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

                if (Validation.GetHasError(uie))
                    ok = false;
            }

            if (!ok)
            {
                MessageBox.Show("Veuillez corriger les erreurs avant de valider.");
                return;
            }

            // Conversion des ComboBox en ID
            NumSousCategorie = GetNumSousCategorie(comboBoxSousCategorie.Text);
            NumPeriode = GetNumPeriode(comboBoxPeriode.Text);

            DialogResult = true;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        // donne le numero de la sous categorie pr bd
        private int GetNumSousCategorie(string nom)
        {
            switch (nom)
            {
                case "Pâtés": return 1;
                case "Cuisine du monde": return 2;
                case "Traiteur festif": return 3;
                case "Terrines": return 4;
                case "Jambons Saucissons": return 5;
                case "Végétarien traiteur": return 6;
                case "Spécialités régionales": return 7;
                case "Plats cuisinés": return 8;
                case "Produits fumés": return 9;
                default: return 0;
            }
        }
        // donne le numero de la periode pr bd
        private int GetNumPeriode(string nom)
        {
            switch (nom)
            {
                case "Printemps": return 1;
                case "Été": return 2;
                case "Automne": return 3;
                case "Hiver": return 4;
                default: return 0;
            }
        }
    }

}

