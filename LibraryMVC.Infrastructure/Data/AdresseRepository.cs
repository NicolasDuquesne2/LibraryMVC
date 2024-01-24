using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Data
{
    internal class AdresseRepository
    {

        protected LibraryDbContext Context { get; }

        public AdresseRepository(LibraryDbContext context)
        {
            Context = context;
        }

        public async Task<Adresse?> GetById(int id)
        {
            return await Context.Adresses.FindAsync(id);
        }

        public async Task<IEnumerable<Adresse>> ListAll()
        {
            return await Context.Adresses.ToListAsync();
        }

        public async Task<Adresse> Insert(Adresse adresse)
        {
            Context.Add(adresse);
            await Context.SaveChangesAsync();
            return adresse;
        }

        public async Task Update(Adresse adresse)
        {
            Context.Update(adresse);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(Adresse adresse)
        {
            Context.Set<Adresse>().Remove(adresse);
            await Context.SaveChangesAsync();
        }
    }
}
