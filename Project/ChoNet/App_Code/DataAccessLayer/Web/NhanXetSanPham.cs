using System.Data;
using System.Data.SqlClient;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class NhanXetSanPham : Base_NhanXetSanPham
    {
        #region Constructors

        #endregion

        #region Added Code

        // add user code here	
        public DataSet SelectNhanXetSanPhamByNguoiDung(int NguoiDungID)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "_SelectNhanXetSanPham";
                cmd.Parameters.Add("@NguoiDungID", SqlDbType.Int).Value = NguoiDungID;
                ds = da.ExecuteQuery(cmd, "NhanXetSanPham");
                return ds;
            }
        }

        #endregion
    }
}