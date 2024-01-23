using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Entities
{
    public class Domaine:Entity
    {
        public string Nom { get; set; } = null!;
        public string Description { get; set; } = null!;

        public HashSet<Livre> Livres { get; set; } = new HashSet<Livre>();

    }
}
