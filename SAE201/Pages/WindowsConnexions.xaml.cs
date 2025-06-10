﻿using SAE201.Models;
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
    /// Logique d'interaction pour WindowsConnexions.xaml
    /// </summary>
    public partial class PageConnexion : Window
    {
        private bool testCo;

        public bool TestCo
        {
            get
            {
                return this.testCo;
            }

            set
            {
                this.testCo = value;
            }
        }



        public PageConnexion()
        {
            InitializeComponent();

        }


        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text))
            {
                MessageBox.Show("metter votre login");
            }
          
            else
            {
                this.Close();
            }
        }
        private void btnEmploye_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string mdp = tbPassword.Password.Trim();

            if (Employe.VerifierConnexion(login, mdp))
            {
                MessageBox.Show("Connexion réussie !");
                // ouvrir la fenêtre suivante ici
            }
            else
            {
                MessageBox.Show("Identifiants incorrects.");
            }
        }


    }
}

    

