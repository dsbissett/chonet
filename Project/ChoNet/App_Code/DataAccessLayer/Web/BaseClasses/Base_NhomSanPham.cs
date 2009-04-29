using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_NhomSanPham
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_NhomSanPham()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("NhomSanPhamID", "NhomSanPhamID")
                                   ,
                                   new DataColumnMapping("TenNhomSanPham", "TenNhomSanPham")
                                   ,
                                   new DataColumnMapping("MoTaNhomSanPham", "MoTaNhomSanPham")
                                   ,
                                   new DataColumnMapping("NhomChaID", "NhomChaID")
                                   ,
                                   new DataColumnMapping("Show", "Show")
                                   ,
                                   new DataColumnMapping("SapXep", "SapXep")
                                   ,
                                   new DataColumnMapping("Bak1", "Bak1")
                                   ,
                                   new DataColumnMapping("Bak2", "Bak2")
                                   ,
                                   new DataColumnMapping("Bak3", "Bak3")
                                   ,
                                   new DataColumnMapping("Bak4", "Bak4")
                                   ,
                                   new DataColumnMapping("Bak5", "Bak5")
                                   ,
                                   new DataColumnMapping("KhuVucShow", "KhuVucShow")
                               };
            dtTblMapping = new DataTableMapping("Table", "NhomSanPham", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetNhomSanPham";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByID(int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetNhomSanPhamById";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }


        public int Insert(string TenNhomSanPham, string MoTaNhomSanPham, int NhomChaID, bool Show, int SapXep,
                          string Bak1, string Bak2, string Bak3, int Bak4, bool Bak5, int KhuVucShow)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertNhomSanPham";

                sqlCmd.Parameters.Add("@TenNhomSanPham", SqlDbType.NVarChar, 50).Value = TenNhomSanPham;

                sqlCmd.Parameters.Add("@MoTaNhomSanPham", SqlDbType.NVarChar, 4000).Value = MoTaNhomSanPham;

                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).Value = NhomChaID;

                sqlCmd.Parameters.Add("@Show", SqlDbType.Bit).Value = Show;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.NVarChar, 50).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;

                sqlCmd.Parameters.Add("@KhuVucShow", SqlDbType.Int).Value = KhuVucShow;


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
                sqlCmd.CommandText = "InsertNhomSanPham";
                sqlCmd.Parameters.Add("@TenNhomSanPham", SqlDbType.NVarChar, 50).SourceColumn = "TenNhomSanPham";

                sqlCmd.Parameters.Add("@MoTaNhomSanPham", SqlDbType.NVarChar, 4000).SourceColumn = "MoTaNhomSanPham";

                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).SourceColumn = "NhomChaID";

                sqlCmd.Parameters.Add("@Show", SqlDbType.Bit).SourceColumn = "Show";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.NVarChar, 50).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                sqlCmd.Parameters.Add("@KhuVucShow", SqlDbType.Int).SourceColumn = "KhuVucShow";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertNhomSanPham_Ref";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";
                sqlCmd.Parameters["@NhomSanPhamID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@TenNhomSanPham", SqlDbType.NVarChar, 4).SourceColumn = "TenNhomSanPham";

                sqlCmd.Parameters.Add("@MoTaNhomSanPham", SqlDbType.NVarChar, 50).SourceColumn = "MoTaNhomSanPham";

                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).SourceColumn = "NhomChaID";

                sqlCmd.Parameters.Add("@Show", SqlDbType.Bit).SourceColumn = "Show";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.NVarChar, 50).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                sqlCmd.Parameters.Add("@KhuVucShow", SqlDbType.Int).SourceColumn = "KhuVucShow";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int NhomSanPhamID, string TenNhomSanPham, string MoTaNhomSanPham, int NhomChaID, bool Show,
                           int SapXep, string Bak1, string Bak2, string Bak3, int Bak4, bool Bak5, int KhuVucShow)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNhomSanPham";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@TenNhomSanPham", SqlDbType.NVarChar, 50).Value = TenNhomSanPham;

                sqlCmd.Parameters.Add("@MoTaNhomSanPham", SqlDbType.NVarChar, 4000).Value = MoTaNhomSanPham;

                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).Value = NhomChaID;

                sqlCmd.Parameters.Add("@Show", SqlDbType.Bit).Value = Show;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.NVarChar, 50).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;

                sqlCmd.Parameters.Add("@KhuVucShow", SqlDbType.Int).Value = KhuVucShow;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNhomSanPham";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@TenNhomSanPham", SqlDbType.NVarChar, 50).SourceColumn = "TenNhomSanPham";

                sqlCmd.Parameters.Add("@MoTaNhomSanPham", SqlDbType.NVarChar, 4000).SourceColumn = "MoTaNhomSanPham";

                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).SourceColumn = "NhomChaID";

                sqlCmd.Parameters.Add("@Show", SqlDbType.Bit).SourceColumn = "Show";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.NVarChar, 50).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                sqlCmd.Parameters.Add("@KhuVucShow", SqlDbType.Int).SourceColumn = "KhuVucShow";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNhomSanPham";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@TenNhomSanPham", SqlDbType.NVarChar, 50).SourceColumn = "TenNhomSanPham";

                sqlCmd.Parameters.Add("@MoTaNhomSanPham", SqlDbType.NVarChar, 4000).SourceColumn = "MoTaNhomSanPham";

                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).SourceColumn = "NhomChaID";

                sqlCmd.Parameters.Add("@Show", SqlDbType.Bit).SourceColumn = "Show";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.NVarChar, 50).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                sqlCmd.Parameters.Add("@KhuVucShow", SqlDbType.Int).SourceColumn = "KhuVucShow";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteNhomSanPham";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int NhomSanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteNhomSanPham";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
            }
        }

        public int InsertFields(string TenNhomSanPham, string MoTaNhomSanPham, int? NhomChaID, bool? Show, int? SapXep,
                                string Bak1, string Bak2, string Bak3, int? Bak4, bool? Bak5, int? KhuVucShow)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsNhomSanPham";

                sqlCmd.Parameters.Add("@TenNhomSanPham", SqlDbType.NVarChar, 50).Value = TenNhomSanPham;

                sqlCmd.Parameters.Add("@MoTaNhomSanPham", SqlDbType.NVarChar, 4000).Value = MoTaNhomSanPham;

                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).Value = NhomChaID;

                sqlCmd.Parameters.Add("@Show", SqlDbType.Bit).Value = Show;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.NVarChar, 50).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;

                sqlCmd.Parameters.Add("@KhuVucShow", SqlDbType.Int).Value = KhuVucShow;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int NhomSanPhamID, string TenNhomSanPham, string MoTaNhomSanPham, int? NhomChaID,
                                 bool? Show, int? SapXep, string Bak1, string Bak2, string Bak3, int? Bak4, bool? Bak5,
                                 int? KhuVucShow)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsNhomSanPham";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@TenNhomSanPham", SqlDbType.NVarChar, 50).Value = TenNhomSanPham;

                sqlCmd.Parameters.Add("@MoTaNhomSanPham", SqlDbType.NVarChar, 4000).Value = MoTaNhomSanPham;

                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).Value = NhomChaID;

                sqlCmd.Parameters.Add("@Show", SqlDbType.Bit).Value = Show;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.NVarChar, 50).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;

                sqlCmd.Parameters.Add("@KhuVucShow", SqlDbType.Int).Value = KhuVucShow;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string TenNhomSanPham, string MoTaNhomSanPham, int? NhomChaID,
                                       bool? Show, int? SapXep, string Bak1, string Bak2, string Bak3, int? Bak4,
                                       bool? Bak5, int? KhuVucShow)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsNhomSanPham";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@TenNhomSanPham", SqlDbType.NVarChar, 50).Value = TenNhomSanPham;

                sqlCmd.Parameters.Add("@MoTaNhomSanPham", SqlDbType.NVarChar, 4000).Value = MoTaNhomSanPham;

                sqlCmd.Parameters.Add("@NhomChaID", SqlDbType.Int).Value = NhomChaID;

                sqlCmd.Parameters.Add("@Show", SqlDbType.Bit).Value = Show;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.NVarChar, 50).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;

                sqlCmd.Parameters.Add("@KhuVucShow", SqlDbType.Int).Value = KhuVucShow;


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
                sqlCmd.CommandText = "SelectNhomSanPhamByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NhomSanPham");
                return dsResult;
            }
        }
    }
}