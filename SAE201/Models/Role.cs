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

        public Role(string nomRole)
        {
            this.NomRole = nomRole;
        }

        public string NomRole
        {
            get
            {
                return this.nomRole;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("il faut un role ");

                }
                this.nomRole = value;
            }
        }
    }
}
