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
        public void addFoundation(Foundation Foundation)
        {
            this.context.Add(Foundation);
        }
        public void updateFoundation(Foundation Foundation)
        {
            this.context.Update(Foundation);
        }
        public void deleteFoundation(Foundation Foundation)
        {
            this.context.Remove(Foundation);
        }

        public async Task<bool> saveChangesAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}