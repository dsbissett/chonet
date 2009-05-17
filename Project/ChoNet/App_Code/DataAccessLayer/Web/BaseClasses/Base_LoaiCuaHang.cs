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
	public class Base_LoaiCuaHang
	{
		DataColumnMapping[] dtColMapping;
        DataTableMapping dtTblMapping;
		public Base_LoaiCuaHang()
		{
			dtColMapping = new DataColumnMapping[]{
				
				new DataColumnMapping("LoaiCuaHangID","LoaiCuaHangID")
					,				

				
				new DataColumnMapping("TenLoaiCuaHang","TenLoaiCuaHang")
					,				

				
				new DataColumnMapping("Mota","Mota")
					};				
			dtTblMapping = new DataTableMapping("Table", "LoaiCuaHang", dtColMapping);	
		}
	
		public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();           
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetLoaiCuaHang";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LoaiCuaHang");
                return dsResult;
            }
        }
		
		public DataSet SelectByID(int LoaiCuaHangID)
		{ 
			DataAccess objDataAccess = new DataAccess(); 
			DataSet dsResult = new DataSet(); dsResult.Locale = CultureInfo.CurrentCulture; 
			using (SqlCommand sqlCmd = new SqlCommand())
			{
				sqlCmd.CommandType = CommandType.StoredProcedure; 
				sqlCmd.CommandText = "GetLoaiCuaHangById"; 
				sqlCmd.Parameters.Add("@LoaiCuaHangID", SqlDbType.Int ).Value = LoaiCuaHangID;
				dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LoaiCuaHang"); 
				return dsResult; 
			}
		}
		
		
		public int Insert(	string TenLoaiCuaHang ,	string Mota )
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
				int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertLoaiCuaHang";

				       sqlCmd.Parameters.Add("@TenLoaiCuaHang",SqlDbType.NVarChar,100).Value = TenLoaiCuaHang;
				
				       sqlCmd.Parameters.Add("@Mota",SqlDbType.NVarChar,200).Value = Mota;
				

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
                sqlCmd.CommandText = "InsertLoaiCuaHang";
				       sqlCmd.Parameters.Add("@TenLoaiCuaHang",SqlDbType.NVarChar,100).SourceColumn = "TenLoaiCuaHang";
				
				       sqlCmd.Parameters.Add("@Mota",SqlDbType.NVarChar,200).SourceColumn = "Mota";
				
                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }
		
		public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertLoaiCuaHang_Ref";
				sqlCmd.Parameters.Add("@LoaiCuaHangID", SqlDbType.Int ).SourceColumn = "LoaiCuaHangID";
                sqlCmd.Parameters["@LoaiCuaHangID"].Direction = ParameterDirection.Output;
				       sqlCmd.Parameters.Add("@TenLoaiCuaHang",SqlDbType.NVarChar,4).SourceColumn = "TenLoaiCuaHang";
				
				       sqlCmd.Parameters.Add("@Mota",SqlDbType.NVarChar,100).SourceColumn = "Mota";
				
                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }
		
		public void Update(int LoaiCuaHangID, 	string TenLoaiCuaHang ,	string Mota )
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateLoaiCuaHang";

				sqlCmd.Parameters.Add("@LoaiCuaHangID", SqlDbType.Int ).Value = LoaiCuaHangID;
				       sqlCmd.Parameters.Add("@TenLoaiCuaHang",SqlDbType.NVarChar,100).Value = TenLoaiCuaHang;
				
				       sqlCmd.Parameters.Add("@Mota",SqlDbType.NVarChar,200).Value = Mota;
				

                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        } 
		
		public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateLoaiCuaHang";
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).SourceColumn = "LoaiCuaHangID";
				
				       sqlCmd.Parameters.Add("@TenLoaiCuaHang",SqlDbType.NVarChar,100).SourceColumn = "TenLoaiCuaHang";
				
				       sqlCmd.Parameters.Add("@Mota",SqlDbType.NVarChar,200).SourceColumn = "Mota";
				
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

		public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateLoaiCuaHang";
				   		sqlCmd.Parameters.Add("@LoaiCuaHangID",SqlDbType.Int).SourceColumn = "LoaiCuaHangID";
				
				       sqlCmd.Parameters.Add("@TenLoaiCuaHang",SqlDbType.NVarChar,100).SourceColumn = "TenLoaiCuaHang";
				
				       sqlCmd.Parameters.Add("@Mota",SqlDbType.NVarChar,200).SourceColumn = "Mota";
				
                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }
	
		public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteLoaiCuaHang";
                sqlCmd.Parameters.Add("@LoaiCuaHangID", SqlDbType.Int).SourceColumn = "LoaiCuaHangID";
                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }
		
		public void Delete(int LoaiCuaHangID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteLoaiCuaHang";
                sqlCmd.Parameters.Add("@LoaiCuaHangID", SqlDbType.Int).Value = LoaiCuaHangID;
                objDataAccess.ExecuteQuery(sqlCmd, "LoaiCuaHang");
            }
        }

		public int InsertFields(string TenLoaiCuaHang , string Mota )
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
				int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsLoaiCuaHang";

				       sqlCmd.Parameters.Add("@TenLoaiCuaHang",SqlDbType.NVarChar,100).Value = TenLoaiCuaHang;
				
				       sqlCmd.Parameters.Add("@Mota",SqlDbType.NVarChar,200).Value = Mota;
				

                iID = objDataAccess.ExecuteScalar(sqlCmd);
				return  iID;
            }
        } 
		
		public void UpdateFields(int LoaiCuaHangID, string TenLoaiCuaHang, string Mota)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsLoaiCuaHang";

				sqlCmd.Parameters.Add("@LoaiCuaHangID", SqlDbType.Int ).Value = LoaiCuaHangID;
				       sqlCmd.Parameters.Add("@TenLoaiCuaHang",SqlDbType.NVarChar,100).Value = TenLoaiCuaHang;
				
				       sqlCmd.Parameters.Add("@Mota",SqlDbType.NVarChar,200).Value = Mota;
				

                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        } 
		
		public int CopyAndUpdateFields(int SourceID, string TenLoaiCuaHang, string Mota)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
				int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsLoaiCuaHang";

				sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
				       sqlCmd.Parameters.Add("@TenLoaiCuaHang",SqlDbType.NVarChar,100).Value = TenLoaiCuaHang;
				
				       sqlCmd.Parameters.Add("@Mota",SqlDbType.NVarChar,200).Value = Mota;
				

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
				sqlCmd.CommandText = "SelectLoaiCuaHangByField"; 
				sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
				sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
				sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
				dsResult = objDataAccess.ExecuteQuery(sqlCmd, "LoaiCuaHang"); 
				return dsResult; 
			}
		}
	}
}

