using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;

namespace CHONET.DataAccessLayer.Web.BaseClasses
{
    public class Base_TraGiaSanPham
    {
        private readonly DataColumnMapping[] dtColMapping;
        private readonly DataTableMapping dtTblMapping;

        public Base_TraGiaSanPham()
        {
            dtColMapping = new DataColumnMapping[]
                               {
                                   new DataColumnMapping("TraGiaID", "TraGiaID")
                                   ,
                                   new DataColumnMapping("SanPhamID", "SanPhamID")
                                   ,
                                   new DataColumnMapping("NguoiDungID", "NguoiDungID")
                                   ,
                                   new DataColumnMapping("GiaMuonMua", "GiaMuonMua")
                                   ,
                                   new DataColumnMapping("SoLuong", "SoLuong")
                                   ,
                                   new DataColumnMapping("ChiTiet", "ChiTiet")
                                   ,
                                   new DataColumnMapping("Bak1", "Bak1")
                                   ,
                                   new DataColumnMapping("Bak2", "Bak2")
                               };
            dtTblMapping = new DataTableMapping("Table", "TraGiaSanPham", dtColMapping);
        }

        public DataSet SelectAll()
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetTraGiaSanPham";
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TraGiaSanPham");
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
                sqlCmd.CommandText = "GetTraGiaSanPhamById";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TraGiaSanPham");
                return dsResult;
            }
        }


        public int Insert(int SanPhamID, int NguoiDungID, decimal GiaMuonMua, int SoLuong, string ChiTiet, int Bak1,
                          bool Bak2)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertTraGiaSanPham";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GiaMuonMua", SqlDbType.Money).Value = GiaMuonMua;

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;

                sqlCmd.Parameters.Add("@ChiTiet", SqlDbType.NVarChar, 1000).Value = ChiTiet;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.Int).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Bit).Value = Bak2;


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
                sqlCmd.CommandText = "InsertTraGiaSanPham";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GiaMuonMua", SqlDbType.Money).SourceColumn = "GiaMuonMua";

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).SourceColumn = "SoLuong";

                sqlCmd.Parameters.Add("@ChiTiet", SqlDbType.NVarChar, 1000).SourceColumn = "ChiTiet";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.Int).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Bit).SourceColumn = "Bak2";

                objDataAccess.UpdateBatch(rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void InsertBatch(ref DataRow[] rowInsert)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertTraGiaSanPham_Ref";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";
                sqlCmd.Parameters["@TraGiaID"].Direction = ParameterDirection.Output;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GiaMuonMua", SqlDbType.Money).SourceColumn = "GiaMuonMua";

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).SourceColumn = "SoLuong";

                sqlCmd.Parameters.Add("@ChiTiet", SqlDbType.NVarChar, 4).SourceColumn = "ChiTiet";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.Int).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Bit).SourceColumn = "Bak2";

                objDataAccess.UpdateBatch(ref rowInsert, sqlCmd, dtTblMapping);
            }
        }

        public void Update(int TraGiaID, int SanPhamID, int NguoiDungID, decimal GiaMuonMua, int SoLuong, string ChiTiet,
                           int Bak1, bool Bak2)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateTraGiaSanPham";

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GiaMuonMua", SqlDbType.Money).Value = GiaMuonMua;

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;

                sqlCmd.Parameters.Add("@ChiTiet", SqlDbType.NVarChar, 1000).Value = ChiTiet;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.Int).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Bit).Value = Bak2;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public void UpdateBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateTraGiaSanPham";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GiaMuonMua", SqlDbType.Money).SourceColumn = "GiaMuonMua";

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).SourceColumn = "SoLuong";

                sqlCmd.Parameters.Add("@ChiTiet", SqlDbType.NVarChar, 1000).SourceColumn = "ChiTiet";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.Int).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Bit).SourceColumn = "Bak2";

                objDataAccess.UpdateBatch(rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void UpdateBatch(ref DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateTraGiaSanPham";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).SourceColumn = "TraGiaID";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).SourceColumn = "SanPhamID";

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).SourceColumn = "NguoiDungID";

                sqlCmd.Parameters.Add("@GiaMuonMua", SqlDbType.Money).SourceColumn = "GiaMuonMua";

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).SourceColumn = "SoLuong";

                sqlCmd.Parameters.Add("@ChiTiet", SqlDbType.NVarChar, 1000).SourceColumn = "ChiTiet";

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.Int).SourceColumn = "Bak1";

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Bit).SourceColumn = "Bak2";

                objDataAccess.UpdateBatch(ref rowUpdate, sqlCmd, dtTblMapping);
            }
        }

        public void DeleteBatch(DataRow[] rowUpdate)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "DeleteTraGiaSanPham";
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
                sqlCmd.CommandText = "DeleteTraGiaSanPham";
                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;
                objDataAccess.ExecuteQuery(sqlCmd, "TraGiaSanPham");
            }
        }

        public int InsertFields(int? SanPhamID, int? NguoiDungID, decimal? GiaMuonMua, int? SoLuong, string ChiTiet,
                                int? Bak1, bool? Bak2)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "InsertFieldsTraGiaSanPham";

                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GiaMuonMua", SqlDbType.Money).Value = GiaMuonMua;

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;

                sqlCmd.Parameters.Add("@ChiTiet", SqlDbType.NVarChar, 1000).Value = ChiTiet;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.Int).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Bit).Value = Bak2;


                iID = objDataAccess.ExecuteScalar(sqlCmd);
                return iID;
            }
        }

        public void UpdateFields(int TraGiaID, int? SanPhamID, int? NguoiDungID, decimal? GiaMuonMua, int? SoLuong,
                                 string ChiTiet, int? Bak1, bool? Bak2)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "UpdateFieldsTraGiaSanPham";

                sqlCmd.Parameters.Add("@TraGiaID", SqlDbType.Int).Value = TraGiaID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GiaMuonMua", SqlDbType.Money).Value = GiaMuonMua;

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;

                sqlCmd.Parameters.Add("@ChiTiet", SqlDbType.NVarChar, 1000).Value = ChiTiet;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.Int).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Bit).Value = Bak2;


                objDataAccess.ExecuteNonQuery(sqlCmd);
            }
        }

        public int CopyAndUpdateFields(int SourceID, int? SanPhamID, int? NguoiDungID, decimal? GiaMuonMua, int? SoLuong,
                                       string ChiTiet, int? Bak1, bool? Bak2)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                int iID = 0;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "CopyAndUpdateFieldsTraGiaSanPham";

                sqlCmd.Parameters.Add("@SourceID", SqlDbType.Int).Value = SourceID;
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;

                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;

                sqlCmd.Parameters.Add("@GiaMuonMua", SqlDbType.Money).Value = GiaMuonMua;

                sqlCmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;

                sqlCmd.Parameters.Add("@ChiTiet", SqlDbType.NVarChar, 1000).Value = ChiTiet;

                sqlCmd.Parameters.Add("@Bak1", SqlDbType.Int).Value = Bak1;

                sqlCmd.Parameters.Add("@Bak2", SqlDbType.Bit).Value = Bak2;


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
                sqlCmd.CommandText = "SelectTraGiaSanPhamByField";
                sqlCmd.Parameters.Add("@FieldName", SqlDbType.NVarChar).Value = FieldName;
                sqlCmd.Parameters.Add("@Value", SqlDbType.NVarChar).Value = value;
                sqlCmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "TraGiaSanPham");
                return dsResult;
            }
        }
    }
}