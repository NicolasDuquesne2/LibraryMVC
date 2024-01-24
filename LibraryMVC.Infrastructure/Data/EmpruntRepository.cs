using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Data
{
    internal class EmpruntRepository
    {
        protected LibraryDbContext Context { get; }

        public EmpruntRepository(LibraryDbContext context)
        {
            Context = context;
        }

        public async Task<Emprunt?> GetById(int id)
        {
            return await Context.Emprunts.FindAsync(id);
        }

        public async Task<IEnumerable<Emprunt>> ListAll()
        {
            return await Context.Emprunts.ToListAsync();
        }

        public async Task<Emprunt> Insert(Emprunt adresse)
        {
            Context.Add(adresse);
            await Context.SaveChangesAsync();
            return adresse;
        }

        public async Task Update(Emprunt adresse)
        {
            Context.Update(adresse);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(Emprunt adresse)
        {
            Context.Set<Emprunt>().Remove(adresse);
            await Context.SaveChangesAsync();
        }
    }
}
