using AnimeDB.Models.Domains;
using AnimeDB.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimeDB.Services.Interfaces
{
    public interface IRoleService
    {
        int InsertRole(InsertRoleRequest model);
        Role SelecRoleById(int Id);
        List<Role> SelectAllRoles();
        bool UpdateRole(UpdateRoleRequest model);
        bool DeleteRole(DeleteRoleRequest model);
    }
}