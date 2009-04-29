using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_LichSuTruyCap
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_LichSuTruyCap()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("LichSuTruyCapID", "LichSuTruyCapID")
                                   ,
                                   new DataColumnMapping("LuotTruyCap", "LuotTruyCap")
                                   ,
                                   new DataColumnMapping("CuaHangID", "CuaHangID")
                               };
            dtTblMapping = new DataTableMapping("Table", "LichSuTruyCap", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetLichSuTruyCap";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LichSuTruyCap");
                return dsResult;
            }
        }

        public DataSet SelectByID(int LichSuTruyCapID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetLichSuTruyCapById";
                sqlCmd.Parameters.Add("@LichSuTruyCapID", SqlDbType.Int).Value = LichSuTruyCapID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LichSuTruyCap");
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
                sqlCmd.CommandText = "GetLichSuTruyCapByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LichSuTruyCap");
                return dsResult;
            }
        }

        public int Insert(int LuotTruyCap, int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertLichSuTruyCap";

                sqlCmd.Parameters.Add("@LuotTruyCap", SqlDbType.Int).Value = LuotTruyCap;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;


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
                sqlCmd.CommandText = "InsertLichSuTruyCap";
                sqlCmd.Parameters.Add("@LuotTruyCap", SqlDbType.Int).SourceColumn = "LuotTruyCap";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertLichSuTruyCap_Ref";
                sqlCmd.Parameters.Add("@LichSuTruyCapID", SqlDbType.Int).SourceColumn = "LichSuTruyCapID";
                sqlCmd.Parameters["@LichSuTruyCapID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@LuotTruyCap", SqlDbType.Int).SourceColumn = "LuotTruyCap";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int LichSuTruyCapID, int LuotTruyCap, int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateLichSuTruyCap";

                sqlCmd.Parameters.Add("@LichSuTruyCapID", SqlDbType.Int).Value = LichSuTruyCapID;
                sqlCmd.Parameters.Add("@LuotTruyCap", SqlDbType.Int).Value = LuotTruyCap;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateLichSuTruyCap";
                sqlCmd.Parameters.Add("@LichSuTruyCapID", SqlDbType.Int).SourceColumn = "LichSuTruyCapID";

                sqlCmd.Parameters.Add("@LuotTruyCap", SqlDbType.Int).SourceColumn = "LuotTruyCap";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateLichSuTruyCap";
                sqlCmd.Parameters.Add("@LichSuTruyCapID", SqlDbType.Int).SourceColumn = "LichSuTruyCapID";

                sqlCmd.Parameters.Add("@LuotTruyCap", SqlDbType.Int).SourceColumn = "LuotTruyCap";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteLichSuTruyCap";
                sqlCmd.Parameters.Add("@LichSuTruyCapID", SqlDbType.Int).SourceColumn = "LichSuTruyCapID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int LichSuTruyCapID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteLichSuTruyCap";
                sqlCmd.Parameters.Add("@LichSuTruyCapID", SqlDbType.Int).Value = LichSuTruyCapID;
                objDataAccess.ExecuteQuery(sqlCmd, "LichSuTruyCap");
            }
        }

        public int InsertFields(int? LuotTruyCap, int? CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsLichSuTruyCap";

                sqlCmd.Parameters.Add("@LuotTruyCap", SqlDbType.Int).Value = LuotTruyCap;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int LichSuTruyCapID, int? LuotTruyCap, int? CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsLichSuTruyCap";

                sqlCmd.Parameters.Add("@LichSuTruyCapID", SqlDbType.Int).Value = LichSuTruyCapID;
                sqlCmd.Parameters.Add("@LuotTruyCap", SqlDbType.Int).Value = LuotTruyCap;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? LuotTruyCap, int? CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsLichSuTruyCap";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@LuotTruyCap", SqlDbType.Int).Value = LuotTruyCap;

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;


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
                sqlCmd.CommandText = "SelectLichSuTruyCapByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LichSuTruyCap");
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
                sqlCmd.CommandText = "GetLichSuTruyCapByCuaHangIDPaging";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LichSuTruyCap");
                return dsResult;
            }
        }
    }
}