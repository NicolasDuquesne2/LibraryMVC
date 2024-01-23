using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Constraints
{
    internal class DomaineConstraints: IEntityTypeConfiguration<Domaine>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domaine> builder)
        {
            builder
            .Property(d => d.Description)
            .IsRequired()
            .HasMaxLength(250);

            builder
           .Property(d => d.Nom)
           .IsRequired()
           .HasMaxLength(25);
        }
    }
}
