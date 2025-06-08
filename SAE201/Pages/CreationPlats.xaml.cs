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

namespace SAE201.Pages
{
    /// <summary>
    /// Logique d'interaction pour CreationPlats.xaml
    /// </summary>
    public partial class CreationPlats : Window
    {
        public CreationPlats(MainWindow.Action actionDeLaPage)
        {
            InitializeComponent();
            ValidBTnCReaPlats.Content = actionDeLaPage ;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // ne pas utiliser sauf si besoin
        }

        private void AnnulerBTnCReaPlats_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
