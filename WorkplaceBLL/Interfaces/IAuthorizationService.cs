using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    public interface IAuthorizationService
    {
        Task Registration(UserDTO user);
        Task<UserDTO> Login(string password, string email);
    }
}
