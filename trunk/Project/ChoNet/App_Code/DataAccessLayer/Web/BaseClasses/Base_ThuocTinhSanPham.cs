using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_ThuocTinhSanPham
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_ThuocTinhSanPham()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("ThuocTinhSanPhamID", "ThuocTinhSanPhamID")
                                   ,
                                   new DataColumnMapping("SanPhamID", "SanPhamID")
                                   ,
                                   new DataColumnMapping("ThuocTinhID", "ThuocTinhID")
                                   ,
                                   new DataColumnMapping("SanPhamMauID", "SanPhamMauID")
                               };
            dtTblMapping = new DataTableMapping("Table", "ThuocTinhSanPham", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetThuocTinhSanPham";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByID(int ThuocTinhSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetThuocTinhSanPhamById";
                sqlCmd.Parameters.Add("@ThuocTinhSanPhamID", SqlDbType.Int).Value = ThuocTinhSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByThuocTinhID(int ThuocTinhID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetThuocTinhSanPhamByThuocTinhID";
                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
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
                sqlCmd.CommandText = "GetThuocTinhSanPhamBySanPhamID";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
                return dsResult;
            }
        }

        public DataSet SelectBySanPhamMauID(int SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetThuocTinhSanPhamBySanPhamMauID";
                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
                return dsResult;
            }
        }

        public int Insert(int SanPhamID, int ThuocTinhID, int SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertThuocTinhSanPham";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;


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
                sqlCmd.CommandText = "InsertThuocTinhSanPham";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).SourceColumn = "ThuocTinhID";

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).SourceColumn = "SanPhamMauID";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertThuocTinhSanPham_Ref";
                sqlCmd.Parameters.Add("@ThuocTinhSanPhamID", SqlDbType.Int).SourceColumn = "ThuocTinhSanPhamID";
                sqlCmd.Parameters["@ThuocTinhSanPhamID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).SourceColumn = "ThuocTinhID";

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).SourceColumn = "SanPhamMauID";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int ThuocTinhSanPhamID, int SanPhamID, int ThuocTinhID, int SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateThuocTinhSanPham";

                sqlCmd.Parameters.Add("@ThuocTinhSanPhamID", SqlDbType.Int).Value = ThuocTinhSanPhamID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateThuocTinhSanPham";
                sqlCmd.Parameters.Add("@ThuocTinhSanPhamID", SqlDbType.Int).SourceColumn = "ThuocTinhSanPhamID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).SourceColumn = "ThuocTinhID";

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).SourceColumn = "SanPhamMauID";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateThuocTinhSanPham";
                sqlCmd.Parameters.Add("@ThuocTinhSanPhamID", SqlDbType.Int).SourceColumn = "ThuocTinhSanPhamID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).SourceColumn = "ThuocTinhID";

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).SourceColumn = "SanPhamMauID";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteThuocTinhSanPham";
                sqlCmd.Parameters.Add("@ThuocTinhSanPhamID", SqlDbType.Int).SourceColumn = "ThuocTinhSanPhamID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int ThuocTinhSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteThuocTinhSanPham";
                sqlCmd.Parameters.Add("@ThuocTinhSanPhamID", SqlDbType.Int).Value = ThuocTinhSanPhamID;
                objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
            }
        }

        public int InsertFields(int? SanPhamID, int? ThuocTinhID, int? SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsThuocTinhSanPham";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int ThuocTinhSanPhamID, int? SanPhamID, int? ThuocTinhID, int? SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsThuocTinhSanPham";

                sqlCmd.Parameters.Add("@ThuocTinhSanPhamID", SqlDbType.Int).Value = ThuocTinhSanPhamID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? SanPhamID, int? ThuocTinhID, int? SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsThuocTinhSanPham";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;


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
                sqlCmd.CommandText = "SelectThuocTinhSanPhamByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByThuocTinhIDPaging(int ThuocTinhID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetThuocTinhSanPhamByThuocTinhIDPaging";
                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
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
                sqlCmd.CommandText = "GetThuocTinhSanPhamBySanPhamIDPaging";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
                return dsResult;
            }
        }

        public DataSet SelectBySanPhamMauIDPaging(int SanPhamMauID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetThuocTinhSanPhamBySanPhamMauIDPaging";
                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
                return dsResult;
            }
        }
    }
}