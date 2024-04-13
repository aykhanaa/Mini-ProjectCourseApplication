using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class EducatonServices : IEducatonServices
    {
        private readonly AppDbContext _context;
        private int count = 1;

        public EducatonServices()
        {
            _context = new AppDbContext();
        }


        public async Task CreateAsync(Education education)
        {
         await _context.Educations.AddAsync(education);
         await _context.SaveChangesAsync();
        }


        public async Task DeleteAsnyc(int? id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            var data = _context.Educations.FirstOrDefault(m=>m.Id == id);

            if (data is null)
            {
                throw new ("Data not found");
            }
            _context.Educations.Remove(data);

            await _context.SaveChangesAsync();
                       
        }


        public async Task<List<Education>> GetAllAsync()
        {
            return await _context.Educations.ToListAsync();
        }



        public async Task<List<Group>> GetAllWithGroupsAsync()
        {
         var educations = await _context.Groups.Include(m => m.Education.Groups).ToListAsync();
         if(educations.Count == 0)
            {
                throw new NotFoundException("Data not found");
            }
         return educations;
        }


        public async Task<Education> GetByIdAsync(int id)
        {
            var data =  _context.Educations.FirstOrDefault(m => m.Id == id);

            if(data is null)
            {
                throw new NotFoundException("Data not found");
            }
            return data;
        }


        public async Task<List<Education>> SearchByNameAsync(string serchText)
        {
            var search = await _context.Educations.Where(m => m.Name.ToLower().Trim().Contains(serchText)).ToListAsync();

            if(search is null)
            {
                throw new NotFoundException("Data not found");
            }
            return search;
        }


        public async Task<List<Education>> SortWithGroupsAsync(string order)
        {
            return await _context.Educations.ToListAsync();
        }

        public Task<Education> Update(Education education)
        {
            throw new NotImplementedException();
        }

        Task<List<Education>> IEducatonServices.GetAllWithGroupsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
