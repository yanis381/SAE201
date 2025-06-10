using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE201.Models
{
    public class Role
    {
        private string nomRole;

        public string NomRole
        {
            get
            {
                return this.nomRole;
            }

            set
            {
                this.nomRole = value;
            }
        }
    }
}
