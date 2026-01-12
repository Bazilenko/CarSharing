using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarSharing.DAL.Entity;

namespace CarSharing.DAL.Repository.Interfaces
{
    public interface IDocumentRepository : IGenericRepository<Document>
    {
        
        Task<IEnumerable<Document>> GetUserDocumentsAsync(int userId);

       
        Task<IEnumerable<Document>> GetPendingDocumentsAsync();
    }
}
