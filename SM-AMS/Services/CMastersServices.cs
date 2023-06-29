using SM_AMS.Models;
using SM_AMS.Services.ServerConnection;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using static SM_AMS.Models.EnumModel;

namespace SM_AMS.Services.UserAdmin
{
    public class CMastersServices
    {
        private readonly DatabaseManager dbManager;
        public CMastersServices()
        {
            dbManager = new DatabaseManager();
        }
        public List<CMastersModel> GetCMasters(enmCMasters CMasters, int? id = null)
        {
            List<CMastersModel> Mstlst = new List<CMastersModel>();
            try
            {
                string spName = "[dbo].[spGetCMasters]";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@numID", id),
                    new SqlParameter("@CMasters",(int)CMasters)
                };
                var dt = dbManager.GetDataTable(spName, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    Mstlst.Add(new CMastersModel
                    {
                        Id = Convert.ToInt32(row["numID"]),
                        code = row["chvCode"].ToString(),
                        Name = row["chvName"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Mstlst;
        }
        public void SaveCMasters(enmCMasters CMasters, CMastersModel model)
        {
            try
            {
                string spName = "[dbo].[spSaveCMasters]";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@numID", model.Id),
                    new SqlParameter("@chvCode", model.code),
                    new SqlParameter("@chvName",model.Name),
                    new SqlParameter("@CMasters",(int)CMasters)
                };
                dbManager.ExecuteNonQuery(spName, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteCMasters(enmCMasters CMasters, int id)
        {
            try
            {
                string spName = "[dbo].[spDeleteCMasters]";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@numID", id),
                    new SqlParameter("@CMasters",(int)CMasters)
                };
                dbManager.ExecuteNonQuery(spName, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
