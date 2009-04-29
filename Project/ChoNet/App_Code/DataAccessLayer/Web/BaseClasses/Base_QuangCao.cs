using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_QuangCao
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_QuangCao()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("QuangCaoID", "QuangCaoID")
                                   ,
                                   new DataColumnMapping("DuongDan", "DuongDan")
                                   ,
                                   new DataColumnMapping("NoiDungQuangCao", "NoiDungQuangCao")
                                   ,
                                   new DataColumnMapping("DuongDanAnh", "DuongDanAnh")
                                   ,
                                   new DataColumnMapping("NguoiDungID", "NguoiDungID")
                                   ,
                                   new DataColumnMapping("GhiChu", "GhiChu")
                                   ,
                                   new DataColumnMapping("LoaiAnh", "LoaiAnh")
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
                               };
            dtTblMapping = new DataTableMapping("Table", "QuangCao", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetQuangCao";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public DataSet SelectByID(int QuangCaoID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetQuangCaoById";
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
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
                sqlCmd.CommandText = "GetQuangCaoByNguoiDungID";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public int Insert(string DuongDan, string NoiDungQuangCao, string DuongDanAnh, int NguoiDungID, string GhiChu,
                          string LoaiAnh, int SapXep, string Bak1, string Bak2, bool Bak3, int Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertQuangCao";

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 200).Value = DuongDan;

                sqlCmd.Parameters.Add("@NoiDungQuangCao", SqlDbType.NVarChar, 4000).Value = NoiDungQuangCao;

                sqlCmd.Parameters.Add("@DuongDanAnh", SqlDbType.NVarChar, 200).Value = DuongDanAnh;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 4000).Value = GhiChu;

                sqlCmd.Parameters.Add("@LoaiAnh", SqlDbType.VarChar, 20).Value = LoaiAnh;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;


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
                sqlCmd.CommandText = "InsertQuangCao";
                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 200).SourceColumn = "DuongDan";

                sqlCmd.Parameters.Add("@NoiDungQuangCao", SqlDbType.NVarChar, 4000).SourceColumn = "NoiDungQuangCao";

                sqlCmd.Parameters.Add("@DuongDanAnh", SqlDbType.NVarChar, 200).SourceColumn = "DuongDanAnh";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 4000).SourceColumn = "GhiChu";

                sqlCmd.Parameters.Add("@LoaiAnh", SqlDbType.VarChar, 20).SourceColumn = "LoaiAnh";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertQuangCao_Ref";
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).SourceColumn = "QuangCaoID";
                sqlCmd.Parameters["@QuangCaoID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 4).SourceColumn = "DuongDan";

                sqlCmd.Parameters.Add("@NoiDungQuangCao", SqlDbType.NVarChar, 200).SourceColumn = "NoiDungQuangCao";

                sqlCmd.Parameters.Add("@DuongDanAnh", SqlDbType.NVarChar, 4000).SourceColumn = "DuongDanAnh";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 4).SourceColumn = "GhiChu";

                sqlCmd.Parameters.Add("@LoaiAnh", SqlDbType.VarChar, 4000).SourceColumn = "LoaiAnh";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int QuangCaoID, string DuongDan, string NoiDungQuangCao, string DuongDanAnh, int NguoiDungID,
                           string GhiChu, string LoaiAnh, int SapXep, string Bak1, string Bak2, bool Bak3, int Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateQuangCao";

                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;
                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 200).Value = DuongDan;

                sqlCmd.Parameters.Add("@NoiDungQuangCao", SqlDbType.NVarChar, 4000).Value = NoiDungQuangCao;

                sqlCmd.Parameters.Add("@DuongDanAnh", SqlDbType.NVarChar, 200).Value = DuongDanAnh;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 4000).Value = GhiChu;

                sqlCmd.Parameters.Add("@LoaiAnh", SqlDbType.VarChar, 20).Value = LoaiAnh;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateQuangCao";
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).SourceColumn = "QuangCaoID";

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 200).SourceColumn = "DuongDan";

                sqlCmd.Parameters.Add("@NoiDungQuangCao", SqlDbType.NVarChar, 4000).SourceColumn = "NoiDungQuangCao";

                sqlCmd.Parameters.Add("@DuongDanAnh", SqlDbType.NVarChar, 200).SourceColumn = "DuongDanAnh";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 4000).SourceColumn = "GhiChu";

                sqlCmd.Parameters.Add("@LoaiAnh", SqlDbType.VarChar, 20).SourceColumn = "LoaiAnh";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateQuangCao";
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).SourceColumn = "QuangCaoID";

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 200).SourceColumn = "DuongDan";

                sqlCmd.Parameters.Add("@NoiDungQuangCao", SqlDbType.NVarChar, 4000).SourceColumn = "NoiDungQuangCao";

                sqlCmd.Parameters.Add("@DuongDanAnh", SqlDbType.NVarChar, 200).SourceColumn = "DuongDanAnh";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 4000).SourceColumn = "GhiChu";

                sqlCmd.Parameters.Add("@LoaiAnh", SqlDbType.VarChar, 20).SourceColumn = "LoaiAnh";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteQuangCao";
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).SourceColumn = "QuangCaoID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int QuangCaoID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteQuangCao";
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;
                objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
            }
        }

        public int InsertFields(string DuongDan, string NoiDungQuangCao, string DuongDanAnh, int? NguoiDungID,
                                string GhiChu, string LoaiAnh, int? SapXep, string Bak1, string Bak2, bool? Bak3,
                                int? Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsQuangCao";

                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 200).Value = DuongDan;

                sqlCmd.Parameters.Add("@NoiDungQuangCao", SqlDbType.NVarChar, 4000).Value = NoiDungQuangCao;

                sqlCmd.Parameters.Add("@DuongDanAnh", SqlDbType.NVarChar, 200).Value = DuongDanAnh;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 4000).Value = GhiChu;

                sqlCmd.Parameters.Add("@LoaiAnh", SqlDbType.VarChar, 20).Value = LoaiAnh;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int QuangCaoID, string DuongDan, string NoiDungQuangCao, string DuongDanAnh,
                                 int? NguoiDungID, string GhiChu, string LoaiAnh, int? SapXep, string Bak1, string Bak2,
                                 bool? Bak3, int? Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsQuangCao";

                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;
                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 200).Value = DuongDan;

                sqlCmd.Parameters.Add("@NoiDungQuangCao", SqlDbType.NVarChar, 4000).Value = NoiDungQuangCao;

                sqlCmd.Parameters.Add("@DuongDanAnh", SqlDbType.NVarChar, 200).Value = DuongDanAnh;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 4000).Value = GhiChu;

                sqlCmd.Parameters.Add("@LoaiAnh", SqlDbType.VarChar, 20).Value = LoaiAnh;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string DuongDan, string NoiDungQuangCao, string DuongDanAnh,
                                       int? NguoiDungID, string GhiChu, string LoaiAnh, int? SapXep, string Bak1,
                                       string Bak2, bool? Bak3, int? Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsQuangCao";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@DuongDan", SqlDbType.NVarChar, 200).Value = DuongDan;

                sqlCmd.Parameters.Add("@NoiDungQuangCao", SqlDbType.NVarChar, 4000).Value = NoiDungQuangCao;

                sqlCmd.Parameters.Add("@DuongDanAnh", SqlDbType.NVarChar, 200).Value = DuongDanAnh;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 4000).Value = GhiChu;

                sqlCmd.Parameters.Add("@LoaiAnh", SqlDbType.VarChar, 20).Value = LoaiAnh;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;


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
                sqlCmd.CommandText = "SelectQuangCaoByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
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
                sqlCmd.CommandText = "GetQuangCaoByNguoiDungIDPaging";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }
    }
}