using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_CuaHangNhomSanPham
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_CuaHangNhomSanPham()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("CuaHangNhomSanPhamID", "CuaHangNhomSanPhamID")
                                   ,
                                   new DataColumnMapping("CuaHangID", "CuaHangID")
                                   ,
                                   new DataColumnMapping("NhomSanPhamID", "NhomSanPhamID")
                               };
            dtTblMapping = new DataTableMapping("Table", "CuaHangNhomSanPham", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetCuaHangNhomSanPham";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByID(int CuaHangNhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetCuaHangNhomSanPhamById";
                sqlCmd.Parameters.Add("@CuaHangNhomSanPhamID", SqlDbType.Int).Value = CuaHangNhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
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
                sqlCmd.CommandText = "GetCuaHangNhomSanPhamByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByNhomSanPhamID(int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetCuaHangNhomSanPhamByNhomSanPhamID";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
                return dsResult;
            }
        }

        public int Insert(int CuaHangID, int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertCuaHangNhomSanPham";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;


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
                sqlCmd.CommandText = "InsertCuaHangNhomSanPham";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertCuaHangNhomSanPham_Ref";
                sqlCmd.Parameters.Add("@CuaHangNhomSanPhamID", SqlDbType.Int).SourceColumn = "CuaHangNhomSanPhamID";
                sqlCmd.Parameters["@CuaHangNhomSanPhamID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int CuaHangNhomSanPhamID, int CuaHangID, int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateCuaHangNhomSanPham";

                sqlCmd.Parameters.Add("@CuaHangNhomSanPhamID", SqlDbType.Int).Value = CuaHangNhomSanPhamID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateCuaHangNhomSanPham";
                sqlCmd.Parameters.Add("@CuaHangNhomSanPhamID", SqlDbType.Int).SourceColumn = "CuaHangNhomSanPhamID";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateCuaHangNhomSanPham";
                sqlCmd.Parameters.Add("@CuaHangNhomSanPhamID", SqlDbType.Int).SourceColumn = "CuaHangNhomSanPhamID";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteCuaHangNhomSanPham";
                sqlCmd.Parameters.Add("@CuaHangNhomSanPhamID", SqlDbType.Int).SourceColumn = "CuaHangNhomSanPhamID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int CuaHangNhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteCuaHangNhomSanPham";
                sqlCmd.Parameters.Add("@CuaHangNhomSanPhamID", SqlDbType.Int).Value = CuaHangNhomSanPhamID;
                objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
            }
        }

        public int InsertFields(int? CuaHangID, int? NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsCuaHangNhomSanPham";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int CuaHangNhomSanPhamID, int? CuaHangID, int? NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsCuaHangNhomSanPham";

                sqlCmd.Parameters.Add("@CuaHangNhomSanPhamID", SqlDbType.Int).Value = CuaHangNhomSanPhamID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? CuaHangID, int? NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsCuaHangNhomSanPham";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;


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
                sqlCmd.CommandText = "SelectCuaHangNhomSanPhamByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
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
                sqlCmd.CommandText = "GetCuaHangNhomSanPhamByCuaHangIDPaging";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByNhomSanPhamIDPaging(int NhomSanPhamID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetCuaHangNhomSanPhamByNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHangNhomSanPham");
                return dsResult;
            }
        }
    }
}