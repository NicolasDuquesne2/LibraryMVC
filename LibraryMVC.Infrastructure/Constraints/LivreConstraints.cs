using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Constraints
{
    internal class LivreConstraints:IEntityTypeConfiguration<Livre>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Livre> builder)
        {
            
           builder
               .Property(l => l.Titre)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(l => l.NombreDePage)
               .IsRequired()
                .HasMaxLength(5);
        }
    }
}
