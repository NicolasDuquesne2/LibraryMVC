using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Entities
{
    public abstract class Personne:Entity
    {
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Telephone { get; set; } = null!;
    }
}
