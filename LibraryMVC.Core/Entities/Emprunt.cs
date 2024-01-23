using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Entities
{
    public class Emprunt:Entity
    {
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }

        public Lecteur Lecteur { get; set; } = null!;
        public Livre Livre { get; set; } = null!;

    }
}
