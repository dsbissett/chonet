using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_ThuocTinh
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_ThuocTinh()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("ThuocTinhID", "ThuocTinhID")
                                   ,
                                   new DataColumnMapping("NhomSanPhamID", "NhomSanPhamID")
                                   ,
                                   new DataColumnMapping("TenThuocTinh", "TenThuocTinh")
                                   ,
                                   new DataColumnMapping("ThuocTinhChaID", "ThuocTinhChaID")
                                   ,
                                   new DataColumnMapping("thutu", "thutu")
                               };
            dtTblMapping = new DataTableMapping("Table", "ThuocTinh", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetThuocTinh";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinh");
                return dsResult;
            }
        }

        public DataSet SelectByID(int ThuocTinhID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetThuocTinhById";
                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinh");
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
                sqlCmd.CommandText = "GetThuocTinhByNhomSanPhamID";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinh");
                return dsResult;
            }
        }

        public DataSet SelectByThuocTinhChaID(int ThuocTinhChaID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetThuocTinhByThuocTinhChaID";
                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).Value = ThuocTinhChaID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinh");
                return dsResult;
            }
        }

        public int Insert(int NhomSanPhamID, string TenThuocTinh, int ThuocTinhChaID, int thutu)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertThuocTinh";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@TenThuocTinh", SqlDbType.NVarChar, 100).Value = TenThuocTinh;

                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).Value = ThuocTinhChaID;

                sqlCmd.Parameters.Add("@thutu", SqlDbType.Int).Value = thutu;


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
                sqlCmd.CommandText = "InsertThuocTinh";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@TenThuocTinh", SqlDbType.NVarChar, 100).SourceColumn = "TenThuocTinh";

                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).SourceColumn = "ThuocTinhChaID";

                sqlCmd.Parameters.Add("@thutu", SqlDbType.Int).SourceColumn = "thutu";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertThuocTinh_Ref";
                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).SourceColumn = "ThuocTinhID";
                sqlCmd.Parameters["@ThuocTinhID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@TenThuocTinh", SqlDbType.NVarChar, 4).SourceColumn = "TenThuocTinh";

                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).SourceColumn = "ThuocTinhChaID";

                sqlCmd.Parameters.Add("@thutu", SqlDbType.Int).SourceColumn = "thutu";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int ThuocTinhID, int NhomSanPhamID, string TenThuocTinh, int ThuocTinhChaID, int thutu)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateThuocTinh";

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@TenThuocTinh", SqlDbType.NVarChar, 100).Value = TenThuocTinh;

                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).Value = ThuocTinhChaID;

                sqlCmd.Parameters.Add("@thutu", SqlDbType.Int).Value = thutu;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateThuocTinh";
                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).SourceColumn = "ThuocTinhID";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@TenThuocTinh", SqlDbType.NVarChar, 100).SourceColumn = "TenThuocTinh";

                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).SourceColumn = "ThuocTinhChaID";

                sqlCmd.Parameters.Add("@thutu", SqlDbType.Int).SourceColumn = "thutu";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateThuocTinh";
                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).SourceColumn = "ThuocTinhID";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@TenThuocTinh", SqlDbType.NVarChar, 100).SourceColumn = "TenThuocTinh";

                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).SourceColumn = "ThuocTinhChaID";

                sqlCmd.Parameters.Add("@thutu", SqlDbType.Int).SourceColumn = "thutu";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteThuocTinh";
                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).SourceColumn = "ThuocTinhID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int ThuocTinhID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteThuocTinh";
                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;
                objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinh");
            }
        }

        public int InsertFields(int? NhomSanPhamID, string TenThuocTinh, int? ThuocTinhChaID, int? thutu)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsThuocTinh";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@TenThuocTinh", SqlDbType.NVarChar, 100).Value = TenThuocTinh;

                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).Value = ThuocTinhChaID;

                sqlCmd.Parameters.Add("@thutu", SqlDbType.Int).Value = thutu;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int ThuocTinhID, int? NhomSanPhamID, string TenThuocTinh, int? ThuocTinhChaID,
                                 int? thutu)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsThuocTinh";

                sqlCmd.Parameters.Add("@ThuocTinhID", SqlDbType.Int).Value = ThuocTinhID;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@TenThuocTinh", SqlDbType.NVarChar, 100).Value = TenThuocTinh;

                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).Value = ThuocTinhChaID;

                sqlCmd.Parameters.Add("@thutu", SqlDbType.Int).Value = thutu;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? NhomSanPhamID, string TenThuocTinh, int? ThuocTinhChaID,
                                       int? thutu)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsThuocTinh";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@TenThuocTinh", SqlDbType.NVarChar, 100).Value = TenThuocTinh;

                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).Value = ThuocTinhChaID;

                sqlCmd.Parameters.Add("@thutu", SqlDbType.Int).Value = thutu;


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
                sqlCmd.CommandText = "SelectThuocTinhByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinh");
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
                sqlCmd.CommandText = "GetThuocTinhByNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinh");
                return dsResult;
            }
        }

        public DataSet SelectByThuocTinhChaIDPaging(int ThuocTinhChaID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetThuocTinhByThuocTinhChaIDPaging";
                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).Value = ThuocTinhChaID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinh");
                return dsResult;
            }
        }
    }
}