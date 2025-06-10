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

namespace SAE201.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageConnexions.xaml
    /// </summary>
    public partial class PageConnexions : Page
    {
        public PageConnexions()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PageAccueil());
        }

        private void Button_Click()
        {

        }
    }
}
