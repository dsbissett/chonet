using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class TinTuc : Base_TinTuc
    {
        #region Constructors

        #endregion

        #region Added Code

        public DataSet GetTinTucByThuTu(int ThuTu)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetTinTucByThuTu";
                sqlCmd.Parameters.Add("@Order", SqlDbType.Int).Value = ThuTu;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TinTuc");
                return dsResult;
            }
        }

        public DataSet SelectAdminNews()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetTinTucByAdmin";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "tintuc");
                return dsResult;
            }
        }

        public DataSet GetTopFiveTinTucByNguoiDung(int NguoiDungID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetTopFiveTinTucByNguoiDungID";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TinTuc");
                return dsResult;
            }
        }

        public DataSet SelectTinTucByNguoiDungID(int NguoiDungID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetTinTucByNguoiDungID";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TinTuc");
                return dsResult;
            }
        }

        #endregion
    }
}