using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_TinTuc
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_TinTuc()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("TinTucID", "TinTucID")
                                   ,
                                   new DataColumnMapping("TieuDe", "TieuDe")
                                   ,
                                   new DataColumnMapping("NoiDung", "NoiDung")
                                   ,
                                   new DataColumnMapping("TomTat", "TomTat")
                                   ,
                                   new DataColumnMapping("NguoiDungID", "NguoiDungID")
                                   ,
                                   new DataColumnMapping("NgayCapNhat", "NgayCapNhat")
                                   ,
                                   new DataColumnMapping("Anh", "Anh")
                                   ,
                                   new DataColumnMapping("LoaiTinTuc", "LoaiTinTuc")
                               };
            dtTblMapping = new DataTableMapping("Table", "TinTuc", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetTinTuc";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TinTuc");
                return dsResult;
            }
        }

        public DataSet SelectByID(int TinTucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetTinTucById";
                sqlCmd.Parameters.Add("@TinTucID", SqlDbType.Int).Value = TinTucID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TinTuc");
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
                sqlCmd.CommandText = "GetTinTucByNguoiDungID";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TinTuc");
                return dsResult;
            }
        }

        public int Insert(string TieuDe, string NoiDung, string TomTat, int NguoiDungID, DateTime NgayCapNhat,
                          string Anh, int LoaiTinTuc)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertTinTuc";

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 200).Value = TieuDe;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;

                sqlCmd.Parameters.Add("@TomTat", SqlDbType.NText).Value = TomTat;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NgayCapNhat", SqlDbType.DateTime).Value = NgayCapNhat;

                sqlCmd.Parameters.Add("@Anh", SqlDbType.VarChar, 100).Value = Anh;

                sqlCmd.Parameters.Add("@LoaiTinTuc", SqlDbType.Int).Value = LoaiTinTuc;


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
                sqlCmd.CommandText = "InsertTinTuc";
                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 200).SourceColumn = "TieuDe";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                sqlCmd.Parameters.Add("@TomTat", SqlDbType.NText).SourceColumn = "TomTat";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NgayCapNhat", SqlDbType.DateTime).SourceColumn = "NgayCapNhat";

                sqlCmd.Parameters.Add("@Anh", SqlDbType.VarChar, 100).SourceColumn = "Anh";

                sqlCmd.Parameters.Add("@LoaiTinTuc", SqlDbType.Int).SourceColumn = "LoaiTinTuc";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertTinTuc_Ref";
                sqlCmd.Parameters.Add("@TinTucID", SqlDbType.Int).SourceColumn = "TinTucID";
                sqlCmd.Parameters["@TinTucID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 4).SourceColumn = "TieuDe";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                sqlCmd.Parameters.Add("@TomTat", SqlDbType.NText).SourceColumn = "TomTat";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NgayCapNhat", SqlDbType.DateTime).SourceColumn = "NgayCapNhat";

                sqlCmd.Parameters.Add("@Anh", SqlDbType.VarChar, 8).SourceColumn = "Anh";

                sqlCmd.Parameters.Add("@LoaiTinTuc", SqlDbType.Int).SourceColumn = "LoaiTinTuc";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int TinTucID, string TieuDe, string NoiDung, string TomTat, int NguoiDungID,
                           DateTime NgayCapNhat, string Anh, int LoaiTinTuc)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateTinTuc";

                sqlCmd.Parameters.Add("@TinTucID", SqlDbType.Int).Value = TinTucID;
                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 200).Value = TieuDe;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;

                sqlCmd.Parameters.Add("@TomTat", SqlDbType.NText).Value = TomTat;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NgayCapNhat", SqlDbType.DateTime).Value = NgayCapNhat;

                sqlCmd.Parameters.Add("@Anh", SqlDbType.VarChar, 100).Value = Anh;

                sqlCmd.Parameters.Add("@LoaiTinTuc", SqlDbType.Int).Value = LoaiTinTuc;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateTinTuc";
                sqlCmd.Parameters.Add("@TinTucID", SqlDbType.Int).SourceColumn = "TinTucID";

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 200).SourceColumn = "TieuDe";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                sqlCmd.Parameters.Add("@TomTat", SqlDbType.NText).SourceColumn = "TomTat";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NgayCapNhat", SqlDbType.DateTime).SourceColumn = "NgayCapNhat";

                sqlCmd.Parameters.Add("@Anh", SqlDbType.VarChar, 100).SourceColumn = "Anh";

                sqlCmd.Parameters.Add("@LoaiTinTuc", SqlDbType.Int).SourceColumn = "LoaiTinTuc";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateTinTuc";
                sqlCmd.Parameters.Add("@TinTucID", SqlDbType.Int).SourceColumn = "TinTucID";

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 200).SourceColumn = "TieuDe";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                sqlCmd.Parameters.Add("@TomTat", SqlDbType.NText).SourceColumn = "TomTat";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NgayCapNhat", SqlDbType.DateTime).SourceColumn = "NgayCapNhat";

                sqlCmd.Parameters.Add("@Anh", SqlDbType.VarChar, 100).SourceColumn = "Anh";

                sqlCmd.Parameters.Add("@LoaiTinTuc", SqlDbType.Int).SourceColumn = "LoaiTinTuc";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteTinTuc";
                sqlCmd.Parameters.Add("@TinTucID", SqlDbType.Int).SourceColumn = "TinTucID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int TinTucID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteTinTuc";
                sqlCmd.Parameters.Add("@TinTucID", SqlDbType.Int).Value = TinTucID;
                objDataAccess.ExecuteQuery(sqlCmd, "TinTuc");
            }
        }

        public int InsertFields(string TieuDe, string NoiDung, string TomTat, int? NguoiDungID, DateTime? NgayCapNhat,
                                string Anh, int? LoaiTinTuc)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsTinTuc";

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 200).Value = TieuDe;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;

                sqlCmd.Parameters.Add("@TomTat", SqlDbType.NText).Value = TomTat;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NgayCapNhat", SqlDbType.DateTime).Value = NgayCapNhat;

                sqlCmd.Parameters.Add("@Anh", SqlDbType.VarChar, 100).Value = Anh;

                sqlCmd.Parameters.Add("@LoaiTinTuc", SqlDbType.Int).Value = LoaiTinTuc;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int TinTucID, string TieuDe, string NoiDung, string TomTat, int? NguoiDungID,
                                 DateTime? NgayCapNhat, string Anh, int? LoaiTinTuc)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsTinTuc";

                sqlCmd.Parameters.Add("@TinTucID", SqlDbType.Int).Value = TinTucID;
                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 200).Value = TieuDe;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;

                sqlCmd.Parameters.Add("@TomTat", SqlDbType.NText).Value = TomTat;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NgayCapNhat", SqlDbType.DateTime).Value = NgayCapNhat;

                sqlCmd.Parameters.Add("@Anh", SqlDbType.VarChar, 100).Value = Anh;

                sqlCmd.Parameters.Add("@LoaiTinTuc", SqlDbType.Int).Value = LoaiTinTuc;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string TieuDe, string NoiDung, string TomTat, int? NguoiDungID,
                                       DateTime? NgayCapNhat, string Anh, int? LoaiTinTuc)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsTinTuc";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 200).Value = TieuDe;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;

                sqlCmd.Parameters.Add("@TomTat", SqlDbType.NText).Value = TomTat;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NgayCapNhat", SqlDbType.DateTime).Value = NgayCapNhat;

                sqlCmd.Parameters.Add("@Anh", SqlDbType.VarChar, 100).Value = Anh;

                sqlCmd.Parameters.Add("@LoaiTinTuc", SqlDbType.Int).Value = LoaiTinTuc;


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
                sqlCmd.CommandText = "SelectTinTucByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TinTuc");
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
                sqlCmd.CommandText = "GetTinTucByNguoiDungIDPaging";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TinTuc");
                return dsResult;
            }
        }
    }
}