using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_BinhChon
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_BinhChon()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("BinhChonID", "BinhChonID")
                                   ,
                                   new DataColumnMapping("CuaHangID", "CuaHangID")
                                   ,
                                   new DataColumnMapping("NguoiDungID", "NguoiDungID")
                                   ,
                                   new DataColumnMapping("GiaCa", "GiaCa")
                                   ,
                                   new DataColumnMapping("ThaiDoPhucVu", "ThaiDoPhucVu")
                                   ,
                                   new DataColumnMapping("CheDoBaoHanh", "CheDoBaoHanh")
                                   ,
                                   new DataColumnMapping("ChatLuongSanPham", "ChatLuongSanPham")
                                   ,
                                   new DataColumnMapping("NhanXetChung", "NhanXetChung")
                                   ,
                                   new DataColumnMapping("Bak1", "Bak1")
                                   ,
                                   new DataColumnMapping("Bak2", "Bak2")
                                   ,
                                   new DataColumnMapping("Bak3", "Bak3")
                                   ,
                                   new DataColumnMapping("ChonGiaCa", "ChonGiaCa")
                                   ,
                                   new DataColumnMapping("ChonThaiDoPhucVu", "ChonThaiDoPhucVu")
                                   ,
                                   new DataColumnMapping("ChonCheDoBaoHanh", "ChonCheDoBaoHanh")
                                   ,
                                   new DataColumnMapping("ChonChatLuongSanPham", "ChonChatLuongSanPham")
                                   ,
                                   new DataColumnMapping("ChonNhanXetChung", "ChonNhanXetChung")
                                   ,
                                   new DataColumnMapping("TieuDe", "TieuDe")
                                   ,
                                   new DataColumnMapping("NoiDung", "NoiDung")
                               };
            dtTblMapping = new DataTableMapping("Table", "BinhChon", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetBinhChon";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "BinhChon");
                return dsResult;
            }
        }

        public DataSet SelectByID(int BinhChonID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetBinhChonById";
                sqlCmd.Parameters.Add("@BinhChonID", SqlDbType.Int).Value = BinhChonID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "BinhChon");
                return dsResult;
            }
        }

        public DataSet SelectByCuaHangID(int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetBinhChonByCuaHangID";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "BinhChon");
                return dsResult;
            }
        }

        public int Insert(int CuaHangID, int NguoiDungID, int GiaCa, int ThaiDoPhucVu, int CheDoBaoHanh,
                          int ChatLuongSanPham, int NhanXetChung, string Bak1, int Bak2, bool Bak3, bool ChonGiaCa,
                          bool ChonThaiDoPhucVu, bool ChonCheDoBaoHanh, bool ChonChatLuongSanPham, bool ChonNhanXetChung,
                          string TieuDe, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertBinhChon";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GiaCa", SqlDbType.Int).Value = GiaCa;

                sqlCmd.Parameters.Add("@ThaiDoPhucVu", SqlDbType.Int).Value = ThaiDoPhucVu;

                sqlCmd.Parameters.Add("@CheDoBaoHanh", SqlDbType.Int).Value = CheDoBaoHanh;

                sqlCmd.Parameters.Add("@ChatLuongSanPham", SqlDbType.Int).Value = ChatLuongSanPham;

                sqlCmd.Parameters.Add("@NhanXetChung", SqlDbType.Int).Value = NhanXetChung;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Int).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).Value = Bak3;

                sqlCmd.Parameters.Add("@ChonGiaCa", SqlDbType.Bit).Value = ChonGiaCa;

                sqlCmd.Parameters.Add("@ChonThaiDoPhucVu", SqlDbType.Bit).Value = ChonThaiDoPhucVu;

                sqlCmd.Parameters.Add("@ChonCheDoBaoHanh", SqlDbType.Bit).Value = ChonCheDoBaoHanh;

                sqlCmd.Parameters.Add("@ChonChatLuongSanPham", SqlDbType.Bit).Value = ChonChatLuongSanPham;

                sqlCmd.Parameters.Add("@ChonNhanXetChung", SqlDbType.Bit).Value = ChonNhanXetChung;

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 100).Value = TieuDe;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;


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
                sqlCmd.CommandText = "InsertBinhChon";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GiaCa", SqlDbType.Int).SourceColumn = "GiaCa";

                sqlCmd.Parameters.Add("@ThaiDoPhucVu", SqlDbType.Int).SourceColumn = "ThaiDoPhucVu";

                sqlCmd.Parameters.Add("@CheDoBaoHanh", SqlDbType.Int).SourceColumn = "CheDoBaoHanh";

                sqlCmd.Parameters.Add("@ChatLuongSanPham", SqlDbType.Int).SourceColumn = "ChatLuongSanPham";

                sqlCmd.Parameters.Add("@NhanXetChung", SqlDbType.Int).SourceColumn = "NhanXetChung";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Int).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@ChonGiaCa", SqlDbType.Bit).SourceColumn = "ChonGiaCa";

                sqlCmd.Parameters.Add("@ChonThaiDoPhucVu", SqlDbType.Bit).SourceColumn = "ChonThaiDoPhucVu";

                sqlCmd.Parameters.Add("@ChonCheDoBaoHanh", SqlDbType.Bit).SourceColumn = "ChonCheDoBaoHanh";

                sqlCmd.Parameters.Add("@ChonChatLuongSanPham", SqlDbType.Bit).SourceColumn = "ChonChatLuongSanPham";

                sqlCmd.Parameters.Add("@ChonNhanXetChung", SqlDbType.Bit).SourceColumn = "ChonNhanXetChung";

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 100).SourceColumn = "TieuDe";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertBinhChon_Ref";
                sqlCmd.Parameters.Add("@BinhChonID", SqlDbType.Int).SourceColumn = "BinhChonID";
                sqlCmd.Parameters["@BinhChonID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GiaCa", SqlDbType.Int).SourceColumn = "GiaCa";

                sqlCmd.Parameters.Add("@ThaiDoPhucVu", SqlDbType.Int).SourceColumn = "ThaiDoPhucVu";

                sqlCmd.Parameters.Add("@CheDoBaoHanh", SqlDbType.Int).SourceColumn = "CheDoBaoHanh";

                sqlCmd.Parameters.Add("@ChatLuongSanPham", SqlDbType.Int).SourceColumn = "ChatLuongSanPham";

                sqlCmd.Parameters.Add("@NhanXetChung", SqlDbType.Int).SourceColumn = "NhanXetChung";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 4).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Int).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@ChonGiaCa", SqlDbType.Bit).SourceColumn = "ChonGiaCa";

                sqlCmd.Parameters.Add("@ChonThaiDoPhucVu", SqlDbType.Bit).SourceColumn = "ChonThaiDoPhucVu";

                sqlCmd.Parameters.Add("@ChonCheDoBaoHanh", SqlDbType.Bit).SourceColumn = "ChonCheDoBaoHanh";

                sqlCmd.Parameters.Add("@ChonChatLuongSanPham", SqlDbType.Bit).SourceColumn = "ChonChatLuongSanPham";

                sqlCmd.Parameters.Add("@ChonNhanXetChung", SqlDbType.Bit).SourceColumn = "ChonNhanXetChung";

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 1).SourceColumn = "TieuDe";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int BinhChonID, int CuaHangID, int NguoiDungID, int GiaCa, int ThaiDoPhucVu, int CheDoBaoHanh,
                           int ChatLuongSanPham, int NhanXetChung, string Bak1, int Bak2, bool Bak3, bool ChonGiaCa,
                           bool ChonThaiDoPhucVu, bool ChonCheDoBaoHanh, bool ChonChatLuongSanPham,
                           bool ChonNhanXetChung, string TieuDe, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateBinhChon";

                sqlCmd.Parameters.Add("@BinhChonID", SqlDbType.Int).Value = BinhChonID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GiaCa", SqlDbType.Int).Value = GiaCa;

                sqlCmd.Parameters.Add("@ThaiDoPhucVu", SqlDbType.Int).Value = ThaiDoPhucVu;

                sqlCmd.Parameters.Add("@CheDoBaoHanh", SqlDbType.Int).Value = CheDoBaoHanh;

                sqlCmd.Parameters.Add("@ChatLuongSanPham", SqlDbType.Int).Value = ChatLuongSanPham;

                sqlCmd.Parameters.Add("@NhanXetChung", SqlDbType.Int).Value = NhanXetChung;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Int).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).Value = Bak3;

                sqlCmd.Parameters.Add("@ChonGiaCa", SqlDbType.Bit).Value = ChonGiaCa;

                sqlCmd.Parameters.Add("@ChonThaiDoPhucVu", SqlDbType.Bit).Value = ChonThaiDoPhucVu;

                sqlCmd.Parameters.Add("@ChonCheDoBaoHanh", SqlDbType.Bit).Value = ChonCheDoBaoHanh;

                sqlCmd.Parameters.Add("@ChonChatLuongSanPham", SqlDbType.Bit).Value = ChonChatLuongSanPham;

                sqlCmd.Parameters.Add("@ChonNhanXetChung", SqlDbType.Bit).Value = ChonNhanXetChung;

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 100).Value = TieuDe;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateBinhChon";
                sqlCmd.Parameters.Add("@BinhChonID", SqlDbType.Int).SourceColumn = "BinhChonID";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GiaCa", SqlDbType.Int).SourceColumn = "GiaCa";

                sqlCmd.Parameters.Add("@ThaiDoPhucVu", SqlDbType.Int).SourceColumn = "ThaiDoPhucVu";

                sqlCmd.Parameters.Add("@CheDoBaoHanh", SqlDbType.Int).SourceColumn = "CheDoBaoHanh";

                sqlCmd.Parameters.Add("@ChatLuongSanPham", SqlDbType.Int).SourceColumn = "ChatLuongSanPham";

                sqlCmd.Parameters.Add("@NhanXetChung", SqlDbType.Int).SourceColumn = "NhanXetChung";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Int).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@ChonGiaCa", SqlDbType.Bit).SourceColumn = "ChonGiaCa";

                sqlCmd.Parameters.Add("@ChonThaiDoPhucVu", SqlDbType.Bit).SourceColumn = "ChonThaiDoPhucVu";

                sqlCmd.Parameters.Add("@ChonCheDoBaoHanh", SqlDbType.Bit).SourceColumn = "ChonCheDoBaoHanh";

                sqlCmd.Parameters.Add("@ChonChatLuongSanPham", SqlDbType.Bit).SourceColumn = "ChonChatLuongSanPham";

                sqlCmd.Parameters.Add("@ChonNhanXetChung", SqlDbType.Bit).SourceColumn = "ChonNhanXetChung";

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 100).SourceColumn = "TieuDe";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateBinhChon";
                sqlCmd.Parameters.Add("@BinhChonID", SqlDbType.Int).SourceColumn = "BinhChonID";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GiaCa", SqlDbType.Int).SourceColumn = "GiaCa";

                sqlCmd.Parameters.Add("@ThaiDoPhucVu", SqlDbType.Int).SourceColumn = "ThaiDoPhucVu";

                sqlCmd.Parameters.Add("@CheDoBaoHanh", SqlDbType.Int).SourceColumn = "CheDoBaoHanh";

                sqlCmd.Parameters.Add("@ChatLuongSanPham", SqlDbType.Int).SourceColumn = "ChatLuongSanPham";

                sqlCmd.Parameters.Add("@NhanXetChung", SqlDbType.Int).SourceColumn = "NhanXetChung";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Int).SourceColumn = "Bak2";

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).SourceColumn = "Bak3";

                sqlCmd.Parameters.Add("@ChonGiaCa", SqlDbType.Bit).SourceColumn = "ChonGiaCa";

                sqlCmd.Parameters.Add("@ChonThaiDoPhucVu", SqlDbType.Bit).SourceColumn = "ChonThaiDoPhucVu";

                sqlCmd.Parameters.Add("@ChonCheDoBaoHanh", SqlDbType.Bit).SourceColumn = "ChonCheDoBaoHanh";

                sqlCmd.Parameters.Add("@ChonChatLuongSanPham", SqlDbType.Bit).SourceColumn = "ChonChatLuongSanPham";

                sqlCmd.Parameters.Add("@ChonNhanXetChung", SqlDbType.Bit).SourceColumn = "ChonNhanXetChung";

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 100).SourceColumn = "TieuDe";

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).SourceColumn = "NoiDung";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteBinhChon";
                sqlCmd.Parameters.Add("@BinhChonID", SqlDbType.Int).SourceColumn = "BinhChonID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void Delete(int BinhChonID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteBinhChon";
                sqlCmd.Parameters.Add("@BinhChonID", SqlDbType.Int).Value = BinhChonID;
                objDataAccess.ExecuteQuery(sqlCmd, "BinhChon");
            }
        }

        public int InsertFields(int? CuaHangID, int? NguoiDungID, int? GiaCa, int? ThaiDoPhucVu, int? CheDoBaoHanh,
                                int? ChatLuongSanPham, int? NhanXetChung, string Bak1, int? Bak2, bool? Bak3,
                                bool? ChonGiaCa, bool? ChonThaiDoPhucVu, bool? ChonCheDoBaoHanh,
                                bool? ChonChatLuongSanPham, bool? ChonNhanXetChung, string TieuDe, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsBinhChon";

                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GiaCa", SqlDbType.Int).Value = GiaCa;

                sqlCmd.Parameters.Add("@ThaiDoPhucVu", SqlDbType.Int).Value = ThaiDoPhucVu;

                sqlCmd.Parameters.Add("@CheDoBaoHanh", SqlDbType.Int).Value = CheDoBaoHanh;

                sqlCmd.Parameters.Add("@ChatLuongSanPham", SqlDbType.Int).Value = ChatLuongSanPham;

                sqlCmd.Parameters.Add("@NhanXetChung", SqlDbType.Int).Value = NhanXetChung;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Int).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).Value = Bak3;

                sqlCmd.Parameters.Add("@ChonGiaCa", SqlDbType.Bit).Value = ChonGiaCa;

                sqlCmd.Parameters.Add("@ChonThaiDoPhucVu", SqlDbType.Bit).Value = ChonThaiDoPhucVu;

                sqlCmd.Parameters.Add("@ChonCheDoBaoHanh", SqlDbType.Bit).Value = ChonCheDoBaoHanh;

                sqlCmd.Parameters.Add("@ChonChatLuongSanPham", SqlDbType.Bit).Value = ChonChatLuongSanPham;

                sqlCmd.Parameters.Add("@ChonNhanXetChung", SqlDbType.Bit).Value = ChonNhanXetChung;

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 100).Value = TieuDe;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int BinhChonID, int? CuaHangID, int? NguoiDungID, int? GiaCa, int? ThaiDoPhucVu,
                                 int? CheDoBaoHanh, int? ChatLuongSanPham, int? NhanXetChung, string Bak1, int? Bak2,
                                 bool? Bak3, bool? ChonGiaCa, bool? ChonThaiDoPhucVu, bool? ChonCheDoBaoHanh,
                                 bool? ChonChatLuongSanPham, bool? ChonNhanXetChung, string TieuDe, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsBinhChon";

                sqlCmd.Parameters.Add("@BinhChonID", SqlDbType.Int).Value = BinhChonID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GiaCa", SqlDbType.Int).Value = GiaCa;

                sqlCmd.Parameters.Add("@ThaiDoPhucVu", SqlDbType.Int).Value = ThaiDoPhucVu;

                sqlCmd.Parameters.Add("@CheDoBaoHanh", SqlDbType.Int).Value = CheDoBaoHanh;

                sqlCmd.Parameters.Add("@ChatLuongSanPham", SqlDbType.Int).Value = ChatLuongSanPham;

                sqlCmd.Parameters.Add("@NhanXetChung", SqlDbType.Int).Value = NhanXetChung;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Int).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).Value = Bak3;

                sqlCmd.Parameters.Add("@ChonGiaCa", SqlDbType.Bit).Value = ChonGiaCa;

                sqlCmd.Parameters.Add("@ChonThaiDoPhucVu", SqlDbType.Bit).Value = ChonThaiDoPhucVu;

                sqlCmd.Parameters.Add("@ChonCheDoBaoHanh", SqlDbType.Bit).Value = ChonCheDoBaoHanh;

                sqlCmd.Parameters.Add("@ChonChatLuongSanPham", SqlDbType.Bit).Value = ChonChatLuongSanPham;

                sqlCmd.Parameters.Add("@ChonNhanXetChung", SqlDbType.Bit).Value = ChonNhanXetChung;

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 100).Value = TieuDe;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? CuaHangID, int? NguoiDungID, int? GiaCa, int? ThaiDoPhucVu,
                                       int? CheDoBaoHanh, int? ChatLuongSanPham, int? NhanXetChung, string Bak1,
                                       int? Bak2, bool? Bak3, bool? ChonGiaCa, bool? ChonThaiDoPhucVu,
                                       bool? ChonCheDoBaoHanh, bool? ChonChatLuongSanPham, bool? ChonNhanXetChung,
                                       string TieuDe, string NoiDung)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsBinhChon";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GiaCa", SqlDbType.Int).Value = GiaCa;

                sqlCmd.Parameters.Add("@ThaiDoPhucVu", SqlDbType.Int).Value = ThaiDoPhucVu;

                sqlCmd.Parameters.Add("@CheDoBaoHanh", SqlDbType.Int).Value = CheDoBaoHanh;

                sqlCmd.Parameters.Add("@ChatLuongSanPham", SqlDbType.Int).Value = ChatLuongSanPham;

                sqlCmd.Parameters.Add("@NhanXetChung", SqlDbType.Int).Value = NhanXetChung;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.NVarChar, 50).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Int).Value = Bak2;

                sqlCmd.Parameters.Add("@Bak3", SqlDbType.Bit).Value = Bak3;

                sqlCmd.Parameters.Add("@ChonGiaCa", SqlDbType.Bit).Value = ChonGiaCa;

                sqlCmd.Parameters.Add("@ChonThaiDoPhucVu", SqlDbType.Bit).Value = ChonThaiDoPhucVu;

                sqlCmd.Parameters.Add("@ChonCheDoBaoHanh", SqlDbType.Bit).Value = ChonCheDoBaoHanh;

                sqlCmd.Parameters.Add("@ChonChatLuongSanPham", SqlDbType.Bit).Value = ChonChatLuongSanPham;

                sqlCmd.Parameters.Add("@ChonNhanXetChung", SqlDbType.Bit).Value = ChonNhanXetChung;

                sqlCmd.Parameters.Add("@TieuDe", SqlDbType.NVarChar, 100).Value = TieuDe;

                sqlCmd.Parameters.Add("@NoiDung", SqlDbType.NText).Value = NoiDung;


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
                sqlCmd.CommandText = "SelectBinhChonByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "BinhChon");
                return dsResult;
            }
        }

        public DataSet SelectByCuaHangIDPaging(int CuaHangID, int RowStart, int PageSize)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetBinhChonByCuaHangIDPaging";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                sqlCmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = PageSize;
                sqlCmd.Parameters.Add("@RowStart", SqlDbType.Int).Value = RowStart;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "BinhChon");
                return dsResult;
            }
        }
    }
}