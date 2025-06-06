using SAE201.UserControl;
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
    /// Logique d'interaction pour WindowAcceuile.xaml
    /// </summary>
    public partial class WindowAcceuile : Window
    {
        public WindowAcceuile()
        {
            InitializeComponent();
        }

        private void menuevoirLescommande_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UCCommande();
        }
    }
}
