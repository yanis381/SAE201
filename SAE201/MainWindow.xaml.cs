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

        public MainWindow()
        {
            

            InitializeComponent();
            PageConnexion wind  = new PageConnexion();
            
            bool? result = wind.ShowDialog();
          




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
            PageConnexion connexion = new PageConnexion();
            connexion.Show();  
            this.Close(); 
        }

        private void menucreercommande_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UCCreerCommande();
        }

        private void menuvoitclient_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new UCRechercheClient();
        }
    }
}