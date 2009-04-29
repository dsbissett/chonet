using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class QuangCao : Base_QuangCao
    {
        #region Constructors

        #endregion

        #region Added Code

        public DataSet SelectAllQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(int LoaiNguoiDungID, int ViTriQuangCao)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllQuangCaoAtViTriQuangCaoByLoaiNguoiDungID";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public DataSet SelectAllQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(int LoaiNguoiDungID, int ViTriQuangCao,
                                                                                  int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public DataSet SelectAllQuangCaoAtViTriQuangCaoByNhomSanPhamID(int NhomSanPhamID, int ViTriQuangCao)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllQuangCaoAtViTriQuangCaoByNhomSanPhamID";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public DataSet SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(int LoaiNguoiDungID, int ViTriQuangCao)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetQuangCaoAtViTriQuangCaoByLoaiNguoiDungID";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public DataSet SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDForHomePage(int LoaiNguoiDungID,
                                                                                 string ViTriQuangCao)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDForHomePage";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.NVarChar).Value = ViTriQuangCao;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public DataSet SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(int LoaiNguoiDungID, int ViTriQuangCao,
                                                                               int KhuVucID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc";
                sqlCmd.Parameters.Add("@KhuVucID", SqlDbType.Int).Value = KhuVucID;
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public DataSet SelectQuangCaoAtViTriQuangCaoByNhomSanPhamID(int NhomSanPhamID, int ViTriQuangCao)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetQuangCaoAtViTriQuangCaoByNhomSanPhamID";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = NhomSanPhamID;
                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public DataSet SelectAllQuangCaoAtViTriQuangCaoByNguoiDungID(int NguoiDungID, int ViTriQuangCao)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAllQuangCaoAtViTriQuangCaoByNguoiDungID";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public DataSet SelectQuangCaoAtViTriQuangCaoByNguoiDungID(int NguoiDungID, int ViTriQuangCao)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetQuangCaoAtViTriQuangCaoByNguoiDungID";
                sqlCmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                sqlCmd.Parameters.Add("@ViTriQuangCao", SqlDbType.Int).Value = ViTriQuangCao;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
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
                sqlCmd.CommandText = "_GetQuangCaoByLoaiNguoiDungID";
                sqlCmd.Parameters.Add("@LoaiNguoiDungID", SqlDbType.Int).Value = LoaiNguoiDungID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        public DataSet SelectByQuangCaoID(int QuangCaoID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetQuangCaoById";
                sqlCmd.Parameters.Add("@QuangCaoID", SqlDbType.Int).Value = QuangCaoID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "QuangCao");
                return dsResult;
            }
        }

        #endregion
    }
}