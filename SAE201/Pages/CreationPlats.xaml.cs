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
        public Plat Platcreer { get; set; }
        public enum comboBoxPeriode { été , hiver , printemps }

        public int TypePlatSelectionne { get; private set; }
        public int PeriodeSelectionnee { get; private set; }

        private Plat monPlat;

        public CreationPlats(MainWindow.Action actionDeLaPage, Plat p)
        {
            InitializeComponent();
            ValidBTnCReaPlats.Content = actionDeLaPage;
            monPlat = p;
            this.DataContext = monPlat;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // ne pas utiliser sauf si besoin
        }

        private void AnnulerBTnCReaPlats_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void ValidBTnCReaPlats_Click(object sender, RoutedEventArgs e)
        {

            bool ok = true;
            foreach (UIElement uie in stackPanelcreerPlat.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                }
                else if (Validation.GetHasError(uie))
                {
                    ok = false;
                }

                // NE PAS activer sinon ca marche plus 
                /*else
                {
                    MessageBox.Show("c'est pas bon", "etstss" , MessageBoxButton.OK , MessageBoxImage.Warning);
                    return;
                }*/
            }
            DialogResult = true;
        }
        
    }
    }

