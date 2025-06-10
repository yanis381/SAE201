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
    }
}
