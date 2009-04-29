using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_NhanXetSanPham
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_NhanXetSanPham()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("NhanXetID", "NhanXetID")
                                   ,
                                   new DataColumnMapping("SanPhamID", "SanPhamID")
                                   ,
                                   new DataColumnMapping("NguoiDungID", "NguoiDungID")
                                   ,
                                   new DataColumnMapping("NguoiNhanXet", "NguoiNhanXet")
                                   ,
                                   new DataColumnMapping("NoiDung", "NoiDung")
                               };
            dtTblMapping = new DataTableMapping("Table", "NhanXetSanPham", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetNhanXetSanPham";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhanXetSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByID(int NhanXetID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetNhanXetSanPhamById";
                sqlCmd.Parameters.Add("@NhanXetID", SqlDbType.Int).Value = NhanXetID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhanXetSanPham");
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
                sqlCmd.CommandText = "GetNhanXetSanPhamBySanPhamID";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhanXetSanPham");
                return dsResult;
            }
        }

        public int Insert(int SanPhamID, int NguoiDungID, string NguoiNhanXet, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertNhanXetSanPham";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NguoiNhanXet", SqlDbType.NVarChar, 50).Value = NguoiNhanXet;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;


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
                sqlCmd.CommandText = "InsertNhanXetSanPham";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NguoiNhanXet", SqlDbType.NVarChar, 50).SourceColumn = "NguoiNhanXet";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertNhanXetSanPham_Ref";
                sqlCmd.Parameters.Add("@NhanXetID", SqlDbType.Int).SourceColumn = "NhanXetID";
                sqlCmd.Parameters["@NhanXetID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NguoiNhanXet", SqlDbType.NVarChar, 4).SourceColumn = "NguoiNhanXet";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int NhanXetID, int SanPhamID, int NguoiDungID, string NguoiNhanXet, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNhanXetSanPham";

                sqlCmd.Parameters.Add("@NhanXetID", SqlDbType.Int).Value = NhanXetID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NguoiNhanXet", SqlDbType.NVarChar, 50).Value = NguoiNhanXet;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNhanXetSanPham";
                sqlCmd.Parameters.Add("@NhanXetID", SqlDbType.Int).SourceColumn = "NhanXetID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NguoiNhanXet", SqlDbType.NVarChar, 50).SourceColumn = "NguoiNhanXet";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNhanXetSanPham";
                sqlCmd.Parameters.Add("@NhanXetID", SqlDbType.Int).SourceColumn = "NhanXetID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NguoiNhanXet", SqlDbType.NVarChar, 50).SourceColumn = "NguoiNhanXet";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteNhanXetSanPham";
                sqlCmd.Parameters.Add("@NhanXetID", SqlDbType.Int).SourceColumn = "NhanXetID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int NhanXetID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteNhanXetSanPham";
                sqlCmd.Parameters.Add("@NhanXetID", SqlDbType.Int).Value = NhanXetID;
                objDataAccess.ExecuteQuery(sqlCmd, "NhanXetSanPham");
            }
        }

        public int InsertFields(int? SanPhamID, int? NguoiDungID, string NguoiNhanXet, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsNhanXetSanPham";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NguoiNhanXet", SqlDbType.NVarChar, 50).Value = NguoiNhanXet;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int NhanXetID, int? SanPhamID, int? NguoiDungID, string NguoiNhanXet, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsNhanXetSanPham";

                sqlCmd.Parameters.Add("@NhanXetID", SqlDbType.Int).Value = NhanXetID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NguoiNhanXet", SqlDbType.NVarChar, 50).Value = NguoiNhanXet;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? SanPhamID, int? NguoiDungID, string NguoiNhanXet,
                                       string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsNhanXetSanPham";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NguoiNhanXet", SqlDbType.NVarChar, 50).Value = NguoiNhanXet;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;


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
                sqlCmd.CommandText = "SelectNhanXetSanPhamByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhanXetSanPham");
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
                sqlCmd.CommandText = "GetNhanXetSanPhamBySanPhamIDPaging";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhanXetSanPham");
                return dsResult;
            }
        }
    }
}