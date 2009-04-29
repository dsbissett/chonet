using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class SanPham : Base_SanPham
    {
        #region Constructors

        #endregion

        #region Added Code

        public DataSet SelectRanDomSixSanPhamByNhomSanPhamID(int cid)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetRanDomSixSanPhamByNhomSanPhamID";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = cid;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamByNguoiDungID(int NguoiDungID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamByNguoiDungId";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectBySanPhamID(int SanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamByID";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamByVTSPKhuVucID(int ViTriSanPham, int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectSanPhamByVTSP";
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamByVTSP(int ViTriSanPham)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectSanPhamByVTSP";
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamAtViTriSanPhamPaging(int ViTriSanPham, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamAtViTriSanPhamPaging";
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamAtViTriSanPhamByKhuVuc(int ViTriSanPham, int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamAtViTriSanPhamByKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamAtViTriSanPhamByNguoiDungID(int ViTriSanPham, int NguoiDungID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamAtViTriSanPhamByNguoiDungID";
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamAtViTriSanPhamByNguoiDungIDPaging(int ViTriSanPham, int NguoiDungID, int RowStart,
                                                                         int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamAtViTriSanPhamByNguoiDungIDPaging";
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamAtViTriSanPhamInNhomSanPhamID(int ViTriSanPham, int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamAtViTriSanPhamInNhomSanPhamID";
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamAtViTriSanPhamInNhomSanPhamIDPaging(int ViTriSanPham, int NhomSanPhamID,
                                                                           int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamAtViTriSanPhamInNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamAtViTriSanPham(int ViTriSanPham)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamAtViTriSanPham";
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamAtViTriSanPhamByKhuVuc(int ViTriSanPham, int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamAtViTriSanPhamByKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamAtViTriSanPhamInNhomSanPhamID(int ViTriSanPham, int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamAtViTriSanPhamInNhomSanPhamID";
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSelectedSanPhamAtViTriSanPhamInNhomSanPhamID(int ViTriSanPham, int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamAtViTriSanPhamInNhomSanPhamID";
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamAtViTriSanPhamInNhomSanPhamIDByKhuVuc(int ViTriSanPham, int NhomSanPhamID,
                                                                          int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamAtViTriSanPhamInNhomSanPhamIDByKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectTopTenSanPhamByCuaHangID(int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetTopTenSanPhamByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamByCuaHangID(int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamQuaHanByCuaHangID(int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamQuaHanByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamQuaHanByChuCuaHangID(int ChuCuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamQuaHanByNguoiDungID";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = ChuCuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamByCuaHangIDPaging(int CuaHangID, int RowStart, int PageSize, string keysearch)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamByCuaHangIDPaging";
                sqlCmd.Parameters.Add("@KeySearch", SqlDbType.NVarChar).Value = keysearch;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamByCuaHangIDInNhomSanPhamIDPaging(int NhomSanPhamID, int CuaHangID, int RowStart,
                                                                     int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamByCuaHangIDInNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamByNhomSanPhamIDPaging(int NhomSanPhamID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamByNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamByNhomSanPhamIDPaging(int NhomSanPhamID, string ThuocTinhID, int RowStart,
                                                          int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamByNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.NVarChar, 100).Value = ThuocTinhID;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectTopFiveSanPhamSapHetKhuyenMai()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetTopFiveSanPhamSapHetKhuyenMai";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectTopFourSanPhamUaChuong()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetTopFourSanPhamUaChuong";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectTopFourSanPhamUaChuongByNhomSanPhamID(int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetTopFourSanPhamUaChuongByNhomSanPhamID";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamGiamGia()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamGiamGia";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamGiamGiaByNhomSanPhamID(int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamGiamGiaByNhomSanPhamID";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamGiamGiaPaging(int PageSize, int RowStart)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamGiamGiaPaging";
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamGiamGiaByCuaHangIDPaging(int CuaHangID, int PageSize, int RowStart)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamGiamGiaByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamGiamGiaByNhomSanPhamIDPaging(int NhomSanPhamID, int PageSize, int RowStart)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamGiamGiaByNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamKhuyenMai()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamKhuyenMai";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSPUc_Top4_GG_KM_GH()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSPuc_Top4_GG_KM_DH_ForHomePage";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamKhuyenMaiPaging(int PageSize, int RowStart)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamKhuyenMaiPaging";
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamKhuyenMaiByCuaHangIDPaging(int CuaHangID, int PageSize, int RowStart)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamKhuyenMaiByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamKhuyenMaiByNhomSanPhamIDPaging(int NhomSanPhamID, int PageSize, int RowStart)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamKhuyenMaiByNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamUaChuongPaging(int PageSize, int RowStart)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamUaChuongPaging";
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamUaChuongByNhomSanPhamIDPaging(int NhomSanPhamID, int PageSize, int RowStart)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamUaChuongByNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamMoiCapNhat()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamMoiCapNhat";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamMoiCapNhatPaging(int PageSize, int RowStart)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamMoiCapNhatPaging";
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamMoiCapNhatByCuaHangID(int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamMoiCapNhatByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectSanPhamMoiCapNhatByNhomSanPhamID(int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamMoiCapNhatByNhomSanPhamID";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SearchByKeyWordAndNhomSanPhamID(string keyword, int NhomSanPhamID, string strOrder)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetSanPhamByKeyWordAndNhomSanPhamID";
                sqlCmd.Parameters.Add("@KeyWord", SqlDbType.NVarChar, 255).Value = keyword;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@strOrder", SqlDbType.NVarChar, 100).Value = strOrder;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet AdvanceSearch(string keyword, string strWhere, string strOrder)
        {
            try
            {
                DataAccess objDataAccess = new DataAccess();
                DataSet dsResult = new DataSet();
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "_AdvanceSearch";
                    sqlCmd.Parameters.Add("@KeyWord", SqlDbType.NVarChar, 255).Value = keyword;
                    sqlCmd.Parameters.Add("@strWhere", SqlDbType.NVarChar, 1000).Value = strWhere;
                    sqlCmd.Parameters.Add("@strOrder", SqlDbType.NVarChar, 50).Value = strOrder;
                    dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                    return dsResult;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CountSanPhamByMaSo(string strDate)
        {
            DataAccess objDataAccess = new DataAccess();
            int intResult = 0;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_CountSanPhamByMaSo";
                sqlCmd.Parameters.Add("@Str", SqlDbType.VarChar).Value = strDate;
                intResult = objDataAccess.ExecuteScalar(sqlCmd);
                return intResult;
            }
        }

        public DataSet SelectAllSanPham()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamForAdmin";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamQuaHan()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamQuaHanForAdmin";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamPaging(string keysearch, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamForAdminPaging";
                sqlCmd.Parameters.Add("@KeySearch", SqlDbType.NVarChar, 1000).Value = keysearch;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        public DataSet SelectAllSanPhamByNguoiDungIDPaging(int NguoiDUngID, string keysearch, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllSanPhamByNguoiDungIDPaging";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDUngID;
                sqlCmd.Parameters.Add("@KeySearch", SqlDbType.NVarChar, 1000).Value = keysearch;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPham");
                return dsResult;
            }
        }

        #endregion
    }
}