using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_DongSanPham
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_DongSanPham()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("DongSanPhamID", "DongSanPhamID")
                                   ,
                                   new DataColumnMapping("TenDongSanPham", "TenDongSanPham")
                               };
            dtTblMapping = new DataTableMapping("Table", "DongSanPham", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetDongSanPham";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DongSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByID(int DongSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetDongSanPhamById";
                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).Value = DongSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DongSanPham");
                return dsResult;
            }
        }


        public int Insert(string TenDongSanPham)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertDongSanPham";

                sqlCmd.Parameters.Add("@TenDongSanPham", SqlDbType.NVarChar, 100).Value = TenDongSanPham;


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
                sqlCmd.CommandText = "InsertDongSanPham";
                sqlCmd.Parameters.Add("@TenDongSanPham", SqlDbType.NVarChar, 100).SourceColumn = "TenDongSanPham";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertDongSanPham_Ref";
                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).SourceColumn = "DongSanPhamID";
                sqlCmd.Parameters["@DongSanPhamID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@TenDongSanPham", SqlDbType.NVarChar, 4).SourceColumn = "TenDongSanPham";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int DongSanPhamID, string TenDongSanPham)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateDongSanPham";

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).Value = DongSanPhamID;
                sqlCmd.Parameters.Add("@TenDongSanPham", SqlDbType.NVarChar, 100).Value = TenDongSanPham;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateDongSanPham";
                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).SourceColumn = "DongSanPhamID";

                sqlCmd.Parameters.Add("@TenDongSanPham", SqlDbType.NVarChar, 100).SourceColumn = "TenDongSanPham";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateDongSanPham";
                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).SourceColumn = "DongSanPhamID";

                sqlCmd.Parameters.Add("@TenDongSanPham", SqlDbType.NVarChar, 100).SourceColumn = "TenDongSanPham";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteDongSanPham";
                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).SourceColumn = "DongSanPhamID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int DongSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteDongSanPham";
                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).Value = DongSanPhamID;
                objDataAccess.ExecuteQuery(sqlCmd, "DongSanPham");
            }
        }

        public int InsertFields(string TenDongSanPham)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsDongSanPham";

                sqlCmd.Parameters.Add("@TenDongSanPham", SqlDbType.NVarChar, 100).Value = TenDongSanPham;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int DongSanPhamID, string TenDongSanPham)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsDongSanPham";

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).Value = DongSanPhamID;
                sqlCmd.Parameters.Add("@TenDongSanPham", SqlDbType.NVarChar, 100).Value = TenDongSanPham;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string TenDongSanPham)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsDongSanPham";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@TenDongSanPham", SqlDbType.NVarChar, 100).Value = TenDongSanPham;


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
                sqlCmd.CommandText = "SelectDongSanPhamByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DongSanPham");
                return dsResult;
            }
        }
    }
}