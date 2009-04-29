using System.Data;
using System.Data.SqlClient;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class TraGiaSanPham : Base_TraGiaSanPham
    {
        #region Constructors

        #endregion

        #region Added Code

        // add user code here	
        public DataSet SelectTraGiaSanPhamBySanPhamID(int SanPhamID)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "_SelectTraGiaSanPhamBySanPhamID";
                cmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                ds = da.ExecuteQuery(cmd, "TraGiaSanPham");
                return ds;
            }
        }

        #endregion
    }
}