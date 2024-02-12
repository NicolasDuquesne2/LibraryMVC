using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Data
{
    public class LivreRepository
    {
        protected LibraryDbContext Context { get; }

        public LivreRepository(LibraryDbContext context) 
        {
            Context = context;
        }

        public async Task<Livre?> GetById(int id)
        {
            return await Context.Livres.Include(l => l.Domaine).Include(l => l.Auteur).FirstOrDefaultAsync(l => l.Id == id);
        }
        public async Task<IEnumerable<Livre>> ListAll()
        {
            return await Context.Livres.Include(l => l.Domaine).Include(l => l.Auteur).ToListAsync();
        }

        public async Task<Livre> Insert(Livre livre)
        {
            Context.Add(livre);
            await Context.SaveChangesAsync();
            return livre;
        }

        public async Task Update(Livre livre)
        {
            Context.Update(livre);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(Livre livre)
        {
            Context.Set<Livre>().Remove(livre);
            await Context.SaveChangesAsync();
        }
    }
}
