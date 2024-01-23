using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Constraints
{
    internal class AdminConstraints : IEntityTypeConfiguration<Admin>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Admin> builder)
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
                .Property(a => a.MotDePasse)
                .IsRequired();
        }
    }
}
