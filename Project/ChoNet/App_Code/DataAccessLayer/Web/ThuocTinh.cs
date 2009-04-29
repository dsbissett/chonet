using System.Data;
using System.Data.SqlClient;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class ThuocTinh : Base_ThuocTinh
    {
        #region Constructors

        #endregion

        #region Added Code

        // add user code here		        
        public DataSet SelectAllThuocTinhByThuocTinhChaAndNhomSanPham(int nhomsanphamid, int thuoctinhchaid)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_SelectAllThuocTinhByThuocTinhChaAndNhomSanPham";
                sqlCmd.Parameters.Add("@NhomSanPhamID", SqlDbType.Int).Value = nhomsanphamid;
                sqlCmd.Parameters.Add("@ThuocTinhChaID", SqlDbType.Int).Value = thuoctinhchaid;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "thuoctinh");
                return dsResult;
            }
        }

        #endregion
    }
}