using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_HangSanXuat
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_HangSanXuat()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("HangSanXuatID", "HangSanXuatID")
                                   ,
                                   new DataColumnMapping("TenHangSanXuat", "TenHangSanXuat")
                                   ,
                                   new DataColumnMapping("ThongTin", "ThongTin")
                                   ,
                                   new DataColumnMapping("SapXep", "SapXep")
                                   ,
                                   new DataColumnMapping("Bak1", "Bak1")
                                   ,
                                   new DataColumnMapping("Bak2", "Bak2")
                                   ,
                                   new DataColumnMapping("Bak3", "Bak3")
                               };
            dtTblMapping = new DataTableMapping("Table", "HangSanXuat", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetHangSanXuat";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HangSanXuat");
                return dsResult;
            }
        }

        public DataSet SelectByID(int HangSanXuatID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetHangSanXuatById";
                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HangSanXuat");
                return dsResult;
            }
        }


        public int Insert(string TenHangSanXuat, string ThongTin, int SapXep, string Bak1, string Bak2, int Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertHangSanXuat";

                sqlCmd.Parameters.Add("@TenHangSanXuat", SqlDbType.NVarChar, 50).Value = TenHangSanXuat;

                sqlCmd.Parameters.Add("@ThongTin", SqlDbType.NVarChar, 4000).Value = ThongTin;

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
                sqlCmd.CommandText = "InsertHangSanXuat";
                sqlCmd.Parameters.Add("@TenHangSanXuat", SqlDbType.NVarChar, 50).SourceColumn = "TenHangSanXuat";

                sqlCmd.Parameters.Add("@ThongTin", SqlDbType.NVarChar, 4000).SourceColumn = "ThongTin";

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
                sqlCmd.CommandText = "InsertHangSanXuat_Ref";
                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).SourceColumn = "HangSanXuatID";
                sqlCmd.Parameters["@HangSanXuatID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@TenHangSanXuat", SqlDbType.NVarChar, 4).SourceColumn = "TenHangSanXuat";

                sqlCmd.Parameters.Add("@ThongTin", SqlDbType.NVarChar, 50).SourceColumn = "ThongTin";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int HangSanXuatID, string TenHangSanXuat, string ThongTin, int SapXep, string Bak1,
                           string Bak2, int Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateHangSanXuat";

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;
                sqlCmd.Parameters.Add("@TenHangSanXuat", SqlDbType.NVarChar, 50).Value = TenHangSanXuat;

                sqlCmd.Parameters.Add("@ThongTin", SqlDbType.NVarChar, 4000).Value = ThongTin;

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
                sqlCmd.CommandText = "UpdateHangSanXuat";
                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).SourceColumn = "HangSanXuatID";

                sqlCmd.Parameters.Add("@TenHangSanXuat", SqlDbType.NVarChar, 50).SourceColumn = "TenHangSanXuat";

                sqlCmd.Parameters.Add("@ThongTin", SqlDbType.NVarChar, 4000).SourceColumn = "ThongTin";

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
                sqlCmd.CommandText = "UpdateHangSanXuat";
                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).SourceColumn = "HangSanXuatID";

                sqlCmd.Parameters.Add("@TenHangSanXuat", SqlDbType.NVarChar, 50).SourceColumn = "TenHangSanXuat";

                sqlCmd.Parameters.Add("@ThongTin", SqlDbType.NVarChar, 4000).SourceColumn = "ThongTin";

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
                sqlCmd.CommandText = "DeleteHangSanXuat";
                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).SourceColumn = "HangSanXuatID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int HangSanXuatID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteHangSanXuat";
                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;
                objDataAccess.ExecuteQuery(sqlCmd, "HangSanXuat");
            }
        }

        public int InsertFields(string TenHangSanXuat, string ThongTin, int? SapXep, string Bak1, string Bak2, int? Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsHangSanXuat";

                sqlCmd.Parameters.Add("@TenHangSanXuat", SqlDbType.NVarChar, 50).Value = TenHangSanXuat;

                sqlCmd.Parameters.Add("@ThongTin", SqlDbType.NVarChar, 4000).Value = ThongTin;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int HangSanXuatID, string TenHangSanXuat, string ThongTin, int? SapXep, string Bak1,
                                 string Bak2, int? Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsHangSanXuat";

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;
                sqlCmd.Parameters.Add("@TenHangSanXuat", SqlDbType.NVarChar, 50).Value = TenHangSanXuat;

                sqlCmd.Parameters.Add("@ThongTin", SqlDbType.NVarChar, 4000).Value = ThongTin;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string TenHangSanXuat, string ThongTin, int? SapXep, string Bak1,
                                       string Bak2, int? Bak3)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsHangSanXuat";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@TenHangSanXuat", SqlDbType.NVarChar, 50).Value = TenHangSanXuat;

                sqlCmd.Parameters.Add("@ThongTin", SqlDbType.NVarChar, 4000).Value = ThongTin;

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
                sqlCmd.CommandText = "SelectHangSanXuatByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HangSanXuat");
                return dsResult;
            }
        }
    }
}