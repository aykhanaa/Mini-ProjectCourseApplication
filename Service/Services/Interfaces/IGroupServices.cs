using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IGroupServices
    {
        Task<List<Education>> GetAllAsync();
        Task<Education> GetByIdAsync(int id);
        Task DeleteAsnyc(int? id);
        Task<List<Education>> SearchByNameAsync(string serchText);

    }
}
