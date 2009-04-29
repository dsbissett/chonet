using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_DauGia
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_DauGia()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("DauGiaID", "DauGiaID")
                                   ,
                                   new DataColumnMapping("SanPhamID", "SanPhamID")
                                   ,
                                   new DataColumnMapping("GiaBanNgay", "GiaBanNgay")
                                   ,
                                   new DataColumnMapping("GiaKhoiDiem", "GiaKhoiDiem")
                                   ,
                                   new DataColumnMapping("BuocGia", "BuocGia")
                                   ,
                                   new DataColumnMapping("BatDau", "BatDau")
                                   ,
                                   new DataColumnMapping("KetThuc", "KetThuc")
                                   ,
                                   new DataColumnMapping("TraGiaID", "TraGiaID")
                                   ,
                                   new DataColumnMapping("Bak1", "Bak1")
                                   ,
                                   new DataColumnMapping("Bak2", "Bak2")
                                   ,
                                   new DataColumnMapping("Bak3", "Bak3")
                                   ,
                                   new DataColumnMapping("Bak4", "Bak4")
                               };
            dtTblMapping = new DataTableMapping("Table", "DauGia", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetDauGia";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DauGia");
                return dsResult;
            }
        }

        public DataSet SelectByID(int DauGiaID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetDauGiaById";
                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DauGia");
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
                sqlCmd.CommandText = "GetDauGiaBySanPhamID";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DauGia");
                return dsResult;
            }
        }

        public int Insert(int SanPhamID, decimal GiaBanNgay, decimal GiaKhoiDiem, decimal BuocGia, DateTime BatDau,
                          DateTime KetThuc, int TraGiaID, string Bak1, string Bak2, int Bak3, bool Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertDauGia";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@GiaBanNgay", SqlDbType.Money).Value = GiaBanNgay;

                sqlCmd.Parameters.Add("@GiaKhoiDiem", SqlDbType.Money).Value = GiaKhoiDiem;

                sqlCmd.Parameters.Add("@BuocGia", SqlDbType.Money).Value = BuocGia;

                sqlCmd.Parameters.Add("@BatDau", SqlDbType.DateTime).Value = BatDau;

                sqlCmd.Parameters.Add("@KetThuc", SqlDbType.DateTime).Value = KetThuc;

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;

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
                sqlCmd.CommandText = "InsertDauGia";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@GiaBanNgay", SqlDbType.Money).SourceColumn = "GiaBanNgay";

                sqlCmd.Parameters.Add("@GiaKhoiDiem", SqlDbType.Money).SourceColumn = "GiaKhoiDiem";

                sqlCmd.Parameters.Add("@BuocGia", SqlDbType.Money).SourceColumn = "BuocGia";

                sqlCmd.Parameters.Add("@BatDau", SqlDbType.DateTime).SourceColumn = "BatDau";

                sqlCmd.Parameters.Add("@KetThuc", SqlDbType.DateTime).SourceColumn = "KetThuc";

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";

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
                sqlCmd.CommandText = "InsertDauGia_Ref";
                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).SourceColumn = "DauGiaID";
                sqlCmd.Parameters["@DauGiaID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@GiaBanNgay", SqlDbType.Money).SourceColumn = "GiaBanNgay";

                sqlCmd.Parameters.Add("@GiaKhoiDiem", SqlDbType.Money).SourceColumn = "GiaKhoiDiem";

                sqlCmd.Parameters.Add("@BuocGia", SqlDbType.Money).SourceColumn = "BuocGia";

                sqlCmd.Parameters.Add("@BatDau", SqlDbType.DateTime).SourceColumn = "BatDau";

                sqlCmd.Parameters.Add("@KetThuc", SqlDbType.DateTime).SourceColumn = "KetThuc";

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).SourceColumn = "Bak4";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int DauGiaID, int SanPhamID, decimal GiaBanNgay, decimal GiaKhoiDiem, decimal BuocGia,
                           DateTime BatDau, DateTime KetThuc, int TraGiaID, string Bak1, string Bak2, int Bak3,
                           bool Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateDauGia";

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@GiaBanNgay", SqlDbType.Money).Value = GiaBanNgay;

                sqlCmd.Parameters.Add("@GiaKhoiDiem", SqlDbType.Money).Value = GiaKhoiDiem;

                sqlCmd.Parameters.Add("@BuocGia", SqlDbType.Money).Value = BuocGia;

                sqlCmd.Parameters.Add("@BatDau", SqlDbType.DateTime).Value = BatDau;

                sqlCmd.Parameters.Add("@KetThuc", SqlDbType.DateTime).Value = KetThuc;

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;

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
                sqlCmd.CommandText = "UpdateDauGia";
                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).SourceColumn = "DauGiaID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@GiaBanNgay", SqlDbType.Money).SourceColumn = "GiaBanNgay";

                sqlCmd.Parameters.Add("@GiaKhoiDiem", SqlDbType.Money).SourceColumn = "GiaKhoiDiem";

                sqlCmd.Parameters.Add("@BuocGia", SqlDbType.Money).SourceColumn = "BuocGia";

                sqlCmd.Parameters.Add("@BatDau", SqlDbType.DateTime).SourceColumn = "BatDau";

                sqlCmd.Parameters.Add("@KetThuc", SqlDbType.DateTime).SourceColumn = "KetThuc";

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";

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
                sqlCmd.CommandText = "UpdateDauGia";
                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).SourceColumn = "DauGiaID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@GiaBanNgay", SqlDbType.Money).SourceColumn = "GiaBanNgay";

                sqlCmd.Parameters.Add("@GiaKhoiDiem", SqlDbType.Money).SourceColumn = "GiaKhoiDiem";

                sqlCmd.Parameters.Add("@BuocGia", SqlDbType.Money).SourceColumn = "BuocGia";

                sqlCmd.Parameters.Add("@BatDau", SqlDbType.DateTime).SourceColumn = "BatDau";

                sqlCmd.Parameters.Add("@KetThuc", SqlDbType.DateTime).SourceColumn = "KetThuc";

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";

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
                sqlCmd.CommandText = "DeleteDauGia";
                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).SourceColumn = "DauGiaID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int DauGiaID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteDauGia";
                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;
                objDataAccess.ExecuteQuery(sqlCmd, "DauGia");
            }
        }

        public int InsertFields(int? SanPhamID, decimal? GiaBanNgay, decimal? GiaKhoiDiem, decimal? BuocGia,
                                DateTime? BatDau, DateTime? KetThuc, int? TraGiaID, string Bak1, string Bak2, int? Bak3,
                                bool? Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsDauGia";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@GiaBanNgay", SqlDbType.Money).Value = GiaBanNgay;

                sqlCmd.Parameters.Add("@GiaKhoiDiem", SqlDbType.Money).Value = GiaKhoiDiem;

                sqlCmd.Parameters.Add("@BuocGia", SqlDbType.Money).Value = BuocGia;

                sqlCmd.Parameters.Add("@BatDau", SqlDbType.DateTime).Value = BatDau;

                sqlCmd.Parameters.Add("@KetThuc", SqlDbType.DateTime).Value = KetThuc;

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).Value = Bak4;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int DauGiaID, int? SanPhamID, decimal? GiaBanNgay, decimal? GiaKhoiDiem,
                                 decimal? BuocGia, DateTime? BatDau, DateTime? KetThuc, int? TraGiaID, string Bak1,
                                 string Bak2, int? Bak3, bool? Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsDauGia";

                sqlCmd.Parameters.Add("@DauGiaID", SqlDbType.Int).Value = DauGiaID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@GiaBanNgay", SqlDbType.Money).Value = GiaBanNgay;

                sqlCmd.Parameters.Add("@GiaKhoiDiem", SqlDbType.Money).Value = GiaKhoiDiem;

                sqlCmd.Parameters.Add("@BuocGia", SqlDbType.Money).Value = BuocGia;

                sqlCmd.Parameters.Add("@BatDau", SqlDbType.DateTime).Value = BatDau;

                sqlCmd.Parameters.Add("@KetThuc", SqlDbType.DateTime).Value = KetThuc;

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 50).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Bit).Value = Bak4;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? SanPhamID, decimal? GiaBanNgay, decimal? GiaKhoiDiem,
                                       decimal? BuocGia, DateTime? BatDau, DateTime? KetThuc, int? TraGiaID, string Bak1,
                                       string Bak2, int? Bak3, bool? Bak4)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsDauGia";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@GiaBanNgay", SqlDbType.Money).Value = GiaBanNgay;

                sqlCmd.Parameters.Add("@GiaKhoiDiem", SqlDbType.Money).Value = GiaKhoiDiem;

                sqlCmd.Parameters.Add("@BuocGia", SqlDbType.Money).Value = BuocGia;

                sqlCmd.Parameters.Add("@BatDau", SqlDbType.DateTime).Value = BatDau;

                sqlCmd.Parameters.Add("@KetThuc", SqlDbType.DateTime).Value = KetThuc;

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;

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
                sqlCmd.CommandText = "SelectDauGiaByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "DauGia");
                return dsResult;
            }
        }
    }
}