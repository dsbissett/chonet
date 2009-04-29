using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_NguoiDung
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_NguoiDung()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("NguoiDungID", "NguoiDungID")
                                   ,
                                   new DataColumnMapping("HoVaTen", "HoVaTen")
                                   ,
                                   new DataColumnMapping("TaiKhoan", "TaiKhoan")
                                   ,
                                   new DataColumnMapping("MatKhau", "MatKhau")
                                   ,
                                   new DataColumnMapping("NgaySinh", "NgaySinh")
                                   ,
                                   new DataColumnMapping("GioiTinh", "GioiTinh")
                                   ,
                                   new DataColumnMapping("email", "email")
                                   ,
                                   new DataColumnMapping("MaSoKichHoat", "MaSoKichHoat")
                                   ,
                                   new DataColumnMapping("KichHoat", "KichHoat")
                                   ,
                                   new DataColumnMapping("DienThoaiDiDong", "DienThoaiDiDong")
                                   ,
                                   new DataColumnMapping("DienThoaiCoDinh", "DienThoaiCoDinh")
                                   ,
                                   new DataColumnMapping("LoaiNguoiDungID", "LoaiNguoiDungID")
                                   ,
                                   new DataColumnMapping("DiaChi", "DiaChi")
                                   ,
                                   new DataColumnMapping("YM", "YM")
                                   ,
                                   new DataColumnMapping("SoChungMinhThu", "SoChungMinhThu")
                                   ,
                                   new DataColumnMapping("SapXep", "SapXep")
                                   ,
                                   new DataColumnMapping("Bak1", "Bak1")
                                   ,
                                   new DataColumnMapping("Bak3", "Bak3")
                                   ,
                                   new DataColumnMapping("Bak4", "Bak4")
                                   ,
                                   new DataColumnMapping("Bak5", "Bak5")
                               };
            dtTblMapping = new DataTableMapping("Table", "NguoiDung", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetNguoiDung";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NguoiDung");
                return dsResult;
            }
        }

        public DataSet SelectByID(int NguoiDungID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetNguoiDungById";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NguoiDung");
                return dsResult;
            }
        }

        public DataSet SelectByLoaiNguoiDungID(int LoaiNguoiDungID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetNguoiDungByLoaiNguoiDungID";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NguoiDung");
                return dsResult;
            }
        }

        public int Insert(string HoVaTen, string TaiKhoan, string MatKhau, DateTime NgaySinh, bool GioiTinh,
                          string email, string MaSoKichHoat, bool KichHoat, string DienThoaiDiDong,
                          string DienThoaiCoDinh, int LoaiNguoiDungID, string DiaChi, string YM, string SoChungMinhThu,
                          int SapXep, string Bak1, int Bak3, string Bak4, bool Bak5)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertNguoiDung";

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).Value = HoVaTen;

                sqlCmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 50).Value = TaiKhoan;

                sqlCmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = MatKhau;

                sqlCmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = NgaySinh;

                sqlCmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = GioiTinh;

                sqlCmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;

                sqlCmd.Parameters.Add("@MaSoKichHoat", SqlDbType.VarChar, 10).Value = MaSoKichHoat;

                sqlCmd.Parameters.Add("@KichHoat", SqlDbType.Bit).Value = KichHoat;

                sqlCmd.Parameters.Add("@DienThoaiDiDong", SqlDbType.NVarChar, 50).Value = DienThoaiDiDong;

                sqlCmd.Parameters.Add("@DienThoaiCoDinh", SqlDbType.NVarChar, 50).Value = DienThoaiCoDinh;

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).Value = DiaChi;

                sqlCmd.Parameters.Add("@YM", SqlDbType.NVarChar, 50).Value = YM;

                sqlCmd.Parameters.Add("@SoChungMinhThu", SqlDbType.NVarChar, 50).Value = SoChungMinhThu;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.NVarChar, 1000).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;


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
                sqlCmd.CommandText = "InsertNguoiDung";
                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).SourceColumn = "HoVaTen";

                sqlCmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 50).SourceColumn = "TaiKhoan";

                sqlCmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).SourceColumn = "MatKhau";

                sqlCmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).SourceColumn = "NgaySinh";

                sqlCmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).SourceColumn = "GioiTinh";

                sqlCmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).SourceColumn = "email";

                sqlCmd.Parameters.Add("@MaSoKichHoat", SqlDbType.VarChar, 10).SourceColumn = "MaSoKichHoat";

                sqlCmd.Parameters.Add("@KichHoat", SqlDbType.Bit).SourceColumn = "KichHoat";

                sqlCmd.Parameters.Add("@DienThoaiDiDong", SqlDbType.NVarChar, 50).SourceColumn = "DienThoaiDiDong";

                sqlCmd.Parameters.Add("@DienThoaiCoDinh", SqlDbType.NVarChar, 50).SourceColumn = "DienThoaiCoDinh";

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).SourceColumn = "LoaiNguoiDungID";

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).SourceColumn = "DiaChi";

                sqlCmd.Parameters.Add("@YM", SqlDbType.NVarChar, 50).SourceColumn = "YM";

                sqlCmd.Parameters.Add("@SoChungMinhThu", SqlDbType.NVarChar, 50).SourceColumn = "SoChungMinhThu";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.NVarChar, 1000).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertNguoiDung_Ref";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";
                sqlCmd.Parameters["@NguoiDungID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 4).SourceColumn = "HoVaTen";

                sqlCmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 100).SourceColumn = "TaiKhoan";

                sqlCmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).SourceColumn = "MatKhau";

                sqlCmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).SourceColumn = "NgaySinh";

                sqlCmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).SourceColumn = "GioiTinh";

                sqlCmd.Parameters.Add("@email", SqlDbType.NVarChar, 1).SourceColumn = "email";

                sqlCmd.Parameters.Add("@MaSoKichHoat", SqlDbType.VarChar, 50).SourceColumn = "MaSoKichHoat";

                sqlCmd.Parameters.Add("@KichHoat", SqlDbType.Bit).SourceColumn = "KichHoat";

                sqlCmd.Parameters.Add("@DienThoaiDiDong", SqlDbType.NVarChar, 1).SourceColumn = "DienThoaiDiDong";

                sqlCmd.Parameters.Add("@DienThoaiCoDinh", SqlDbType.NVarChar, 50).SourceColumn = "DienThoaiCoDinh";

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).SourceColumn = "LoaiNguoiDungID";

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 4).SourceColumn = "DiaChi";

                sqlCmd.Parameters.Add("@YM", SqlDbType.NVarChar, 1000).SourceColumn = "YM";

                sqlCmd.Parameters.Add("@SoChungMinhThu", SqlDbType.NVarChar, 50).SourceColumn = "SoChungMinhThu";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.NVarChar, 4).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int NguoiDungID, string HoVaTen, string TaiKhoan, string MatKhau, DateTime NgaySinh,
                           bool GioiTinh, string email, string MaSoKichHoat, bool KichHoat, string DienThoaiDiDong,
                           string DienThoaiCoDinh, int LoaiNguoiDungID, string DiaChi, string YM, string SoChungMinhThu,
                           int SapXep, string Bak1, int Bak3, string Bak4, bool Bak5)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNguoiDung";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).Value = HoVaTen;

                sqlCmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 50).Value = TaiKhoan;

                sqlCmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = MatKhau;

                sqlCmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = NgaySinh;

                sqlCmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = GioiTinh;

                sqlCmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;

                sqlCmd.Parameters.Add("@MaSoKichHoat", SqlDbType.VarChar, 10).Value = MaSoKichHoat;

                sqlCmd.Parameters.Add("@KichHoat", SqlDbType.Bit).Value = KichHoat;

                sqlCmd.Parameters.Add("@DienThoaiDiDong", SqlDbType.NVarChar, 50).Value = DienThoaiDiDong;

                sqlCmd.Parameters.Add("@DienThoaiCoDinh", SqlDbType.NVarChar, 50).Value = DienThoaiCoDinh;

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).Value = DiaChi;

                sqlCmd.Parameters.Add("@YM", SqlDbType.NVarChar, 50).Value = YM;

                sqlCmd.Parameters.Add("@SoChungMinhThu", SqlDbType.NVarChar, 50).Value = SoChungMinhThu;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.NVarChar, 1000).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNguoiDung";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).SourceColumn = "HoVaTen";

                sqlCmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 50).SourceColumn = "TaiKhoan";

                sqlCmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).SourceColumn = "MatKhau";

                sqlCmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).SourceColumn = "NgaySinh";

                sqlCmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).SourceColumn = "GioiTinh";

                sqlCmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).SourceColumn = "email";

                sqlCmd.Parameters.Add("@MaSoKichHoat", SqlDbType.VarChar, 10).SourceColumn = "MaSoKichHoat";

                sqlCmd.Parameters.Add("@KichHoat", SqlDbType.Bit).SourceColumn = "KichHoat";

                sqlCmd.Parameters.Add("@DienThoaiDiDong", SqlDbType.NVarChar, 50).SourceColumn = "DienThoaiDiDong";

                sqlCmd.Parameters.Add("@DienThoaiCoDinh", SqlDbType.NVarChar, 50).SourceColumn = "DienThoaiCoDinh";

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).SourceColumn = "LoaiNguoiDungID";

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).SourceColumn = "DiaChi";

                sqlCmd.Parameters.Add("@YM", SqlDbType.NVarChar, 50).SourceColumn = "YM";

                sqlCmd.Parameters.Add("@SoChungMinhThu", SqlDbType.NVarChar, 50).SourceColumn = "SoChungMinhThu";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.NVarChar, 1000).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateNguoiDung";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).SourceColumn = "HoVaTen";

                sqlCmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 50).SourceColumn = "TaiKhoan";

                sqlCmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).SourceColumn = "MatKhau";

                sqlCmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).SourceColumn = "NgaySinh";

                sqlCmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).SourceColumn = "GioiTinh";

                sqlCmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).SourceColumn = "email";

                sqlCmd.Parameters.Add("@MaSoKichHoat", SqlDbType.VarChar, 10).SourceColumn = "MaSoKichHoat";

                sqlCmd.Parameters.Add("@KichHoat", SqlDbType.Bit).SourceColumn = "KichHoat";

                sqlCmd.Parameters.Add("@DienThoaiDiDong", SqlDbType.NVarChar, 50).SourceColumn = "DienThoaiDiDong";

                sqlCmd.Parameters.Add("@DienThoaiCoDinh", SqlDbType.NVarChar, 50).SourceColumn = "DienThoaiCoDinh";

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).SourceColumn = "LoaiNguoiDungID";

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).SourceColumn = "DiaChi";

                sqlCmd.Parameters.Add("@YM", SqlDbType.NVarChar, 50).SourceColumn = "YM";

                sqlCmd.Parameters.Add("@SoChungMinhThu", SqlDbType.NVarChar, 50).SourceColumn = "SoChungMinhThu";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.NVarChar, 1000).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteNguoiDung";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int NguoiDungID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteNguoiDung";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                objDataAccess.ExecuteQuery(sqlCmd, "NguoiDung");
            }
        }

        public int InsertFields(string HoVaTen, string TaiKhoan, string MatKhau, DateTime? NgaySinh, bool? GioiTinh,
                                string email, string MaSoKichHoat, bool? KichHoat, string DienThoaiDiDong,
                                string DienThoaiCoDinh, int? LoaiNguoiDungID, string DiaChi, string YM,
                                string SoChungMinhThu, int? SapXep, string Bak1, int? Bak3, string Bak4, bool? Bak5)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsNguoiDung";

                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).Value = HoVaTen;

                sqlCmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 50).Value = TaiKhoan;

                sqlCmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = MatKhau;

                sqlCmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = NgaySinh;

                sqlCmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = GioiTinh;

                sqlCmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;

                sqlCmd.Parameters.Add("@MaSoKichHoat", SqlDbType.VarChar, 10).Value = MaSoKichHoat;

                sqlCmd.Parameters.Add("@KichHoat", SqlDbType.Bit).Value = KichHoat;

                sqlCmd.Parameters.Add("@DienThoaiDiDong", SqlDbType.NVarChar, 50).Value = DienThoaiDiDong;

                sqlCmd.Parameters.Add("@DienThoaiCoDinh", SqlDbType.NVarChar, 50).Value = DienThoaiCoDinh;

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).Value = DiaChi;

                sqlCmd.Parameters.Add("@YM", SqlDbType.NVarChar, 50).Value = YM;

                sqlCmd.Parameters.Add("@SoChungMinhThu", SqlDbType.NVarChar, 50).Value = SoChungMinhThu;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.NVarChar, 1000).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int NguoiDungID, string HoVaTen, string TaiKhoan, string MatKhau, DateTime? NgaySinh,
                                 bool? GioiTinh, string email, string MaSoKichHoat, bool? KichHoat,
                                 string DienThoaiDiDong, string DienThoaiCoDinh, int? LoaiNguoiDungID, string DiaChi,
                                 string YM, string SoChungMinhThu, int? SapXep, string Bak1, int? Bak3, string Bak4,
                                 bool? Bak5)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsNguoiDung";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).Value = HoVaTen;

                sqlCmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 50).Value = TaiKhoan;

                sqlCmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = MatKhau;

                sqlCmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = NgaySinh;

                sqlCmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = GioiTinh;

                sqlCmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;

                sqlCmd.Parameters.Add("@MaSoKichHoat", SqlDbType.VarChar, 10).Value = MaSoKichHoat;

                sqlCmd.Parameters.Add("@KichHoat", SqlDbType.Bit).Value = KichHoat;

                sqlCmd.Parameters.Add("@DienThoaiDiDong", SqlDbType.NVarChar, 50).Value = DienThoaiDiDong;

                sqlCmd.Parameters.Add("@DienThoaiCoDinh", SqlDbType.NVarChar, 50).Value = DienThoaiCoDinh;

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).Value = DiaChi;

                sqlCmd.Parameters.Add("@YM", SqlDbType.NVarChar, 50).Value = YM;

                sqlCmd.Parameters.Add("@SoChungMinhThu", SqlDbType.NVarChar, 50).Value = SoChungMinhThu;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.NVarChar, 1000).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string HoVaTen, string TaiKhoan, string MatKhau, DateTime? NgaySinh,
                                       bool? GioiTinh, string email, string MaSoKichHoat, bool? KichHoat,
                                       string DienThoaiDiDong, string DienThoaiCoDinh, int? LoaiNguoiDungID,
                                       string DiaChi, string YM, string SoChungMinhThu, int? SapXep, string Bak1,
                                       int? Bak3, string Bak4, bool? Bak5)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsNguoiDung";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@HoVaTen", SqlDbType.NVarChar, 100).Value = HoVaTen;

                sqlCmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar, 50).Value = TaiKhoan;

                sqlCmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar, 50).Value = MatKhau;

                sqlCmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = NgaySinh;

                sqlCmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = GioiTinh;

                sqlCmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;

                sqlCmd.Parameters.Add("@MaSoKichHoat", SqlDbType.VarChar, 10).Value = MaSoKichHoat;

                sqlCmd.Parameters.Add("@KichHoat", SqlDbType.Bit).Value = KichHoat;

                sqlCmd.Parameters.Add("@DienThoaiDiDong", SqlDbType.NVarChar, 50).Value = DienThoaiDiDong;

                sqlCmd.Parameters.Add("@DienThoaiCoDinh", SqlDbType.NVarChar, 50).Value = DienThoaiCoDinh;

                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;

                sqlCmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 1000).Value = DiaChi;

                sqlCmd.Parameters.Add("@YM", SqlDbType.NVarChar, 50).Value = YM;

                sqlCmd.Parameters.Add("@SoChungMinhThu", SqlDbType.NVarChar, 50).Value = SoChungMinhThu;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.NVarChar, 1000).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;


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
                sqlCmd.CommandText = "SelectNguoiDungByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NguoiDung");
                return dsResult;
            }
        }

        public DataSet SelectByLoaiNguoiDungIDPaging(int LoaiNguoiDungID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetNguoiDungByLoaiNguoiDungIDPaging";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "NguoiDung");
                return dsResult;
            }
        }
    }
}