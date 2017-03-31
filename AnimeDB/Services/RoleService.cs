using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Sabio.Data;
using System.Linq;
using System.Web;
using AnimeDB.Models.Requests;
using AnimeDB.Models.Domains;
using System.Data;
using AnimeDB.Services.Interfaces;

namespace AnimeDB.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public int InsertRole(InsertRoleRequest model)
        {
            int id = 0;
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Role_Insert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("Name", model.Name);
                    paramCollection.AddWithValue("Description", model.Description);

                    SqlParameter roleId = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    roleId.Direction = System.Data.ParameterDirection.Output;

                    paramCollection.Add(roleId);
                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@Id"].Value.ToString(), out id);
                });
            return id;
        }

        public Role SelecRoleById(int Id)
        {
            Role RoleInfo = new Role();

            DataProvider.ExecuteCmd(GetConnection, "dbo.Role_SelectById"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {

                }, map: delegate (IDataReader reader, short set)
                {
                    int startingIndex = 0;

                    RoleInfo.Id = reader.GetSafeInt32(startingIndex++);
                    RoleInfo.Name = reader.GetSafeString(startingIndex++);
                    RoleInfo.Description = reader.GetSafeString(startingIndex++);
                });
            return RoleInfo;
        }

        public List<Role> SelectAllRoles()
        {
            List<Role> RoleList = new List<Role>();

            DataProvider.ExecuteCmd(GetConnection, "dbo.Role_SelectAll"
                , inputParamMapper: delegate(SqlParameterCollection paramCollection)
                {
                    
                }, map: delegate(IDataReader reader, short set)
                {
                    Role Role = new Role();
                    int startingIndex = 0;

                    Role.Id = reader.GetSafeInt32(startingIndex++);
                    Role.Name = reader.GetSafeString(startingIndex++);
                    Role.Description = reader.GetSafeString(startingIndex++);

                    RoleList.Add(Role);

                });
            return RoleList;
        }

        public bool UpdateRole(UpdateRoleRequest model)
        {
            bool success = false;
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Role_Update",
                inputParamMapper: delegate(SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Name", model.Name);
                    paramCollection.AddWithValue("@Description", model.Description);
                    paramCollection.AddWithValue("@Id", model.Id);
                }, returnParameters: delegate(SqlParameterCollection param)
                {
                    success = true;
                });
            return success;
        }

        public bool DeleteRole(DeleteRoleRequest model)
        {
            bool success = false;
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Role_Delete"
                , inputParamMapper: delegate(SqlParameterCollection parameCollection)
                {
                    parameCollection.AddWithValue("@Id", model.Id);
                }, returnParameters: delegate(SqlParameterCollection param)
                {
                    success = true;
                });
            return success;
        }
    }
}