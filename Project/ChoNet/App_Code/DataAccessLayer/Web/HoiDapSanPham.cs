using System.Data;
using System.Data.SqlClient;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class HoiDapSanPham : Base_HoiDapSanPham
    {
        #region Constructors

        #endregion

        #region Added Code

        // add user code here	
        public DataSet SelectHoiDapSanPhamByNguoiDung(int NguoiDungID)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "_SelectHoiDapSanPham";
                cmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                ds = da.ExecuteQuery(cmd, "HoiDapSanPham");
                return ds;
            }
        }

        public DataSet SelectHoiDapSanPhamBySanPhamID(int SanPhamID)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "_SelectHoiDapSanPhamBySanPhamID";
                cmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                ds = da.ExecuteQuery(cmd, "HoiDapSanPham");
                return ds;
            }
        }

        #endregion
    }
}