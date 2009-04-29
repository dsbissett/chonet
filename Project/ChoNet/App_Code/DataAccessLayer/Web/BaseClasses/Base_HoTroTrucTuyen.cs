using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_HoTroTrucTuyen
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_HoTroTrucTuyen()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("HoTroTrucTuyenID", "HoTroTrucTuyenID")
                                   ,
                                   new DataColumnMapping("CuaHangID", "CuaHangID")
                                   ,
                                   new DataColumnMapping("TenHoTro", "TenHoTro")
                                   ,
                                   new DataColumnMapping("YM", "YM")
                                   ,
                                   new DataColumnMapping("HoVaTen", "HoVaTen")
                                   ,
                                   new DataColumnMapping("DienThoai", "DienThoai")
                                   ,
                                   new DataColumnMapping("email", "email")
                               };
            dtTblMapping = new DataTableMapping("Table", "HoTroTrucTuyen", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetHoTroTrucTuyen";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HoTroTrucTuyen");
                return dsResult;
            }
        }

        public DataSet SelectByID(int HoTroTrucTuyenID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetHoTroTrucTuyenById";
                sqlCmd.Parameters.Add("@HoTroTrucTuyenID", SqlDbType.Int).Value = HoTroTrucTuyenID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HoTroTrucTuyen");
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
                sqlCmd.CommandText = "GetHoTroTrucTuyenByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HoTroTrucTuyen");
                return dsResult;
            }
        }

        public int Insert(int CuaHangID, string TenHoTro, string YM, string HoVaTen, string DienThoai, string email)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertHoTroTrucTuyen";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@TenHoTro", SqlDbType.NVarChar, 100).Value = TenHoTro;

                sqlCmd.Parameters.Add("@YM", SqlDbType.VarChar, 100).Value = YM;

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).Value = HoVaTen;

                sqlCmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 20).Value = DienThoai;

                sqlCmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;


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
                sqlCmd.CommandText = "InsertHoTroTrucTuyen";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@TenHoTro", SqlDbType.NVarChar, 100).SourceColumn = "TenHoTro";

                sqlCmd.Parameters.Add("@YM", SqlDbType.VarChar, 100).SourceColumn = "YM";

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).SourceColumn = "HoVaTen";

                sqlCmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 20).SourceColumn = "DienThoai";

                sqlCmd.Parameters.Add("@email", SqlDbType.VarChar, 100).SourceColumn = "email";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertHoTroTrucTuyen_Ref";
                sqlCmd.Parameters.Add("@HoTroTrucTuyenID", SqlDbType.Int).SourceColumn = "HoTroTrucTuyenID";
                sqlCmd.Parameters["@HoTroTrucTuyenID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@TenHoTro", SqlDbType.NVarChar, 4).SourceColumn = "TenHoTro";

                sqlCmd.Parameters.Add("@YM", SqlDbType.VarChar, 100).SourceColumn = "YM";

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).SourceColumn = "HoVaTen";

                sqlCmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 100).SourceColumn = "DienThoai";

                sqlCmd.Parameters.Add("@email", SqlDbType.VarChar, 20).SourceColumn = "email";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int HoTroTrucTuyenID, int CuaHangID, string TenHoTro, string YM, string HoVaTen,
                           string DienThoai, string email)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateHoTroTrucTuyen";

                sqlCmd.Parameters.Add("@HoTroTrucTuyenID", SqlDbType.Int).Value = HoTroTrucTuyenID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@TenHoTro", SqlDbType.NVarChar, 100).Value = TenHoTro;

                sqlCmd.Parameters.Add("@YM", SqlDbType.VarChar, 100).Value = YM;

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).Value = HoVaTen;

                sqlCmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 20).Value = DienThoai;

                sqlCmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateHoTroTrucTuyen";
                sqlCmd.Parameters.Add("@HoTroTrucTuyenID", SqlDbType.Int).SourceColumn = "HoTroTrucTuyenID";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@TenHoTro", SqlDbType.NVarChar, 100).SourceColumn = "TenHoTro";

                sqlCmd.Parameters.Add("@YM", SqlDbType.VarChar, 100).SourceColumn = "YM";

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).SourceColumn = "HoVaTen";

                sqlCmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 20).SourceColumn = "DienThoai";

                sqlCmd.Parameters.Add("@email", SqlDbType.VarChar, 100).SourceColumn = "email";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateHoTroTrucTuyen";
                sqlCmd.Parameters.Add("@HoTroTrucTuyenID", SqlDbType.Int).SourceColumn = "HoTroTrucTuyenID";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@TenHoTro", SqlDbType.NVarChar, 100).SourceColumn = "TenHoTro";

                sqlCmd.Parameters.Add("@YM", SqlDbType.VarChar, 100).SourceColumn = "YM";

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).SourceColumn = "HoVaTen";

                sqlCmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 20).SourceColumn = "DienThoai";

                sqlCmd.Parameters.Add("@email", SqlDbType.VarChar, 100).SourceColumn = "email";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteHoTroTrucTuyen";
                sqlCmd.Parameters.Add("@HoTroTrucTuyenID", SqlDbType.Int).SourceColumn = "HoTroTrucTuyenID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int HoTroTrucTuyenID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteHoTroTrucTuyen";
                sqlCmd.Parameters.Add("@HoTroTrucTuyenID", SqlDbType.Int).Value = HoTroTrucTuyenID;
                objDataAccess.ExecuteQuery(sqlCmd, "HoTroTrucTuyen");
            }
        }

        public int InsertFields(int? CuaHangID, string TenHoTro, string YM, string HoVaTen, string DienThoai,
                                string email)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsHoTroTrucTuyen";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@TenHoTro", SqlDbType.NVarChar, 100).Value = TenHoTro;

                sqlCmd.Parameters.Add("@YM", SqlDbType.VarChar, 100).Value = YM;

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).Value = HoVaTen;

                sqlCmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 20).Value = DienThoai;

                sqlCmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int HoTroTrucTuyenID, int? CuaHangID, string TenHoTro, string YM, string HoVaTen,
                                 string DienThoai, string email)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsHoTroTrucTuyen";

                sqlCmd.Parameters.Add("@HoTroTrucTuyenID", SqlDbType.Int).Value = HoTroTrucTuyenID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@TenHoTro", SqlDbType.NVarChar, 100).Value = TenHoTro;

                sqlCmd.Parameters.Add("@YM", SqlDbType.VarChar, 100).Value = YM;

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).Value = HoVaTen;

                sqlCmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 20).Value = DienThoai;

                sqlCmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? CuaHangID, string TenHoTro, string YM, string HoVaTen,
                                       string DienThoai, string email)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsHoTroTrucTuyen";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@TenHoTro", SqlDbType.NVarChar, 100).Value = TenHoTro;

                sqlCmd.Parameters.Add("@YM", SqlDbType.VarChar, 100).Value = YM;

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).Value = HoVaTen;

                sqlCmd.Parameters.Add("@DienThoai", SqlDbType.VarChar, 20).Value = DienThoai;

                sqlCmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;


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
                sqlCmd.CommandText = "SelectHoTroTrucTuyenByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HoTroTrucTuyen");
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
                sqlCmd.CommandText = "GetHoTroTrucTuyenByCuaHangIDPaging";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HoTroTrucTuyen");
                return dsResult;
            }
        }
    }
}