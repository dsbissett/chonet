using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_HoiDapSanPham
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_HoiDapSanPham()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("HoiDapID", "HoiDapID")
                                   ,
                                   new DataColumnMapping("SanPhamID", "SanPhamID")
                                   ,
                                   new DataColumnMapping("NguoiDungID", "NguoiDungID")
                                   ,
                                   new DataColumnMapping("NguoiHoi", "NguoiHoi")
                                   ,
                                   new DataColumnMapping("CauHoi", "CauHoi")
                                   ,
                                   new DataColumnMapping("TraLoi", "TraLoi")
                                   ,
                                   new DataColumnMapping("NgayHoi", "NgayHoi")
                                   ,
                                   new DataColumnMapping("NgayTraLoi", "NgayTraLoi")
                                   ,
                                   new DataColumnMapping("bak", "bak")
                                   ,
                                   new DataColumnMapping("bak1", "bak1")
                                   ,
                                   new DataColumnMapping("ChiTietCauHoi", "ChiTietCauHoi")
                               };
            dtTblMapping = new DataTableMapping("Table", "HoiDapSanPham", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetHoiDapSanPham";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HoiDapSanPham");
                return dsResult;
            }
        }

        public DataSet SelectByID(int HoiDapID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetHoiDapSanPhamById";
                sqlCmd.Parameters.Add("@HoiDapID", SqlDbType.Int).Value = HoiDapID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HoiDapSanPham");
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
                sqlCmd.CommandText = "GetHoiDapSanPhamBySanPhamID";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HoiDapSanPham");
                return dsResult;
            }
        }

        public int Insert(int SanPhamID, int NguoiDungID, string NguoiHoi, string CauHoi, string TraLoi,
                          DateTime NgayHoi, DateTime NgayTraLoi, int bak, bool bak1, string ChiTietCauHoi)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertHoiDapSanPham";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NguoiHoi", SqlDbType.NVarChar, 50).Value = NguoiHoi;

                sqlCmd.Parameters.Add("@CauHoi", SqlDbType.NVarChar, 400).Value = CauHoi;

                sqlCmd.Parameters.Add("@TraLoi", SqlDbType.NText).Value = TraLoi;

                sqlCmd.Parameters.Add("@NgayHoi", SqlDbType.DateTime).Value = NgayHoi;

                sqlCmd.Parameters.Add("@NgayTraLoi", SqlDbType.DateTime).Value = NgayTraLoi;

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).Value = bak;

                sqlCmd.Parameters.Add("@bak1", SqlDbType.Bit).Value = bak1;

                sqlCmd.Parameters.Add("@ChiTietCauHoi", SqlDbType.NVarChar, 4000).Value = ChiTietCauHoi;


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
                sqlCmd.CommandText = "InsertHoiDapSanPham";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NguoiHoi", SqlDbType.NVarChar, 50).SourceColumn = "NguoiHoi";

                sqlCmd.Parameters.Add("@CauHoi", SqlDbType.NVarChar, 400).SourceColumn = "CauHoi";

                sqlCmd.Parameters.Add("@TraLoi", SqlDbType.NText).SourceColumn = "TraLoi";

                sqlCmd.Parameters.Add("@NgayHoi", SqlDbType.DateTime).SourceColumn = "NgayHoi";

                sqlCmd.Parameters.Add("@NgayTraLoi", SqlDbType.DateTime).SourceColumn = "NgayTraLoi";

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).SourceColumn = "bak";

                sqlCmd.Parameters.Add("@bak1", SqlDbType.Bit).SourceColumn = "bak1";

                sqlCmd.Parameters.Add("@ChiTietCauHoi", SqlDbType.NVarChar, 4000).SourceColumn = "ChiTietCauHoi";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertHoiDapSanPham_Ref";
                sqlCmd.Parameters.Add("@HoiDapID", SqlDbType.Int).SourceColumn = "HoiDapID";
                sqlCmd.Parameters["@HoiDapID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NguoiHoi", SqlDbType.NVarChar, 4).SourceColumn = "NguoiHoi";

                sqlCmd.Parameters.Add("@CauHoi", SqlDbType.NVarChar, 50).SourceColumn = "CauHoi";

                sqlCmd.Parameters.Add("@TraLoi", SqlDbType.NText).SourceColumn = "TraLoi";

                sqlCmd.Parameters.Add("@NgayHoi", SqlDbType.DateTime).SourceColumn = "NgayHoi";

                sqlCmd.Parameters.Add("@NgayTraLoi", SqlDbType.DateTime).SourceColumn = "NgayTraLoi";

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).SourceColumn = "bak";

                sqlCmd.Parameters.Add("@bak1", SqlDbType.Bit).SourceColumn = "bak1";

                sqlCmd.Parameters.Add("@ChiTietCauHoi", SqlDbType.NVarChar, 1).SourceColumn = "ChiTietCauHoi";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int HoiDapID, int SanPhamID, int NguoiDungID, string NguoiHoi, string CauHoi, string TraLoi,
                           DateTime NgayHoi, DateTime NgayTraLoi, int bak, bool bak1, string ChiTietCauHoi)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateHoiDapSanPham";

                sqlCmd.Parameters.Add("@HoiDapID", SqlDbType.Int).Value = HoiDapID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NguoiHoi", SqlDbType.NVarChar, 50).Value = NguoiHoi;

                sqlCmd.Parameters.Add("@CauHoi", SqlDbType.NVarChar, 400).Value = CauHoi;

                sqlCmd.Parameters.Add("@TraLoi", SqlDbType.NText).Value = TraLoi;

                sqlCmd.Parameters.Add("@NgayHoi", SqlDbType.DateTime).Value = NgayHoi;

                sqlCmd.Parameters.Add("@NgayTraLoi", SqlDbType.DateTime).Value = NgayTraLoi;

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).Value = bak;

                sqlCmd.Parameters.Add("@bak1", SqlDbType.Bit).Value = bak1;

                sqlCmd.Parameters.Add("@ChiTietCauHoi", SqlDbType.NVarChar, 4000).Value = ChiTietCauHoi;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateHoiDapSanPham";
                sqlCmd.Parameters.Add("@HoiDapID", SqlDbType.Int).SourceColumn = "HoiDapID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NguoiHoi", SqlDbType.NVarChar, 50).SourceColumn = "NguoiHoi";

                sqlCmd.Parameters.Add("@CauHoi", SqlDbType.NVarChar, 400).SourceColumn = "CauHoi";

                sqlCmd.Parameters.Add("@TraLoi", SqlDbType.NText).SourceColumn = "TraLoi";

                sqlCmd.Parameters.Add("@NgayHoi", SqlDbType.DateTime).SourceColumn = "NgayHoi";

                sqlCmd.Parameters.Add("@NgayTraLoi", SqlDbType.DateTime).SourceColumn = "NgayTraLoi";

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).SourceColumn = "bak";

                sqlCmd.Parameters.Add("@bak1", SqlDbType.Bit).SourceColumn = "bak1";

                sqlCmd.Parameters.Add("@ChiTietCauHoi", SqlDbType.NVarChar, 4000).SourceColumn = "ChiTietCauHoi";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateHoiDapSanPham";
                sqlCmd.Parameters.Add("@HoiDapID", SqlDbType.Int).SourceColumn = "HoiDapID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@NguoiHoi", SqlDbType.NVarChar, 50).SourceColumn = "NguoiHoi";

                sqlCmd.Parameters.Add("@CauHoi", SqlDbType.NVarChar, 400).SourceColumn = "CauHoi";

                sqlCmd.Parameters.Add("@TraLoi", SqlDbType.NText).SourceColumn = "TraLoi";

                sqlCmd.Parameters.Add("@NgayHoi", SqlDbType.DateTime).SourceColumn = "NgayHoi";

                sqlCmd.Parameters.Add("@NgayTraLoi", SqlDbType.DateTime).SourceColumn = "NgayTraLoi";

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).SourceColumn = "bak";

                sqlCmd.Parameters.Add("@bak1", SqlDbType.Bit).SourceColumn = "bak1";

                sqlCmd.Parameters.Add("@ChiTietCauHoi", SqlDbType.NVarChar, 4000).SourceColumn = "ChiTietCauHoi";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteHoiDapSanPham";
                sqlCmd.Parameters.Add("@HoiDapID", SqlDbType.Int).SourceColumn = "HoiDapID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int HoiDapID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteHoiDapSanPham";
                sqlCmd.Parameters.Add("@HoiDapID", SqlDbType.Int).Value = HoiDapID;
                objDataAccess.ExecuteQuery(sqlCmd, "HoiDapSanPham");
            }
        }

        public int InsertFields(int? SanPhamID, int? NguoiDungID, string NguoiHoi, string CauHoi, string TraLoi,
                                DateTime? NgayHoi, DateTime? NgayTraLoi, int? bak, bool? bak1, string ChiTietCauHoi)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsHoiDapSanPham";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NguoiHoi", SqlDbType.NVarChar, 50).Value = NguoiHoi;

                sqlCmd.Parameters.Add("@CauHoi", SqlDbType.NVarChar, 400).Value = CauHoi;

                sqlCmd.Parameters.Add("@TraLoi", SqlDbType.NText).Value = TraLoi;

                sqlCmd.Parameters.Add("@NgayHoi", SqlDbType.DateTime).Value = NgayHoi;

                sqlCmd.Parameters.Add("@NgayTraLoi", SqlDbType.DateTime).Value = NgayTraLoi;

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).Value = bak;

                sqlCmd.Parameters.Add("@bak1", SqlDbType.Bit).Value = bak1;

                sqlCmd.Parameters.Add("@ChiTietCauHoi", SqlDbType.NVarChar, 4000).Value = ChiTietCauHoi;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int HoiDapID, int? SanPhamID, int? NguoiDungID, string NguoiHoi, string CauHoi,
                                 string TraLoi, DateTime? NgayHoi, DateTime? NgayTraLoi, int? bak, bool? bak1,
                                 string ChiTietCauHoi)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsHoiDapSanPham";

                sqlCmd.Parameters.Add("@HoiDapID", SqlDbType.Int).Value = HoiDapID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NguoiHoi", SqlDbType.NVarChar, 50).Value = NguoiHoi;

                sqlCmd.Parameters.Add("@CauHoi", SqlDbType.NVarChar, 400).Value = CauHoi;

                sqlCmd.Parameters.Add("@TraLoi", SqlDbType.NText).Value = TraLoi;

                sqlCmd.Parameters.Add("@NgayHoi", SqlDbType.DateTime).Value = NgayHoi;

                sqlCmd.Parameters.Add("@NgayTraLoi", SqlDbType.DateTime).Value = NgayTraLoi;

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).Value = bak;

                sqlCmd.Parameters.Add("@bak1", SqlDbType.Bit).Value = bak1;

                sqlCmd.Parameters.Add("@ChiTietCauHoi", SqlDbType.NVarChar, 4000).Value = ChiTietCauHoi;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? SanPhamID, int? NguoiDungID, string NguoiHoi, string CauHoi,
                                       string TraLoi, DateTime? NgayHoi, DateTime? NgayTraLoi, int? bak, bool? bak1,
                                       string ChiTietCauHoi)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsHoiDapSanPham";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@NguoiHoi", SqlDbType.NVarChar, 50).Value = NguoiHoi;

                sqlCmd.Parameters.Add("@CauHoi", SqlDbType.NVarChar, 400).Value = CauHoi;

                sqlCmd.Parameters.Add("@TraLoi", SqlDbType.NText).Value = TraLoi;

                sqlCmd.Parameters.Add("@NgayHoi", SqlDbType.DateTime).Value = NgayHoi;

                sqlCmd.Parameters.Add("@NgayTraLoi", SqlDbType.DateTime).Value = NgayTraLoi;

                sqlCmd.Parameters.Add("@bak", SqlDbType.Int).Value = bak;

                sqlCmd.Parameters.Add("@bak1", SqlDbType.Bit).Value = bak1;

                sqlCmd.Parameters.Add("@ChiTietCauHoi", SqlDbType.NVarChar, 4000).Value = ChiTietCauHoi;


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
                sqlCmd.CommandText = "SelectHoiDapSanPhamByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HoiDapSanPham");
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
                sqlCmd.CommandText = "GetHoiDapSanPhamBySanPhamIDPaging";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "HoiDapSanPham");
                return dsResult;
            }
        }
    }
}