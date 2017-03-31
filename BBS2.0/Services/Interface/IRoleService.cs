using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS2._0.ViewModel;

namespace BBS2._0.Services
{
    public interface IRoleService
    {
        List<RoleDTO> GetAllRoles();
        List<RolePermissonDTO> GetRolePermisson(Int32 RoleId);
        bool Register(String name, String description);
        bool SaveRolePermission(Int32 roleId, List<String> keyCodes);
        bool DeleteRole(Int32 roleId);
    }
}
