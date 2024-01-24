using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMVC.Data
{
    internal class AuteurRepository
    {
        protected LibraryDbContext Context { get; }

        public AuteurRepository(LibraryDbContext context)
        {
            Context = context;
        }

        public async Task<Auteur?> GetById(int id)
        {
            return await Context.Auteurs.FindAsync(id);
        }

        public async Task<IEnumerable<Auteur>> ListAll()
        {
            return await Context.Auteurs.ToListAsync();
        }

        public async Task<Auteur> Insert(Auteur auteur)
        {
            Context.Add(auteur);
            await Context.SaveChangesAsync();
            return auteur;
        }

        public async Task Update(Auteur auteur)
        {
            Context.Update(auteur);
            await Context.SaveChangesAsync();
        }

        public async Task Delete(Auteur auteur)
        {
            Context.Set<Auteur>().Remove(auteur);
            await Context.SaveChangesAsync();
        }
    }
}
