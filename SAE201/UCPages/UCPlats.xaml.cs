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
            dataPlats.Items.Filter = RecherchePlat;
            platforms = Plat.FindAll();
            dataPlats.ItemsSource = platforms;  
        }
        private bool RecherchePlat(object obj)
        {
            Plat unplat = obj as Plat;
            return (unplat.NomPlat.StartsWith(textBoxPlats.Text, StringComparison.OrdinalIgnoreCase)
            || unplat.NomPlat.StartsWith(textBoxPlats.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void creerproduit_Click(object sender, RoutedEventArgs e)
        {

            Plat unPlat = new Plat();
            CreationPlats wPlat = new CreationPlats(unPlat);

            bool? result = wPlat.ShowDialog();

            //if (result == true)
            //{
            //    try
            //    {
            //        int id = unPlat.Create(wPlat.NumSousCategorie, wPlat.NumPeriode); // Insère en base
            //        platforms.Add(unPlat); // Ajout à la liste affichée
            //        dataPlats.ItemsSource = null;
            //        dataPlats.ItemsSource = platforms;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Le plat n'a pas pu être créé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
        }

        private void textBoxPlats_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            CollectionViewSource.GetDefaultView(dataPlats.ItemsSource).Refresh();
        }
    }
}
