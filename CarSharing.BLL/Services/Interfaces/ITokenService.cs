using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.DAL.Entity;

namespace CarSharing.BLL.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
    }
}
