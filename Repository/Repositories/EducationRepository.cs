using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Repository.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly AppDbContext _context;

        public EducationRepository()
        {
            _context = new AppDbContext();
        }


        public async Task DeleteAsnyc(int? id)
        {
           _context.Remove(id);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Education>> GetAllAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<List<Education>> GetAllWithGroupsAsync()
        {
           return await _context.Educations.Include(m=>m.Group).ToListAsync();
        }

        public async Task<Education> GetByIdAsync(int id)
        {
            return _context.Educations.FirstOrDefault(m => m.Id == id);
        }

 

        public async Task<List<Education>> SearchByNameAsync(string serchText)
        {
           return await _context.Educations.Where(m=>m.Name.ToLower().Trim().Contains(serchText)).ToListAsync();
        }

        public async Task<List<Education>> SortWithGroupsAsync(string order)
        {
          return await _context.Educations.ToListAsync();
        }

        public Task<Education> Update(Education education)
        {
            throw new NotImplementedException();
        }
    }
}
