using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Globalization;
using CHONET.DataAccessLayer;
namespace CHONET.DataAccessLayer.Web.BaseClasses
{
	public class Base_CuaHang
	{
		DataColumnMapping[] dtColMapping;
        DataTableMapping dtTblMapping;
		public Base_CuaHang()
		{
			dtColMapping = new DataColumnMapping[]{
				
				new DataColumnMapping("CuaHangID","CuaHangID")
					,				

				
				new DataColumnMapping("TenCuaHang","TenCuaHang")
					,				

				
				new DataColumnMapping("GioiThieu","GioiThieu")
					,				

				
				new DataColumnMapping("NguoiDungID","NguoiDungID")
					,				

				
				new DataColumnMapping("Email","Email")
					,				

				
				new DataColumnMapping("Anh","Anh")
					,				

				
				new DataColumnMapping("DienThoaiDiDong","DienThoaiDiDong")
					,				

				
				new DataColumnMapping("DienThoaiCoDinh","DienThoaiCoDinh")
					,				

				
				new DataColumnMapping("ThongTinLienHe","ThongTinLienHe")
					,				

				
				new DataColumnMapping("DiaChi","DiaChi")
					,				

				
				new DataColumnMapping("Website","Website")
					,				

				
				new DataColumnMapping("Fax","Fax")
					,				

				
				new DataColumnMapping("YM","YM")
					,				

				
				new DataColumnMapping("KichHoat","KichHoat")
					,				

				
				new DataColumnMapping("SapXep","SapXep")
					,				

				
				new DataColumnMapping("Bak1","Bak1")
					,				

				
				new DataColumnMapping("Bak2","Bak2")
					,				

				
				new DataColumnMapping("Bak3","Bak3")
					,				

				
				new DataColumnMapping("Bak4","Bak4")
					,				

				
				new DataColumnMapping("Bak5","Bak5")
					,				

				
				new DataColumnMapping("bak6","bak6")
					,				

				
				new DataColumnMapping("bak7","bak7")
					,				

				
				new DataColumnMapping("bak8","bak8")
					,				

				
				new DataColumnMapping("Bak9","Bak9")
					,				

				
				new DataColumnMapping("BaoDam","BaoDam")
					,				

				
				new DataColumnMapping("LoaiCuaHang","LoaiCuaHang")
					,				

				
				new DataColumnMapping("LoaiCuaHangID","LoaiCuaHangID")
					};				
			dtTblMapping = new DataTableMapping("Table", "CuaHang", dtColMapping);	
		}
	
