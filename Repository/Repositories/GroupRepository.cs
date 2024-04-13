using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GroupRepository : IGroupRepository
    {

        private readonly AppDbContext _context;

        public GroupRepository()
        {
            _context = new AppDbContext();
        }

        public Task CreateAsync(Group group)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsnyc(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> FilterByEducationName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> GetAllWithEducationIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> SearchByNameAsync(string serchText)
        {
            throw new NotImplementedException();
        }

        public Task<List<Group>> SortWithCapacityAsync(string order)
        {
            throw new NotImplementedException();
        }

        public Task<Group> Update(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
