using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Entities
{
    public class Auteur:Personne
    {
        public string Grade { get; set; } = null!;

        public HashSet<Livre>? Livres { get; set; } = new HashSet<Livre>();
    }
}
