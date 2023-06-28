using SM_AMS.Models;
using SM_AMS.Services.ServerConnection;
using System.Data.SqlClient;
using System.Data;

namespace SM_AMS.Services.UserAdmin
{
    public class BranchMasterServices
    {
        private readonly DatabaseManager dbManager;
        public BranchMasterServices()
        {
            dbManager = new DatabaseManager();
        }
        public List<BranchModel> GetBranches(int? id = null)
        {
            List<BranchModel> BrMstlst = new List<BranchModel>();
            try
            {
                string spName = "[dbo].[spGetBranch]";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@numBrID", id)
                };
                var dt = dbManager.GetDataTable(spName, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    BrMstlst.Add(new BranchModel
                    {
                        Id = Convert.ToInt32(row["numBrID"]),
                        code = row["chvBranchCode"].ToString(),
                        Name = row["chvBranchName"].ToString()
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return BrMstlst;
        }
        public void SaveBranch(BranchModel model)
        {
            try
            {
                string spName = "[dbo].[spSaveBranch]";
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@numBrID", model.Id),
                new SqlParameter("@chvBranchCode", model.code),
                new SqlParameter("@chvBrName",model.Name)
                };
                dbManager.ExecuteNonQuery(spName, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteBranch(int id)
        {
            try
            {
                dbManager.Delete($"Delete [dbo].[tbl_Branch_Mst] Where numBrID = {id}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
