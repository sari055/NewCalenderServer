using Microsoft.EntityFrameworkCore;
using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Repositories
{
    public class ParentRepository : IParentRepository
    {
        readonly IContext _context;

        public ParentRepository(IContext context)
        {
            _context = context;
        }


  

        public async Task<Parent> AddAsync( string firstName, string lastName, DateTime dateOfBirth,string tz, string type, string hMO/*, List<int> childrenId*/)
        {
            Parent parent = new Parent() { FirstName = firstName, LastName = lastName,DateOfBirth = dateOfBirth,Tz=tz, Type = type, HMO = hMO};
            _context.Parents.Add(parent);
            await _context.SaveChangesAsync();
            return parent;
        }
        public async Task<string> CreateTzAsync(string tz)
        {
            return tz;
        }
        public async Task DeleteAsync(int id)
        {
            _context.Parents.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Parent>> GetAllAsync()
        {
            return await _context.Parents.ToListAsync();
        }

        public async Task<Parent> GetByIdAsync(int id)
        {
            return await _context.Parents.FindAsync(id);
        }
        public async Task<int> GetByTzAsync(string tz)
        {
            var parentsList = await GetAllAsync();
            return parentsList.Find(u => u.Tz == tz).Id;
            // return await _context.Parents.FindAsync(tz);
        }
        public async Task<Parent> UpdateAsync(Parent parent)
        {
            var updateParent = _context.Parents.Update(parent).Entity;
            await _context.SaveChangesAsync();
            return updateParent;
        }
    }
}