		public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();           
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetCuaHang";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
                return dsResult;
            }
        }
		
		public DataSet SelectByID(int CuaHangID)
		{ 
			DataAccess objDataAccess = new DataAccess(); 
			DataSet dsResult = new DataSet(); dsResult.Locale = CultureInfo.CurrentCulture; 
			using (SqlCommand sqlCmd = new SqlCommand())
			{
				sqlCmd.CommandType = CommandType.StoredProcedure; 
				sqlCmd.CommandText = "GetCuaHangById"; 
				sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int ).Value = CuaHangID;
				dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang"); 
				return dsResult; 
			}
		}
		
		public DataSet SelectByNguoiDungID(int NguoiDungID)
		{ 
			DataAccess objDataAccess = new DataAccess(); 
			DataSet dsResult = new DataSet(); dsResult.Locale = CultureInfo.CurrentCulture; 
			using (SqlCommand sqlCmd = new SqlCommand())
			{
				sqlCmd.CommandType = CommandType.StoredProcedure; 
				sqlCmd.CommandText = "GetCuaHangByNguoiDungID"; 
				sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int ).Value = NguoiDungID;
				dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang"); 
				return dsResult; 
			}
		}
		
		public int Insert(	string TenCuaHang ,	string GioiThieu ,	int NguoiDungID ,	string Email ,	string Anh ,	string DienThoaiDiDong ,	string DienThoaiCoDinh ,	string ThongTinLienHe ,	string DiaChi ,	string Website ,	string Fax ,	string YM ,	bool KichHoat ,	int SapXep ,	string Bak1 ,	string Bak2 ,	int Bak3 ,	int Bak4 ,	bool Bak5 ,	string bak6 ,	string bak7 ,	string bak8 ,	int Bak9 ,	short BaoDam ,	short LoaiCuaHang ,	int LoaiCuaHangID )
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
				int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertCuaHang";

				       sqlCmd.Parameters.Add("@TenCuaHang",SqlDbType.NVarChar,100).Value = TenCuaHang;
				
				       sqlCmd.Parameters.Add("@GioiThieu",SqlDbType.NVarChar,4000).Value = GioiThieu;
				
				   		sqlCmd.Parameters.Add("@NguoiDungID",SqlDbType.Int).Value = NguoiDungID;
				
				       sqlCmd.Parameters.Add("@Email",SqlDbType.NVarChar,50).Value = Email;
				
				       sqlCmd.Parameters.Add("@Anh",SqlDbType.NVarChar,100).Value = Anh;
				
				       sqlCmd.Parameters.Add("@DienThoaiDiDong",SqlDbType.NVarChar,50).Value = DienThoaiDiDong;
				
				       sqlCmd.Parameters.Add("@DienThoaiCoDinh",SqlDbType.NVarChar,50).Value = DienThoaiCoDinh;
				
				       sqlCmd.Parameters.Add("@ThongTinLienHe",SqlDbType.NVarChar,4000).Value = ThongTinLienHe;
				
				       sqlCmd.Parameters.Add("@DiaChi",SqlDbType.NVarChar,200).Value = DiaChi;
				
				       sqlCmd.Parameters.Add("@Website",SqlDbType.NVarChar,200).Value = Website;
				
				       sqlCmd.Parameters.Add("@Fax",SqlDbType.NVarChar,50).Value = Fax;
				
				       sqlCmd.Parameters.Add("@YM",SqlDbType.NVarChar,50).Value = YM;
				
				   		sqlCmd.Parameters.Add("@KichHoat",SqlDbType.Bit).Value = KichHoat;
				
				   		sqlCmd.Parameters.Add("@SapXep",SqlDbType.Int).Value = SapXep;
				
				       sqlCmd.Parameters.Add("@Bak1",SqlDbType.NVarChar,50).Value = Bak1;
				
				       sqlCmd.Parameters.Add("@Bak2",SqlDbType.NVarChar,1000).Value = Bak2;
				
				   		sqlCmd.Parameters.Add("@Bak3",SqlDbType.Int).Value = Bak3;
				
				   		sqlCmd.Parameters.Add("@Bak4",SqlDbType.Int).Value = Bak4;
				
				   		sqlCmd.Parameters.Add("@Bak5",SqlDbType.Bit).Value = Bak5;
				
				       sqlCmd.Parameters.Add("@bak6",SqlDbType.NVarChar,50).Value = bak6;
				
				       sqlCmd.Parameters.Add("@bak7",SqlDbType.NVarChar,1000).Value = bak7;
				
				       sqlCmd.Parameters.Add("@bak8",SqlDbType.NVarChar,1000).Value = bak8;
				
				   		sqlCmd.Parameters.Add("@Bak9",SqlDbType.Int).Value = Bak9;
				
				   		sqlCmd.Parameters.Add("@BaoDam",SqlDbType.TinyInt).Value = BaoDam;
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHang",SqlDbType.TinyInt).Value = LoaiCuaHang;
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).Value = LoaiCuaHangID;
				

                iID = objDataAccess.ExecuteScalar(sqlCmd);
				return  iID;
            }
        } 

		public void InsertBatch(DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertCuaHang";
				       sqlCmd.Parameters.Add("@TenCuaHang",SqlDbType.NVarChar,100).SourceColumn = "TenCuaHang";
				
				       sqlCmd.Parameters.Add("@GioiThieu",SqlDbType.NVarChar,4000).SourceColumn = "GioiThieu";
				
				   		sqlCmd.Parameters.Add("@NguoiDungID",SqlDbType.Int).SourceColumn = "NguoiDungID";
				
				       sqlCmd.Parameters.Add("@Email",SqlDbType.NVarChar,50).SourceColumn = "Email";
				
				       sqlCmd.Parameters.Add("@Anh",SqlDbType.NVarChar,100).SourceColumn = "Anh";
				
				       sqlCmd.Parameters.Add("@DienThoaiDiDong",SqlDbType.NVarChar,50).SourceColumn = "DienThoaiDiDong";
				
				       sqlCmd.Parameters.Add("@DienThoaiCoDinh",SqlDbType.NVarChar,50).SourceColumn = "DienThoaiCoDinh";
				
				       sqlCmd.Parameters.Add("@ThongTinLienHe",SqlDbType.NVarChar,4000).SourceColumn = "ThongTinLienHe";
				
				       sqlCmd.Parameters.Add("@DiaChi",SqlDbType.NVarChar,200).SourceColumn = "DiaChi";
				
				       sqlCmd.Parameters.Add("@Website",SqlDbType.NVarChar,200).SourceColumn = "Website";
				
				       sqlCmd.Parameters.Add("@Fax",SqlDbType.NVarChar,50).SourceColumn = "Fax";
				
				       sqlCmd.Parameters.Add("@YM",SqlDbType.NVarChar,50).SourceColumn = "YM";
				
				   		sqlCmd.Parameters.Add("@KichHoat",SqlDbType.Bit).SourceColumn = "KichHoat";
				
				   		sqlCmd.Parameters.Add("@SapXep",SqlDbType.Int).SourceColumn = "SapXep";
				
				       sqlCmd.Parameters.Add("@Bak1",SqlDbType.NVarChar,50).SourceColumn = "Bak1";
				
				       sqlCmd.Parameters.Add("@Bak2",SqlDbType.NVarChar,1000).SourceColumn = "Bak2";
				
				   		sqlCmd.Parameters.Add("@Bak3",SqlDbType.Int).SourceColumn = "Bak3";
				
				   		sqlCmd.Parameters.Add("@Bak4",SqlDbType.Int).SourceColumn = "Bak4";
				
				   		sqlCmd.Parameters.Add("@Bak5",SqlDbType.Bit).SourceColumn = "Bak5";
				
				       sqlCmd.Parameters.Add("@bak6",SqlDbType.NVarChar,50).SourceColumn = "bak6";
				
				       sqlCmd.Parameters.Add("@bak7",SqlDbType.NVarChar,1000).SourceColumn = "bak7";
				
				       sqlCmd.Parameters.Add("@bak8",SqlDbType.NVarChar,1000).SourceColumn = "bak8";
				
				   		sqlCmd.Parameters.Add("@Bak9",SqlDbType.Int).SourceColumn = "Bak9";
				
				   		sqlCmd.Parameters.Add("@BaoDam",SqlDbType.TinyInt).SourceColumn = "BaoDam";
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHang",SqlDbType.TinyInt).SourceColumn = "LoaiCuaHang";
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).SourceColumn = "LoaiCuaHangID";
				
                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }
		
		public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertCuaHang_Ref";
				sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int ).SourceColumn = "CuaHangID";
                sqlCmd.Parameters["@CuaHangID"].Direction = ParameterDirection.Output;
				       sqlCmd.Parameters.Add("@TenCuaHang",SqlDbType.NVarChar,4).SourceColumn = "TenCuaHang";
				
				       sqlCmd.Parameters.Add("@GioiThieu",SqlDbType.NVarChar,100).SourceColumn = "GioiThieu";
				
				   		sqlCmd.Parameters.Add("@NguoiDungID",SqlDbType.Int).SourceColumn = "NguoiDungID";
				
				       sqlCmd.Parameters.Add("@Email",SqlDbType.NVarChar,4).SourceColumn = "Email";
				
				       sqlCmd.Parameters.Add("@Anh",SqlDbType.NVarChar,50).SourceColumn = "Anh";
				
				       sqlCmd.Parameters.Add("@DienThoaiDiDong",SqlDbType.NVarChar,100).SourceColumn = "DienThoaiDiDong";
				
				       sqlCmd.Parameters.Add("@DienThoaiCoDinh",SqlDbType.NVarChar,50).SourceColumn = "DienThoaiCoDinh";
				
				       sqlCmd.Parameters.Add("@ThongTinLienHe",SqlDbType.NVarChar,50).SourceColumn = "ThongTinLienHe";
				
				       sqlCmd.Parameters.Add("@DiaChi",SqlDbType.NVarChar,4000).SourceColumn = "DiaChi";
				
				       sqlCmd.Parameters.Add("@Website",SqlDbType.NVarChar,200).SourceColumn = "Website";
				
				       sqlCmd.Parameters.Add("@Fax",SqlDbType.NVarChar,200).SourceColumn = "Fax";
				
				       sqlCmd.Parameters.Add("@YM",SqlDbType.NVarChar,50).SourceColumn = "YM";
				
				   		sqlCmd.Parameters.Add("@KichHoat",SqlDbType.Bit).SourceColumn = "KichHoat";
				
				   		sqlCmd.Parameters.Add("@SapXep",SqlDbType.Int).SourceColumn = "SapXep";
				
				       sqlCmd.Parameters.Add("@Bak1",SqlDbType.NVarChar,4).SourceColumn = "Bak1";
				
				       sqlCmd.Parameters.Add("@Bak2",SqlDbType.NVarChar,50).SourceColumn = "Bak2";
				
				   		sqlCmd.Parameters.Add("@Bak3",SqlDbType.Int).SourceColumn = "Bak3";
				
				   		sqlCmd.Parameters.Add("@Bak4",SqlDbType.Int).SourceColumn = "Bak4";
				
				   		sqlCmd.Parameters.Add("@Bak5",SqlDbType.Bit).SourceColumn = "Bak5";
				
				       sqlCmd.Parameters.Add("@bak6",SqlDbType.NVarChar,1).SourceColumn = "bak6";
				
				       sqlCmd.Parameters.Add("@bak7",SqlDbType.NVarChar,50).SourceColumn = "bak7";
				
				       sqlCmd.Parameters.Add("@bak8",SqlDbType.NVarChar,1000).SourceColumn = "bak8";
				
				   		sqlCmd.Parameters.Add("@Bak9",SqlDbType.Int).SourceColumn = "Bak9";
				
				   		sqlCmd.Parameters.Add("@BaoDam",SqlDbType.TinyInt).SourceColumn = "BaoDam";
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHang",SqlDbType.TinyInt).SourceColumn = "LoaiCuaHang";
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).SourceColumn = "LoaiCuaHangID";
				
                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }
		
		public void Update(int CuaHangID, 	string TenCuaHang ,	string GioiThieu ,	int NguoiDungID ,	string Email ,	string Anh ,	string DienThoaiDiDong ,	string DienThoaiCoDinh ,	string ThongTinLienHe ,	string DiaChi ,	string Website ,	string Fax ,	string YM ,	bool KichHoat ,	int SapXep ,	string Bak1 ,	string Bak2 ,	int Bak3 ,	int Bak4 ,	bool Bak5 ,	string bak6 ,	string bak7 ,	string bak8 ,	int Bak9 ,	short BaoDam ,	short LoaiCuaHang ,	int LoaiCuaHangID )
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateCuaHang";

				sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int ).Value = CuaHangID;
				       sqlCmd.Parameters.Add("@TenCuaHang",SqlDbType.NVarChar,100).Value = TenCuaHang;
				
				       sqlCmd.Parameters.Add("@GioiThieu",SqlDbType.NVarChar,4000).Value = GioiThieu;
				
				   		sqlCmd.Parameters.Add("@NguoiDungID",SqlDbType.Int).Value = NguoiDungID;
				
				       sqlCmd.Parameters.Add("@Email",SqlDbType.NVarChar,50).Value = Email;
				
				       sqlCmd.Parameters.Add("@Anh",SqlDbType.NVarChar,100).Value = Anh;
				
				       sqlCmd.Parameters.Add("@DienThoaiDiDong",SqlDbType.NVarChar,50).Value = DienThoaiDiDong;
				
				       sqlCmd.Parameters.Add("@DienThoaiCoDinh",SqlDbType.NVarChar,50).Value = DienThoaiCoDinh;
				
				       sqlCmd.Parameters.Add("@ThongTinLienHe",SqlDbType.NVarChar,4000).Value = ThongTinLienHe;
				
				       sqlCmd.Parameters.Add("@DiaChi",SqlDbType.NVarChar,200).Value = DiaChi;
				
				       sqlCmd.Parameters.Add("@Website",SqlDbType.NVarChar,200).Value = Website;
				
				       sqlCmd.Parameters.Add("@Fax",SqlDbType.NVarChar,50).Value = Fax;
				
				       sqlCmd.Parameters.Add("@YM",SqlDbType.NVarChar,50).Value = YM;
				
				   		sqlCmd.Parameters.Add("@KichHoat",SqlDbType.Bit).Value = KichHoat;
				
				   		sqlCmd.Parameters.Add("@SapXep",SqlDbType.Int).Value = SapXep;
				
				       sqlCmd.Parameters.Add("@Bak1",SqlDbType.NVarChar,50).Value = Bak1;
				
				       sqlCmd.Parameters.Add("@Bak2",SqlDbType.NVarChar,1000).Value = Bak2;
				
				   		sqlCmd.Parameters.Add("@Bak3",SqlDbType.Int).Value = Bak3;
				
				   		sqlCmd.Parameters.Add("@Bak4",SqlDbType.Int).Value = Bak4;
				
				   		sqlCmd.Parameters.Add("@Bak5",SqlDbType.Bit).Value = Bak5;
				
				       sqlCmd.Parameters.Add("@bak6",SqlDbType.NVarChar,50).Value = bak6;
				
				       sqlCmd.Parameters.Add("@bak7",SqlDbType.NVarChar,1000).Value = bak7;
				
				       sqlCmd.Parameters.Add("@bak8",SqlDbType.NVarChar,1000).Value = bak8;
				
				   		sqlCmd.Parameters.Add("@Bak9",SqlDbType.Int).Value = Bak9;
				
				   		sqlCmd.Parameters.Add("@BaoDam",SqlDbType.TinyInt).Value = BaoDam;
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHang",SqlDbType.TinyInt).Value = LoaiCuaHang;
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).Value = LoaiCuaHangID;
				

                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        } 
		
		public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateCuaHang";
				   		sqlCmd.Parameters.Add("@CuaHangID",SqlDbType.Int).SourceColumn = "CuaHangID";
				
				       sqlCmd.Parameters.Add("@TenCuaHang",SqlDbType.NVarChar,100).SourceColumn = "TenCuaHang";
				
				       sqlCmd.Parameters.Add("@GioiThieu",SqlDbType.NVarChar,4000).SourceColumn = "GioiThieu";
				
				   		sqlCmd.Parameters.Add("@NguoiDungID",SqlDbType.Int).SourceColumn = "NguoiDungID";
				
				       sqlCmd.Parameters.Add("@Email",SqlDbType.NVarChar,50).SourceColumn = "Email";
				
				       sqlCmd.Parameters.Add("@Anh",SqlDbType.NVarChar,100).SourceColumn = "Anh";
				
				       sqlCmd.Parameters.Add("@DienThoaiDiDong",SqlDbType.NVarChar,50).SourceColumn = "DienThoaiDiDong";
				
				       sqlCmd.Parameters.Add("@DienThoaiCoDinh",SqlDbType.NVarChar,50).SourceColumn = "DienThoaiCoDinh";
				
				       sqlCmd.Parameters.Add("@ThongTinLienHe",SqlDbType.NVarChar,4000).SourceColumn = "ThongTinLienHe";
				
				       sqlCmd.Parameters.Add("@DiaChi",SqlDbType.NVarChar,200).SourceColumn = "DiaChi";
				
				       sqlCmd.Parameters.Add("@Website",SqlDbType.NVarChar,200).SourceColumn = "Website";
				
				       sqlCmd.Parameters.Add("@Fax",SqlDbType.NVarChar,50).SourceColumn = "Fax";
				
				       sqlCmd.Parameters.Add("@YM",SqlDbType.NVarChar,50).SourceColumn = "YM";
				
				   		sqlCmd.Parameters.Add("@KichHoat",SqlDbType.Bit).SourceColumn = "KichHoat";
				
				   		sqlCmd.Parameters.Add("@SapXep",SqlDbType.Int).SourceColumn = "SapXep";
				
				       sqlCmd.Parameters.Add("@Bak1",SqlDbType.NVarChar,50).SourceColumn = "Bak1";
				
				       sqlCmd.Parameters.Add("@Bak2",SqlDbType.NVarChar,1000).SourceColumn = "Bak2";
				
				   		sqlCmd.Parameters.Add("@Bak3",SqlDbType.Int).SourceColumn = "Bak3";
				
				   		sqlCmd.Parameters.Add("@Bak4",SqlDbType.Int).SourceColumn = "Bak4";
				
				   		sqlCmd.Parameters.Add("@Bak5",SqlDbType.Bit).SourceColumn = "Bak5";
				
				       sqlCmd.Parameters.Add("@bak6",SqlDbType.NVarChar,50).SourceColumn = "bak6";
				
				       sqlCmd.Parameters.Add("@bak7",SqlDbType.NVarChar,1000).SourceColumn = "bak7";
				
				       sqlCmd.Parameters.Add("@bak8",SqlDbType.NVarChar,1000).SourceColumn = "bak8";
				
				   		sqlCmd.Parameters.Add("@Bak9",SqlDbType.Int).SourceColumn = "Bak9";
				
				   		sqlCmd.Parameters.Add("@BaoDam",SqlDbType.TinyInt).SourceColumn = "BaoDam";
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHang",SqlDbType.TinyInt).SourceColumn = "LoaiCuaHang";
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).SourceColumn = "LoaiCuaHangID";
				
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

		public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateCuaHang";
				   		sqlCmd.Parameters.Add("@CuaHangID",SqlDbType.Int).SourceColumn = "CuaHangID";
				
				       sqlCmd.Parameters.Add("@TenCuaHang",SqlDbType.NVarChar,100).SourceColumn = "TenCuaHang";
				
				       sqlCmd.Parameters.Add("@GioiThieu",SqlDbType.NVarChar,4000).SourceColumn = "GioiThieu";
				
				   		sqlCmd.Parameters.Add("@NguoiDungID",SqlDbType.Int).SourceColumn = "NguoiDungID";
				
				       sqlCmd.Parameters.Add("@Email",SqlDbType.NVarChar,50).SourceColumn = "Email";
				
				       sqlCmd.Parameters.Add("@Anh",SqlDbType.NVarChar,100).SourceColumn = "Anh";
				
				       sqlCmd.Parameters.Add("@DienThoaiDiDong",SqlDbType.NVarChar,50).SourceColumn = "DienThoaiDiDong";
				
				       sqlCmd.Parameters.Add("@DienThoaiCoDinh",SqlDbType.NVarChar,50).SourceColumn = "DienThoaiCoDinh";
				
				       sqlCmd.Parameters.Add("@ThongTinLienHe",SqlDbType.NVarChar,4000).SourceColumn = "ThongTinLienHe";
				
				       sqlCmd.Parameters.Add("@DiaChi",SqlDbType.NVarChar,200).SourceColumn = "DiaChi";
				
				       sqlCmd.Parameters.Add("@Website",SqlDbType.NVarChar,200).SourceColumn = "Website";
				
				       sqlCmd.Parameters.Add("@Fax",SqlDbType.NVarChar,50).SourceColumn = "Fax";
				
				       sqlCmd.Parameters.Add("@YM",SqlDbType.NVarChar,50).SourceColumn = "YM";
				
				   		sqlCmd.Parameters.Add("@KichHoat",SqlDbType.Bit).SourceColumn = "KichHoat";
				
				   		sqlCmd.Parameters.Add("@SapXep",SqlDbType.Int).SourceColumn = "SapXep";
				
				       sqlCmd.Parameters.Add("@Bak1",SqlDbType.NVarChar,50).SourceColumn = "Bak1";
				
				       sqlCmd.Parameters.Add("@Bak2",SqlDbType.NVarChar,1000).SourceColumn = "Bak2";
				
				   		sqlCmd.Parameters.Add("@Bak3",SqlDbType.Int).SourceColumn = "Bak3";
				
				   		sqlCmd.Parameters.Add("@Bak4",SqlDbType.Int).SourceColumn = "Bak4";
				
				   		sqlCmd.Parameters.Add("@Bak5",SqlDbType.Bit).SourceColumn = "Bak5";
				
				       sqlCmd.Parameters.Add("@bak6",SqlDbType.NVarChar,50).SourceColumn = "bak6";
				
				       sqlCmd.Parameters.Add("@bak7",SqlDbType.NVarChar,1000).SourceColumn = "bak7";
				
				       sqlCmd.Parameters.Add("@bak8",SqlDbType.NVarChar,1000).SourceColumn = "bak8";
				
				   		sqlCmd.Parameters.Add("@Bak9",SqlDbType.Int).SourceColumn = "Bak9";
				
				   		sqlCmd.Parameters.Add("@BaoDam",SqlDbType.TinyInt).SourceColumn = "BaoDam";
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHang",SqlDbType.TinyInt).SourceColumn = "LoaiCuaHang";
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).SourceColumn = "LoaiCuaHangID";
				
                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }
	
		public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteCuaHang";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).SourceColumn = "CuaHangID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }
		
		public void Delete(int CuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteCuaHang";
                sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int).Value = CuaHangID;
                objDataAccess.ExecuteQuery(sqlCmd, "CuaHang");
            }
        }

		public int InsertFields(string TenCuaHang , string GioiThieu , int? NguoiDungID , string Email , string Anh , string DienThoaiDiDong , string DienThoaiCoDinh , string ThongTinLienHe , string DiaChi , string Website , string Fax , string YM , bool? KichHoat , int? SapXep , string Bak1 , string Bak2 , int? Bak3 , int? Bak4 , bool? Bak5 , string bak6 , string bak7 , string bak8 , int? Bak9 , short? BaoDam , short? LoaiCuaHang , int? LoaiCuaHangID )
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
				int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsCuaHang";

				       sqlCmd.Parameters.Add("@TenCuaHang",SqlDbType.NVarChar,100).Value = TenCuaHang;
				
				       sqlCmd.Parameters.Add("@GioiThieu",SqlDbType.NVarChar,4000).Value = GioiThieu;
				
				   		sqlCmd.Parameters.Add("@NguoiDungID",SqlDbType.Int).Value = NguoiDungID;
				
				       sqlCmd.Parameters.Add("@Email",SqlDbType.NVarChar,50).Value = Email;
				
				       sqlCmd.Parameters.Add("@Anh",SqlDbType.NVarChar,100).Value = Anh;
				
				       sqlCmd.Parameters.Add("@DienThoaiDiDong",SqlDbType.NVarChar,50).Value = DienThoaiDiDong;
				
				       sqlCmd.Parameters.Add("@DienThoaiCoDinh",SqlDbType.NVarChar,50).Value = DienThoaiCoDinh;
				
				       sqlCmd.Parameters.Add("@ThongTinLienHe",SqlDbType.NVarChar,4000).Value = ThongTinLienHe;
				
				       sqlCmd.Parameters.Add("@DiaChi",SqlDbType.NVarChar,200).Value = DiaChi;
				
				       sqlCmd.Parameters.Add("@Website",SqlDbType.NVarChar,200).Value = Website;
				
				       sqlCmd.Parameters.Add("@Fax",SqlDbType.NVarChar,50).Value = Fax;
				
				       sqlCmd.Parameters.Add("@YM",SqlDbType.NVarChar,50).Value = YM;
				
				   		sqlCmd.Parameters.Add("@KichHoat",SqlDbType.Bit).Value = KichHoat;
				
				   		sqlCmd.Parameters.Add("@SapXep",SqlDbType.Int).Value = SapXep;
				
				       sqlCmd.Parameters.Add("@Bak1",SqlDbType.NVarChar,50).Value = Bak1;
				
				       sqlCmd.Parameters.Add("@Bak2",SqlDbType.NVarChar,1000).Value = Bak2;
				
				   		sqlCmd.Parameters.Add("@Bak3",SqlDbType.Int).Value = Bak3;
				
				   		sqlCmd.Parameters.Add("@Bak4",SqlDbType.Int).Value = Bak4;
				
				   		sqlCmd.Parameters.Add("@Bak5",SqlDbType.Bit).Value = Bak5;
				
				       sqlCmd.Parameters.Add("@bak6",SqlDbType.NVarChar,50).Value = bak6;
				
				       sqlCmd.Parameters.Add("@bak7",SqlDbType.NVarChar,1000).Value = bak7;
				
				       sqlCmd.Parameters.Add("@bak8",SqlDbType.NVarChar,1000).Value = bak8;
				
				   		sqlCmd.Parameters.Add("@Bak9",SqlDbType.Int).Value = Bak9;
				
				   		sqlCmd.Parameters.Add("@BaoDam",SqlDbType.TinyInt).Value = BaoDam;
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHang",SqlDbType.TinyInt).Value = LoaiCuaHang;
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).Value = LoaiCuaHangID;
				

                iID = objDataAccess.ExecuteScalar(sqlCmd);
				return  iID;
            }
        } 
		
		public void UpdateFields(int CuaHangID, string TenCuaHang, string GioiThieu, int? NguoiDungID, string Email, string Anh, string DienThoaiDiDong, string DienThoaiCoDinh, string ThongTinLienHe, string DiaChi, string Website, string Fax, string YM, bool? KichHoat, int? SapXep, string Bak1, string Bak2, int? Bak3, int? Bak4, bool? Bak5, string bak6, string bak7, string bak8, int? Bak9, short? BaoDam, short? LoaiCuaHang, int? LoaiCuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsCuaHang";

				sqlCmd.Parameters.Add("@CuaHangID", SqlDbType.Int ).Value = CuaHangID;
				       sqlCmd.Parameters.Add("@TenCuaHang",SqlDbType.NVarChar,100).Value = TenCuaHang;
				
				       sqlCmd.Parameters.Add("@GioiThieu",SqlDbType.NVarChar,4000).Value = GioiThieu;
				
				   		sqlCmd.Parameters.Add("@NguoiDungID",SqlDbType.Int).Value = NguoiDungID;
				
				       sqlCmd.Parameters.Add("@Email",SqlDbType.NVarChar,50).Value = Email;
				
				       sqlCmd.Parameters.Add("@Anh",SqlDbType.NVarChar,100).Value = Anh;
				
				       sqlCmd.Parameters.Add("@DienThoaiDiDong",SqlDbType.NVarChar,50).Value = DienThoaiDiDong;
				
				       sqlCmd.Parameters.Add("@DienThoaiCoDinh",SqlDbType.NVarChar,50).Value = DienThoaiCoDinh;
				
				       sqlCmd.Parameters.Add("@ThongTinLienHe",SqlDbType.NVarChar,4000).Value = ThongTinLienHe;
				
				       sqlCmd.Parameters.Add("@DiaChi",SqlDbType.NVarChar,200).Value = DiaChi;
				
				       sqlCmd.Parameters.Add("@Website",SqlDbType.NVarChar,200).Value = Website;
				
				       sqlCmd.Parameters.Add("@Fax",SqlDbType.NVarChar,50).Value = Fax;
				
				       sqlCmd.Parameters.Add("@YM",SqlDbType.NVarChar,50).Value = YM;
				
				   		sqlCmd.Parameters.Add("@KichHoat",SqlDbType.Bit).Value = KichHoat;
				
				   		sqlCmd.Parameters.Add("@SapXep",SqlDbType.Int).Value = SapXep;
				
				       sqlCmd.Parameters.Add("@Bak1",SqlDbType.NVarChar,50).Value = Bak1;
				
				       sqlCmd.Parameters.Add("@Bak2",SqlDbType.NVarChar,1000).Value = Bak2;
				
				   		sqlCmd.Parameters.Add("@Bak3",SqlDbType.Int).Value = Bak3;
				
				   		sqlCmd.Parameters.Add("@Bak4",SqlDbType.Int).Value = Bak4;
				
				   		sqlCmd.Parameters.Add("@Bak5",SqlDbType.Bit).Value = Bak5;
				
				       sqlCmd.Parameters.Add("@bak6",SqlDbType.NVarChar,50).Value = bak6;
				
				       sqlCmd.Parameters.Add("@bak7",SqlDbType.NVarChar,1000).Value = bak7;
				
				       sqlCmd.Parameters.Add("@bak8",SqlDbType.NVarChar,1000).Value = bak8;
				
				   		sqlCmd.Parameters.Add("@Bak9",SqlDbType.Int).Value = Bak9;
				
				   		sqlCmd.Parameters.Add("@BaoDam",SqlDbType.TinyInt).Value = BaoDam;
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHang",SqlDbType.TinyInt).Value = LoaiCuaHang;
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).Value = LoaiCuaHangID;
				

                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        } 
		
		public int CopyAndUpdateFields(int SourceID, string TenCuaHang, string GioiThieu, int? NguoiDungID, string Email, string Anh, string DienThoaiDiDong, string DienThoaiCoDinh, string ThongTinLienHe, string DiaChi, string Website, string Fax, string YM, bool? KichHoat, int? SapXep, string Bak1, string Bak2, int? Bak3, int? Bak4, bool? Bak5, string bak6, string bak7, string bak8, int? Bak9, short? BaoDam, short? LoaiCuaHang, int? LoaiCuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
				int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsCuaHang";

				sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
				       sqlCmd.Parameters.Add("@TenCuaHang",SqlDbType.NVarChar,100).Value = TenCuaHang;
				
				       sqlCmd.Parameters.Add("@GioiThieu",SqlDbType.NVarChar,4000).Value = GioiThieu;
				
				   		sqlCmd.Parameters.Add("@NguoiDungID",SqlDbType.Int).Value = NguoiDungID;
				
				       sqlCmd.Parameters.Add("@Email",SqlDbType.NVarChar,50).Value = Email;
				
				       sqlCmd.Parameters.Add("@Anh",SqlDbType.NVarChar,100).Value = Anh;
				
				       sqlCmd.Parameters.Add("@DienThoaiDiDong",SqlDbType.NVarChar,50).Value = DienThoaiDiDong;
				
				       sqlCmd.Parameters.Add("@DienThoaiCoDinh",SqlDbType.NVarChar,50).Value = DienThoaiCoDinh;
				
				       sqlCmd.Parameters.Add("@ThongTinLienHe",SqlDbType.NVarChar,4000).Value = ThongTinLienHe;
				
				       sqlCmd.Parameters.Add("@DiaChi",SqlDbType.NVarChar,200).Value = DiaChi;
				
				       sqlCmd.Parameters.Add("@Website",SqlDbType.NVarChar,200).Value = Website;
				
				       sqlCmd.Parameters.Add("@Fax",SqlDbType.NVarChar,50).Value = Fax;
				
				       sqlCmd.Parameters.Add("@YM",SqlDbType.NVarChar,50).Value = YM;
				
				   		sqlCmd.Parameters.Add("@KichHoat",SqlDbType.Bit).Value = KichHoat;
				
				   		sqlCmd.Parameters.Add("@SapXep",SqlDbType.Int).Value = SapXep;
				
				       sqlCmd.Parameters.Add("@Bak1",SqlDbType.NVarChar,50).Value = Bak1;
				
				       sqlCmd.Parameters.Add("@Bak2",SqlDbType.NVarChar,1000).Value = Bak2;
				
				   		sqlCmd.Parameters.Add("@Bak3",SqlDbType.Int).Value = Bak3;
				
				   		sqlCmd.Parameters.Add("@Bak4",SqlDbType.Int).Value = Bak4;
				
				   		sqlCmd.Parameters.Add("@Bak5",SqlDbType.Bit).Value = Bak5;
				
				       sqlCmd.Parameters.Add("@bak6",SqlDbType.NVarChar,50).Value = bak6;
				
				       sqlCmd.Parameters.Add("@bak7",SqlDbType.NVarChar,1000).Value = bak7;
				
				       sqlCmd.Parameters.Add("@bak8",SqlDbType.NVarChar,1000).Value = bak8;
				
				   		sqlCmd.Parameters.Add("@Bak9",SqlDbType.Int).Value = Bak9;
				
				   		sqlCmd.Parameters.Add("@BaoDam",SqlDbType.TinyInt).Value = BaoDam;
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHang",SqlDbType.TinyInt).Value = LoaiCuaHang;
				
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).Value = LoaiCuaHangID;
				

                iID = objDataAccess.ExecuteScalar(sqlCmd);
				return  iID;
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
				sqlCmd.CommandText = "SelectCuaHangByField"; 
				sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
				sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
				sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
				dsResult = objDataAccess.ExecuteQuery(sqlCmd, "CuaHang"); 
				return dsResult; 
			}
		}
	}
}

