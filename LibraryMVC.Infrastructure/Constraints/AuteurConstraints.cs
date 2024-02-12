using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Constraints
{
    internal class AuteurConstraints : IEntityTypeConfiguration<Auteur>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Auteur> builder)
        {
            builder
                .Property(a => a.Nom)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(a => a.Prenom)
                .IsRequired()
                .HasMaxLength(32);

            builder
               .Property(a => a.Email)
               .IsRequired()
               .HasMaxLength(32);

            builder
               .Property(a => a.Telephone)
               .IsRequired()
               .HasMaxLength(10);

            builder
                .Property(a => a.Grade)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
