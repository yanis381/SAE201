using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class MagazinReserv
    {
        private string nom;
        private ObservableCollection<Clients> lesclients;
        private ObservableCollection<Plat> lesPlatscommandée;
        private ObservableCollection<Commande> lescommandes;

        public MagazinReserv(string nom)
        {
            this.nom = nom;
            this.Lescommandes = new ObservableCollection<Commande>(Commande.FindAll());

        }

        public ObservableCollection<Clients> Lesclients
        {
            get
            {
                return this.lesclients;
            }

            set
            {
                this.lesclients = value;
            }
        }

        public ObservableCollection<Plat> LesPlatscommandée
        {
            get
            {
                return this.lesPlatscommandée;
            }

            set
            {
                this.lesPlatscommandée = value;
            }
        }

        public ObservableCollection<Commande> Lescommandes
        {
            get
            {
                return this.lescommandes;
            }

            set
            {
                this.lescommandes = value;
            }
        }

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
            }
        }
    }
}
