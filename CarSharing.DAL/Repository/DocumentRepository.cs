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
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Document>> GetUserDocumentsAsync(int userId)
        {
            return await _dbSet
                .Where(d => d.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Document>> GetPendingDocumentsAsync()
        {
            return await _dbSet
                .Include(d => d.User) 
                .Where(d => d.Status == "Pending")
                .ToListAsync();
        }
    }
}
