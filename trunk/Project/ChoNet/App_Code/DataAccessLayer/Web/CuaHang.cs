using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class CuaHang : Base_CuaHang
    {
        #region Constructors

        #endregion

        #region Added Code

        // add user code here\
        public DataSet SelectByCuaHangID(int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet(); dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetViewCuaHangById";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }
        public DataSet SelectAllCuaHangAtViTriCuaHang(int ViTriCuaHang)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllCuaHangAtViTriCuaHang";
                sqlCmd.Parameters.Add("@ViTriCuaHang", SqlDbType.Int).Value = ViTriCuaHang;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        public DataSet SelectAllCuaHangAtViTriCuaHangByKhuVuc(int ViTriCuaHang, int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllCuaHangAtViTriCuaHangByKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                sqlCmd.Parameters.Add("@ViTriCuaHang", SqlDbType.Int).Value = ViTriCuaHang;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        public DataSet SelectAllCuaHangAtViTriCuaHangByNguoiDungID(int NguoiDungID, int ViTriCuaHang)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllCuaHangAtViTriCuaHangByNguoiDungID";
                sqlCmd.Parameters.Add("@ViTriCuaHang", SqlDbType.Int).Value = ViTriCuaHang;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        public DataSet SelectCuaHangAtViTriCuaHang(int ViTriCuaHang)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetCuaHangAtViTriCuaHang";
                sqlCmd.Parameters.Add("@ViTriCuaHang", SqlDbType.Int).Value = ViTriCuaHang;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        public DataSet SelectCuaHangAtViTriCuaHangByKhuVuc(int ViTriCuaHang, int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetCuaHangAtViTriCuaHangByKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                sqlCmd.Parameters.Add("@ViTriCuaHang", SqlDbType.Int).Value = ViTriCuaHang;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        public DataSet SelectCuaHangAtViTriCuaHangByNguoiDungID(int NguoiDungID, int ViTriCuaHang)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetCuaHangAtViTriCuaHangByNguoiDungID";
                sqlCmd.Parameters.Add("@ViTriCuaHang", SqlDbType.Int).Value = ViTriCuaHang;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        public DataSet SelectCuaHangAtViTriCuaHangByCuaHangID(int CuaHangID, int ViTriCuaHang)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetCuaHangAtViTriCuaHangByCuaHangID";
                sqlCmd.Parameters.Add("@ViTriCuaHang", SqlDbType.Int).Value = ViTriCuaHang;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        public DataSet SelectAllCuaHangPaging(int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllCuaHangPaging";
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        public DataSet SelectCuaHangInNhomSanPhamIDPaging(int NhomSanPhamID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetCuaHangInNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        //loai cua hang = 1 -> VIP
        //loai cua hang = 2 -> Chuyên nghiệp
        //loai cua hang = 3 -> VIP
        public DataSet SelectCuaHangInLoaiCuaHangNhomSanPhamIDPaging(string KeySearch, int Loaicuahang,
                                                                     int NhomSanPhamID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetCuaHangInLoaiCuaHangNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@KeySearch", SqlDbType.NVarChar).Value = KeySearch;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@LoaiCuaHang", SqlDbType.Int).Value = Loaicuahang;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        public DataSet SelectAllCuaHangByNhomSanPhamIDPaging(int NhomSanPhamID, string KeySearch, int RowStart,
                                                             int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllCuaHangByNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@KeySearch", SqlDbType.NVarChar).Value = KeySearch;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        public DataSet SelectAllCuaHangPaging(string KeySearch, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllCuaHangPaging";
                sqlCmd.Parameters.Add("@KeySearch", SqlDbType.NVarChar).Value = KeySearch;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }

        #endregion
    }
}