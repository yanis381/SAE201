using SAE201.Models;
using SAE201.Pages;
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

namespace SAE201.UCPages
{
    /// <summary>
    /// Logique d'interaction pour UCPlats.xaml
    /// </summary>
    public partial class UCPlats : UserControl
    {

        public Plat PlatAPrevoir { get; set; }
        private List<Plat> platforms = new List<Plat>();
        public UCPlats()
        {

            InitializeComponent();
            platforms = Plat.FindAll();
            dataPlats.ItemsSource = platforms;  
        }

        private void creerproduit_Click(object sender, RoutedEventArgs e)
        {
            int periodenb = 0;
            int typeproduits = 0; 
            CreationPlats plats = new CreationPlats(MainWindow.Action.Créer);
            Plat pl = new Plat(); 
            if(plats.comboBoxPeriodeDef.Text == "plats principale") {
                periodenb = 1;
            }
            else if(plats.comboBoxPeriodeDef.Text == "dessert")
            {

            periodenb = 2;}
            if(plats.comboBoxTypePlatsDef.Text == "printemps")
            {

            typeproduits = 1;}
            else if (plats.comboBoxTypePlatsDef.Text == "hivert")
            {

                typeproduits = 2;
            }
            bool? result = plats.ShowDialog();
            if (result == true)
            {
                try
                {
                    pl.IdPlat = pl.Create(typeproduits , periodenb);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "Le Box n'a pas pu être créé.", "Attention", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }

        }

        private void textBoxPlats_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataPlats.ItemsSource).Refresh();
        }
    }
}
