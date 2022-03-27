using foundation.Models;

namespace foundation.Repositories
{
    public interface IFoundationRepository
    {
        Task<IEnumerable<Foundation>> getFoundations();
        Task<Foundation> getFoundationById(int id);
        Task<Foundation> getFoundationByCnpj(string cnpj);
        void addFoundation(Foundation foundation);
        void updateFoundation(Foundation foundation);
        void deleteFoundation(Foundation foundation);
        Task<bool> saveChangesAsync();
    }
}
