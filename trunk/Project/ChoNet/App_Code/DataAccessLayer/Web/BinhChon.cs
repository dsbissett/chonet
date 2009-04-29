using System.Data;
using System.Data.SqlClient;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class BinhChon : Base_BinhChon
    {
        #region Constructors

        #endregion

        #region Added Code

        public DataSet SelectBinhChonByNguoiDungIDAndCuaHangID(int NguoiDungID, int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetBinhChonByNguoiDungIdAndCuaHangId";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "BinhChon");
                return dsResult;
            }
        }

        #endregion
    }
}