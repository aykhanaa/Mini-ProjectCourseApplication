using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IEducatonServices
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
