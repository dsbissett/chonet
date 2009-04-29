using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class NhomSanPham : Base_NhomSanPham
    {
        #region Constructors

        #endregion

        #region Added Code
        public DataSet SelectNhomSanPhamByLevel(int level)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectNhomSanPhamByLevel";
                sqlCmd.Parameters.Add("@Level", SqlDbType.Int).Value = level;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }
        public DataSet SelectAllNhomSanPhamByLevel()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectAllNhomSanPhamByLevel";

                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
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
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectRanDomNhomSanPhamShowed()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectRanDomNhomSanPhamShowed";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectNhomSanPhamByNhomChaAndCuaHangID(int CuaHangID, int NhomChaID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectNhomSanPhamByNhomChaAndCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).Value = NhomChaID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectNhomSanPhamNotInCuaHangbyCuaHangID(int CuaHangID, int NhomChaID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectNhomSanPhamNotInCuaHangbyCuaHangID";
                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).Value = NhomChaID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectNhomSanPhamByNhomChaID(int NhomChaID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectNhomSanPhamByNhomChaID";
                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).Value = NhomChaID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectNhomVaNhomChaByNhomSanPhamID(int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectNhomVaNhomChaByNhomSanPhamID";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectNhomSanPhamNotIsNhomCha(int NhomChaID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectNhomSanPhamNotIsNhomCha";
                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).Value = NhomChaID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllNhomCha()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectAllNhomCha";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }

        #endregion
    }
}