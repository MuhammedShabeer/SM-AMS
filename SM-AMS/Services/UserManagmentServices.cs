using SM_AMS.Services.ServerConnection;
using System.Data.SqlClient;
using System.Data;
using SM_AMS.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Policy;

namespace SM_AMS.Services.UserAdmin
{
    public class UserManagmentServices
    {
        private readonly DatabaseManager dbManager;

        public UserManagmentServices()
        {
            dbManager = new DatabaseManager();
        }
        public List<UserManagmentModel> GetUsers(int? id = null)
        {
            List<UserManagmentModel> userManagmentlst = new List<UserManagmentModel>();
            try
            {
                string spName = "spGetUsers";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@numID", id)
                };
                var dt = dbManager.GetDataTable(spName, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    userManagmentlst.Add(new UserManagmentModel
                    {
                        Id = Convert.ToInt32(row["numID"]),
                        UserName = row["chvUserName"].ToString(),
                        Email = row["chvEmail"].ToString(),
                        BranchID = Convert.ToInt32(row["numBranchID"]),
                        Branch = row["Branch"].ToString(),
                        UserType = (EnumModel.enmUserType)Convert.ToInt32(row["tnyUserType"]),
                    });
                }

            }
            catch (Exception)
            {

                throw;
            }
            return userManagmentlst;
        }
        public void SaveUsers(UserManagmentModel model)
        {
            try
            {
                string spName = "spSaveUsers";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@numID", model.Id),
                new SqlParameter("@chvUserName", model.UserName),
                new SqlParameter("@chvEmail",model.Email),
                new SqlParameter("@numBranchID",model.BranchID),
                new SqlParameter("@tnyUserType",(int)model.UserType)
                };
                dbManager.ExecuteNonQuery(spName, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteUser(int id)
        {
            try
            {
                dbManager.Delete($"Delete [dbo].[tbl_Users_Mst] Where numID = {id}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
