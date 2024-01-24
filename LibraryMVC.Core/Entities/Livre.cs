using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Entities
{
    public class Livre:Entity
    {
        public string Titre { get; set; } = null!;
        public int NombreDePage { get; set; }

        public int DomaineId { get; set; }

        public int AuteurId { get; set; }

        public Domaine Domaine { get; set; } = null!;

        public Auteur Auteur { get; set; } = null!;
        public HashSet<Emprunt> Emprunts { get; set;} = new HashSet<Emprunt>();

    }
}
