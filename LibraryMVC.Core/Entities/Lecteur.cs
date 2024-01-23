using LibraryMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Entities
{
    public class Lecteur:Personne
    {
        public string MotDePasse { get; set; } = null!;

        public Adresse Adresse { get; set; } = null!;
        public HashSet<Emprunt> Emprunts { get; set; } = new HashSet<Emprunt>();

    }
}
