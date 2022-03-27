using Microsoft.EntityFrameworkCore;

using foundation.Repositories;
using foundation.Models;
using foundation.Data;

namespace foundation.Repositories
{
    public class FoundationRepository : IFoundationRepository
    {
        private readonly FoundationDbContext context;

        public FoundationRepository(FoundationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Foundation>> getFoundations()
        {
            return await this.context.Foundations.ToListAsync();
        }
        public async Task<Foundation> getFoundationById(int id)
        {
            return await this.context.Foundations.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Foundation> getFoundationByCnpj(string cnpj)
        {
            return await this.context.Foundations.Where(x => x.Cnpj == cnpj).FirstOrDefaultAsync();
        }
        public void addFoundation(Foundation foundation)
        {
            this.context.Add(foundation);
        }
        public void updateFoundation(Foundation foundation)
        {
            this.context.Update(foundation);
        }
        public void deleteFoundation(Foundation foundation)
        {
            this.context.Remove(foundation);
        }

        public async Task<bool> saveChangesAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}