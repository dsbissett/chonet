using System.Data;
using System.Data.SqlClient;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class ThuocTinhSanPham : Base_ThuocTinhSanPham
    {
        #region Constructors

        #endregion

        #region Added Code

        public void DeleteBySanPhamID(int SanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_DeleteThuocTinhSanPhamBySanPhamID";
                sqlCmd.Parameters.Add("SanPhamID", SqlDbType.Int).Value = SanPhamID;
                objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
            }
        }

        public void DeleteBySanPhamMauID(int SanPhamMauID)
        {
            DataAccess objDataAccess = new DataAccess();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_DeleteThuocTinhSanPhamBySanPhamMauID";
                sqlCmd.Parameters.Add("SanPhamMauID", SqlDbType.Int).Value = SanPhamMauID;
                objDataAccess.ExecuteQuery(sqlCmd, "ThuocTinhSanPham");
            }
        }

        // add user code here		

        #endregion
    }
}