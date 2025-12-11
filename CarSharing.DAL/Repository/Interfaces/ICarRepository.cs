using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Entity;

namespace CarSharing.DAL.Repository.Interfaces
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        
        Task<Car?> GetCarWithDetailsAsync(int id);
    }
}
