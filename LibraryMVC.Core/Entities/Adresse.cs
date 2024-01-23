using LibraryMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Entities
{
    public class Adresse:Entity
    {
        public string Appartement { get; set; } = null!;
        public string Rue { get; set; } = null!;
        public string Ville { get; set; } = null!;
        public string CodePostal { get; set; } = null!;
        public string Pays { get; set; } = null!;

        public HashSet<Lecteur> Lecteurs { get; } = new HashSet<Lecteur>();
    }
}
