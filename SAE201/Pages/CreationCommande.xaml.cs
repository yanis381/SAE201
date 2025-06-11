using SAE201.Models;
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
using System.Windows.Shapes;
using static SAE201.MainWindow;

namespace SAE201.Pages
{
    /// <summary>
    /// Logique d'interaction pour CreationCommande.xaml
    /// </summary>
    public partial class CreationCommande : Window
    {
        public Commande CommandeCreee { get; private set; }

        public CreationCommande(Commande commande)
        {
            InitializeComponent();
            this.CommandeCreee = commande;
            this.DataContext = CommandeCreee;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;

            // Vérifie chaque champ pour mettre à jour les bindings
            foreach (UIElement uie in stackPanelCommande.Children)
            {
                if (uie is TextBox txt)
                    txt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();

                if (uie is DatePicker dp)
                    dp.GetBindingExpression(DatePicker.SelectedDateProperty)?.UpdateSource();

                if (uie is CheckBox cb)
                    cb.GetBindingExpression(CheckBox.IsCheckedProperty)?.UpdateSource();

                if (Validation.GetHasError(uie))
                    ok = false;
            }

            if (!ok)
            {
                MessageBox.Show("Corrigez les erreurs avant de valider.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            this.DialogResult = true;
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
