using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_KhuVuc
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_KhuVuc()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("KhuVucID", "KhuVucID")
                                   ,
                                   new DataColumnMapping("TenKhuVuc", "TenKhuVuc")
                                   ,
                                   new DataColumnMapping("GhiChu", "GhiChu")
                                   ,
                                   new DataColumnMapping("SapXep", "SapXep")
                                   ,
                                   new DataColumnMapping("HienThi", "HienThi")
                                   ,
                                   new DataColumnMapping("Bak1", "Bak1")
                                   ,
                                   new DataColumnMapping("Bak2", "Bak2")
                                   ,
                                   new DataColumnMapping("Bak3", "Bak3")
                               };
            dtTblMapping = new DataTableMapping("Table", "KhuVuc", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetKhuVuc";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "KhuVuc");
                return dsResult;
            }
        }

        public DataSet SelectByID(int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetKhuVucById";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "KhuVuc");
                return dsResult;
            }
        }


        public int Insert(string TenKhuVuc, string GhiChu, int SapXep, bool HienThi, string Bak1, string Bak2, int Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertKhuVuc";

                sqlCmd.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 50).Value = TenKhuVuc;

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 1000).Value = GhiChu;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@HienThi", SqlDbType.Bit).Value = HienThi;

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
                sqlCmd.CommandText = "InsertKhuVuc";
                sqlCmd.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 50).SourceColumn = "TenKhuVuc";

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 1000).SourceColumn = "GhiChu";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@HienThi", SqlDbType.Bit).SourceColumn = "HienThi";

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
                sqlCmd.CommandText = "InsertKhuVuc_Ref";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";
                sqlCmd.Parameters["@KhuVucID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 4).SourceColumn = "TenKhuVuc";

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 50).SourceColumn = "GhiChu";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@HienThi", SqlDbType.Bit).SourceColumn = "HienThi";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 1).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int KhuVucID, string TenKhuVuc, string GhiChu, int SapXep, bool HienThi, string Bak1,
                           string Bak2, int Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateKhuVuc";

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                sqlCmd.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 50).Value = TenKhuVuc;

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 1000).Value = GhiChu;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@HienThi", SqlDbType.Bit).Value = HienThi;

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
                sqlCmd.CommandText = "UpdateKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";

                sqlCmd.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 50).SourceColumn = "TenKhuVuc";

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 1000).SourceColumn = "GhiChu";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@HienThi", SqlDbType.Bit).SourceColumn = "HienThi";

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
                sqlCmd.CommandText = "UpdateKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";

                sqlCmd.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 50).SourceColumn = "TenKhuVuc";

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 1000).SourceColumn = "GhiChu";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@HienThi", SqlDbType.Bit).SourceColumn = "HienThi";

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
                sqlCmd.CommandText = "DeleteKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                objDataAccess.ExecuteQuery(sqlCmd, "KhuVuc");
            }
        }

        public int InsertFields(string TenKhuVuc, string GhiChu, int? SapXep, bool? HienThi, string Bak1, string Bak2,
                                int? Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsKhuVuc";

                sqlCmd.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 50).Value = TenKhuVuc;

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 1000).Value = GhiChu;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@HienThi", SqlDbType.Bit).Value = HienThi;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int KhuVucID, string TenKhuVuc, string GhiChu, int? SapXep, bool? HienThi, string Bak1,
                                 string Bak2, int? Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsKhuVuc";

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                sqlCmd.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 50).Value = TenKhuVuc;

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 1000).Value = GhiChu;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@HienThi", SqlDbType.Bit).Value = HienThi;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string TenKhuVuc, string GhiChu, int? SapXep, bool? HienThi,
                                       string Bak1, string Bak2, int? Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsKhuVuc";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@TenKhuVuc", SqlDbType.NVarChar, 50).Value = TenKhuVuc;

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 1000).Value = GhiChu;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@HienThi", SqlDbType.Bit).Value = HienThi;

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
                sqlCmd.CommandText = "SelectKhuVucByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "KhuVuc");
                return dsResult;
            }
        }
    }
}