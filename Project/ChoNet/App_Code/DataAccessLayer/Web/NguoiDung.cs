using System.Data;
using System.Data.SqlClient;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class NguoiDung : Base_NguoiDung
    {
        #region Constructors

        #endregion

        #region Added Code

        public DataSet SelectAllNguoiDung()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllNguoiDung";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NguoiDung");
                return dsResult;
            }
        }

        public bool CheckExistTenTruyCap(int id, string TenTruyCap)
        {
            DataAccess objDataAccess = new DataAccess();
            int result = 0;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_CheckExistTenTruyCap";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = id;
                sqlCmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = TenTruyCap;
                result = objDataAccess.ExecuteScalar(sqlCmd);
                if (result == 0)
                    return false;
                else
                    return true;
            }
        }

        #endregion
    }
}