using System.Data;
using System.Data.SqlClient;
using CHONET.DataAccessLayer.Web.BaseClasses;

namespace CHONET.DataAccessLayer.Web
{
    public class Anh : Base_Anh
    {
        #region Constructors

        #endregion

        #region Added Code

        public DataSet SelectBySanPham(int SanPhamID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.CommandText = "GetAnhBySanPham";
                sqlCmd.Parameters.Add("@SanPhamID", SqlDbType.Int).Value = SanPhamID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "Anh");
                return dsResult;
            }
        }

        public DataSet SelectByAnhID(int AnhID)
        {
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "_GetAnhByID";
                sqlCmd.Parameters.Add("@AnhID", SqlDbType.Int).Value = AnhID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "Anh");
                return dsResult;
            }
        }

        #endregion
    }
}