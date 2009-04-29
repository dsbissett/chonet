using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_ChiTietDonHang
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_ChiTietDonHang()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("ChiTietDonHangID", "ChiTietDonHangID")
                                   ,
                                   new DataColumnMapping("DonHangID", "DonHangID")
                                   ,
                                   new DataColumnMapping("SanPhamID", "SanPhamID")
                                   ,
                                   new DataColumnMapping("TenSanPham", "TenSanPham")
                                   ,
                                   new DataColumnMapping("GiaSanPham", "GiaSanPham")
                                   ,
                                   new DataColumnMapping("SoLuong", "SoLuong")
                                   ,
                                   new DataColumnMapping("TongTien", "TongTien")
                                   ,
                                   new DataColumnMapping("CuaHangID", "CuaHangID")
                                   ,
                                   new DataColumnMapping("TenCuaHang", "TenCuaHang")
                               };
            dtTblMapping = new DataTableMapping("Table", "ChiTietDonHang", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetChiTietDonHang";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ChiTietDonHang");
                return dsResult;
            }
        }

        public DataSet SelectByID(int ChiTietDonHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetChiTietDonHangById";
                sqlCmd.Parameters.Add("@ChiTietDonHangID", SqlDbType.Int).Value = ChiTietDonHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ChiTietDonHang");
                return dsResult;
            }
        }

        public DataSet SelectByDonHangID(int DonHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetChiTietDonHangByDonHangID";
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ChiTietDonHang");
                return dsResult;
            }
        }

        public DataSet SelectBySanPhamID(int SanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetChiTietDonHangBySanPhamID";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ChiTietDonHang");
                return dsResult;
            }
        }

        public DataSet SelectByCuaHangID(int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetChiTietDonHangByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ChiTietDonHang");
                return dsResult;
            }
        }

        public int Insert(int DonHangID, int SanPhamID, string TenSanPham, decimal GiaSanPham, int SoLuong,
                          decimal TongTien, int CuaHangID, string TenCuaHang)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertChiTietDonHang";

                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 50).Value = TenSanPham;

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).Value = GiaSanPham;

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;

                sqlCmd.Parameters.Add("@TongTien", SqlDbType.Money).Value = TongTien;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@TenCuaHang", SqlDbType.NVarChar, 100).Value = TenCuaHang;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void InsertBatch(DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertChiTietDonHang";
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).SourceColumn = "DonHangID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 50).SourceColumn = "TenSanPham";

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).SourceColumn = "GiaSanPham";

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).SourceColumn = "SoLuong";

                sqlCmd.Parameters.Add("@TongTien", SqlDbType.Money).SourceColumn = "TongTien";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@TenCuaHang", SqlDbType.NVarChar, 100).SourceColumn = "TenCuaHang";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertChiTietDonHang_Ref";
                sqlCmd.Parameters.Add("@ChiTietDonHangID", SqlDbType.Int).SourceColumn = "ChiTietDonHangID";
                sqlCmd.Parameters["@ChiTietDonHangID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).SourceColumn = "DonHangID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 4).SourceColumn = "TenSanPham";

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).SourceColumn = "GiaSanPham";

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).SourceColumn = "SoLuong";

                sqlCmd.Parameters.Add("@TongTien", SqlDbType.Money).SourceColumn = "TongTien";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@TenCuaHang", SqlDbType.NVarChar, 4).SourceColumn = "TenCuaHang";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int ChiTietDonHangID, int DonHangID, int SanPhamID, string TenSanPham, decimal GiaSanPham,
                           int SoLuong, decimal TongTien, int CuaHangID, string TenCuaHang)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateChiTietDonHang";

                sqlCmd.Parameters.Add("@ChiTietDonHangID", SqlDbType.Int).Value = ChiTietDonHangID;
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 50).Value = TenSanPham;

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).Value = GiaSanPham;

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;

                sqlCmd.Parameters.Add("@TongTien", SqlDbType.Money).Value = TongTien;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@TenCuaHang", SqlDbType.NVarChar, 100).Value = TenCuaHang;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateChiTietDonHang";
                sqlCmd.Parameters.Add("@ChiTietDonHangID", SqlDbType.Int).SourceColumn = "ChiTietDonHangID";

                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).SourceColumn = "DonHangID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 50).SourceColumn = "TenSanPham";

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).SourceColumn = "GiaSanPham";

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).SourceColumn = "SoLuong";

                sqlCmd.Parameters.Add("@TongTien", SqlDbType.Money).SourceColumn = "TongTien";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@TenCuaHang", SqlDbType.NVarChar, 100).SourceColumn = "TenCuaHang";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateChiTietDonHang";
                sqlCmd.Parameters.Add("@ChiTietDonHangID", SqlDbType.Int).SourceColumn = "ChiTietDonHangID";

                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).SourceColumn = "DonHangID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 50).SourceColumn = "TenSanPham";

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).SourceColumn = "GiaSanPham";

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).SourceColumn = "SoLuong";

                sqlCmd.Parameters.Add("@TongTien", SqlDbType.Money).SourceColumn = "TongTien";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@TenCuaHang", SqlDbType.NVarChar, 100).SourceColumn = "TenCuaHang";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteChiTietDonHang";
                sqlCmd.Parameters.Add("@ChiTietDonHangID", SqlDbType.Int).SourceColumn = "ChiTietDonHangID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int ChiTietDonHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteChiTietDonHang";
                sqlCmd.Parameters.Add("@ChiTietDonHangID", SqlDbType.Int).Value = ChiTietDonHangID;
                objDataAccess.ExecuteQuery(sqlCmd, "ChiTietDonHang");
            }
        }

        public int InsertFields(int? DonHangID, int? SanPhamID, string TenSanPham, decimal? GiaSanPham, int? SoLuong,
                                decimal? TongTien, int? CuaHangID, string TenCuaHang)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsChiTietDonHang";

                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 50).Value = TenSanPham;

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).Value = GiaSanPham;

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;

                sqlCmd.Parameters.Add("@TongTien", SqlDbType.Money).Value = TongTien;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@TenCuaHang", SqlDbType.NVarChar, 100).Value = TenCuaHang;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int ChiTietDonHangID, int? DonHangID, int? SanPhamID, string TenSanPham,
                                 decimal? GiaSanPham, int? SoLuong, decimal? TongTien, int? CuaHangID, string TenCuaHang)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsChiTietDonHang";

                sqlCmd.Parameters.Add("@ChiTietDonHangID", SqlDbType.Int).Value = ChiTietDonHangID;
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 50).Value = TenSanPham;

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).Value = GiaSanPham;

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;

                sqlCmd.Parameters.Add("@TongTien", SqlDbType.Money).Value = TongTien;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@TenCuaHang", SqlDbType.NVarChar, 100).Value = TenCuaHang;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? DonHangID, int? SanPhamID, string TenSanPham,
                                       decimal? GiaSanPham, int? SoLuong, decimal? TongTien, int? CuaHangID,
                                       string TenCuaHang)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsChiTietDonHang";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 50).Value = TenSanPham;

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).Value = GiaSanPham;

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;

                sqlCmd.Parameters.Add("@TongTien", SqlDbType.Money).Value = TongTien;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@TenCuaHang", SqlDbType.NVarChar, 100).Value = TenCuaHang;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public DataSet SelectByField(string FieldName, string value, string type)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "SelectChiTietDonHangByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ChiTietDonHang");
                return dsResult;
            }
        }

        public DataSet SelectByDonHangIDPaging(int DonHangID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetChiTietDonHangByDonHangIDPaging";
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ChiTietDonHang");
                return dsResult;
            }
        }

        public DataSet SelectBySanPhamIDPaging(int SanPhamID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetChiTietDonHangBySanPhamIDPaging";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ChiTietDonHang");
                return dsResult;
            }
        }

        public DataSet SelectByCuaHangIDPaging(int CuaHangID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetChiTietDonHangByCuaHangIDPaging";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ChiTietDonHang");
                return dsResult;
            }
        }
    }
}