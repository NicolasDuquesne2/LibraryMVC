using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Constraints
{
    internal class AdresseConstraints: IEntityTypeConfiguration<Adresse>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Adresse> builder)
        {
            builder
                .Property(a => a.Appartement)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(a => a.Rue)
                .IsRequired()
                .HasMaxLength(32);
            builder
                .Property(a => a.CodePostal)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(a => a.Pays)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .Property(a => a.Ville)
                .IsRequired()
                .HasMaxLength(32);
        }
    }
}
