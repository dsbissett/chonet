using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_DonHang
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_DonHang()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("DonHangID", "DonHangID")
                                   ,
                                   new DataColumnMapping("NguoiDungID", "NguoiDungID")
                                   ,
                                   new DataColumnMapping("HovaTenNguoiNhan", "HovaTenNguoiNhan")
                                   ,
                                   new DataColumnMapping("DiaChiNguoiNhan", "DiaChiNguoiNhan")
                                   ,
                                   new DataColumnMapping("EmailNguoiNhan", "EmailNguoiNhan")
                                   ,
                                   new DataColumnMapping("DTDDNguoiNhan", "DTDDNguoiNhan")
                                   ,
                                   new DataColumnMapping("CMTND", "CMTND")
                               };
            dtTblMapping = new DataTableMapping("Table", "DonHang", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetDonHang";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DonHang");
                return dsResult;
            }
        }

        public DataSet SelectByID(int DonHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetDonHangById";
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DonHang");
                return dsResult;
            }
        }

        public DataSet SelectByNguoiDungID(int NguoiDungID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetDonHangByNguoiDungID";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DonHang");
                return dsResult;
            }
        }

        public int Insert(int NguoiDungID, string HovaTenNguoiNhan, string DiaChiNguoiNhan, string EmailNguoiNhan,
                          string DTDDNguoiNhan, string CMTND)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertDonHang";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@HovaTenNguoiNhan", SqlDbType.NVarChar, 50).Value = HovaTenNguoiNhan;

                sqlCmd.Parameters.Add("@DiaChiNguoiNhan", SqlDbType.NVarChar, 1000).Value = DiaChiNguoiNhan;

                sqlCmd.Parameters.Add("@EmailNguoiNhan", SqlDbType.NVarChar, 50).Value = EmailNguoiNhan;

                sqlCmd.Parameters.Add("@DTDDNguoiNhan", SqlDbType.NVarChar, 50).Value = DTDDNguoiNhan;

                sqlCmd.Parameters.Add("@CMTND", SqlDbType.VarChar, 9).Value = CMTND;


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
                sqlCmd.CommandText = "InsertDonHang";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@HovaTenNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "HovaTenNguoiNhan";

                sqlCmd.Parameters.Add("@DiaChiNguoiNhan", SqlDbType.NVarChar, 1000).SourceColumn = "DiaChiNguoiNhan";

                sqlCmd.Parameters.Add("@EmailNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "EmailNguoiNhan";

                sqlCmd.Parameters.Add("@DTDDNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "DTDDNguoiNhan";

                sqlCmd.Parameters.Add("@CMTND", SqlDbType.VarChar, 9).SourceColumn = "CMTND";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertDonHang_Ref";
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).SourceColumn = "DonHangID";
                sqlCmd.Parameters["@DonHangID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@HovaTenNguoiNhan", SqlDbType.NVarChar, 4).SourceColumn = "HovaTenNguoiNhan";

                sqlCmd.Parameters.Add("@DiaChiNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "DiaChiNguoiNhan";

                sqlCmd.Parameters.Add("@EmailNguoiNhan", SqlDbType.NVarChar, 1000).SourceColumn = "EmailNguoiNhan";

                sqlCmd.Parameters.Add("@DTDDNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "DTDDNguoiNhan";

                sqlCmd.Parameters.Add("@CMTND", SqlDbType.VarChar, 50).SourceColumn = "CMTND";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int DonHangID, int NguoiDungID, string HovaTenNguoiNhan, string DiaChiNguoiNhan,
                           string EmailNguoiNhan, string DTDDNguoiNhan, string CMTND)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateDonHang";

                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@HovaTenNguoiNhan", SqlDbType.NVarChar, 50).Value = HovaTenNguoiNhan;

                sqlCmd.Parameters.Add("@DiaChiNguoiNhan", SqlDbType.NVarChar, 1000).Value = DiaChiNguoiNhan;

                sqlCmd.Parameters.Add("@EmailNguoiNhan", SqlDbType.NVarChar, 50).Value = EmailNguoiNhan;

                sqlCmd.Parameters.Add("@DTDDNguoiNhan", SqlDbType.NVarChar, 50).Value = DTDDNguoiNhan;

                sqlCmd.Parameters.Add("@CMTND", SqlDbType.VarChar, 9).Value = CMTND;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateDonHang";
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).SourceColumn = "DonHangID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@HovaTenNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "HovaTenNguoiNhan";

                sqlCmd.Parameters.Add("@DiaChiNguoiNhan", SqlDbType.NVarChar, 1000).SourceColumn = "DiaChiNguoiNhan";

                sqlCmd.Parameters.Add("@EmailNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "EmailNguoiNhan";

                sqlCmd.Parameters.Add("@DTDDNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "DTDDNguoiNhan";

                sqlCmd.Parameters.Add("@CMTND", SqlDbType.VarChar, 9).SourceColumn = "CMTND";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateDonHang";
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).SourceColumn = "DonHangID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@HovaTenNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "HovaTenNguoiNhan";

                sqlCmd.Parameters.Add("@DiaChiNguoiNhan", SqlDbType.NVarChar, 1000).SourceColumn = "DiaChiNguoiNhan";

                sqlCmd.Parameters.Add("@EmailNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "EmailNguoiNhan";

                sqlCmd.Parameters.Add("@DTDDNguoiNhan", SqlDbType.NVarChar, 50).SourceColumn = "DTDDNguoiNhan";

                sqlCmd.Parameters.Add("@CMTND", SqlDbType.VarChar, 9).SourceColumn = "CMTND";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteDonHang";
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).SourceColumn = "DonHangID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int DonHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteDonHang";
                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;
                objDataAccess.ExecuteQuery(sqlCmd, "DonHang");
            }
        }

        public int InsertFields(int? NguoiDungID, string HovaTenNguoiNhan, string DiaChiNguoiNhan, string EmailNguoiNhan,
                                string DTDDNguoiNhan, string CMTND)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsDonHang";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@HovaTenNguoiNhan", SqlDbType.NVarChar, 50).Value = HovaTenNguoiNhan;

                sqlCmd.Parameters.Add("@DiaChiNguoiNhan", SqlDbType.NVarChar, 1000).Value = DiaChiNguoiNhan;

                sqlCmd.Parameters.Add("@EmailNguoiNhan", SqlDbType.NVarChar, 50).Value = EmailNguoiNhan;

                sqlCmd.Parameters.Add("@DTDDNguoiNhan", SqlDbType.NVarChar, 50).Value = DTDDNguoiNhan;

                sqlCmd.Parameters.Add("@CMTND", SqlDbType.VarChar, 9).Value = CMTND;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int DonHangID, int? NguoiDungID, string HovaTenNguoiNhan, string DiaChiNguoiNhan,
                                 string EmailNguoiNhan, string DTDDNguoiNhan, string CMTND)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsDonHang";

                sqlCmd.Parameters.Add("@DonHangID", SqlDbType.Int).Value = DonHangID;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@HovaTenNguoiNhan", SqlDbType.NVarChar, 50).Value = HovaTenNguoiNhan;

                sqlCmd.Parameters.Add("@DiaChiNguoiNhan", SqlDbType.NVarChar, 1000).Value = DiaChiNguoiNhan;

                sqlCmd.Parameters.Add("@EmailNguoiNhan", SqlDbType.NVarChar, 50).Value = EmailNguoiNhan;

                sqlCmd.Parameters.Add("@DTDDNguoiNhan", SqlDbType.NVarChar, 50).Value = DTDDNguoiNhan;

                sqlCmd.Parameters.Add("@CMTND", SqlDbType.VarChar, 9).Value = CMTND;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? NguoiDungID, string HovaTenNguoiNhan, string DiaChiNguoiNhan,
                                       string EmailNguoiNhan, string DTDDNguoiNhan, string CMTND)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsDonHang";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@HovaTenNguoiNhan", SqlDbType.NVarChar, 50).Value = HovaTenNguoiNhan;

                sqlCmd.Parameters.Add("@DiaChiNguoiNhan", SqlDbType.NVarChar, 1000).Value = DiaChiNguoiNhan;

                sqlCmd.Parameters.Add("@EmailNguoiNhan", SqlDbType.NVarChar, 50).Value = EmailNguoiNhan;

                sqlCmd.Parameters.Add("@DTDDNguoiNhan", SqlDbType.NVarChar, 50).Value = DTDDNguoiNhan;

                sqlCmd.Parameters.Add("@CMTND", SqlDbType.VarChar, 9).Value = CMTND;


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
                sqlCmd.CommandText = "SelectDonHangByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DonHang");
                return dsResult;
            }
        }

        public DataSet SelectByNguoiDungIDPaging(int NguoiDungID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetDonHangByNguoiDungIDPaging";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DonHang");
                return dsResult;
            }
        }
    }
}