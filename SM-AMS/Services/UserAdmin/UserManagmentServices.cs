using SM_AMS.Services.ServerConnection;
using System.Data.SqlClient;
using System.Data;
using SM_AMS.Models;
using System.Collections.Generic;

namespace SM_AMS.Services.UserAdmin
{
    public class UserManagmentServices
    {
        private readonly DatabaseManager dbManager;

        public UserManagmentServices()
        {
            dbManager = new DatabaseManager();
        }

        public List<UserManagmentModel> GetUsers()
        {
            List<UserManagmentModel> userManagmentlst = new List<UserManagmentModel>();
            string spName = "spGetUsers";
            var dt = dbManager.GetDataTable(spName);
            return userManagmentlst;
        }

        public void SaveUsers(UserManagmentModel model)
        {
            string spName = "spSaveUsers";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@numID", model.Id),
                new SqlParameter("@chvUserName", model.UserName),
                new SqlParameter("@chvEmail",model.Email),
                new SqlParameter("@numBranchID",model.Branch),
                new SqlParameter("@tnyUserType",model.UserTypeID)
            };
            dbManager.ExecuteNonQuery(spName, parameters);
        }
    }
}
