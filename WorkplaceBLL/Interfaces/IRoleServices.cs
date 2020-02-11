using System;
using System.Collections.Generic;
using System.Text;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    interface IRoleServices
    {
        void MakeRole(RoleDTO roleDTO);
        RoleDTO GetRole(int? id);
        IEnumerable<RoleDTO> GetRoles();
        void Dispose();

    }
}
