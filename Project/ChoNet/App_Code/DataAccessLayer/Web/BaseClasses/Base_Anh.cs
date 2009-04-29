using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_Anh
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_Anh()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("AnhID", "AnhID")
                                   ,
                                   new DataColumnMapping("SanPhamID", "SanPhamID")
                                   ,
                                   new DataColumnMapping("DuongDan", "DuongDan")
                                   ,
                                   new DataColumnMapping("Bak1", "Bak1")
                                   ,
                                   new DataColumnMapping("Bak2", "Bak2")
                                   ,
                                   new DataColumnMapping("Bak3", "Bak3")
                                   ,
                                   new DataColumnMapping("SanPhamMauID", "SanPhamMauID")
                               };
            dtTblMapping = new DataTableMapping("Table", "Anh", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetAnh";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "Anh");
                return dsResult;
            }
        }

        public DataSet SelectByID(int AnhID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetAnhById";
                sqlCmd.Parameters.Add("@AnhID", SqlDbType.Int).Value = AnhID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "Anh");
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
                sqlCmd.CommandText = "GetAnhBySanPhamMauID";
                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "Anh");
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
                sqlCmd.CommandText = "GetAnhBySanPhamID";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "Anh");
                return dsResult;
            }
        }

        public int Insert(int SanPhamID, string DuongDan, string Bak1, string Bak2, int Bak3, int SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertAnh";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 100).Value = DuongDan;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

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
                sqlCmd.CommandText = "InsertAnh";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 100).SourceColumn = "DuongDan";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

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
                sqlCmd.CommandText = "InsertAnh_Ref";
                sqlCmd.Parameters.Add("@AnhID", SqlDbType.Int).SourceColumn = "AnhID";
                sqlCmd.Parameters["@AnhID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 4).SourceColumn = "DuongDan";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 100).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).SourceColumn = "SanPhamMauID";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int AnhID, int SanPhamID, string DuongDan, string Bak1, string Bak2, int Bak3,
                           int SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateAnh";

                sqlCmd.Parameters.Add("@AnhID", SqlDbType.Int).Value = AnhID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 100).Value = DuongDan;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

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
                sqlCmd.CommandText = "UpdateAnh";
                sqlCmd.Parameters.Add("@AnhID", SqlDbType.Int).SourceColumn = "AnhID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 100).SourceColumn = "DuongDan";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

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
                sqlCmd.CommandText = "UpdateAnh";
                sqlCmd.Parameters.Add("@AnhID", SqlDbType.Int).SourceColumn = "AnhID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 100).SourceColumn = "DuongDan";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

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
                sqlCmd.CommandText = "DeleteAnh";
                sqlCmd.Parameters.Add("@AnhID", SqlDbType.Int).SourceColumn = "AnhID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int AnhID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteAnh";
                sqlCmd.Parameters.Add("@AnhID", SqlDbType.Int).Value = AnhID;
                objDataAccess.ExecuteQuery(sqlCmd, "Anh");
            }
        }

        public int InsertFields(int? SanPhamID, string DuongDan, string Bak1, string Bak2, int? Bak3, int? SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsAnh";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 100).Value = DuongDan;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int AnhID, int? SanPhamID, string DuongDan, string Bak1, string Bak2, int? Bak3,
                                 int? SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsAnh";

                sqlCmd.Parameters.Add("@AnhID", SqlDbType.Int).Value = AnhID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 100).Value = DuongDan;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? SanPhamID, string DuongDan, string Bak1, string Bak2,
                                       int? Bak3, int? SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsAnh";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 100).Value = DuongDan;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

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
                sqlCmd.CommandText = "SelectAnhByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "Anh");
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
                sqlCmd.CommandText = "GetAnhBySanPhamMauIDPaging";
                sqlCmd.Parameters.Add("@SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "Anh");
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
                sqlCmd.CommandText = "GetAnhBySanPhamIDPaging";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "Anh");
                return dsResult;
            }
        }
    }
}