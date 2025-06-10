using SAE201.Models;
using SAE201.Pages;
using SAE201.UCPages;
using System;
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
        public MagazinReserv LeMagazin {  get; set; }

        public enum Action { Modifier, Créer }
        public MainWindow()
        {
            InitializeComponent();
            WindowsConnexions wind  = new WindowsConnexions();
            wind.ShowDialog();
            //MainContent.Content = new Connexions();
            
            //MainFrame.Navigate(new Pages.PageConnexions());
             





        }
        public void ChargeData()
        {
            try
            {
                LeMagazin = new MagazinReserv("LeMagasin");
                this.DataContext = LeMagazin;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème lors de récupération des données, veuillez consulter votre admin");

                Application.Current.Shutdown();
            }
        }

        private void cbChoix_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void menuevoirLescommande_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UCCommande();
        }

        private void menuPlat_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UCPlats();
        }

        

        private void itemJusteSeDeco_Click(object sender, RoutedEventArgs e)
        {
            //DecoPuisReco();
            MessageBox.Show("en devellopement");

            
            
        }

        private void itemSeDecoEtQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }
        private void DecoPuisReco()
        {
            this.Close();
            DecoPartdeux();
        }
        private void DecoPartdeux()
        {
            MainWindow reco = new MainWindow();

            reco.ShowDialog();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // clients 
            MainContent.Content = new UCRechercheClient();
        }
    }
}