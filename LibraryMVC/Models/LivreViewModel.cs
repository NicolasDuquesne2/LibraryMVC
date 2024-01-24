namespace LibraryMVC.Models
{
    public class LivreViewModel
    {
        public int DomaineId { get; set; }
        public int AuteurId { get; set; }

        public string Titre { get; set; } = null!;
        public int NombreDePage { get; set; }

    }
}
