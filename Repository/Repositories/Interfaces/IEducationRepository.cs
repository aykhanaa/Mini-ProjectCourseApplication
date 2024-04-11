using Domain.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IEducationRepository
    {
        Task<List<Education>> GetAllAsync();
        Task<Education> GetByIdAsync(int id);
        Task DeleteAsnyc(int? id);
        Task<List<Education>> SearchByNameAsync(string serchText);
        Task<List<Education>> GetAllWithGroupsAsync();
        Task<List<Education>> SortWithGroupsAsync(string order);
        Task<Education> Update(Education education);

    }
}
