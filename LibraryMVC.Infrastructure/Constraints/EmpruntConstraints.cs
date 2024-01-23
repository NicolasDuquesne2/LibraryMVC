using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Constraints
{
    internal class EmpruntConstraints : IEntityTypeConfiguration<Emprunt>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Emprunt> builder)
        {
            builder
                .Property(e => e.DateEmprunt)
                .IsRequired();

            builder
               .Property(e => e.DateRetour)
               .IsRequired();
        }
    }
}
