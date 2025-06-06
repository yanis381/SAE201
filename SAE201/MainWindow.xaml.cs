using SAE201.Pages;
using SAE201.UCPages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SAE201
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MainContent.Content = new Connexions();
            
            //MainFrame.Navigate(new Pages.PageConnexions());
             





        }

        private void cbChoix_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void menuevoirLescommande_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UCCommande();
        }
    }
}