using Domain.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateAsync(Group group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsnyc(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            var data = _context.Groups.FirstOrDefault(m => m.Id == id);

            if (data is null)
            {
                throw new("Data not found");
            }
            _context.Groups.Remove(data);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Group>> FilterByEducationName(string name)
        {
            var data = await _context.Groups.Include(m => m.Education).Where(m => m.Education.Name == name).ToListAsync();
            if (data is null)
            {
                throw new NotFoundException("Data not found");
            }
            return data;
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<List<Group>> GetAllWithEducationIdAsync(int? id)
        {
            return await _context.Groups.Include(m => m.Id).ToListAsync();
        }

        public Task<Group> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Group>> SearchByNameAsync(string serchText)
        {
            var search = await _context.Groups.Where(m => m.Name.ToLower().Trim().Contains(serchText)).ToListAsync();

            if (search is null)
            {
                throw new NotFoundException("Data not found");
            }
            return search;
        }

        public async Task<List<Group>> SortWithCapacityAsync(string text)
        {
            if (text.ToLower().Trim() == "asc")
            {
                return await _context.Groups.OrderBy(m => m.Capacity).ToListAsync();
            }
            else if (text.ToLower().Trim() == "desc")
            {
                return await _context.Groups.OrderByDescending(m => m.Capacity).ToListAsync();
            }
            else
            {
                throw new Exception("Incorrect Operation");
            }
        }

        public Task<Group> Update(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
