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
        private ObservableCollection<Clients> lesclients;
        private ObservableCollection<Plat> lesPlatscommandée;
        private ObservableCollection<Commande> lescommandes;

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
    }
}
