using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_CauHinhHeThong
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_CauHinhHeThong()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("Khoa", "Khoa")
                                   ,
                                   new DataColumnMapping("NoiDung", "NoiDung")
                               };
            dtTblMapping = new DataTableMapping("Table", "CauHinhHeThong", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetCauHinhHeThong";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CauHinhHeThong");
                return dsResult;
            }
        }

        public DataSet SelectByID(int Khoa)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetCauHinhHeThongById";
                sqlCmd.Parameters.Add("@Khoa", SqlDbType.VarChar).Value = Khoa;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CauHinhHeThong");
                return dsResult;
            }
        }


        public int Insert(string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertCauHinhHeThong";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 1000).Value = NoiDung;


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
                sqlCmd.CommandText = "InsertCauHinhHeThong";
                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 1000).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertCauHinhHeThong_Ref";
                sqlCmd.Parameters.Add("@Khoa", SqlDbType.VarChar).SourceColumn = "Khoa";
                sqlCmd.Parameters["@Khoa"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 50).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int Khoa, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateCauHinhHeThong";

                sqlCmd.Parameters.Add("@Khoa", SqlDbType.VarChar).Value = Khoa;
                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 1000).Value = NoiDung;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateCauHinhHeThong";
                sqlCmd.Parameters.Add("@Khoa", SqlDbType.VarChar, 50).SourceColumn = "Khoa";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 1000).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateCauHinhHeThong";
                sqlCmd.Parameters.Add("@Khoa", SqlDbType.VarChar, 50).SourceColumn = "Khoa";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 1000).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteCauHinhHeThong";
                sqlCmd.Parameters.Add("@Khoa", SqlDbType.VarChar).SourceColumn = "Khoa";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int Khoa)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteCauHinhHeThong";
                sqlCmd.Parameters.Add("@Khoa", SqlDbType.VarChar).Value = Khoa;
                objDataAccess.ExecuteQuery(sqlCmd, "CauHinhHeThong");
            }
        }

        public int InsertFields(string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsCauHinhHeThong";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 1000).Value = NoiDung;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int Khoa, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsCauHinhHeThong";

                sqlCmd.Parameters.Add("@Khoa", SqlDbType.VarChar).Value = Khoa;
                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 1000).Value = NoiDung;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsCauHinhHeThong";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NVarChar, 1000).Value = NoiDung;


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
                sqlCmd.CommandText = "SelectCauHinhHeThongByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CauHinhHeThong");
                return dsResult;
            }
        }
    }
}