using SAE201.Models;
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
using static SAE201.MainWindow;

namespace SAE201.Pages
{
    /// <summary>
    /// Logique d'interaction pour CreationClient.xaml
    /// </summary>
    public partial class CreationClient : Window
    {
        public CreationClient(Clients unClient)
        {
            this.DataContext = unClient;
            InitializeComponent();
        }

        private void boutValider_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            foreach (UIElement uie in panelFormClient.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
                }

                if (Validation.GetHasError(uie))
                    ok = false;
            }

            if (!ok)
            {
                MessageBox.Show("Corrigez les erreurs avant de valider.");
                return;
            }

            this.DialogResult = true;
        }
    }
}