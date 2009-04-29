using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_ViTriQuangCao
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_ViTriQuangCao()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("ViTriQuangCaoID", "ViTriQuangCaoID")
                                   ,
                                   new DataColumnMapping("QuangCaoID", "QuangCaoID")
                                   ,
                                   new DataColumnMapping("ViTriQuangCao", "ViTriQuangCao")
                                   ,
                                   new DataColumnMapping("NhomSanPhamID", "NhomSanPhamID")
                                   ,
                                   new DataColumnMapping("khuvucid", "khuvucid")
                                   ,
                                   new DataColumnMapping("bak", "bak")
                               };
            dtTblMapping = new DataTableMapping("Table", "ViTriQuangCao", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetViTriQuangCao";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ViTriQuangCao");
                return dsResult;
            }
        }

        public DataSet SelectByID(int ViTriQuangCaoID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetViTriQuangCaoById";
                sqlCmd.Parameters.Add("@ViTriQuangCaoID", SqlDbType.Int).Value = ViTriQuangCaoID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ViTriQuangCao");
                return dsResult;
            }
        }

        public DataSet SelectByQuangCaoID(int QuangCaoID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetViTriQuangCaoByQuangCaoID";
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ViTriQuangCao");
                return dsResult;
            }
        }

        public int Insert(int QuangCaoID, int ViTriQuangCao, int NhomSanPhamID, int khuvucid, int bak)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertViTriQuangCao";

                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;

                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@khuvucid", SqlDbType.Int).Value = khuvucid;

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).Value = bak;


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
                sqlCmd.CommandText = "InsertViTriQuangCao";
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).SourceColumn = "QuangCaoID";

                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).SourceColumn = "ViTriQuangCao";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@khuvucid", SqlDbType.Int).SourceColumn = "khuvucid";

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).SourceColumn = "bak";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertViTriQuangCao_Ref";
                sqlCmd.Parameters.Add("@ViTriQuangCaoID", SqlDbType.Int).SourceColumn = "ViTriQuangCaoID";
                sqlCmd.Parameters["@ViTriQuangCaoID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).SourceColumn = "QuangCaoID";

                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).SourceColumn = "ViTriQuangCao";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@khuvucid", SqlDbType.Int).SourceColumn = "khuvucid";

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).SourceColumn = "bak";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int ViTriQuangCaoID, int QuangCaoID, int ViTriQuangCao, int NhomSanPhamID, int khuvucid,
                           int bak)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateViTriQuangCao";

                sqlCmd.Parameters.Add("@ViTriQuangCaoID", SqlDbType.Int).Value = ViTriQuangCaoID;
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;

                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@khuvucid", SqlDbType.Int).Value = khuvucid;

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).Value = bak;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateViTriQuangCao";
                sqlCmd.Parameters.Add("@ViTriQuangCaoID", SqlDbType.Int).SourceColumn = "ViTriQuangCaoID";

                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).SourceColumn = "QuangCaoID";

                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).SourceColumn = "ViTriQuangCao";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@khuvucid", SqlDbType.Int).SourceColumn = "khuvucid";

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).SourceColumn = "bak";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateViTriQuangCao";
                sqlCmd.Parameters.Add("@ViTriQuangCaoID", SqlDbType.Int).SourceColumn = "ViTriQuangCaoID";

                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).SourceColumn = "QuangCaoID";

                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).SourceColumn = "ViTriQuangCao";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@khuvucid", SqlDbType.Int).SourceColumn = "khuvucid";

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).SourceColumn = "bak";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteViTriQuangCao";
                sqlCmd.Parameters.Add("@ViTriQuangCaoID", SqlDbType.Int).SourceColumn = "ViTriQuangCaoID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int ViTriQuangCaoID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteViTriQuangCao";
                sqlCmd.Parameters.Add("@ViTriQuangCaoID", SqlDbType.Int).Value = ViTriQuangCaoID;
                objDataAccess.ExecuteQuery(sqlCmd, "ViTriQuangCao");
            }
        }

        public int InsertFields(int? QuangCaoID, int? ViTriQuangCao, int? NhomSanPhamID, int? khuvucid, int? bak)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsViTriQuangCao";

                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;

                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@khuvucid", SqlDbType.Int).Value = khuvucid;

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).Value = bak;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int ViTriQuangCaoID, int? QuangCaoID, int? ViTriQuangCao, int? NhomSanPhamID,
                                 int? khuvucid, int? bak)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsViTriQuangCao";

                sqlCmd.Parameters.Add("@ViTriQuangCaoID", SqlDbType.Int).Value = ViTriQuangCaoID;
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;

                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@khuvucid", SqlDbType.Int).Value = khuvucid;

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).Value = bak;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? QuangCaoID, int? ViTriQuangCao, int? NhomSanPhamID,
                                       int? khuvucid, int? bak)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsViTriQuangCao";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;

                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@khuvucid", SqlDbType.Int).Value = khuvucid;

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).Value = bak;


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
                sqlCmd.CommandText = "SelectViTriQuangCaoByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ViTriQuangCao");
                return dsResult;
            }
        }

        public DataSet SelectByQuangCaoIDPaging(int QuangCaoID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetViTriQuangCaoByQuangCaoIDPaging";
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "ViTriQuangCao");
                return dsResult;
            }
        }
    }
}