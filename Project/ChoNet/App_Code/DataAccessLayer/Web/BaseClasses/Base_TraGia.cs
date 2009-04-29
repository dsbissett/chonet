using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_TraGia
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_TraGia()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("TraGiaID", "TraGiaID")
                                   ,
                                   new DataColumnMapping("NguoiDungID", "NguoiDungID")
                                   ,
                                   new DataColumnMapping("DauGiaID", "DauGiaID")
                                   ,
                                   new DataColumnMapping("TraGia", "TraGia")
                                   ,
                                   new DataColumnMapping("ThoiGianTraGia", "ThoiGianTraGia")
                                   ,
                                   new DataColumnMapping("Bak1", "Bak1")
                                   ,
                                   new DataColumnMapping("Bak2", "Bak2")
                                   ,
                                   new DataColumnMapping("Bak3", "Bak3")
                                   ,
                                   new DataColumnMapping("Bak4", "Bak4")
                               };
            dtTblMapping = new DataTableMapping("Table", "TraGia", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetTraGia";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TraGia");
                return dsResult;
            }
        }

        public DataSet SelectByID(int TraGiaID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetTraGiaById";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TraGia");
                return dsResult;
            }
        }

        public DataSet SelectByDauGiaID(int DauGiaID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetTraGiaByDauGiaID";
                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TraGia");
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
                sqlCmd.CommandText = "GetTraGiaByNguoiDungID";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TraGia");
                return dsResult;
            }
        }

        public int Insert(int NguoiDungID, int DauGiaID, decimal TraGia, DateTime ThoiGianTraGia, string Bak1,
                          string Bak2, int Bak3, bool Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertTraGia";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;

                sqlCmd.Parameters.Add("@TraGia", SqlDbType.Money).Value = TraGia;

                sqlCmd.Parameters.Add("@ThoiGianTraGia", SqlDbType.DateTime).Value = ThoiGianTraGia;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).Value = Bak4;


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
                sqlCmd.CommandText = "InsertTraGia";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).SourceColumn = "DauGiaID";

                sqlCmd.Parameters.Add("@TraGia", SqlDbType.Money).SourceColumn = "TraGia";

                sqlCmd.Parameters.Add("@ThoiGianTraGia", SqlDbType.DateTime).SourceColumn = "ThoiGianTraGia";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).SourceColumn = "Bak4";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertTraGia_Ref";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";
                sqlCmd.Parameters["@TraGiaID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).SourceColumn = "DauGiaID";

                sqlCmd.Parameters.Add("@TraGia", SqlDbType.Money).SourceColumn = "TraGia";

                sqlCmd.Parameters.Add("@ThoiGianTraGia", SqlDbType.DateTime).SourceColumn = "ThoiGianTraGia";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 8).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).SourceColumn = "Bak4";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int TraGiaID, int NguoiDungID, int DauGiaID, decimal TraGia, DateTime ThoiGianTraGia,
                           string Bak1, string Bak2, int Bak3, bool Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateTraGia";

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;

                sqlCmd.Parameters.Add("@TraGia", SqlDbType.Money).Value = TraGia;

                sqlCmd.Parameters.Add("@ThoiGianTraGia", SqlDbType.DateTime).Value = ThoiGianTraGia;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).Value = Bak4;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateTraGia";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).SourceColumn = "DauGiaID";

                sqlCmd.Parameters.Add("@TraGia", SqlDbType.Money).SourceColumn = "TraGia";

                sqlCmd.Parameters.Add("@ThoiGianTraGia", SqlDbType.DateTime).SourceColumn = "ThoiGianTraGia";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).SourceColumn = "Bak4";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateTraGia";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).SourceColumn = "DauGiaID";

                sqlCmd.Parameters.Add("@TraGia", SqlDbType.Money).SourceColumn = "TraGia";

                sqlCmd.Parameters.Add("@ThoiGianTraGia", SqlDbType.DateTime).SourceColumn = "ThoiGianTraGia";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).SourceColumn = "Bak4";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteTraGia";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int TraGiaID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteTraGia";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;
                objDataAccess.ExecuteQuery(sqlCmd, "TraGia");
            }
        }

        public int InsertFields(int? NguoiDungID, int? DauGiaID, decimal? TraGia, DateTime? ThoiGianTraGia, string Bak1,
                                string Bak2, int? Bak3, bool? Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsTraGia";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;

                sqlCmd.Parameters.Add("@TraGia", SqlDbType.Money).Value = TraGia;

                sqlCmd.Parameters.Add("@ThoiGianTraGia", SqlDbType.DateTime).Value = ThoiGianTraGia;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).Value = Bak4;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int TraGiaID, int? NguoiDungID, int? DauGiaID, decimal? TraGia,
                                 DateTime? ThoiGianTraGia, string Bak1, string Bak2, int? Bak3, bool? Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsTraGia";

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;

                sqlCmd.Parameters.Add("@TraGia", SqlDbType.Money).Value = TraGia;

                sqlCmd.Parameters.Add("@ThoiGianTraGia", SqlDbType.DateTime).Value = ThoiGianTraGia;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).Value = Bak4;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? NguoiDungID, int? DauGiaID, decimal? TraGia,
                                       DateTime? ThoiGianTraGia, string Bak1, string Bak2, int? Bak3, bool? Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsTraGia";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;

                sqlCmd.Parameters.Add("@TraGia", SqlDbType.Money).Value = TraGia;

                sqlCmd.Parameters.Add("@ThoiGianTraGia", SqlDbType.DateTime).Value = ThoiGianTraGia;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).Value = Bak4;


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
                sqlCmd.CommandText = "SelectTraGiaByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TraGia");
                return dsResult;
            }
        }

        public DataSet SelectByDauGiaIDPaging(int DauGiaID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetTraGiaByDauGiaIDPaging";
                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TraGia");
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
                sqlCmd.CommandText = "GetTraGiaByNguoiDungIDPaging";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TraGia");
                return dsResult;
            }
        }
    }
}