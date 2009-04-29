using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_LoaiNguoiDung
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_LoaiNguoiDung()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("LoaiNguoiDungID", "LoaiNguoiDungID")
                                   ,
                                   new DataColumnMapping("LoaiNguoiDung", "LoaiNguoiDung")
                                   ,
                                   new DataColumnMapping("SapXep", "SapXep")
                                   ,
                                   new DataColumnMapping("Bak1", "Bak1")
                                   ,
                                   new DataColumnMapping("Bak2", "Bak2")
                                   ,
                                   new DataColumnMapping("Bak3", "Bak3")
                               };
            dtTblMapping = new DataTableMapping("Table", "LoaiNguoiDung", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetLoaiNguoiDung";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LoaiNguoiDung");
                return dsResult;
            }
        }

        public DataSet SelectByID(int LoaiNguoiDungID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetLoaiNguoiDungById";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LoaiNguoiDung");
                return dsResult;
            }
        }


        public int Insert(string LoaiNguoiDung, int SapXep, string Bak1, string Bak2, int Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertLoaiNguoiDung";

                sqlCmd.Parameters.Add("@LoaiNguoiDung", SqlDbType.NVarChar, 50).Value = LoaiNguoiDung;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;


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
                sqlCmd.CommandText = "InsertLoaiNguoiDung";
                sqlCmd.Parameters.Add("@LoaiNguoiDung", SqlDbType.NVarChar, 50).SourceColumn = "LoaiNguoiDung";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertLoaiNguoiDung_Ref";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).SourceColumn = "LoaiNguoiDungID";
                sqlCmd.Parameters["@LoaiNguoiDungID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@LoaiNguoiDung", SqlDbType.NVarChar, 4).SourceColumn = "LoaiNguoiDung";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int LoaiNguoiDungID, string LoaiNguoiDung, int SapXep, string Bak1, string Bak2, int Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateLoaiNguoiDung";

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                sqlCmd.Parameters.Add("@LoaiNguoiDung", SqlDbType.NVarChar, 50).Value = LoaiNguoiDung;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateLoaiNguoiDung";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).SourceColumn = "LoaiNguoiDungID";

                sqlCmd.Parameters.Add("@LoaiNguoiDung", SqlDbType.NVarChar, 50).SourceColumn = "LoaiNguoiDung";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateLoaiNguoiDung";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).SourceColumn = "LoaiNguoiDungID";

                sqlCmd.Parameters.Add("@LoaiNguoiDung", SqlDbType.NVarChar, 50).SourceColumn = "LoaiNguoiDung";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteLoaiNguoiDung";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).SourceColumn = "LoaiNguoiDungID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int LoaiNguoiDungID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteLoaiNguoiDung";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                objDataAccess.ExecuteQuery(sqlCmd, "LoaiNguoiDung");
            }
        }

        public int InsertFields(string LoaiNguoiDung, int? SapXep, string Bak1, string Bak2, int? Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsLoaiNguoiDung";

                sqlCmd.Parameters.Add("@LoaiNguoiDung", SqlDbType.NVarChar, 50).Value = LoaiNguoiDung;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int LoaiNguoiDungID, string LoaiNguoiDung, int? SapXep, string Bak1, string Bak2,
                                 int? Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsLoaiNguoiDung";

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                sqlCmd.Parameters.Add("@LoaiNguoiDung", SqlDbType.NVarChar, 50).Value = LoaiNguoiDung;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string LoaiNguoiDung, int? SapXep, string Bak1, string Bak2,
                                       int? Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsLoaiNguoiDung";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@LoaiNguoiDung", SqlDbType.NVarChar, 50).Value = LoaiNguoiDung;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;


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
                sqlCmd.CommandText = "SelectLoaiNguoiDungByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LoaiNguoiDung");
                return dsResult;
            }
        }
    }
}