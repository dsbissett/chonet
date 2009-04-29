using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class CuaHangNhomSanPham : Base_CuaHangNhomSanPham
    {
        #region Constructors

        #endregion

        #region Added Code

        // add user code here
        public void DeleteAllByCuaHangNhomSanPhamID(int CuaHangNhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_DeleteAllCuaHangNhomSanPhamByCuahangNhomSanPhamID";
                sqlCmd.Parameters.Add("@CuaHangNhomSanPhamID", SqlDbType.Int).Value = CuaHangNhomSanPhamID;
                objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
            }
        }

        public DataSet SelectNhomSanPhamByCuaHangID(int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectNhomSanPhamByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByNhomSanPhamCuaHangID(int CuaHangID, int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectCuaHangNhomSanPhamByNhomSanPhamCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
                return dsResult;
            }
        }

        #endregion
    }
}