using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InGazAPI.Models;
using InGazAPI.Data;

namespace InGazAPI.Repositories
{
    public class StationRepository
    {
        private readonly YourDbContext _context;
        private readonly DbSet<Station> _dbSet;

        public StationRepository(InGazDbContext context)
        {
            _context = context;
            _dbSet = context.Stations; // or _context.Set<Station>();
        }

        // Stations Methods
        public async Task<IEnumerable<Station>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Station?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Station station)
        {
            await _dbSet.AddAsync(station);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Station station)
        {
            _dbSet.Update(station);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Station station)
        {
            _dbSet.Remove(station);
            await _context.SaveChangesAsync();
        }

      

        // Custom Methods
        public async Task<IEnumerable<Station>> GetByAreaIdAsync(int areaId)
        {
            return await _dbSet.Where(s => s.AreaId == areaId).ToListAsync();
        }

        public async Task<IEnumerable<Station>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(s => s.AssignedUsers.Any(u => u.UserId == userId))
                .ToListAsync();
        }
    }


    public class AreaRepository
    {
        private readonly InGazDbContext _context;
        private readonly DbSet<Area> _dbSet;

        public AreaRepository(InGazDbContext context)
        {
            _context = context;
            _dbSet = context.Area; // or _context.Set<Area>();
        }

        // Areas Methods
        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Area?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Area area)
        {
            await _dbSet.AddAsync(area);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Area area)
        {
            _dbSet.Update(area);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Area area)
        {
            _dbSet.Remove(area);
            await _context.SaveChangesAsync();
        }

        // Custom Methods
        public async Task<IEnumerable<Area>> GetByAreaIdAsync(int areaId)
        {
            return await _dbSet.Where(s => s.AreaId == areaId).ToListAsync();
        }

        public async Task<IEnumerable<Area>> GetByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(s => s.AssignedUsers.Any(u => u.UserId == userId))
                .ToListAsync();
        }
    }
}
