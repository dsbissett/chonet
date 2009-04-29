using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_ViTriSanPham
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_ViTriSanPham()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("ViTriSanPhamID", "ViTriSanPhamID")
                                   ,
                                   new DataColumnMapping("SanPhamID", "SanPhamID")
                                   ,
                                   new DataColumnMapping("ViTriSanPham", "ViTriSanPham")
                                   ,
                                   new DataColumnMapping("CuaHangID", "CuaHangID")
                                   ,
                                   new DataColumnMapping("KhuVucID", "KhuVucID")
                               };
            dtTblMapping = new DataTableMapping("Table", "ViTriSanPham", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetViTriSanPham";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ViTriSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByID(int ViTriSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetViTriSanPhamById";
                sqlCmd.Parameters.Add("@ViTriSanPhamID", SqlDbType.Int).Value = ViTriSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ViTriSanPham");
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
                sqlCmd.CommandText = "GetViTriSanPhamBySanPhamID";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ViTriSanPham");
                return dsResult;
            }
        }

        public int Insert(int SanPhamID, int ViTriSanPham, int CuaHangID, int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertViTriSanPham";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;


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
                sqlCmd.CommandText = "InsertViTriSanPham";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).SourceColumn = "ViTriSanPham";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertViTriSanPham_Ref";
                sqlCmd.Parameters.Add("@ViTriSanPhamID", SqlDbType.Int).SourceColumn = "ViTriSanPhamID";
                sqlCmd.Parameters["@ViTriSanPhamID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).SourceColumn = "ViTriSanPham";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int ViTriSanPhamID, int SanPhamID, int ViTriSanPham, int CuaHangID, int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateViTriSanPham";

                sqlCmd.Parameters.Add("@ViTriSanPhamID", SqlDbType.Int).Value = ViTriSanPhamID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateViTriSanPham";
                sqlCmd.Parameters.Add("@ViTriSanPhamID", SqlDbType.Int).SourceColumn = "ViTriSanPhamID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).SourceColumn = "ViTriSanPham";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateViTriSanPham";
                sqlCmd.Parameters.Add("@ViTriSanPhamID", SqlDbType.Int).SourceColumn = "ViTriSanPhamID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).SourceColumn = "ViTriSanPham";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteViTriSanPham";
                sqlCmd.Parameters.Add("@ViTriSanPhamID", SqlDbType.Int).SourceColumn = "ViTriSanPhamID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int ViTriSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteViTriSanPham";
                sqlCmd.Parameters.Add("@ViTriSanPhamID", SqlDbType.Int).Value = ViTriSanPhamID;
                objDataAccess.ExecuteQuery(sqlCmd, "ViTriSanPham");
            }
        }

        public int InsertFields(int? SanPhamID, int? ViTriSanPham, int? CuaHangID, int? KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsViTriSanPham";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int ViTriSanPhamID, int? SanPhamID, int? ViTriSanPham, int? CuaHangID, int? KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsViTriSanPham";

                sqlCmd.Parameters.Add("@ViTriSanPhamID", SqlDbType.Int).Value = ViTriSanPhamID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? SanPhamID, int? ViTriSanPham, int? CuaHangID, int? KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsViTriSanPham";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@ViTriSanPham", SqlDbType.Int).Value = ViTriSanPham;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;


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
                sqlCmd.CommandText = "SelectViTriSanPhamByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ViTriSanPham");
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
                sqlCmd.CommandText = "GetViTriSanPhamBySanPhamIDPaging";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ViTriSanPham");
                return dsResult;
            }
        }
    }
}