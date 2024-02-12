using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Data
{
    public class LecteurRepository
    {
        protected LibraryDbContext Context { get;}

        public LecteurRepository(LibraryDbContext context)
        {
            Context = context;
        }

        public async Task<Lecteur?> GetById(int id)
        {
            return await Context.Lecteurs
                .Include(l => l.Adresse)
                .FirstOrDefaultAsync(l => l.Id == id);
  
        }

        public async Task<IEnumerable<Lecteur>> ListAll()
        {
            return await Context.Lecteurs.ToListAsync();
        }

        public async Task<Lecteur> Insert(Lecteur lecteur)
        {
            Context.Add(lecteur);
            await Context.SaveChangesAsync();
            return lecteur;
        }

        public async Task Update(Lecteur lecteur)
        {
            Context.Update(lecteur);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(Lecteur lecteur)
        {
            Context.Set<Lecteur>().Remove(lecteur);
            await Context.SaveChangesAsync();
        }
    }
}
