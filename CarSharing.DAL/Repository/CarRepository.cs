using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Context;
using CarSharing.DAL.Entity;
using CarSharing.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarSharing.DAL.Repository
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Car?> GetCarWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Images)      
                .Include(c => c.Host)        
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _dbSet
                .Include(c => c.Images)
                .Include(c => c.Host)
                .ToListAsync();
        }
    }
}
