using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Constraints
{
    internal class LecteurConstraints : IEntityTypeConfiguration<Lecteur>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Lecteur> builder)
        {

            builder
                 .Property(l => l.Nom)
                 .IsRequired()
                 .HasMaxLength(32);

            builder
                .Property(l => l.Prenom)
                .IsRequired()
                .HasMaxLength(32);

            builder
               .Property(l => l.Email)
               .IsRequired()
               .HasMaxLength(32);

            builder
               .Property(l => l.Telephone)
               .IsRequired()
               .HasMaxLength(10);

            builder
                .Property(l => l.MotDePasse)
                .IsRequired();
        }
    }
}
