using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSharing.BLL.DTOs;
using CarSharing.BLL.DTOs.User;

namespace CarSharing.BLL.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterUserDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}
