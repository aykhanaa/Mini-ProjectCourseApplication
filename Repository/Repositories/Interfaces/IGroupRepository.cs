using Domain.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAllAsync();
        Task<Group> GetByIdAsync(int id);
        Task DeleteAsnyc(int? id);
        Task<List<Group>> SearchByNameAsync(string serchText);
        Task<List<Group>> GetAllWithEducationIdAsync(int? id);
        Task<List<Group>> SortWithCapacityAsync(string order);
        Task<Group> Update(Group group);
        Task<List<Group>> FilterByEducationName(string name);
    }
}
