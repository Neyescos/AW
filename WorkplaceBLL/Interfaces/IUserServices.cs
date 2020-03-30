using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    public interface IUserServices
    {
        Task UpdateUser(UserDTO user);
        Task<UserDTO> GetUser(int? id);
        Task <IEnumerable<UserDTO>> GetUsers();
        Task Delete(int id);
    }
}
