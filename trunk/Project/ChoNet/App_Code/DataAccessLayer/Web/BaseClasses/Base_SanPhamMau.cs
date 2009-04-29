using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_SanPhamMau
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_SanPhamMau()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("SanPhamID", "SanPhamID")
                                   ,
                                   new DataColumnMapping("TenSanPham", "TenSanPham")
                                   ,
                                   new DataColumnMapping("MaSoSanPham", "MaSoSanPham")
                                   ,
                                   new DataColumnMapping("GiaSanPham", "GiaSanPham")
                                   ,
                                   new DataColumnMapping("DonViTienTe", "DonViTienTe")
                                   ,
                                   new DataColumnMapping("MoTaSanPham", "MoTaSanPham")
                                   ,
                                   new DataColumnMapping("ThongTinSanPham", "ThongTinSanPham")
                                   ,
                                   new DataColumnMapping("NhomSanPhamID", "NhomSanPhamID")
                                   ,
                                   new DataColumnMapping("HangSanXuatID", "HangSanXuatID")
                                   ,
                                   new DataColumnMapping("NguoiDungID", "NguoiDungID")
                                   ,
                                   new DataColumnMapping("AnhSanPham", "AnhSanPham")
                                   ,
                                   new DataColumnMapping("KhuyenMai", "KhuyenMai")
                                   ,
                                   new DataColumnMapping("MoTaKhuyenMai", "MoTaKhuyenMai")
                                   ,
                                   new DataColumnMapping("GiaKhuyenMai", "GiaKhuyenMai")
                                   ,
                                   new DataColumnMapping("BatDauKhuyenMai", "BatDauKhuyenMai")
                                   ,
                                   new DataColumnMapping("KetThucKhuyenMai", "KetThucKhuyenMai")
                                   ,
                                   new DataColumnMapping("DongSanPhamID", "DongSanPhamID")
                                   ,
                                   new DataColumnMapping("KhuVucID", "KhuVucID")
                                   ,
                                   new DataColumnMapping("Uachuong", "Uachuong")
                                   ,
                                   new DataColumnMapping("GiaMoi", "GiaMoi")
                                   ,
                                   new DataColumnMapping("GiamGia", "GiamGia")
                                   ,
                                   new DataColumnMapping("MoiCapNhat", "MoiCapNhat")
                                   ,
                                   new DataColumnMapping("NgayThemSanPham", "NgayThemSanPham")
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
                                   new DataColumnMapping("bak6", "bak6")
                                   ,
                                   new DataColumnMapping("bak7", "bak7")
                               };
            dtTblMapping = new DataTableMapping("Table", "SanPhamMau", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetSanPhamMau";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
                return dsResult;
            }
        }

        public DataSet SelectByID(int SanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetSanPhamMauById";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
                return dsResult;
            }
        }

        public DataSet SelectByHangSanXuatID(int HangSanXuatID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetSanPhamMauByHangSanXuatID";
                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
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
                sqlCmd.CommandText = "GetSanPhamMauByNguoiDungID";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
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
                sqlCmd.CommandText = "GetSanPhamMauByNhomSanPhamID";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
                return dsResult;
            }
        }

        public DataSet SelectByKhuVucID(int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetSanPhamMauByKhuVucID";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
                return dsResult;
            }
        }

        public int Insert(string TenSanPham, string MaSoSanPham, decimal GiaSanPham, string DonViTienTe,
                          string MoTaSanPham, string ThongTinSanPham, int NhomSanPhamID, int HangSanXuatID,
                          int NguoiDungID, string AnhSanPham, bool KhuyenMai, string MoTaKhuyenMai, decimal GiaKhuyenMai,
                          DateTime BatDauKhuyenMai, DateTime KetThucKhuyenMai, int DongSanPhamID, int KhuVucID,
                          bool Uachuong, decimal GiaMoi, bool GiamGia, bool MoiCapNhat, DateTime NgayThemSanPham,
                          int SapXep, string Bak1, string Bak2, int Bak3, int Bak4, bool Bak5, string bak6, string bak7)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertSanPhamMau";

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 200).Value = TenSanPham;

                sqlCmd.Parameters.Add("@MaSoSanPham", SqlDbType.Char, 12).Value = MaSoSanPham;

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).Value = GiaSanPham;

                sqlCmd.Parameters.Add("@DonViTienTe", SqlDbType.NVarChar, 15).Value = DonViTienTe;

                sqlCmd.Parameters.Add("@MoTaSanPham", SqlDbType.NText).Value = MoTaSanPham;

                sqlCmd.Parameters.Add("@ThongTinSanPham", SqlDbType.NText).Value = ThongTinSanPham;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@AnhSanPham", SqlDbType.NVarChar, 200).Value = AnhSanPham;

                sqlCmd.Parameters.Add("@KhuyenMai", SqlDbType.Bit).Value = KhuyenMai;

                sqlCmd.Parameters.Add("@MoTaKhuyenMai", SqlDbType.NVarChar, 200).Value = MoTaKhuyenMai;

                sqlCmd.Parameters.Add("@GiaKhuyenMai", SqlDbType.Money).Value = GiaKhuyenMai;

                sqlCmd.Parameters.Add("@BatDauKhuyenMai", SqlDbType.DateTime).Value = BatDauKhuyenMai;

                sqlCmd.Parameters.Add("@KetThucKhuyenMai", SqlDbType.DateTime).Value = KetThucKhuyenMai;

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).Value = DongSanPhamID;

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;

                sqlCmd.Parameters.Add("@Uachuong", SqlDbType.Bit).Value = Uachuong;

                sqlCmd.Parameters.Add("@GiaMoi", SqlDbType.Money).Value = GiaMoi;

                sqlCmd.Parameters.Add("@GiamGia", SqlDbType.Bit).Value = GiamGia;

                sqlCmd.Parameters.Add("@MoiCapNhat", SqlDbType.Bit).Value = MoiCapNhat;

                sqlCmd.Parameters.Add("@NgayThemSanPham", SqlDbType.DateTime).Value = NgayThemSanPham;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4000).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 100).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;

                sqlCmd.Parameters.Add("@bak6", SqlDbType.NVarChar, 50).Value = bak6;

                sqlCmd.Parameters.Add("@bak7", SqlDbType.NVarChar, 1000).Value = bak7;


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
                sqlCmd.CommandText = "InsertSanPhamMau";
                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 200).SourceColumn = "TenSanPham";

                sqlCmd.Parameters.Add("@MaSoSanPham", SqlDbType.Char, 12).SourceColumn = "MaSoSanPham";

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).SourceColumn = "GiaSanPham";

                sqlCmd.Parameters.Add("@DonViTienTe", SqlDbType.NVarChar, 15).SourceColumn = "DonViTienTe";

                sqlCmd.Parameters.Add("@MoTaSanPham", SqlDbType.NText).SourceColumn = "MoTaSanPham";

                sqlCmd.Parameters.Add("@ThongTinSanPham", SqlDbType.NText).SourceColumn = "ThongTinSanPham";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).SourceColumn = "HangSanXuatID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@AnhSanPham", SqlDbType.NVarChar, 200).SourceColumn = "AnhSanPham";

                sqlCmd.Parameters.Add("@KhuyenMai", SqlDbType.Bit).SourceColumn = "KhuyenMai";

                sqlCmd.Parameters.Add("@MoTaKhuyenMai", SqlDbType.NVarChar, 200).SourceColumn = "MoTaKhuyenMai";

                sqlCmd.Parameters.Add("@GiaKhuyenMai", SqlDbType.Money).SourceColumn = "GiaKhuyenMai";

                sqlCmd.Parameters.Add("@BatDauKhuyenMai", SqlDbType.DateTime).SourceColumn = "BatDauKhuyenMai";

                sqlCmd.Parameters.Add("@KetThucKhuyenMai", SqlDbType.DateTime).SourceColumn = "KetThucKhuyenMai";

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).SourceColumn = "DongSanPhamID";

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";

                sqlCmd.Parameters.Add("@Uachuong", SqlDbType.Bit).SourceColumn = "Uachuong";

                sqlCmd.Parameters.Add("@GiaMoi", SqlDbType.Money).SourceColumn = "GiaMoi";

                sqlCmd.Parameters.Add("@GiamGia", SqlDbType.Bit).SourceColumn = "GiamGia";

                sqlCmd.Parameters.Add("@MoiCapNhat", SqlDbType.Bit).SourceColumn = "MoiCapNhat";

                sqlCmd.Parameters.Add("@NgayThemSanPham", SqlDbType.DateTime).SourceColumn = "NgayThemSanPham";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4000).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 100).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                sqlCmd.Parameters.Add("@bak6", SqlDbType.NVarChar, 50).SourceColumn = "bak6";

                sqlCmd.Parameters.Add("@bak7", SqlDbType.NVarChar, 1000).SourceColumn = "bak7";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertSanPhamMau_Ref";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";
                sqlCmd.Parameters["@SanPhamID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 4).SourceColumn = "TenSanPham";

                sqlCmd.Parameters.Add("@MaSoSanPham", SqlDbType.Char, 200).SourceColumn = "MaSoSanPham";

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).SourceColumn = "GiaSanPham";

                sqlCmd.Parameters.Add("@DonViTienTe", SqlDbType.NVarChar, 8).SourceColumn = "DonViTienTe";

                sqlCmd.Parameters.Add("@MoTaSanPham", SqlDbType.NText).SourceColumn = "MoTaSanPham";

                sqlCmd.Parameters.Add("@ThongTinSanPham", SqlDbType.NText).SourceColumn = "ThongTinSanPham";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).SourceColumn = "HangSanXuatID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@AnhSanPham", SqlDbType.NVarChar, 4).SourceColumn = "AnhSanPham";

                sqlCmd.Parameters.Add("@KhuyenMai", SqlDbType.Bit).SourceColumn = "KhuyenMai";

                sqlCmd.Parameters.Add("@MoTaKhuyenMai", SqlDbType.NVarChar, 1).SourceColumn = "MoTaKhuyenMai";

                sqlCmd.Parameters.Add("@GiaKhuyenMai", SqlDbType.Money).SourceColumn = "GiaKhuyenMai";

                sqlCmd.Parameters.Add("@BatDauKhuyenMai", SqlDbType.DateTime).SourceColumn = "BatDauKhuyenMai";

                sqlCmd.Parameters.Add("@KetThucKhuyenMai", SqlDbType.DateTime).SourceColumn = "KetThucKhuyenMai";

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).SourceColumn = "DongSanPhamID";

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";

                sqlCmd.Parameters.Add("@Uachuong", SqlDbType.Bit).SourceColumn = "Uachuong";

                sqlCmd.Parameters.Add("@GiaMoi", SqlDbType.Money).SourceColumn = "GiaMoi";

                sqlCmd.Parameters.Add("@GiamGia", SqlDbType.Bit).SourceColumn = "GiamGia";

                sqlCmd.Parameters.Add("@MoiCapNhat", SqlDbType.Bit).SourceColumn = "MoiCapNhat";

                sqlCmd.Parameters.Add("@NgayThemSanPham", SqlDbType.DateTime).SourceColumn = "NgayThemSanPham";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 4000).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                sqlCmd.Parameters.Add("@bak6", SqlDbType.NVarChar, 1).SourceColumn = "bak6";

                sqlCmd.Parameters.Add("@bak7", SqlDbType.NVarChar, 50).SourceColumn = "bak7";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int SanPhamID, string TenSanPham, string MaSoSanPham, decimal GiaSanPham, string DonViTienTe,
                           string MoTaSanPham, string ThongTinSanPham, int NhomSanPhamID, int HangSanXuatID,
                           int NguoiDungID, string AnhSanPham, bool KhuyenMai, string MoTaKhuyenMai,
                           decimal GiaKhuyenMai, DateTime BatDauKhuyenMai, DateTime KetThucKhuyenMai, int DongSanPhamID,
                           int KhuVucID, bool Uachuong, decimal GiaMoi, bool GiamGia, bool MoiCapNhat,
                           DateTime NgayThemSanPham, int SapXep, string Bak1, string Bak2, int Bak3, int Bak4, bool Bak5,
                           string bak6, string bak7)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateSanPhamMau";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 200).Value = TenSanPham;

                sqlCmd.Parameters.Add("@MaSoSanPham", SqlDbType.Char, 12).Value = MaSoSanPham;

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).Value = GiaSanPham;

                sqlCmd.Parameters.Add("@DonViTienTe", SqlDbType.NVarChar, 15).Value = DonViTienTe;

                sqlCmd.Parameters.Add("@MoTaSanPham", SqlDbType.NText).Value = MoTaSanPham;

                sqlCmd.Parameters.Add("@ThongTinSanPham", SqlDbType.NText).Value = ThongTinSanPham;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@AnhSanPham", SqlDbType.NVarChar, 200).Value = AnhSanPham;

                sqlCmd.Parameters.Add("@KhuyenMai", SqlDbType.Bit).Value = KhuyenMai;

                sqlCmd.Parameters.Add("@MoTaKhuyenMai", SqlDbType.NVarChar, 200).Value = MoTaKhuyenMai;

                sqlCmd.Parameters.Add("@GiaKhuyenMai", SqlDbType.Money).Value = GiaKhuyenMai;

                sqlCmd.Parameters.Add("@BatDauKhuyenMai", SqlDbType.DateTime).Value = BatDauKhuyenMai;

                sqlCmd.Parameters.Add("@KetThucKhuyenMai", SqlDbType.DateTime).Value = KetThucKhuyenMai;

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).Value = DongSanPhamID;

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;

                sqlCmd.Parameters.Add("@Uachuong", SqlDbType.Bit).Value = Uachuong;

                sqlCmd.Parameters.Add("@GiaMoi", SqlDbType.Money).Value = GiaMoi;

                sqlCmd.Parameters.Add("@GiamGia", SqlDbType.Bit).Value = GiamGia;

                sqlCmd.Parameters.Add("@MoiCapNhat", SqlDbType.Bit).Value = MoiCapNhat;

                sqlCmd.Parameters.Add("@NgayThemSanPham", SqlDbType.DateTime).Value = NgayThemSanPham;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4000).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 100).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;

                sqlCmd.Parameters.Add("@bak6", SqlDbType.NVarChar, 50).Value = bak6;

                sqlCmd.Parameters.Add("@bak7", SqlDbType.NVarChar, 1000).Value = bak7;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateSanPhamMau";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 200).SourceColumn = "TenSanPham";

                sqlCmd.Parameters.Add("@MaSoSanPham", SqlDbType.Char, 12).SourceColumn = "MaSoSanPham";

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).SourceColumn = "GiaSanPham";

                sqlCmd.Parameters.Add("@DonViTienTe", SqlDbType.NVarChar, 15).SourceColumn = "DonViTienTe";

                sqlCmd.Parameters.Add("@MoTaSanPham", SqlDbType.NText).SourceColumn = "MoTaSanPham";

                sqlCmd.Parameters.Add("@ThongTinSanPham", SqlDbType.NText).SourceColumn = "ThongTinSanPham";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).SourceColumn = "HangSanXuatID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@AnhSanPham", SqlDbType.NVarChar, 200).SourceColumn = "AnhSanPham";

                sqlCmd.Parameters.Add("@KhuyenMai", SqlDbType.Bit).SourceColumn = "KhuyenMai";

                sqlCmd.Parameters.Add("@MoTaKhuyenMai", SqlDbType.NVarChar, 200).SourceColumn = "MoTaKhuyenMai";

                sqlCmd.Parameters.Add("@GiaKhuyenMai", SqlDbType.Money).SourceColumn = "GiaKhuyenMai";

                sqlCmd.Parameters.Add("@BatDauKhuyenMai", SqlDbType.DateTime).SourceColumn = "BatDauKhuyenMai";

                sqlCmd.Parameters.Add("@KetThucKhuyenMai", SqlDbType.DateTime).SourceColumn = "KetThucKhuyenMai";

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).SourceColumn = "DongSanPhamID";

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";

                sqlCmd.Parameters.Add("@Uachuong", SqlDbType.Bit).SourceColumn = "Uachuong";

                sqlCmd.Parameters.Add("@GiaMoi", SqlDbType.Money).SourceColumn = "GiaMoi";

                sqlCmd.Parameters.Add("@GiamGia", SqlDbType.Bit).SourceColumn = "GiamGia";

                sqlCmd.Parameters.Add("@MoiCapNhat", SqlDbType.Bit).SourceColumn = "MoiCapNhat";

                sqlCmd.Parameters.Add("@NgayThemSanPham", SqlDbType.DateTime).SourceColumn = "NgayThemSanPham";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4000).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 100).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                sqlCmd.Parameters.Add("@bak6", SqlDbType.NVarChar, 50).SourceColumn = "bak6";

                sqlCmd.Parameters.Add("@bak7", SqlDbType.NVarChar, 1000).SourceColumn = "bak7";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateSanPhamMau";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 200).SourceColumn = "TenSanPham";

                sqlCmd.Parameters.Add("@MaSoSanPham", SqlDbType.Char, 12).SourceColumn = "MaSoSanPham";

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).SourceColumn = "GiaSanPham";

                sqlCmd.Parameters.Add("@DonViTienTe", SqlDbType.NVarChar, 15).SourceColumn = "DonViTienTe";

                sqlCmd.Parameters.Add("@MoTaSanPham", SqlDbType.NText).SourceColumn = "MoTaSanPham";

                sqlCmd.Parameters.Add("@ThongTinSanPham", SqlDbType.NText).SourceColumn = "ThongTinSanPham";

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).SourceColumn = "NhomSanPhamID";

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).SourceColumn = "HangSanXuatID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@AnhSanPham", SqlDbType.NVarChar, 200).SourceColumn = "AnhSanPham";

                sqlCmd.Parameters.Add("@KhuyenMai", SqlDbType.Bit).SourceColumn = "KhuyenMai";

                sqlCmd.Parameters.Add("@MoTaKhuyenMai", SqlDbType.NVarChar, 200).SourceColumn = "MoTaKhuyenMai";

                sqlCmd.Parameters.Add("@GiaKhuyenMai", SqlDbType.Money).SourceColumn = "GiaKhuyenMai";

                sqlCmd.Parameters.Add("@BatDauKhuyenMai", SqlDbType.DateTime).SourceColumn = "BatDauKhuyenMai";

                sqlCmd.Parameters.Add("@KetThucKhuyenMai", SqlDbType.DateTime).SourceColumn = "KetThucKhuyenMai";

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).SourceColumn = "DongSanPhamID";

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).SourceColumn = "KhuVucID";

                sqlCmd.Parameters.Add("@Uachuong", SqlDbType.Bit).SourceColumn = "Uachuong";

                sqlCmd.Parameters.Add("@GiaMoi", SqlDbType.Money).SourceColumn = "GiaMoi";

                sqlCmd.Parameters.Add("@GiamGia", SqlDbType.Bit).SourceColumn = "GiamGia";

                sqlCmd.Parameters.Add("@MoiCapNhat", SqlDbType.Bit).SourceColumn = "MoiCapNhat";

                sqlCmd.Parameters.Add("@NgayThemSanPham", SqlDbType.DateTime).SourceColumn = "NgayThemSanPham";

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).SourceColumn = "SapXep";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4000).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 100).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).SourceColumn = "Bak4";

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).SourceColumn = "Bak5";

                sqlCmd.Parameters.Add("@bak6", SqlDbType.NVarChar, 50).SourceColumn = "bak6";

                sqlCmd.Parameters.Add("@bak7", SqlDbType.NVarChar, 1000).SourceColumn = "bak7";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteSanPhamMau";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int SanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteSanPhamMau";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
            }
        }

        public int InsertFields(string TenSanPham, string MaSoSanPham, decimal? GiaSanPham, string DonViTienTe,
                                string MoTaSanPham, string ThongTinSanPham, int? NhomSanPhamID, int? HangSanXuatID,
                                int? NguoiDungID, string AnhSanPham, bool? KhuyenMai, string MoTaKhuyenMai,
                                decimal? GiaKhuyenMai, DateTime? BatDauKhuyenMai, DateTime? KetThucKhuyenMai,
                                int? DongSanPhamID, int? KhuVucID, bool? Uachuong, decimal? GiaMoi, bool? GiamGia,
                                bool? MoiCapNhat, DateTime? NgayThemSanPham, int? SapXep, string Bak1, string Bak2,
                                int? Bak3, int? Bak4, bool? Bak5, string bak6, string bak7)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsSanPhamMau";

                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 200).Value = TenSanPham;

                sqlCmd.Parameters.Add("@MaSoSanPham", SqlDbType.Char, 12).Value = MaSoSanPham;

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).Value = GiaSanPham;

                sqlCmd.Parameters.Add("@DonViTienTe", SqlDbType.NVarChar, 15).Value = DonViTienTe;

                sqlCmd.Parameters.Add("@MoTaSanPham", SqlDbType.NText).Value = MoTaSanPham;

                sqlCmd.Parameters.Add("@ThongTinSanPham", SqlDbType.NText).Value = ThongTinSanPham;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@AnhSanPham", SqlDbType.NVarChar, 200).Value = AnhSanPham;

                sqlCmd.Parameters.Add("@KhuyenMai", SqlDbType.Bit).Value = KhuyenMai;

                sqlCmd.Parameters.Add("@MoTaKhuyenMai", SqlDbType.NVarChar, 200).Value = MoTaKhuyenMai;

                sqlCmd.Parameters.Add("@GiaKhuyenMai", SqlDbType.Money).Value = GiaKhuyenMai;

                sqlCmd.Parameters.Add("@BatDauKhuyenMai", SqlDbType.DateTime).Value = BatDauKhuyenMai;

                sqlCmd.Parameters.Add("@KetThucKhuyenMai", SqlDbType.DateTime).Value = KetThucKhuyenMai;

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).Value = DongSanPhamID;

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;

                sqlCmd.Parameters.Add("@Uachuong", SqlDbType.Bit).Value = Uachuong;

                sqlCmd.Parameters.Add("@GiaMoi", SqlDbType.Money).Value = GiaMoi;

                sqlCmd.Parameters.Add("@GiamGia", SqlDbType.Bit).Value = GiamGia;

                sqlCmd.Parameters.Add("@MoiCapNhat", SqlDbType.Bit).Value = MoiCapNhat;

                sqlCmd.Parameters.Add("@NgayThemSanPham", SqlDbType.DateTime).Value = NgayThemSanPham;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4000).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 100).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;

                sqlCmd.Parameters.Add("@bak6", SqlDbType.NVarChar, 50).Value = bak6;

                sqlCmd.Parameters.Add("@bak7", SqlDbType.NVarChar, 1000).Value = bak7;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int SanPhamID, string TenSanPham, string MaSoSanPham, decimal? GiaSanPham,
                                 string DonViTienTe, string MoTaSanPham, string ThongTinSanPham, int? NhomSanPhamID,
                                 int? HangSanXuatID, int? NguoiDungID, string AnhSanPham, bool? KhuyenMai,
                                 string MoTaKhuyenMai, decimal? GiaKhuyenMai, DateTime? BatDauKhuyenMai,
                                 DateTime? KetThucKhuyenMai, int? DongSanPhamID, int? KhuVucID, bool? Uachuong,
                                 decimal? GiaMoi, bool? GiamGia, bool? MoiCapNhat, DateTime? NgayThemSanPham,
                                 int? SapXep, string Bak1, string Bak2, int? Bak3, int? Bak4, bool? Bak5, string bak6,
                                 string bak7)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsSanPhamMau";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 200).Value = TenSanPham;

                sqlCmd.Parameters.Add("@MaSoSanPham", SqlDbType.Char, 12).Value = MaSoSanPham;

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).Value = GiaSanPham;

                sqlCmd.Parameters.Add("@DonViTienTe", SqlDbType.NVarChar, 15).Value = DonViTienTe;

                sqlCmd.Parameters.Add("@MoTaSanPham", SqlDbType.NText).Value = MoTaSanPham;

                sqlCmd.Parameters.Add("@ThongTinSanPham", SqlDbType.NText).Value = ThongTinSanPham;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@AnhSanPham", SqlDbType.NVarChar, 200).Value = AnhSanPham;

                sqlCmd.Parameters.Add("@KhuyenMai", SqlDbType.Bit).Value = KhuyenMai;

                sqlCmd.Parameters.Add("@MoTaKhuyenMai", SqlDbType.NVarChar, 200).Value = MoTaKhuyenMai;

                sqlCmd.Parameters.Add("@GiaKhuyenMai", SqlDbType.Money).Value = GiaKhuyenMai;

                sqlCmd.Parameters.Add("@BatDauKhuyenMai", SqlDbType.DateTime).Value = BatDauKhuyenMai;

                sqlCmd.Parameters.Add("@KetThucKhuyenMai", SqlDbType.DateTime).Value = KetThucKhuyenMai;

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).Value = DongSanPhamID;

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;

                sqlCmd.Parameters.Add("@Uachuong", SqlDbType.Bit).Value = Uachuong;

                sqlCmd.Parameters.Add("@GiaMoi", SqlDbType.Money).Value = GiaMoi;

                sqlCmd.Parameters.Add("@GiamGia", SqlDbType.Bit).Value = GiamGia;

                sqlCmd.Parameters.Add("@MoiCapNhat", SqlDbType.Bit).Value = MoiCapNhat;

                sqlCmd.Parameters.Add("@NgayThemSanPham", SqlDbType.DateTime).Value = NgayThemSanPham;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4000).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 100).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;

                sqlCmd.Parameters.Add("@bak6", SqlDbType.NVarChar, 50).Value = bak6;

                sqlCmd.Parameters.Add("@bak7", SqlDbType.NVarChar, 1000).Value = bak7;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, string TenSanPham, string MaSoSanPham, decimal? GiaSanPham,
                                       string DonViTienTe, string MoTaSanPham, string ThongTinSanPham,
                                       int? NhomSanPhamID, int? HangSanXuatID, int? NguoiDungID, string AnhSanPham,
                                       bool? KhuyenMai, string MoTaKhuyenMai, decimal? GiaKhuyenMai,
                                       DateTime? BatDauKhuyenMai, DateTime? KetThucKhuyenMai, int? DongSanPhamID,
                                       int? KhuVucID, bool? Uachuong, decimal? GiaMoi, bool? GiamGia, bool? MoiCapNhat,
                                       DateTime? NgayThemSanPham, int? SapXep, string Bak1, string Bak2, int? Bak3,
                                       int? Bak4, bool? Bak5, string bak6, string bak7)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsSanPhamMau";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar, 200).Value = TenSanPham;

                sqlCmd.Parameters.Add("@MaSoSanPham", SqlDbType.Char, 12).Value = MaSoSanPham;

                sqlCmd.Parameters.Add("@GiaSanPham", SqlDbType.Money).Value = GiaSanPham;

                sqlCmd.Parameters.Add("@DonViTienTe", SqlDbType.NVarChar, 15).Value = DonViTienTe;

                sqlCmd.Parameters.Add("@MoTaSanPham", SqlDbType.NText).Value = MoTaSanPham;

                sqlCmd.Parameters.Add("@ThongTinSanPham", SqlDbType.NText).Value = ThongTinSanPham;

                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;

                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@AnhSanPham", SqlDbType.NVarChar, 200).Value = AnhSanPham;

                sqlCmd.Parameters.Add("@KhuyenMai", SqlDbType.Bit).Value = KhuyenMai;

                sqlCmd.Parameters.Add("@MoTaKhuyenMai", SqlDbType.NVarChar, 200).Value = MoTaKhuyenMai;

                sqlCmd.Parameters.Add("@GiaKhuyenMai", SqlDbType.Money).Value = GiaKhuyenMai;

                sqlCmd.Parameters.Add("@BatDauKhuyenMai", SqlDbType.DateTime).Value = BatDauKhuyenMai;

                sqlCmd.Parameters.Add("@KetThucKhuyenMai", SqlDbType.DateTime).Value = KetThucKhuyenMai;

                sqlCmd.Parameters.Add("@DongSanPhamID", SqlDbType.Int).Value = DongSanPhamID;

                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;

                sqlCmd.Parameters.Add("@Uachuong", SqlDbType.Bit).Value = Uachuong;

                sqlCmd.Parameters.Add("@GiaMoi", SqlDbType.Money).Value = GiaMoi;

                sqlCmd.Parameters.Add("@GiamGia", SqlDbType.Bit).Value = GiamGia;

                sqlCmd.Parameters.Add("@MoiCapNhat", SqlDbType.Bit).Value = MoiCapNhat;

                sqlCmd.Parameters.Add("@NgayThemSanPham", SqlDbType.DateTime).Value = NgayThemSanPham;

                sqlCmd.Parameters.Add("@SapXep", SqlDbType.Int).Value = SapXep;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4000).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.NVarChar, 100).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Int).Value = Bak3;

                sqlCmd.Parameters.Add("@Bak4", SqlDbType.Int).Value = Bak4;

                sqlCmd.Parameters.Add("@Bak5", SqlDbType.Bit).Value = Bak5;

                sqlCmd.Parameters.Add("@bak6", SqlDbType.NVarChar, 50).Value = bak6;

                sqlCmd.Parameters.Add("@bak7", SqlDbType.NVarChar, 1000).Value = bak7;


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
                sqlCmd.CommandText = "SelectSanPhamMauByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
                return dsResult;
            }
        }

        public DataSet SelectByHangSanXuatIDPaging(int HangSanXuatID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetSanPhamMauByHangSanXuatIDPaging";
                sqlCmd.Parameters.Add("@HangSanXuatID", SqlDbType.Int).Value = HangSanXuatID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
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
                sqlCmd.CommandText = "GetSanPhamMauByNguoiDungIDPaging";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
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
                sqlCmd.CommandText = "GetSanPhamMauByNhomSanPhamIDPaging";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
                return dsResult;
            }
        }

        public DataSet SelectByKhuVucIDPaging(int KhuVucID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetSanPhamMauByKhuVucIDPaging";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "SanPhamMau");
                return dsResult;
            }
        }
    }
}