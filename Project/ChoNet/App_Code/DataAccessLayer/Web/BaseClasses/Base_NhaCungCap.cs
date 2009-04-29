using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_NhaCungCap
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_NhaCungCap()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("NhaCungCapID", "NhaCungCapID")
                                   ,
                                   new DataColumnMapping("TenNhaCungCap", "TenNhaCungCap")
                                   ,
                                   new DataColumnMapping("DiaChi", "DiaChi")
                                   ,
                                   new DataColumnMapping("SoDienThoaiDiDong", "SoDienThoaiDiDong")
                                   ,
                                   new DataColumnMapping("SoDienThoaiCoDinh", "SoDienThoaiCoDinh")
                               };
            dtTblMapping = new DataTableMapping("Table", "NhaCungCap", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetNhaCungCap";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhaCungCap");
                return dsResult;
            }
        }

        public DataSet SelectByID(int NhaCungCapID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetNhaCungCapById";
                sqlCmd.Parameters.Add("@NhaCungCapID", SqlDbType.Int).Value = NhaCungCapID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhaCungCap");
                return dsResult;
            }
        }


        public int Insert(string TenNhaCungCap, string DiaChi, string SoDienThoaiDiDong, string SoDienThoaiCoDinh)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertNhaCungCap";

                sqlCmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar, 50).Value = TenNhaCungCap;

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).Value = DiaChi;

                sqlCmd.Parameters.Add("@SoDienThoaiDiDong", SqlDbType.NVarChar, 50).Value = SoDienThoaiDiDong;

                sqlCmd.Parameters.Add("@SoDienThoaiCoDinh", SqlDbType.NVarChar, 50).Value = SoDienThoaiCoDinh;


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
                sqlCmd.CommandText = "InsertNhaCungCap";
                sqlCmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar, 50).SourceColumn = "TenNhaCungCap";

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).SourceColumn = "DiaChi";

                sqlCmd.Parameters.Add("@SoDienThoaiDiDong", SqlDbType.NVarChar, 50).SourceColumn = "SoDienThoaiDiDong";

                sqlCmd.Parameters.Add("@SoDienThoaiCoDinh", SqlDbType.NVarChar, 50).SourceColumn = "SoDienThoaiCoDinh";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertNhaCungCap_Ref";
                sqlCmd.Parameters.Add("@NhaCungCapID", SqlDbType.Int).SourceColumn = "NhaCungCapID";
                sqlCmd.Parameters["@NhaCungCapID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar, 4).SourceColumn = "TenNhaCungCap";

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50).SourceColumn = "DiaChi";

                sqlCmd.Parameters.Add("@SoDienThoaiDiDong", SqlDbType.NVarChar, 1000).SourceColumn = "SoDienThoaiDiDong";

                sqlCmd.Parameters.Add("@SoDienThoaiCoDinh", SqlDbType.NVarChar, 50).SourceColumn = "SoDienThoaiCoDinh";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int NhaCungCapID, string TenNhaCungCap, string DiaChi, string SoDienThoaiDiDong,
                           string SoDienThoaiCoDinh)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNhaCungCap";

                sqlCmd.Parameters.Add("@NhaCungCapID", SqlDbType.Int).Value = NhaCungCapID;
                sqlCmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar, 50).Value = TenNhaCungCap;

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).Value = DiaChi;

                sqlCmd.Parameters.Add("@SoDienThoaiDiDong", SqlDbType.NVarChar, 50).Value = SoDienThoaiDiDong;

                sqlCmd.Parameters.Add("@SoDienThoaiCoDinh", SqlDbType.NVarChar, 50).Value = SoDienThoaiCoDinh;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNhaCungCap";
                sqlCmd.Parameters.Add("@NhaCungCapID", SqlDbType.Int).SourceColumn = "NhaCungCapID";

                sqlCmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar, 50).SourceColumn = "TenNhaCungCap";

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).SourceColumn = "DiaChi";

                sqlCmd.Parameters.Add("@SoDienThoaiDiDong", SqlDbType.NVarChar, 50).SourceColumn = "SoDienThoaiDiDong";

                sqlCmd.Parameters.Add("@SoDienThoaiCoDinh", SqlDbType.NVarChar, 50).SourceColumn = "SoDienThoaiCoDinh";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNhaCungCap";
                sqlCmd.Parameters.Add("@NhaCungCapID", SqlDbType.Int).SourceColumn = "NhaCungCapID";

                sqlCmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar, 50).SourceColumn = "TenNhaCungCap";

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).SourceColumn = "DiaChi";

                sqlCmd.Parameters.Add("@SoDienThoaiDiDong", SqlDbType.NVarChar, 50).SourceColumn = "SoDienThoaiDiDong";

                sqlCmd.Parameters.Add("@SoDienThoaiCoDinh", SqlDbType.NVarChar, 50).SourceColumn = "SoDienThoaiCoDinh";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteNhaCungCap";
                sqlCmd.Parameters.Add("@NhaCungCapID", SqlDbType.Int).SourceColumn = "NhaCungCapID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int NhaCungCapID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteNhaCungCap";
                sqlCmd.Parameters.Add("@NhaCungCapID", SqlDbType.Int).Value = NhaCungCapID;
                objDataAccess.ExecuteQuery(sqlCmd, "NhaCungCap");
            }
        }

        public int InsertFields(string TenNhaCungCap, string DiaChi, string SoDienThoaiDiDong, string SoDienThoaiCoDinh)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsNhaCungCap";

                sqlCmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar, 50).Value = TenNhaCungCap;

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).Value = DiaChi;

                sqlCmd.Parameters.Add("@SoDienThoaiDiDong", SqlDbType.NVarChar, 50).Value = SoDienThoaiDiDong;

                sqlCmd.Parameters.Add("@SoDienThoaiCoDinh", SqlDbType.NVarChar, 50).Value = SoDienThoaiCoDinh;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int NhaCungCapID, string TenNhaCungCap, string DiaChi, string SoDienThoaiDiDong,
                                 string SoDienThoaiCoDinh)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsNhaCungCap";

                sqlCmd.Parameters.Add("@NhaCungCapID", SqlDbType.Int).Value = NhaCungCapID;
                sqlCmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar, 50).Value = TenNhaCungCap;

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).Value = DiaChi;

                sqlCmd.Parameters.Add("@SoDienThoaiDiDong", SqlDbType.NVarChar, 50).Value = SoDienThoaiDiDong;

                sqlCmd.Parameters.Add("@SoDienThoaiCoDinh", SqlDbType.NVarChar, 50).Value = SoDienThoaiCoDinh;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string TenNhaCungCap, string DiaChi, string SoDienThoaiDiDong,
                                       string SoDienThoaiCoDinh)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsNhaCungCap";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar, 50).Value = TenNhaCungCap;

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).Value = DiaChi;

                sqlCmd.Parameters.Add("@SoDienThoaiDiDong", SqlDbType.NVarChar, 50).Value = SoDienThoaiDiDong;

                sqlCmd.Parameters.Add("@SoDienThoaiCoDinh", SqlDbType.NVarChar, 50).Value = SoDienThoaiCoDinh;


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
                sqlCmd.CommandText = "SelectNhaCungCapByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhaCungCap");
                return dsResult;
            }
        }
    }
}